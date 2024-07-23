using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match
{
    Utilities utils = new Utilities();
    private Team homeTeam, awayTeam;
    private int homeScore, awayScore;
    private int homePercentagePossession, awayPercentagePossession;
    int date;
    string description;
    bool isSecondMatch;
    private bool homeWon;
    private bool draw = false;
    private int league;
    private bool ended;

    public Match(Team hT, Team aT, int d, int leagueNum)
    {
        homeTeam = hT;
        awayTeam = aT;
        date = d;
        league = leagueNum;
    }

    public string GetDate()
    {
        return utils.SortDate(date);
    }
    public int GetIntDate()
    {
        return date;
    }
    public void SetWhoWon(int mR)
    {
        if (mR == 1)
        {
            homeWon = true;
            draw = false;
        }
        if (mR == 2)
        {
            homeWon = false;
            draw = false;
        }
        if (mR == 3)
            draw = true;
    }
    public int GetLeague()
    {
        return league;
    }
    public Team GetMatchWinner()
    {
        if(homeWon)
        {
            return homeTeam;
        }
        else
        {
            return awayTeam;
        }
    }
    public bool GetMatchDraw()
    {
        return draw;
    }
    public Team GetAwayTeam()
    {
        return awayTeam;
    }
    public Team GetHomeTeam()
    {
        return homeTeam;
    }
    public void SetIsSecondMatch(bool toggle)
    {
        isSecondMatch = toggle;
    }
    public bool GetIsSecondMatch()
    {
        return isSecondMatch;
    }
    public bool GetEnded()
    {
        return ended;
    }
    public void SetEnded(bool toggle)
    {
        ended = toggle;
    }
    public int GetHomeScore()
    {
        return homeScore;
    }
    public int GetAwayScore()
    {
        return awayScore;
    }
    public void SetHomeScore(int score)
    {
        homeScore = score;
    }
    public void SetAwayScore(int score)
    {
        awayScore = score;
    }
    public void SetDate(int d)
    {
        date = d;
    }
}
