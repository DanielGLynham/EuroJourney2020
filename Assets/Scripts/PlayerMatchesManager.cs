using System.Collections.Generic;
using UnityEngine;

public class PlayerMatchesManager : MonoBehaviour
{
    List<Match> allInterTournements = new List<Match>();
    List<Match> allDomTournements = new List<Match>();

    List<Match> schoolMatches = new List<Match>();
    List<List<Team>> teamsNeedMatches = new List<List<Team>>();
    List<List<DoubleMatch>> matchesPlayed = new List<List<DoubleMatch>>();
    List<List<DoubleMatch>> domesticMatchesPlayed = new List<List<DoubleMatch>>();

    GameManager gm;
    StoryManager sm;
    LeagueManager lm;
    MainPlayer player;

    int champsfirstDate;
    int champsSecondDate;
    int champsThirdDate;
    int champsFourthDate;
    int champsFithDate;
    int champsCount;
    int champsGroupCount;

    public void Awake()
    {
        gm = this.gameObject.GetComponent<GameManager>();
        sm = this.gameObject.GetComponent<StoryManager>();
        lm = this.gameObject.GetComponent<LeagueManager>();
        player = this.gameObject.GetComponent<MainPlayer>();
    }
    public List<Match> GetSchoolMatches()
    {
        return schoolMatches;
    }
    public void SchoolYear(int leagueNum)
    {
        lm.SetUpSchoolYear(leagueNum);
        //Debug.Log("School matches count " + schoolMatches.Count);
        for (int i = 0; i < schoolMatches.Count; i++)
        {
            if (schoolMatches[i].GetHomeTeam().GetTeamName() == player.GetTeamName() || schoolMatches[i].GetAwayTeam().GetTeamName() == player.GetTeamName())
            {
                AddInternationalTournement(new Match(schoolMatches[i].GetHomeTeam(), schoolMatches[i].GetAwayTeam(), schoolMatches[i].GetIntDate(), leagueNum));
            }
        }
    }
    public void PlaySchoolYear()
    {
        for (int i = 0; i < schoolMatches.Count; i++)
            if (!(schoolMatches[i].GetHomeTeam().GetTeamName() == player.GetTeamName() || schoolMatches[i].GetAwayTeam().GetTeamName() == player.GetTeamName()))
            {
                if (schoolMatches[i].GetIntDate() == sm.GetIntDate())
                {
                    gm.StartMatch(schoolMatches[i], false, false);
                }
            }
    }

