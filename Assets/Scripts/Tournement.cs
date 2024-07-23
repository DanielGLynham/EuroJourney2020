using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tournement
{
    // teams playing
    int _date;
    string date;
    Team _countryHosting;
    Team playerTeam;
    // Connor add all the stuff you need

    public Tournement(int date, Team host, Team pTeam)
    {
        _date = date;
        _countryHosting = host;
        playerTeam = pTeam;
    }
    private void SortDate()
    {
        int weeks = 1;
        int months = 1;
        int years = 2016;
        int temp = _date;
        while (temp > 48)
        {
            temp -= 48;
            years++;
        }
        while (temp > 3)
        {
            temp -= 4;
            months++;
        }
        weeks = temp + 1;
        date = weeks + "/" + months + "/" + years;
    }
    public string GetDate()
    {
        SortDate();
        return date;
    }
    public void SetDate(int d)
    {
        _date = d;
    }
    public int GetIntDate()
    {
        return _date;
    }
    public Team GetAgainst()
    {
        return _countryHosting;
    }
    public Team GetPlayerTeam()
    {
        return playerTeam;
    }

}
