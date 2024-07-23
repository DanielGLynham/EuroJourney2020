using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayersData // for saving
{

    //  Week, dilemas, player stats, money, player relationships, 
    public int _date;
    public List<Task> _completeDilemas = new List<Task>();
    public int[] _playerStats;
    public int[] _playerStatLevels;
    public int _money;
    public RelationshipHolder[] _playerRelationShips;

    public PlayersData(int date, int money, List<Task> completeDilemas, int[] playerStats, int[] playerStatLevels, RelationshipHolder[] playerRelationships)
    {
        _date = date;
        _completeDilemas = completeDilemas;
        _playerStats = playerStats;
        _playerStatLevels = playerStatLevels;
        _money = money;
        _playerRelationShips = playerRelationships;
    }
}