    public List<List<Team>> GetTeamsNeedMatches()
    {
        return teamsNeedMatches;
    }
    public List<List<DoubleMatch>> GetMatchesPlayed()
    {
        return matchesPlayed;
    }
    public List<List<DoubleMatch>> GetDomMatchesPlayed()
    {
        return domesticMatchesPlayed;
    }
    private void Euros(int stage)
    {
        // if correct calls - 1st = 5, 2nd = 2, 3rd = 3
        // lm.euros.organiseEuros

    }
    private void EurosPlay(int stage)
    {
        // play matchesPlayed[start at 21] 
        // add to international if player else just play

    }
    private void Champs(int stage, int date, bool secondCall, int leagueNum) // date is x, stage is what this should be calling
    {
        //if (champsCount < 2 && champsGroupCount < 6)
        //{
        //    champsCount++;
        //    if (!secondCall)
        //    {
        //        champsfirstDate = date;

        //    }
        //    else
        //    {
        //        lm.ChampsLeague(stage + 1, champsfirstDate, secondCall, date, leagueNum);
        //        DisplayTourns(date);
        //    }
        //}
    }
    private void ChampsGroup(int stage, int date, bool lastCall, int leagueNum)
    {
        if (champsGroupCount < 6 && champsCount < 2)
        {
            //Debug.Log("champs stage set up called : " + stage);
            if (champsGroupCount == 0)
            {
                champsfirstDate = date;
            }
            else if (champsGroupCount == 1)
            {
                champsSecondDate = date;
            }
            else if (champsGroupCount == 2)
            {
                champsThirdDate = date;
            }
            else if (champsGroupCount == 3)
            {
                champsFourthDate = date;
            }
            else if (champsGroupCount == 4)
            {
                champsFithDate = date;
            }
            else if (champsGroupCount == 5)
            {
                lm.ChampsLeague(champsfirstDate, champsSecondDate, champsThirdDate, champsFourthDate, champsFithDate, date, lastCall, leagueNum);
                DisplayTourns(date);
            }
            champsGroupCount++;
        }
    }
    public void DisplayTourns(int date)
    {
        for (int i = 0; i < matchesPlayed.Count; i++)
            for (int j = 0; j < matchesPlayed[i].Count; j++)
            {
                if (matchesPlayed[i][j].GetSecondMatch().GetIntDate() == date)
                    //play game
                    if (matchesPlayed[i][j].GetHomeTeam().GetTeamName() == player.GetTeamName())
                    {
                        sm.AddInterTourn(new Match(matchesPlayed[i][j].GetFirstMatch().GetHomeTeam(), matchesPlayed[i][j].GetFirstMatch().GetAwayTeam(), matchesPlayed[i][j].GetFirstMatch().GetIntDate(), matchesPlayed[i][j].GetLeague()));
                        sm.AddInterTourn(new Match(matchesPlayed[i][j].GetSecondMatch().GetHomeTeam(), matchesPlayed[i][j].GetSecondMatch().GetAwayTeam(), matchesPlayed[i][j].GetSecondMatch().GetIntDate(), matchesPlayed[i][j].GetLeague()));
                        //Debug.Log(matchesPlayed.Count);
                        //Debug.Log(matchesPlayed[i].Count);
                    }
                    else if (matchesPlayed[i][j].GetAwayTeam().GetTeamName() == player.GetTeamName())
                    {
                        //sm.AddInterTourn(new Match(matchesPlayed[i][j].GetAwayTeam(), matchesPlayed[i][j].GetHomeTeam(), date));
                        sm.AddInterTourn(new Match(matchesPlayed[i][j].GetFirstMatch().GetHomeTeam(), matchesPlayed[i][j].GetFirstMatch().GetAwayTeam(), matchesPlayed[i][j].GetFirstMatch().GetIntDate(), matchesPlayed[i][j].GetLeague()));
                        sm.AddInterTourn(new Match(matchesPlayed[i][j].GetSecondMatch().GetHomeTeam(), matchesPlayed[i][j].GetSecondMatch().GetAwayTeam(), matchesPlayed[i][j].GetSecondMatch().GetIntDate(), matchesPlayed[i][j].GetLeague()));
                    }
            }
    }
    public void ChampsPlay(int date, int leagueNum)
    { 
        //int count = 0;
        //for (int i = 0; i < matchesPlayed.Count; i++)
        //    for (int j = 0; j < matchesPlayed[i].Count; j++)
        //    {
        //        if (matchesPlayed[i][j].GetFirstMatch().GetIntDate() == date)
        //        {
        //            //play game
        //            if (matchesPlayed[i][j].GetHomeTeam().GetTeamName() == player.GetTeamName())
        //            {
        //                AddInternationalTournement(new Match(matchesPlayed[i][j].GetHomeTeam(), matchesPlayed[i][j].GetAwayTeam(), date, leagueNum));
        //                allInterTournements[allInterTournements.Count - 1].SetIsSecondMatch(false);
        //            }
        //            else if (matchesPlayed[i][j].GetAwayTeam().GetTeamName() == player.GetTeamName())
        //            {
        //                AddInternationalTournement(new Match(matchesPlayed[i][j].GetHomeTeam(), matchesPlayed[i][j].GetAwayTeam(), date, leagueNum));
        //                allInterTournements[allInterTournements.Count - 1].SetIsSecondMatch(false);
        //            }
        //            else
        //            {
        //                // play game 
        //                gm.StartMatch(GetMatchesPlayed()[i][j].GetFirstMatch(), false, false);
        //            }
        //        }
        //        if (matchesPlayed[i][j].GetSecondMatch().GetIntDate() == date)
        //        {
        //            // play game
        //            if (matchesPlayed[i][j].GetHomeTeam().GetTeamName() == player.GetTeamName())
        //            {
        //                AddInternationalTournement(new Match(matchesPlayed[i][j].GetHomeTeam(), matchesPlayed[i][j].GetAwayTeam(), date, leagueNum));
        //                allInterTournements[allInterTournements.Count - 1].SetIsSecondMatch(true);
        //            }
        //            else if (matchesPlayed[i][j].GetAwayTeam().GetTeamName() == player.GetTeamName())
        //            {
        //                AddInternationalTournement(new Match(matchesPlayed[i][j].GetHomeTeam(), matchesPlayed[i][j].GetAwayTeam(), date, leagueNum));
        //                allInterTournements[allInterTournements.Count - 1].SetIsSecondMatch(true);
        //            }
        //            else
        //            {
        //                // play game 
        //                gm.StartMatch(GetMatchesPlayed()[i][j].GetSecondMatch(), false, false);
        //            }
        //            champsCount = 0;
        //            if (count == matchesPlayed[i].Count)
        //            {
        //                //Debug.Log("player wasn't included");
        //                CalendarYearOneQuick(date + 1);
        //            }
        //        }

        //    }
    }
    private void Domestic(int stage, int leagueNum)
    {
        //lm.DomesticLeague(stage, leagueNum);
    }
    private void DomesticPlay(int stage)
    {

    }
    private void DomesticOne(int stage) // english football league - cup
    {

    }
    private void DomesticOnePlay(int stage) // english football league - cup
    {

    }
    private void DomesticTwo(int stage) // football assossiation cup
    {

    }
    private void DomesticTwoPlay(int stage) // football assossiation cup
    {

    }
    private void Friendly(int stage)
    {

    }
    private void FriendlyPlay(int stage)
    {

    }
    private void WorldCup(int stage) // world cup
    {

    }
    private void WorldCupPlay(int stage) // world cup
    {

    }
    public void CalendarYearOne(int i) // 2015/ 16
    {
        // LeagueNum key: Champs = 0
        switch (i)
        {
            case 1:
                // euro quals 1st
                EurosPlay(0);
                ChampsPlay(i, 0); // somehow signal that the code has worked stuff out and just needs to play second game later on? Can't be calling 0 twice.
                break;
            case 2:
                // EU quals
                EurosPlay(0);
                ChampsPlay(i, 0);
                break;
            case 3:
                // champs prelims
                // champs 1st quals
                // EU 1st quals
                ChampsPlay(i, 0);
                EurosPlay(1);
                break;
            case 4:
                // champs 1st qual
                // EU 1st quals
                ChampsPlay(i, 0);
                EurosPlay(1);
                break;
            case 5:
                // champs 2nd quals
                // EU 2nd quals
                ChampsPlay(i, 0);
                EurosPlay(2);
                break;
            case 6:
                // champs 2nd quals
                // EU 2nd quals
                ChampsPlay(i, 0);
                EurosPlay(2);
                break;
            case 7:
                //champs 3rd quals
                // EU 3rd quals
                ChampsPlay(i, 0);
                EurosPlay(3);
                break;
            case 8:
                // champs 3rd quals
                ChampsPlay(i, 0);
                break;
            case 9:
                //Domestic one 1st round
                // EU 3rd quals
                DomesticOnePlay(0);
                EurosPlay(3);
                break;
            case 10:
                // domestic week 1
                // champs play off
                // EU play off 
                DomesticPlay(0);
                ChampsPlay(i, 0);
                EurosPlay(4);
                break;
            case 11:
                // Domestic week 2
                // champs play off
                // Domestic one 2nd round
                // EU play off
                DomesticPlay(1);
                ChampsPlay(i, 0);
                DomesticOnePlay(1);
                EurosPlay(4);
                break;
            case 12:
                // domestic week 3
                DomesticPlay(2);
                break;
            case 13:
                // Euro quals 2nd
                // Euros quals 3rd 
                EurosPlay(5);
                EurosPlay(6);
                break;
            case 14:
                // domestic week 4
                // champs group 
                // EU group
                DomesticPlay(3);
                ChampsPlay(i, 0);
                EurosPlay(7);
                break;
            case 15:
                // Domestic week 5 
                // Domestic one 3rd round
                DomesticPlay(4);
                DomesticOnePlay(2);
                break;
            case 16:
                // domestic week 6
                // champs group 
                // EU group  
                DomesticPlay(5);
                ChampsPlay(i, 0);
                EurosPlay(7);
                break;
            case 17:
                // domestic week 7
                // Euro quals
                DomesticPlay(6);
                EurosPlay(8);
                break;
            case 18:
                // World cup quater final 1st round
                // euro quals
                // friendly
                WorldCupPlay(0);
                EurosPlay(8);
                Friendly(0);
                break;
            case 19:
                // domestic week 8
                // champs group 3
                // EU group 3
                DomesticPlay(7);
                ChampsPlay(i, 0);
                EurosPlay(7);
                break;
            case 20:
                // domestic week 9
                // domestic One last 16
                DomesticPlay(8);
                DomesticOnePlay(3);
                break;
            case 21:
                // domestic week 10
                // champs group 4
                // EU group 4
                DomesticPlay(9);
                ChampsPlay(i, 0);
                EurosPlay(7);
                break;
            case 22:
                // domestic week 11
                DomesticPlay(10);
                break;
            case 23:
                // friendly
                // friendly
                FriendlyPlay(1);
                FriendlyPlay(2);
                break;
            case 24:
                // domestic week 12
                // champs group 5
                // EU group 5
                DomesticPlay(11);
                ChampsPlay(i, 0);
                EurosPlay(7);
                break;
            case 25:
                // domestic week 13
                // domestic One quater final
                DomesticPlay(12);
                DomesticOnePlay(4);
                break;
            case 26:
                // domestic week 14
                // champs group 6
                // EU group 6
                DomesticPlay(13);
                ChampsPlay(i, 0);
                EurosPlay(7);
                break;
            case 27:
                // domestic week 15
                // domestic week 16 
                DomesticPlay(14);
                DomesticPlay(15);
                break;
            case 28:
                // domestic week 17
                DomesticPlay(16);
                ChampsPlay(i, 0);
                break;
            case 29:
                //domestic week 18
                DomesticPlay(17);
                ChampsPlay(i, 0);
                break;
            case 30:
                // domestic week 19
                // domestic week 20
                // domestic two cup 3rd round
                DomesticPlay(18);
                DomesticPlay(19);
                DomesticTwoPlay(0);
                break;
            case 31:
                // domestic one semi final
                DomesticOnePlay(5);
                break;
            case 32:
                // domestic week 21
                // domestic two 3rd round
                DomesticPlay(20);
                DomesticTwoPlay(1);
                break;
            case 33:
                // domestic week 22
                // domestic one semi final
                DomesticPlay(21);
                DomesticOnePlay(5);
                break;
            case 34:
                // domestic two cup 4th round
                // domestic week 23
                DomesticTwoPlay(2);
                DomesticPlay(22);
                break;
            case 35:
                //domestic 24
                // domestic two 4th round
                DomesticPlay(23);
                DomesticTwoPlay(3);
                break;
            case 36:
                // doemstic week 25
                // champs round 16
                // EU round 32
                DomesticPlay(24);
                ChampsPlay(i, 0);
                EurosPlay(8);
                break;
            case 37:
                // domestic two 5th round
                //EU round 32
                DomesticTwoPlay(4);
                EurosPlay(8);
                break;
            case 38:
                // domestic week 26
                // domestic week 46
                // domestic one cup final
                // domestic two cup 5th round
                DomesticPlay(25);
                DomesticPlay(45);
                DomesticOnePlay(6);
                DomesticTwoPlay(4);
                break;
            case 39:
                // domestic week 27 
                // champs round 16
                // EU round 16
                DomesticPlay(26);
                //Champs(9);
                EurosPlay(9);
                break;
            case 40:
                // domestic week 28
                // domestic week 45
                // doemstic two quater final
                // EU round 16
                DomesticPlay(27);
                DomesticPlay(44);
                DomesticTwoPlay(5);
                EurosPlay(9);
                break;
            case 41:
                // domestic week 29 
                // domestic week 44
                DomesticPlay(28);
                DomesticPlay(43);
                break;
            case 42:
                break;
            case 43:
                // domestic week 30
                // domestic week 31
                DomesticPlay(29);
                DomesticPlay(30);
                break;
            case 44:
                // domestic week 32
                // champs quater final
                // EU quaterfinal
                DomesticPlay(31);
                ChampsPlay(i, 0);
                EurosPlay(10);
                break;
            case 45:
                // domestic week 33
                // champs quater final 
                // EU Quater final
                DomesticPlay(32);
                ChampsPlay(i, 0);
                EurosPlay(10);
                break;
            case 46:
                // domestic week 34
                // domestic two semi final
                DomesticPlay(33);
                DomesticTwoPlay(6);
                break;
            case 47:
                // domestic week 35
                // champs semi final 
                // EU semi final 
                DomesticPlay(34);
                ChampsPlay(i, 0);
                EurosPlay(11);
                break;
            case 48:
                // domestic week 36 
                // champs semi final
                // EU semi final
                DomesticPlay(35);
                ChampsPlay(i, 0);
                EurosPlay(11);
                break;
            case 49:
                // domestic week 37
                // domestic week 42
                DomesticPlay(36);
                DomesticPlay(41);
                break;
            case 50:
                // domestic week 38
                // domestic week 43
                // EU final
                DomesticPlay(37);
                DomesticPlay(42);
                EurosPlay(12);
                break;
            case 51:
                // domestic week 39 
                // champs final
                // domestic two cup final
                DomesticPlay(38);
                ChampsPlay(i, 0);
                DomesticTwoPlay(7);
                break;
            case 52:
                // domestic week 40
                // domestic week 41
                // domestic week 42
                DomesticPlay(39);
                DomesticPlay(40);
                DomesticPlay(41);
                break;
        }
    }
    public void CalendarYearOneQuick(int i) // 2015/ 16
    {
        // LeagueNum key: Champs = 0, Domestic = 1, School = 2
        int x = i;
        while (x < 52)
        {
            switch (x)
            {
                case 1:
                    // euro quals 1st
                    Euros(0);
                    Champs(0, x, false, 0); // somehow signal that the code has worked stuff out and just needs to play second game later on? Can't be calling 0 twice.
                    break;
                case 2:
                    // EU qualsv
                    Euros(0);
                    Champs(0, x, true, 0);
                    break;
                case 3:
                    // champs prelims
                    // champs 1st quals
                    // EU 1st quals
                    Champs(1, x, false, 0);
                    Euros(1);
                    break;
                case 4:
                    // champs 1st qual
                    // EU 1st quals
                    Champs(1, x, true, 0);
                    Euros(1);
                    break;
                case 5:
                    // champs 2nd quals
                    // EU 2nd quals
                    Champs(2, x, false, 0);
                    Euros(2);
                    break;
                case 6:
                    // champs 2nd quals
                    // EU 2nd quals
                    Champs(2, x, true, 0);
                    Euros(2);
                    break;
                case 7:
                    //champs 3rd quals
                    // EU 3rd quals
                    Champs(3, x, false, 0);
                    Euros(3);
                    break;
                case 8:
                    // champs 3rd quals
                    Champs(3, x, true, 0);
                    break;
                case 9:
                    //Domestic one 1st round
                    // EU 3rd quals
                    DomesticOne(0);
                    Euros(3);
                    break;
                case 10:
                    // domestic week 1
                    // champs play off
                    // EU play off 
                    Domestic(0, 1);
                    Champs(4, x, false, 0);
                    Euros(4);
                    break;
                case 11:
                    // Domestic week 2
                    // champs play off
                    // Domestic one 2nd round
                    // EU play off
                    Domestic(1, 1);
                    Champs(4, x, true, 0);
                    DomesticOne(1);
                    Euros(4);
                    break;
                case 12:
                    // domestic week 3
                    Domestic(2, 1);
                    break;
                case 13:
                    // Euro quals 2nd
                    // Euros quals 3rd 
                    Euros(5);
                    Euros(5);
                    ChampsGroup(5, x, false, 0);
                    break;
                case 14:
                    // domestic week 4
                    // champs group 
                    // EU group
                    Domestic(3, 1);
                    ChampsGroup(5, x, false, 0);
                    Euros(6);
                    break;
                case 15:
                    // Domestic week 5 
                    // Domestic one 3rd round
                    Domestic(4, 1);
                    DomesticOne(2);
                    ChampsGroup(5, x, false, 0);
                    break;
                case 16:
                    // domestic week 6
                    // champs group 
                    // EU group  
                    Domestic(5, 1);
                    ChampsGroup(5, x, false, 0);
                    Euros(6);
                    break;
                case 17:
                    // domestic week 7
                    // Euro quals
                    Domestic(6, 1);
                    Euros(7);
                    ChampsGroup(5, x, false, 0);
                    break;
                case 18:
                    // World cup quater final 1st round
                    // euro quals
                    // friendly
                    WorldCup(0);
                    Euros(7);
                    Friendly(0);
                    break;
                case 19:
                    // domestic week 8
                    // champs group 3
                    // EU group 3
                    Domestic(7, 1);
                    ChampsGroup(5, x, true, 0);
                    Euros(8);
                    break;
                case 20:
                    // domestic week 9
                    // domestic One last 16
                    Domestic(8, 1);
                    DomesticOne(3);
                    break;
                case 21:
                    // domestic week 10
                    // champs group 4
                    // EU group 4
                    Domestic(9, 1);
                    Champs(6, x, false, 0);
                    Euros(8);
                    break;
                case 22:
                    // domestic week 11
                    Domestic(10, 1);
                    break;
                case 23:
                    // friendly
                    // friendly
                    Friendly(1);
                    Friendly(2);
                    break;
                case 24:
                    // domestic week 12
                    // champs group 5
                    // EU group 5
                    Domestic(11, 1);
                    Champs(6, x, true, 0);
                    Euros(9);
                    break;
                case 25:
                    // domestic week 13
                    // domestic One quater final
                    Domestic(12, 1);
                    DomesticOne(4);
                    break;
                case 26:
                    // domestic week 14
                    // champs group 6
                    // EU group 6
                    Domestic(13, 1);
                    Champs(7, x, false, 0);
                    Euros(9);
                    break;
                case 27:
                    // domestic week 15
                    // domestic week 16 
                    Domestic(14, 1);
                    Domestic(15, 1);
                    break;
                case 28:
                    // domestic week 17
                    Domestic(16, 1);
                    Champs(7, x, true, 0);
                    break;
                case 29:
                    //domestic week 18
                    Domestic(17, 1);
                    Champs(8, x, false, 0);
                    break;
                case 30:
                    // domestic week 19
                    // domestic week 20
                    // domestic two cup 3rd round
                    Domestic(18, 1);
                    Domestic(19, 1);
                    DomesticTwo(0);
                    break;
                case 31:
                    // domestic one semi final
                    DomesticOne(5);
                    break;
                case 32:
                    // domestic week 21
                    // domestic two 3rd round
                    Domestic(20, 1);
                    DomesticTwo(1);
                    break;
                case 33:
                    // domestic week 22
                    // domestic one semi final
                    Domestic(21, 1);
                    DomesticOne(5);
                    break;
                case 34:
                    // domestic two cup 4th round
                    // domestic week 23
                    DomesticTwo(2);
                    Domestic(22, 1);
                    break;
                case 35:
                    //domestic 24
                    // domestic two 4th round
                    Domestic(23, 1);
                    DomesticTwo(3);
                    break;
                case 36:
                    // doemstic week 25
                    // champs round 16
                    // EU round 32
                    Domestic(24, 1);
                    Champs(8, x, true, 0);
                    Euros(10);
                    break;
                case 37:
                    // domestic two 5th round
                    //EU round 32
                    DomesticTwo(4);
                    Euros(10);
                    break;
                case 38:
                    // domestic week 26
                    // domestic week 46
                    // domestic one cup final
                    // domestic two cup 5th round
                    Domestic(25, 1);
                    Domestic(45, 1);
                    DomesticOne(6);
                    DomesticTwo(4);
                    break;
                case 39:
                    // domestic week 27 
                    // champs round 16
                    // EU round 16
                    Domestic(26, 1);
                    //Champs(9);
                    Euros(11);
                    break;
                case 40:
                    // domestic week 28
                    // domestic week 45
                    // doemstic two quater final
                    // EU round 16
                    Domestic(27, 1);
                    Domestic(44, 1);
                    DomesticTwo(5);
                    //Euros(9);
                    break;
                case 41:
                    // domestic week 29 
                    // domestic week 44
                    Domestic(28, 1);
                    Domestic(43, 1);
                    break;
                case 42:
                    break;
                case 43:
                    // domestic week 30
                    // domestic week 31
                    Domestic(29, 1);
                    Domestic(30, 1);
                    break;
                case 44:
                    // domestic week 32
                    // champs quater final
                    // EU quaterfinal
                    Domestic(31, 1);
                    Champs(9, x, false, 0);
                    //Euros(10);
                    break;
                case 45:
                    // domestic week 33
                    // champs quater final 
                    // EU Quater final
                    Domestic(32, 1);
                    Champs(9, x, true, 0);
                    //Euros(10);
                    break;
                case 46:
                    // domestic week 34
                    // domestic two semi final
                    Domestic(33, 1);
                    DomesticTwo(6);
                    break;
                case 47:
                    // domestic week 35
                    // champs semi final 
                    // EU semi final 
                    Domestic(34, 1);
                    Champs(10, x, false, 0);
                    //Euros(11);
                    break;
                case 48:
                    // domestic week 36 
                    // champs semi final
                    // EU semi final
                    Domestic(35, 1);
                    Champs(10, x, true, 0);
                    //Euros(11);
                    break;
                case 49:
                    // domestic week 37
                    // domestic week 42
                    Domestic(36, 1);
                    Domestic(41, 1);
                    break;
                case 50:
                    // domestic week 38
                    // domestic week 43
                    // EU final
                    Domestic(37, 1);
                    Domestic(42, 1);
                    //Euros(12);
                    break;
                case 51:
                    // domestic week 39 
                    // champs final
                    // domestic two cup final
                    Domestic(38, 1);
                    Champs(11, x, true, 0);
                    DomesticTwo(7);
                    break;
                case 52:
                    // domestic week 40
                    // domestic week 41
                    // domestic week 42
                    Domestic(39, 1);
                    Domestic(40, 1);
                    Domestic(41, 1);
                    break;
            }
            x++;
        }
    }

