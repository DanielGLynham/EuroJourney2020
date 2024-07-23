using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleMatch
{
    Utilities utils;
    private Team homeTeam, awayTeam;
    private Match firstGame, secondGame; // home is home first game but is away on second
    private bool homeWon;
    private string description;
    private bool matchEnded = false;
    

    private int league;         // LeagueNum key: Champs = 0, Domestic = 1, School = 2, Euros = 3
    public void Update()
    {
        if (!matchEnded && secondGame.GetEnded())
        {
            matchEnded = true;
            SetWhoWon(CalcWhoWon());
        }
    }
    public DoubleMatch(Team hT, Team aT, int leagueNum)
    {
        homeTeam = hT;
        awayTeam = aT;
        league = leagueNum;
    }
    public void SetWhoWon(bool hW) // has to be played twice
    {
        homeWon = hW;
        if (hW)
            homeTeam.IncGroupScore();
        else
            awayTeam.IncGroupScore();
        
    }
    public int GetLeague()
    {
        return league;
    }
    public Team GetOverallWinner()
    {
        if (homeWon)
        {
            //Debug.Log(homeTeam.GetTeamName());
            return homeTeam;
        }
        else
        {
            //Debug.Log(awayTeam.GetTeamName());
            return awayTeam;
        }
    }
    public Team GetHomeTeam()
    {
        return homeTeam;
    }
    public Team GetAwayTeam()
    {
        return awayTeam;
    }
    public void CreateFirstMatch(int date)
    {
        firstGame = new Match(homeTeam, awayTeam, date, league);
    }
    public void SetFirstMatch(Match match)
    {
        firstGame = match;
    }
    public void SetSecondMatch(Match match)
    {
        secondGame = match;
    }
    public void CreateSecondMatch(int date)
    {
        secondGame = new Match(homeTeam, awayTeam, date, league);
    }
    public Match GetFirstMatch()
    {
        return firstGame;
    }
    public Match GetSecondMatch()
    {
        return secondGame;
    }
    public void PlayGameQuick() // play two games
    {

    }
    public void PlayGamePlayer() // set up two games to be played
    {

    }
    public void SetLeague(int leagueNum)
    {
        league = leagueNum;
    }
    private bool CalcWhoWon()
    {
        bool homeTeamWon;

        if (firstGame.GetMatchWinner().GetNationID() == secondGame.GetMatchWinner().GetNationID())
        {
            if (firstGame.GetMatchWinner().GetNationID() == homeTeam.GetNationID())
                homeTeamWon = true;
            else
                homeTeamWon = false;
        }
        else
            homeTeamWon = firstGame.GetAwayScore() + secondGame.GetAwayScore() < firstGame.GetHomeScore() + secondGame.GetHomeScore();

        return homeTeamWon;
    }
}
