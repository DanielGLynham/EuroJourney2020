using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    private Utilities utilities = new Utilities();
    private int maxNumberPlayers = 24;
    private int tier;
    private int teamID;
    private int nationID;
    private string teamName;
    private string nation;
    private string teamAbbreviation;
    private int numberOfPlayers;

    private List<Player> team = new List<Player>();
    private int tempGroupScore = 0;
    private int matchesPlayed, wins, losses, draws, goalsFor, goalsAgainst, goalDifference, points;
    private bool playersTeam = false;
    private int schoolScore = 0;
    private int eurosScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!playersTeam)
            for (int i = 0; i < maxNumberPlayers; i++)
                if (i != 0)
                    team.Add(new Player());
                else
                    team.Add(new Goalie());
        else
            for (int i = 0; i < maxNumberPlayers; i++)
                team.Add(new Player());
        // TODO: player team has no goalie
        CreatePlayer();
    }
    public void SetPlayersTeam(bool t)
    {
        playersTeam = t;
        Start();
    }
    public Team(Team t)
    {
        tier = t.tier;
        teamID = t.teamID;
        nationID = t.nationID;
        teamName = t.teamName;
        nation = t.nation;
        teamAbbreviation = t.teamAbbreviation;
        numberOfPlayers = t.numberOfPlayers;
        team = t.team;
        tempGroupScore = t.tempGroupScore;
        matchesPlayed = t.matchesPlayed;
        wins = t.wins;
        losses = t.losses;
        draws = t.draws;
        goalsFor = t.goalsFor;
        goalsAgainst = t.goalsAgainst;
        goalDifference = t.goalDifference;
        points = t.points;
        playersTeam = t.playersTeam;
        schoolScore = t.schoolScore;
    }
    public Team(int t, int tID, string tn, string n, int nID, string a)
    {
        tier = t;
        teamID = tID;
        teamName = tn;
        nation = n;
        nationID = nID;
        teamAbbreviation = a;

    }
    public Team(int _tier, int _teamID, string _teamName, string _abrbreviation)
    {
        tier = _tier;
        teamID = _teamID;
        teamName = _teamName;
        teamAbbreviation = _abrbreviation;

    }
    public void SetSchoolScore(int i)
    {
        schoolScore = i;
    }
    public int GetNationID()
    {
        return nationID;
    }
    public string GetNation()
    {
        return nation;
    }
    public string GetTeamName()
    {
        return teamName;
    }
    public string GetTeamAbbreviation()
    {
        return teamAbbreviation;
    }
    public int GetGroupScore()
    {
        return tempGroupScore;
    }
    public void IncGroupScore()
    {
        tempGroupScore++;
    }
    public int GetEurosScore()
    {
        return eurosScore;
    }
    private void IncEurosScore()
    {
        eurosScore++;
    }
    public void CreatePlayer()
    {
        //Debug.Log(teamName + " " + team.Count);
        for (int i = 0; i < team.Count; i++)
        {            
            team[i].SetNation(utilities.GetNationality());
            team[i].SetAge(utilities.SetAge());
            team[i].SetUpStats(utilities.SetUpStats(GetTier()));
        }
          
    }
    public void AssignPlayerGender(bool g)
    {        
        for (int i = 0; i < maxNumberPlayers; i++)
        {
            if (g == true)
            {
                team[i].SetName(utilities.GetMaleName() + " " + utilities.GetSecondName());
            }
            if (g == false)
            {
                team[i].SetName(utilities.GetFemaleName() + " " + utilities.GetSecondName());
            }

            team[i].SetNation(utilities.GetNationality());
            team[i].SetAge(utilities.SetAge());
            //Debug.Log("Set up stats yah");
            team[i].SetUpStats(utilities.SetUpStats(GetTier()));
        }
    }

    public Player GetPlayer(int i)
    {
        //Debug.Log(team.Count);
        return team[i];
    }
    public List<Player> GetTeammates()
    {
        return team;
    }
    public List<Player> GetTeam()
    {
        return team;
    }
    public void SetTier(int t)
    {
        tier = t;

    }
    public int GetTier()
    {
        return tier;
    }
    public int GetSchoolScore()
    {
        return schoolScore;
    }
    public void IncSchoolScore(int amount)
    {
        schoolScore += amount;
    }
    public void WeeklyStatInc(int opps, int goals)                                          //This is the incrementing for every player  //Change this depending on the performance on the team
    {
        for (int i = 0; i < maxNumberPlayers; i++)
        {
            //Debug.Log("This is the team count" + team.Count);
            int defaultInc;
            //if (GetPlayer(i).GetName() == player.GetName())                               //This isn't finished TODO************************************
            //    player.WeeklyStatInc(opps, goals);
            defaultInc = ((28 - GetPlayer(i).GetAge()) + (Random.Range(0, 12)));            
            
            for (int j = 0; j < 14; j++)
            {
                //Debug.Log("I = " + i);
                GetPlayer(i).IncStat(j, defaultInc);

            }
        }
    }

    public int GetTeamID()
    {
        return teamID;
    }

    public void ReplaceFirstWithPlayer(MainPlayer mp)
    {
        team[0] = mp;
    }
}
