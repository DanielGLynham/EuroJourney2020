using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Attributes
    protected string fullName;
    protected string teamName;
    
    protected string nationality;
    protected int age;
    protected int fieldPosition;
    protected bool male = true;
    protected int overallSkill;

    protected int freekicks;
    protected int passing;
    protected int dribbling;
    


    // stats ----------------------------------------------------------------
    protected int numberOfStats = 15;
    // 0 = stamina, 1 = speed, 2 = agility, 3 = strength, 4 = jumpingSkill;  //physical
    // 5 = accuracy, 6 = timing, 7 = freekicks, 8 = passing, 9 = dribbling;  //Skill
    // 10 = aggression, 11 = motivation, 12 = positioning, 13 = teaching, 14 = confidence;   //Mental

    protected int[] stats;
    protected int[] statsLevels;
    // ----------------------------------------------------------------------

    // Functions
    protected virtual void Start()
    {
        StartSetup();
    }
    public void SetOverallSkill()
    {
        overallSkill = 0;
        for (int i = 0; i < 14; i++)
        {
            overallSkill = overallSkill + statsLevels[i];         
            
        }
    }
    public int GetOverallSkill()
    {
        return overallSkill;
    }
    public virtual void StartSetup()
    {
        stats = new int[numberOfStats];
        statsLevels = new int[numberOfStats];
        //overallSkill = 0;  Don't think this is needed
        for (int i = 0; i < numberOfStats; i++)
        {
            stats[i] = Random.Range(40, 90);
            statsLevels[i] = 20;
            overallSkill++;
        }
    }

    public void SetName(string name)
    {
        fullName = name;
    }
    public string GetName()
    {
        return fullName;
    }
    
    public void SetNation(string nation)
    {
        nationality = nation;
    }
    public string GetNation()
    {
        return nationality;
    }
    public string GetTeamName()
    {
        return teamName;
    }
    
    public string GetNationality()
    {
        return nationality;
    }
    public void SetAge(int a)
    {
        age = a;
    }
    public int GetAge()
    {
        return age;
    }
    public void SetFieldPosition(int pos)
    {
        fieldPosition = pos;
    }
    public int GetFieldPosition()
    {
        return fieldPosition;
    }
    public bool GetMale()
    {
        return male;
    }
    public void SetMale(bool m)
    {
        male = m;
    }
    public virtual void IncStatLevel(int stat)
    {        
        stats[stat] -= 100;
        statsLevels[stat]++;
    }
    public virtual void DecStatLevel(int stat, int amount)
    {
        stats[stat] = 100;                                                               //Not sure this is needed I don't think we should minus levels, maybe the stats from 1-10 but not the levels
        stats[stat] += amount;
        statsLevels[stat]--;
    }
    public virtual void IncStat(int stat, int amount)
    {
        stats[stat] += amount;
        if(stats[stat] < 0)
        {
            DecStatLevel(stat, stats[stat]);
        }
        if (stats[stat] > 100)
        {
            IncStatLevel(stat);
        }
    }
    
    // Get Stats
    public int[] GetStats()
    {
        return stats;
    }
    // Get Stats
    public int GetStat(int stat)
    {
        return stats[stat];
    }
    public int GetStatLevel(int stat)
    {
        return statsLevels[stat];
    }
    public int[] GetStatLevels()
    {
        return statsLevels;
    }
    public void SetStats(int[] _stats)
    {
        stats = _stats;
    }
    public void SetStatLevels(int[] _statLevels)
    {
        statsLevels = _statLevels;
    }
    public void SetUpPracticeStats()
    {
        overallSkill = 0;
        int randomInt = 0;

        for (int i = 0; i < numberOfStats; i++)
        {
            //randomInt = Random.Range(1, 99);
            // REMOVE LATER
            randomInt = 50;
            stats[i] = randomInt;
            overallSkill += randomInt;
        }
    }

    public void SetUpStats(int[] mainStats)
    {
        stats = new int[numberOfStats];
        statsLevels = new int[numberOfStats];
        overallSkill = 0; 

        for (int i = 0; i < numberOfStats; i++)
        {                      
            statsLevels[i] = mainStats[i];
            overallSkill += mainStats[i];
        }
    }
}
