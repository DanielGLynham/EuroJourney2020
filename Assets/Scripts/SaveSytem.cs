using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSytem
{
    public static void SavePlayer(int date, int money, List<Task> completeDilemas, int[] playerStats, int[] playerStatLevels, RelationshipHolder[] playerRelationships)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayersData data = new PlayersData(date, money, completeDilemas, playerStats, playerStatLevels, playerRelationships);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayersData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayersData data = formatter.Deserialize(stream) as PlayersData;
            stream.Close();

            return data;
        }
        else
        {
            //Debug.LogError("no file" + path);
            return null;
        }
    }
    public static void DeleteSave()
    {
        string path = Application.persistentDataPath + "/player.fun";
        File.Delete(path);
    }
}