    public void AddInternationalTournement(Match newT)
    {
        allInterTournements.Add(newT);
        sm.AddInterTourn(newT);
    }
    public List<Match> GetAllInterTournements()
    {
        return allInterTournements;
    }
    public Match GetTournement(int date)
    {
        //if (allInterTournements[date] != null)
        return allInterTournements[date];
        //else
        //return null;
    }
    public Match GetNextTournement(int date)
    {
        return allInterTournements[20 + date]; // might be add 19?
    }
    public Match GetDomTournement(int date)
    {
        return allDomTournements[date];
    }
    public Match GetNextDomTournement(int date)
    {
        return allDomTournements[20 + date]; // might be add 19?
    }

    private int GetATournementDate(Tournement t)
    {
        return t.GetIntDate();
    }
    public void PlayerMatchEnded(Match match, bool isPlayerMatch)
    {
        if (isPlayerMatch)
            for (int i = 0; i < GetAllInterTournements().Count; i++)
            {
                if (GetAllInterTournements()[i].GetIntDate() == sm.GetIntDate() && GetAllInterTournements()[i].GetHomeTeam().GetTeamID() == match.GetHomeTeam().GetTeamID() && GetAllInterTournements()[i].GetAwayTeam().GetTeamID() == match.GetAwayTeam().GetTeamID())
                {
                    GetAllInterTournements()[i] = match;

                }
            }

        //if (matchesPlayed.Count > 0)
        //    for (int i = 0; i < matchesPlayed.Count; i++)
        //        Debug.Log("MatchesPlayed[] Count: " + matchesPlayed[i].Count);
        //else
        //    Debug.Log("MatchesPlayed Count: " + matchesPlayed.Count);

        for (int i = 0; i < matchesPlayed.Count; i++)
            for (int j = 0; j < matchesPlayed[i].Count; j++)
            {
                //Debug.Log("Home Team: " + matchesPlayed[i][j].GetFirstMatch().GetHomeTeam().GetTeamName() +
                //          ", Away Team: " + matchesPlayed[i][j].GetFirstMatch().GetAwayTeam().GetTeamName() +
                //          ", Match Array League ID: " + matchesPlayed[i][j].GetLeague() +
                //          ", Match League ID: " + match.GetLeague());
                if (matchesPlayed[i][j].GetFirstMatch().GetIntDate() == sm.GetIntDate()
                    && matchesPlayed[i][j].GetFirstMatch().GetHomeTeam().GetTeamID() == match.GetHomeTeam().GetTeamID()
                    && matchesPlayed[i][j].GetFirstMatch().GetAwayTeam().GetTeamID() == match.GetAwayTeam().GetTeamID()
                    && matchesPlayed[i][j].GetLeague() == match.GetLeague())
                {
                    matchesPlayed[i][j].SetFirstMatch(match);
                    //Debug.Log("1st home score: " + matchesPlayed[i][j].GetFirstMatch().GetHomeTeam().GetTeamName() + " " + matchesPlayed[i][j].GetFirstMatch().GetHomeScore());
                    //Debug.Log("1st away score: " + matchesPlayed[i][j].GetFirstMatch().GetAwayTeam().GetTeamName() + " " + matchesPlayed[i][j].GetFirstMatch().GetAwayScore());
                    //Debug.Log("Won First game: " + matchesPlayed[i][j].GetFirstMatch().GetMatchWinner().GetTeamName());
                }
                else if (matchesPlayed[i][j].GetSecondMatch().GetIntDate() == sm.GetIntDate()
                    && matchesPlayed[i][j].GetSecondMatch().GetHomeTeam().GetTeamID() == match.GetHomeTeam().GetTeamID()
                    && matchesPlayed[i][j].GetSecondMatch().GetAwayTeam().GetTeamID() == match.GetAwayTeam().GetTeamID()
                    && matchesPlayed[i][j].GetLeague() == match.GetLeague())
                {
                    matchesPlayed[i][j].SetSecondMatch(match);
                    matchesPlayed[i][j].Update();
                    //Debug.Log("2nd home score: " + matchesPlayed[i][j].GetSecondMatch().GetHomeTeam().GetTeamName() + " " + matchesPlayed[i][j].GetSecondMatch().GetHomeScore());
                    //Debug.Log("2nd away score: " + matchesPlayed[i][j].GetSecondMatch().GetAwayTeam().GetTeamName() + " " + matchesPlayed[i][j].GetSecondMatch().GetAwayScore());
                    //Debug.Log("Won Second game: " + matchesPlayed[i][j].GetSecondMatch().GetMatchWinner().GetTeamName());
                    //Debug.Log("Won overall: " + matchesPlayed[i][j].GetOverallWinner().GetTeamName() + "!!! Congrats " + matchesPlayed[i][j].GetOverallWinner().GetTeamName());
                }
            }
        if (match.GetLeague() == 2)
            for (int i = 0; i < schoolMatches.Count; i++)
            {
                if (schoolMatches[i].GetIntDate() == sm.GetIntDate()
                    && schoolMatches[i].GetHomeTeam().GetTeamID() == match.GetHomeTeam().GetTeamID()
                    && schoolMatches[i].GetAwayTeam().GetTeamID() == match.GetAwayTeam().GetTeamID())
                {
                    //Debug.Log("yo dog, this is wak! I was here yesterday so start here to get fixing. Thanks for working this out future Dan! :)");
                    schoolMatches[i] = match;
                    if (schoolMatches[i].GetMatchDraw())
                    {
                        schoolMatches[i].GetAwayTeam().IncSchoolScore(1);
                        schoolMatches[i].GetHomeTeam().IncSchoolScore(1);
                    }
                    else
                    {
                        schoolMatches[i].GetMatchWinner().IncSchoolScore(3);
                        //if (schoolMatches[i].GetMatchWinner() == player.GetTeam())
                            //Debug.Log("Player has won so increment the points of the school");
                    }
                    lm.SortSchoolWinner();

                    //Debug.Log("school matches count" + schoolMatches.Count);
                    //Debug.Log("Home score: " + schoolMatches[i].GetHomeTeam().GetTeamName() + " " + schoolMatches[i].GetHomeScore());
                    //Debug.Log("Away score: " + schoolMatches[i].GetAwayTeam().GetTeamName() + " " + schoolMatches[i].GetAwayScore());
                    //Debug.Log("Won Game: " + schoolMatches[i].GetMatchWinner().GetTeamName());
                }
            }
    }

}
