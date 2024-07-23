using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : Teammate
{
    // Attributes
    private string firstName, secondName;
    private int birthWeek;
    protected string teamAbbreviation;
    private bool interestedIn;
    private int money;
    private int chessTourn = 0;
    private int chessProgress = 32;
    private int income = 150;
    private int minimumStatCost = 20;

    private bool footballInterest;
    private string mumsName, dadsName;
    protected int statCost;
    private BTNManager btnm;

    private int numRelationships = 10;
    public struct Sponsorship {                                 //TODO******************************************* Make private
        private bool hasSponsor;
        public bool HasSponsor
        {get
            {
                return hasSponsor;
            }
            set
            {
                hasSponsor = value;
            }

        }
        private int income;
        public int Income
        { get

            {
                return income;
            }
            set
            {
                income = value;
            }
        }
    };
    private Sponsorship[] sponsorships = new Sponsorship[5];    

    private RelationshipHolder[] relationships;
    private RelationshipHolder sportyParent = new RelationshipHolder(0);
    private RelationshipHolder nonSportyParent = new RelationshipHolder(1);
    private RelationshipHolder partner = new RelationshipHolder(2);
    private RelationshipHolder fans = new RelationshipHolder(3);
    private RelationshipHolder team = new RelationshipHolder(4);
    private RelationshipHolder coach = new RelationshipHolder(5);
    private RelationshipHolder manager = new RelationshipHolder(6);
    private RelationshipHolder agent = new RelationshipHolder(7);
    private RelationshipHolder rival = new RelationshipHolder(8);
    private RelationshipHolder pet = new RelationshipHolder(9);

    // Stats: 0 = goalsScored, 1 = goalOpps, 2 = goal%, 3 = matchesWon, 4 = matchesDrawn, 5 = matchesPlayed, 
    //        6 = matchesWon%, 7 = matchesDrawn%, 8 = ballInTeamPos, 9 = ballInOppPos, 10 = ballPossession%
    private const int maxStatisticsSize = 11;
    private float[] statistics = new float[maxStatisticsSize];
    
    private Team playerTeam;
    private string relationshipName;
    protected override void Start()
    {
        base.Start();
        stats[11] = 110;
        
    }
    public void Awake()
    {
        btnm = this.gameObject.GetComponent<BTNManager>();
        relationships = new RelationshipHolder[numRelationships];

        relationships[0] = sportyParent;
        relationships[1] = nonSportyParent;
        relationships[2] = partner;
        relationships[3] = fans;
        relationships[4] = team;
        relationships[5] = coach;
        relationships[6] = manager;
        relationships[7] = agent;
        relationships[8] = rival;
        relationships[9] = pet;

        SetUpStatistics();
        SetUpSponsorships();
        money = 50;
        teamName = "St Laurence";
        base.Start();
    }

    void Update()
    {
        for (int i = 0; i < 15; i++)
        {
            if (stats[i] > 99)
            {
                btnm.IncAvailible(i);
            }
            else
                btnm.IncNotAvailible(i);
        }
    }

    private void SetUpStatistics()
    {
        // TODO: Change when saving and loading is added
        for (int i = 0; i < maxStatisticsSize; i++)
            statistics[i] = 0.0f;
    }
    private void SetUpSponsorships()
    {   //boots[0]  //watch[1] //computer[2] //car[3]//food[4]
       
        for (int i = 0; i < 5; i++)
        {
            sponsorships[i] = new Sponsorship();           
            sponsorships[i].HasSponsor = false;
            sponsorships[i].Income = 0;
        }                  

    }
    public Sponsorship GetSponsorships(int i)
    {
        return sponsorships[i];
    }
    public Team GetTeam()
    {
        return playerTeam;
    }
    public void SetTeam(Team t)
    {
        playerTeam = t;
    }
    public int GetIncome()
    {
        int sponsorshipIncome = 0;
        for (int i = 0; i < 4; i++)
        {
            sponsorshipIncome += sponsorships[i].Income;
        }
        return income + sponsorshipIncome;
    }
    public void SetIncome(int I)
    {
        income = I;
    }
    public void IncIncome(int I)
    {
        income += I;
    }
    public void SetFirstName(string name)
    {
        firstName = name;
    }
    public string GetFirstName()
    {
        return firstName;
    }
    public int GetChessTourn()
    {
        return chessTourn;
    }
    public void IncChessTourn()
    {
        chessTourn++;
    }
    public int GetChessProgress()
    {
        return chessProgress;
    }
    public void IncChessProgress()
    {
        chessProgress = chessProgress / 2;
    }
    public void SetTeamAbbreviation()
    {
        playerTeam.GetTeamAbbreviation();
    }
    public string GetTeamAbbreviation()
    {
        return teamAbbreviation;
    }
    public void SetRelationshipName(string rn)
    {
        relationshipName = rn;
    }
    public string GetRelationshipName()
    {
        return relationshipName;
    }
    public int GetBirthWeek()
    {
        return birthWeek;
    }
    
    public bool GetInterestedIn()
    {
        return interestedIn;
    }
    public int GetMoney()
    {
        return money;
    }
    public string GetMumsName()
    {
        return mumsName;
    }
    public void SetMumsName(string mn)
    {
        mumsName = mn;
    }
    public string GetDadsName()
    {
        return dadsName;
    }
    public void SetDadsName(string dn)
    {
        dadsName = dn;
    }
    private void IncrementAge()
    {
        // Needs story manager
    }
    public float GetStatistics(int i)
    {
        switch (i)
        {
            case 2:
                float goalPercent = statistics[2] * 100.0f;
                return goalPercent - (goalPercent % 0.01f);
            case 6:
                float matchesWonPercent = statistics[6] * 100.0f;
                return matchesWonPercent - (matchesWonPercent % 0.01f);
            case 7:
                float matchesDrawnPercent = statistics[7] * 100.0f;
                return matchesDrawnPercent - (matchesDrawnPercent % 0.01f);
            case 10:
                float ballPosPercent = statistics[10] * 100.0f;
                return ballPosPercent - (ballPosPercent % 0.01f);
            default:
                return statistics[i] - (statistics[i] % 1.0f);
        }
    }
    public void AddStatistic(int i, float increment)
    {
        statistics[i] += increment;
    }
    public void UpdateStatisticPercentages()
    {
        // Goals Scored
        if (statistics[1] == 0.0f)
            statistics[2] = 0.0f;
        else
            statistics[2] = statistics[0] / statistics[1];

        // Matches Won
        if (statistics[5] == 0.0f)
            statistics[6] = 0.0f;
        else
            statistics[6] = statistics[3] / statistics[5];

        // Matches Drawn
        if (statistics[5] == 0.0f)
            statistics[7] = 0.0f;
        else
            statistics[7] = statistics[4] / statistics[5];

        // Ball Possession
        statistics[10] = statistics[8] / (statistics[9] + statistics[8]);
    }
    // set stats
    public void SetStat(int stat)
    {
        stats[stat]++;
        if (stats[stat] == 100)
        {
            btnm.IncAvailible(stat);
        }
    }
    public void SetMoney(int amount)
    {
        money = amount;
    }
    public void IncMoney(int amount)
    {
        money += amount;
    }
    public RelationshipHolder[] GetRelationships()
    {
        return relationships;
    }
    public int GetRelationshipBond(int i)
    {
        return relationships[i].GetBondToPlayer();
    }
    public RelationshipHolder GetRelationship(int i)
    {
        return relationships[i];
    }
    public void SetRelationships(RelationshipHolder[] _relationships)
    {
        relationships = _relationships;
    }
    public void SetFootballInterest(bool interested)
    {
        footballInterest = interested;
    }
    public bool GetFootballInterest()
    {
        return footballInterest;
    }
    public override void IncStatLevel(int stat)
    {
        stats[stat] -= 100;
        statsLevels[stat]++;
    }
    public override void DecStatLevel(int stat, int amount)
    {
        stats[stat] = 100;                                                               //Not sure this is needed I don't think we should minus levels, maybe the stats from 1-10 but not the levels
        stats[stat] += amount;
        statsLevels[stat]--;
        btnm.IncNotAvailible(stat);
    }
    public override void IncStat(int stat, int amount)
    {
        stats[stat] += amount;
        if (stats[stat] < 0)
        {
            DecStatLevel(stat, stats[stat]);
        }
    }
    public void WeeklyStatInc(int oppurtunities, int goals)    //Player training, each weeks improvements
    {
        int defaultInc = 0, skillRelationshipInc = 0, personalRelationshipInc = 0, mentalRelationshipInc = 0, overallSkillInc = 0, overallPersonalInc = 0, overallMentalInc = 0;
        int ageStatInc = (28 - age),  statInc = ((stats[11] - 50) % 10), matchPerfInc; 
        if (oppurtunities == 0)
        {
            matchPerfInc = -5;
            defaultInc = ageStatInc + matchPerfInc + statInc;
        }
        else
        {
            matchPerfInc = ((((goals / oppurtunities) * 10) % 1) - 5);
            defaultInc = ageStatInc + matchPerfInc + statInc;
        }
        personalRelationshipInc = (((stats[0] + stats[1] + stats[2] + stats[3] + stats[4]) - 250) % 10);
        skillRelationshipInc = (((stats[5] + stats[6] + stats[7] + stats[8] + stats[9])- 250)% 10);
        mentalRelationshipInc = (((stats[10] + stats[11] + stats[12] + stats[13] + stats[14]) - 250) % 10);
        overallSkillInc = defaultInc + skillRelationshipInc;overallMentalInc = defaultInc + mentalRelationshipInc;overallPersonalInc = defaultInc + personalRelationshipInc;
        IncStat(0, overallPersonalInc);IncStat(1, overallPersonalInc);IncStat(2, overallPersonalInc);IncStat(3, overallPersonalInc);IncStat(4, overallPersonalInc);
        IncStat(5, overallSkillInc);IncStat(6, overallSkillInc);IncStat(7, overallSkillInc);IncStat(8, overallSkillInc);IncStat(9, overallSkillInc);
        IncStat(10, overallMentalInc);IncStat(11, overallMentalInc);IncStat(12, overallMentalInc); IncStat(13, overallMentalInc);IncStat(14, overallMentalInc);
    }
    public int GetStatCost(int statNum)
    {
        SetStatCost(statNum);
        return statCost;
    }
    public void SetStatCost(int statNumber)
    {
        statCost = minimumStatCost + ((statsLevels[statNumber] - 20) * (5 + (statsLevels[statNumber] - 20)));
    }
    public void SetHasSponsorAtPos(int i, bool hasSponsor)
    {
        sponsorships[i].HasSponsor = hasSponsor;
    }
    public void SetIncomeAtPos(int i, int income)
    {
        sponsorships[i].Income = income;
    }
    public int GetIncomeAtPos(int i)
    {
        return sponsorships[i].Income;
    }
}
