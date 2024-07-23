using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeagueManager : MonoBehaviour
{
    List<List<Team>> allTeams = new List<List<Team>>();
    List<Team> schoolTeams = new List<Team>();
    List<Team> europeTeams = new List<Team>();
    List<List<Team>> fiveLeagueEuros = new List<List<Team>>();
    List<List<Team>> sixLeagueEuros = new List<List<Team>>();
    List<List<Team>> FourByFourEuros = new List<List<Team>>();
    List<List<Team>> SixByFourEuros = new List<List<Team>>();
    List<Team> playOffsEuros = new List<Team>();

    //List<List<Team>> teamsNeedMatches = new List<List<Team>>();                                                               
    //List<List<DoubleMatch>> matchesPlayed = new List<List<DoubleMatch>>();
    PlayerMatchesManager pmm;
    MainPlayer player;
    TeamManager tm;
    private int champsStage = 0;
    private bool domesticCalledOnce = false;
    private int domesticCounter = 0;

    private List<List<Team>> euroQualsFiveTeams, euroQualsSixTeams;

    public void Awake()
    {
        pmm = this.GetComponent<PlayerMatchesManager>(); 
        player = this.gameObject.GetComponent<MainPlayer>();
        tm = this.gameObject.GetComponent<TeamManager>();
        tm.Initialise();
        allTeams = this.gameObject.GetComponent<TeamManager>().GetAllTeams();
        schoolTeams = this.gameObject.GetComponent<TeamManager>().GetSchoolTeams();
        for(int i = 0;  i < allTeams.Count; i++)
        {
            europeTeams.Add(allTeams[i][0]);
        }
    }
    public void OrganiseEuros(int stage)
    {
        switch(stage)
        {
            case 0: // EuroQuals - 55 Teams into 5x5 and 5x6
                // 55 teams qually skills split into 5 leagues of 5 and 6 leagues of 6.
                // there are tiers 1 - 6
                // 2-6, 1-5?
                // TODO:: Seperate properly into equal quality groups insead of number order.
                int count = europeTeams.Count;
                for(int i = 0; i < 5; i++)
                {
                    fiveLeagueEuros.Add(new List<Team>());
                    for(int x = 0; x < 5; x++)
                    {
                        fiveLeagueEuros[i].Add(europeTeams[count]);
                        count++;
                        sixLeagueEuros[i].Add(europeTeams[count]);
                        count++;
                    }
                    sixLeagueEuros[i].Add(europeTeams[count]);
                    count++;
                }
                // set up games for all v all in matchesPlayed[21]
                for(int i = 0; i < 5; i++)
                {
                    SetUpRoundRobin(fiveLeagueEuros[i], 3, 21);
                    SetUpRoundRobin(sixLeagueEuros[i], 3, 21);
                }
                SetUpRoundRobin(sixLeagueEuros[5], 3, 21);
                break;
            case 1: // EuroFinalQuals - 16 teams into 4x4
                // 16 next teams that didn't make it paly off for 4 winners
                // use points scored to get into equal skills?
                List<Team> notFirstOrSecondTeams = new List<Team>();
                for(int i = 0; i < 5; i++) // 5 leagues
                {
                    notFirstOrSecondTeams.Add(fiveLeagueEuros[i][2]);
                    notFirstOrSecondTeams.Add(fiveLeagueEuros[i][3]);
                    notFirstOrSecondTeams.Add(sixLeagueEuros[i][2]);
                    notFirstOrSecondTeams.Add(sixLeagueEuros[i][3]);
                }
                // need to get rid of worst 4.....
                for (int i = 0; i < 4; i++)
                {
                    int smallest = 0;
                    for(int x = 0; x < notFirstOrSecondTeams.Count; x++)
                    {
                        if(notFirstOrSecondTeams[x].GetEurosScore() <= notFirstOrSecondTeams[smallest].GetEurosScore())
                        {
                            smallest = x;
                        }
                    }
                    notFirstOrSecondTeams.RemoveAt(smallest);
                }
                List<Team> tempsixteenTeams = notFirstOrSecondTeams;
                for(int a = 0; a < 4; a++) // 4 teams
                {
                    for(int b = 0; b < 4; b++) // 4 leagues
                    {
                        FourByFourEuros.Add(new List<Team>());
                        int largest = 0;

                        for(int c = 0; c < tempsixteenTeams.Count; c++) // search all teams
                        {
                            if(tempsixteenTeams[c].GetEurosScore() > tempsixteenTeams[largest].GetEurosScore())
                            {
                                largest = c;
                            }
                        }
                        FourByFourEuros[b].Add(tempsixteenTeams[largest]);
                        tempsixteenTeams.RemoveAt(largest);
                    }
                }
                // set up games for topvbottom in matchesPlayed[22]
                break;
            case 2: // EuroMain - 24 teams into 6x4
                // 24 teams taken from above, Play to get a group position
                // use position in groups to organise
                int oneCount = 0;
                int TwoCount = 0;
                for(int a = 0; a < 4; a++)
                {
                    for(int b = 0; b < 6; b++)
                    {
                        SixByFourEuros.Add(new List<Team>());
                        if(b >=0 || b <= 3)
                        {
                            if(a == 0 || a == 1)
                            {
                                if(oneCount < 6)
                                {
                                    SixByFourEuros[b].Add(sixLeagueEuros[oneCount][0]); // first best added
                                    oneCount++;
                                }
                                else if(oneCount < 10)
                                {
                                    SixByFourEuros[b].Add(fiveLeagueEuros[oneCount - 6][0]); // first best added
                                    oneCount++;
                                }
                            }
                            else if(a == 2)
                            {
                                if(TwoCount < 6)
                                {
                                    SixByFourEuros[b].Add(sixLeagueEuros[TwoCount][1]); // second best added
                                    TwoCount++;
                                }
                                else if(TwoCount < 10)
                                {
                                    SixByFourEuros[b].Add(fiveLeagueEuros[TwoCount][1]); // second best added
                                    TwoCount++;
                                }
                            }
                            else
                            {
                                SixByFourEuros[b].Add(FourByFourEuros[b][0]); // 3rd best added
                            }
                        }
                        else
                        {
                            if(a == 0)
                            {
                                SixByFourEuros[b].Add(sixLeagueEuros[oneCount][0]); // first best added
                                oneCount++;
                            }
                            else
                            {
                                SixByFourEuros[b].Add(fiveLeagueEuros[TwoCount][1]); // second best added
                                TwoCount++;
                            }
                        }
                    }
                }
                // set up games for Top v bottom in matchesPlayed[23]
                break;
            case 3: // EuroFinal - 16 teams into 2x8 until one winner
                // top two and 4 top 3's 
                List<Team> temp = new List<Team>();
                for(int i = 0; i < 6; i++)
                {
                    temp.Add(SixByFourEuros[i][0]);
                }
                for (int i = 0; i < 6; i++)
                {
                    temp.Add(SixByFourEuros[i][1]);
                }
                for (int i = 0; i < 4; i++) // needs to be the best 4 though, not just first 4.
                {
                    temp.Add(SixByFourEuros[i][2]);
                }

                playOffsEuros.Add(temp[0]);
                playOffsEuros.Add(temp[15]);
                playOffsEuros.Add(temp[1]);
                playOffsEuros.Add(temp[14]);
                playOffsEuros.Add(temp[2]);
                playOffsEuros.Add(temp[11]);
                playOffsEuros.Add(temp[6]);
                playOffsEuros.Add(temp[10]);
                playOffsEuros.Add(temp[3]);
                playOffsEuros.Add(temp[13]);
                playOffsEuros.Add(temp[4]);
                playOffsEuros.Add(temp[12]);
                playOffsEuros.Add(temp[5]);
                playOffsEuros.Add(temp[9]);
                playOffsEuros.Add(temp[8]);
                playOffsEuros.Add(temp[7]);
                // set up games in two's in matchesPlayed[24]
                break;
        }
    }
    public List<Team> GetSchoolTeams()
    {
        return schoolTeams;
    }
    public void SetUpSchoolYear(int leagueNum)
    {
        SetUpRoundRobin(schoolTeams, leagueNum);
    }
    public void SortSchoolWinner()
    {
        List<Team> copyTeams = new List<Team>(schoolTeams);

        for (int i = 0; i < schoolTeams.Count; i++)
        {
            Team temp = copyTeams[0];
            for (int j = 0; j < copyTeams.Count; j++)
                if (copyTeams[j] != temp && copyTeams[j].GetSchoolScore() > temp.GetSchoolScore())
                    temp = copyTeams[j];
            schoolTeams[i] = temp;
            copyTeams.Remove(temp);
        }
    }

    public void DomesticLeague(int stage, int leagueNum)
    {
        domesticCounter++;
        if (!domesticCalledOnce)
        {
            for (int i = 0; i < allTeams.Count; i++)
            {
                pmm.GetDomMatchesPlayed().Add(new List<DoubleMatch>());
                if (domesticCounter < allTeams[i].Count)
                    for (int j = 0; j < allTeams[i].Count; j++)
                    {
                        int counter = j;
                        while (counter < allTeams[j].Count)
                        {
                            //Debug.Log(pmm.GetDomMatchesPlayed()[i].Count);
                            pmm.GetDomMatchesPlayed()[i].Add(new DoubleMatch(allTeams[i][j], allTeams[i][counter + 1], leagueNum));
                            counter++;
                            //Debug.Log("i j counter" + i + " " + j + " " + counter);
                        }
                    }
            }

            domesticCalledOnce = true;
        }
    }
    public void ChampsLeague(int firstDate, int SecondDate, int thirdDate, int fourthDate, int fithDate, int sixthDate, bool lastCall, int leagueNum)
    {
        if (lastCall)
        {
            //Debug.Log("Groups called");
            Groups(leagueNum);
            // for 8 groups 
            for (int y = 9; y < 16; y++)
                //for (int i = 0; i < pmm.GetMatchesPlayed()[y].Count; i++)
            {
                //Debug.Log(y);
                pmm.GetMatchesPlayed()[y][0].SetLeague(leagueNum);
                pmm.GetMatchesPlayed()[y][0].CreateFirstMatch(firstDate);
                pmm.GetMatchesPlayed()[y][0].CreateSecondMatch(SecondDate);
                pmm.GetMatchesPlayed()[y][5].SetLeague(leagueNum);
                pmm.GetMatchesPlayed()[y][5].CreateFirstMatch(firstDate);
                pmm.GetMatchesPlayed()[y][5].CreateSecondMatch(SecondDate);
                pmm.GetMatchesPlayed()[y][1].SetLeague(leagueNum);
                pmm.GetMatchesPlayed()[y][1].CreateFirstMatch(thirdDate);
                pmm.GetMatchesPlayed()[y][1].CreateSecondMatch(fourthDate);
                pmm.GetMatchesPlayed()[y][4].SetLeague(leagueNum);
                pmm.GetMatchesPlayed()[y][4].CreateFirstMatch(thirdDate);
                pmm.GetMatchesPlayed()[y][4].CreateSecondMatch(fourthDate);
                pmm.GetMatchesPlayed()[y][2].SetLeague(leagueNum);
                pmm.GetMatchesPlayed()[y][2].CreateFirstMatch(fithDate);
                pmm.GetMatchesPlayed()[y][2].CreateSecondMatch(sixthDate);
                pmm.GetMatchesPlayed()[y][3].SetLeague(leagueNum);
                pmm.GetMatchesPlayed()[y][3].CreateFirstMatch(fithDate);
                pmm.GetMatchesPlayed()[y][3].CreateSecondMatch(sixthDate);
                // set up 6 games
            }
        }
    }
    public void ChampsLeague(int stage, int date, bool secondCall, int secondDate, int leagueNum)
    {
        switch (stage) // remembers what point we are at
        {
            
            case 1:
                if(!secondCall)
                {
                }
                else
                {
                    FirstPrelims(leagueNum);
                    for (int i = 0; i < pmm.GetMatchesPlayed()[0].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[0][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[0][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[0][i].CreateSecondMatch(secondDate);
                    }
                }
                break;
            case 2:
                if (!secondCall)
                {

                }
                else
                {
                    FinalPrelims(leagueNum);
                    for (int i = 0; i < pmm.GetMatchesPlayed()[1].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[1][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[1][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[1][i].CreateSecondMatch(secondDate);
                    }
                }
                break;
            case 3:
                if (!secondCall)
                {

                }
                else
                {
                    FirstQuals(leagueNum);
                    for (int i = 0; i < pmm.GetMatchesPlayed()[2].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[2][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[2][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[2][i].CreateSecondMatch(secondDate);
                    }
                }
                break;
            case 4:
                if (!secondCall)
                { }
                else
                {
                    //Debug.Log("2nd quals called");
                    SecondQuals(leagueNum);
                    for (int i = 0; i < pmm.GetMatchesPlayed()[3].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[3][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[3][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[3][i].CreateSecondMatch(secondDate);
                    }
                    for (int i = 0; i < pmm.GetMatchesPlayed()[4].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[4][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[4][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[4][i].CreateSecondMatch(secondDate);
                    }
                }
                break;
            case 5:
                if (!secondCall)
                { }
                else
                {
                    //Debug.Log("3rd quals called");
                    ThirdQuals(leagueNum);
                    for (int i = 0; i < pmm.GetMatchesPlayed()[5].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[5][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[5][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[5][i].CreateSecondMatch(secondDate);
                    }
                    for (int i = 0; i < pmm.GetMatchesPlayed()[6].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[6][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[6][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[6][i].CreateSecondMatch(secondDate);
                    }
                }
                break;
            case 6:
                if (!secondCall)
                { }
                else
                {
                    //Debug.Log("Play off got called");
                    PlayOff(leagueNum);
                    for (int i = 0; i < pmm.GetMatchesPlayed()[7].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[7][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[7][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[7][i].CreateSecondMatch(secondDate);
                    }
                    for (int i = 0; i < pmm.GetMatchesPlayed()[8].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[8][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[8][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[8][i].CreateSecondMatch(secondDate);
                    }
                }
                break;
            case 7:
                if (!secondCall)
                { }
                else
                {
                    //Debug.Log("Groups called");
                    Groups(leagueNum);
                    // for 8 groups 
                    for (int y = 9; y < 16; y++)
                        for (int i = 0; i < pmm.GetMatchesPlayed()[y].Count; i++)
                        {
                            //Debug.Log(y);
                            pmm.GetMatchesPlayed()[y][i].SetLeague(leagueNum);
                            pmm.GetMatchesPlayed()[y][i].CreateFirstMatch(date);
                            pmm.GetMatchesPlayed()[y][i].CreateSecondMatch(secondDate);
                            //if (pmm.GetMatchesPlayed()[y][i].GetHomeTeam().GetTeamName() == player.GetTeamName())
                            //{
                            //            pmm.AddInternationalTournement(new Tournement(date, pmm.GetMatchesPlayed()[y][i].GetAwayTeam(), player.GetTeam()));
                            //}
                            //else if (pmm.GetMatchesPlayed()[y][i].GetAwayTeam().GetTeamName() == player.GetTeamName())
                            //{
                            //            pmm.AddInternationalTournement(new Tournement(date, pmm.GetMatchesPlayed()[y][i].GetHomeTeam(), player.GetTeam()));
                            //}
                            //else
                            //{
                            //    // play game 
                            //    pmm.GetMatchesPlayed()[y][i].SetWhoWon(true);
                            //}
                        }
                }
                break;
            case 8:
                if (!secondCall)
                { }
                else
                {
                    KnockOutOne(leagueNum);
                    for (int i = 0; i < pmm.GetMatchesPlayed()[17].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[17][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[17][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[17][i].CreateSecondMatch(secondDate);
                    }
                }
                //for (int i = 0; i < pmm.GetMatchesPlayed()[17].Count; i++)
                //{
                //    if (pmm.GetMatchesPlayed()[17][i].GetHomeTeam().GetTeamName() == player.GetTeamName())
                //    {
                //            pmm.AddInternationalTournement(new Tournement(date, pmm.GetMatchesPlayed()[17][i].GetAwayTeam(), player.GetTeam()));
                //    }
                //    else if (pmm.GetMatchesPlayed()[17][i].GetAwayTeam().GetTeamName() == player.GetTeamName())
                //    {
                //            pmm.AddInternationalTournement(new Tournement(date, pmm.GetMatchesPlayed()[17][i].GetHomeTeam(), player.GetTeam()));
                //    }
                //    else
                //    {
                //        // play game 
                //        pmm.GetMatchesPlayed()[17][i].SetWhoWon(true);
                //    }
                //}
                break;
            case 9:
                if (!secondCall)
                { }
                else
                {
                    KnockOutTwo(leagueNum);
                    for (int i = 0; i < pmm.GetMatchesPlayed()[18].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[18][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[18][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[18][i].CreateSecondMatch(secondDate);
                    }
                }
                //for (int i = 0; i < pmm.GetMatchesPlayed()[18].Count; i++)
                //{
                //    if (pmm.GetMatchesPlayed()[18][i].GetHomeTeam().GetTeamName() == player.GetTeamName())
                //    {
                //            pmm.AddInternationalTournement(new Tournement(date, pmm.GetMatchesPlayed()[18][i].GetAwayTeam(), player.GetTeam()));
                //    }
                //    else if (pmm.GetMatchesPlayed()[18][i].GetAwayTeam().GetTeamName() == player.GetTeamName())
                //    {
                //            pmm.AddInternationalTournement(new Tournement(date, pmm.GetMatchesPlayed()[18][i].GetHomeTeam(), player.GetTeam()));
                //    }
                //    else
                //    {
                //        // play game 
                //        pmm.GetMatchesPlayed()[18][i].SetWhoWon(true);
                //    }
                //}
                break;
            case 10:
                if (!secondCall)
                { }
                else
                {
                    KnockOutThree(leagueNum);
                    for (int i = 0; i < pmm.GetMatchesPlayed()[19].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[19][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[19][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[19][i].CreateSecondMatch(secondDate);
                    }
                }
                //for (int i = 0; i < pmm.GetMatchesPlayed()[19].Count; i++)
                //{
                //    if (pmm.GetMatchesPlayed()[19][i].GetHomeTeam().GetTeamName() == player.GetTeamName())
                //    {
                //            pmm.AddInternationalTournement(new Tournement(date, pmm.GetMatchesPlayed()[19][i].GetAwayTeam(), player.GetTeam()));
                //    }
                //    else if (pmm.GetMatchesPlayed()[19][i].GetAwayTeam().GetTeamName() == player.GetTeamName())
                //    {
                //            pmm.AddInternationalTournement(new Tournement(date, pmm.GetMatchesPlayed()[19][i].GetHomeTeam(), player.GetTeam()));
                //    }
                //    else
                //    {
                //        // play game 
                //        pmm.GetMatchesPlayed()[19][i].SetWhoWon(true);
                //    }
                //}
                break;
            case 11:
                if (!secondCall)
                { }
                else
                {
                    KnockOutFour(leagueNum);
                    for (int i = 0; i < pmm.GetMatchesPlayed()[20].Count; i++)
                    {
                        pmm.GetMatchesPlayed()[20][i].SetLeague(leagueNum);
                        pmm.GetMatchesPlayed()[20][i].CreateFirstMatch(date);
                        pmm.GetMatchesPlayed()[20][i].CreateSecondMatch(secondDate);
                    }
                }
                //for (int i = 0; i < pmm.GetMatchesPlayed()[20].Count; i++)
                //{
                //    if (pmm.GetMatchesPlayed()[20][i].GetHomeTeam().GetTeamName() == player.GetTeamName())
                //    {
                //            pmm.AddInternationalTournement(new Tournement(date, pmm.GetMatchesPlayed()[20][i].GetAwayTeam(), player.GetTeam()));
                //    }
                //    else if (pmm.GetMatchesPlayed()[20][i].GetAwayTeam().GetTeamName() == player.GetTeamName())
                //    {
                //            pmm.AddInternationalTournement(new Tournement(date, pmm.GetMatchesPlayed()[20][i].GetHomeTeam(), player.GetTeam()));
                //    }
                //    else
                //    {
                //        // play game 
                //        pmm.GetMatchesPlayed()[20][i].SetWhoWon(true);
                //    }
                //}
                break;
        }

        //// prelims
        //SetMatchesTopBottom(OrganiseTeamNeedMatchesList(51, 54, 0), 0);
        //matchesPlayed[1].Add(new DoubleMatch(matchesPlayed[0][0].GetMatchWinner(), matchesPlayed[0][1].GetMatchWinner())); // sets up the match in matches played
        //// 1st quals
        //teamsNeedMatches[2] = OrganiseTeamNeedMatchesList(17, 50, 0); // set up who needs matches
        //teamsNeedMatches[2].Add(matchesPlayed[1][0].GetMatchWinner()); // add the extra
        //SetMatchesTopBottom(teamsNeedMatches[2], 2); // Set them up ready to play
        //// 2nd quals
        //teamsNeedMatches[3] = OrganiseTeamNeedMatchesList(15, 17, 0);
        //for (int i = 0; i < matchesPlayed[2].Count; i++)
        //    teamsNeedMatches[3].Add(matchesPlayed[2][i].GetMatchWinner()); // get winners from champs 2
        //for (int i = 10; i < 15; i++) 
        //    teamsNeedMatches[4].Add(allTeams[i][1]); // NEED SECOND TEAM!
        //SetMatchesTopBottom(teamsNeedMatches[3], 3);
        //SetMatchesTopBottom(teamsNeedMatches[4], 4);
        //// 3rd quals
        //teamsNeedMatches[5] = OrganiseTeamNeedMatchesList(13, 14, 0);
        //for (int i = 0; i < matchesPlayed[2].Count; i++)
        //    teamsNeedMatches[5].Add(matchesPlayed[3][i].GetMatchWinner()); // get winners from champs 2
        //for (int i = 7; i < 9; i++)
        //    teamsNeedMatches[6].Add(allTeams[i][1]); // NEED SECOND TEAM!
        //for (int i = 5; i < 6; i++)
        //    teamsNeedMatches[6].Add(allTeams[i][2]); // NEED THIRD TEAM!
        //SetMatchesTopBottom(teamsNeedMatches[5], 5);
        //SetMatchesTopBottom(teamsNeedMatches[6], 6);
        //// Play off
        //teamsNeedMatches[7] = OrganiseTeamNeedMatchesList(11, 12, 0);
        //for (int i = 0; i < matchesPlayed[5].Count; i++)
        //    teamsNeedMatches[7].Add(matchesPlayed[5][i].GetMatchWinner()); // get winners from champs 2
        //for (int i = 0; i < matchesPlayed[6].Count; i++)
        //    teamsNeedMatches[8].Add(matchesPlayed[6][i].GetMatchWinner()); // get winners from champs 2
        //SetMatchesTopBottom(teamsNeedMatches[7], 7);
        //SetMatchesTopBottom(teamsNeedMatches[8], 8);
        //// Group stage
        //// NEED UEFA champ league winner and UEFA europa league winner 
        //OrganiseTeamNeedMatchesList(0, 10, 0);
        //OrganiseTeamNeedMatchesList(0, 6, 1);
        //OrganiseTeamNeedMatchesList(0, 4, 2);
        //OrganiseTeamNeedMatchesList(0, 4, 4);
        //for (int i = 0; i < matchesPlayed[7].Count; i++)
        //    teamsNeedMatches[9].Add(matchesPlayed[7][i].GetMatchWinner()); // get winners from champs 2
        //for (int i = 0; i < matchesPlayed[7].Count; i++)
        //    teamsNeedMatches[9].Add(matchesPlayed[8][i].GetMatchWinner()); // get winners from league 2
        //for(int x = 0; x < teamsNeedMatches.Count; x++)
        //{
        //    for(int y = 0; y < 4; y++)
        //    {
        //        int i = Random.Range(0, teamsNeedMatches[9].Count);
        //        teamsNeedMatches[9 + x].Add(teamsNeedMatches[9][i]);
        //        teamsNeedMatches[9 + x].RemoveAt(i);
        //    }
        //    SetMatchesAllPlayAll(teamsNeedMatches[9 + x], 9 + x);
        //}
        //// knock outs
        //for(int i = 0; i < 8; i++)
        //{
        //    OrganiseGroupInWinOrder(teamsNeedMatches[9+i]);
        //    teamsNeedMatches[17].Add(teamsNeedMatches[9 + i][0]);
        //    teamsNeedMatches[17].Add(teamsNeedMatches[9 + i][1]);
        //}
        //SetMatchesTopBottom(teamsNeedMatches[17], 17);
        //SetMatchesTopBottom(GetWinners(matchesPlayed[17]), 18);
        //SetMatchesTopBottom(GetWinners(matchesPlayed[18]), 19);
        //SetMatchesTopBottom(GetWinners(matchesPlayed[19]), 20);
        //// found our winner
    }
    private void FirstPrelims(int leagueNum)
    {
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        SetMatchesTopBottom(OrganiseTeamNeedMatchesList(51, 54, 0), 0, leagueNum);
        // play round 0 and set winners. If player is in then get player to play
        // if player plays then create a tournement on a date for them.
        // when player has played then call next stage.
        // player needs to know what stage they are playing for so it passes back here to call correct function.
        // player calls champs that calls correct function after every tournement. 
        champsStage++;
        //Debug.Log("got first prelimes");
    }
    private void FinalPrelims(int leagueNum)
    {
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetMatchesPlayed()[1].Add(new DoubleMatch(pmm.GetMatchesPlayed()[0][0].GetOverallWinner(), pmm.GetMatchesPlayed()[0][1].GetOverallWinner(), leagueNum)); // sets up the match in matches played
        // Get a winner
        champsStage++;
        //Debug.Log("second Prelim = " + pmm.GetMatchesPlayed()[1].Count);
    }
    private void FirstQuals(int leagueNum)
    {
        //for (int i = 17; i <= 50; i++)
        //{
        //    Debug.Log("1st quals " + i + " " + allTeams[i][0]);
        //}
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches()[2] = OrganiseTeamNeedMatchesList(17, 50, 0); // set up who needs matches
        pmm.GetTeamsNeedMatches()[2].Add(pmm.GetMatchesPlayed()[1][0].GetOverallWinner()); // add the extra
        SetMatchesTopBottom(pmm.GetTeamsNeedMatches()[2], 2, leagueNum); // Set them up ready to play
        champsStage++;
        //Debug.Log("1st quals = " + pmm.GetMatchesPlayed()[2].Count);
    }
    private void SecondQuals(int leagueNum)
    {
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());

        pmm.GetTeamsNeedMatches()[3] = OrganiseTeamNeedMatchesList(15, 17, 0);
        for (int i = 0; i < pmm.GetMatchesPlayed()[2].Count; i++)
            pmm.GetTeamsNeedMatches()[3].Add(pmm.GetMatchesPlayed()[2][i].GetOverallWinner()); // get winners from champs 2
        for (int i = 10; i <= 15; i++)
            pmm.GetTeamsNeedMatches()[4].Add(allTeams[i][1]); // NEED SECOND TEAM!
        SetMatchesTopBottom(pmm.GetTeamsNeedMatches()[3], 3, leagueNum);
        SetMatchesTopBottom(pmm.GetTeamsNeedMatches()[4], 4, leagueNum);
        champsStage++;
        //Debug.Log("champs 2nd quals = " + pmm.GetMatchesPlayed()[3].Count);
        //Debug.Log("euros 2nd quals = " + pmm.GetMatchesPlayed()[4].Count);
    }
    private void ThirdQuals(int leagueNum)
    {
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());

        pmm.GetTeamsNeedMatches()[5] = OrganiseTeamNeedMatchesList(13, 14, 0);
        for (int i = 0; i < pmm.GetMatchesPlayed()[3].Count; i++)
            pmm.GetTeamsNeedMatches()[5].Add(pmm.GetMatchesPlayed()[3][i].GetOverallWinner()); // get winners from champs 2
        for (int i = 7; i <= 9; i++)
            pmm.GetTeamsNeedMatches()[6].Add(allTeams[i][1]); // NEED SECOND TEAM!
        for (int i = 5; i <= 6; i++)
            pmm.GetTeamsNeedMatches()[6].Add(allTeams[i][2]); // NEED THIRD TEAM!
        for (int i = 0; i < pmm.GetMatchesPlayed()[4].Count; i++)
            pmm.GetTeamsNeedMatches()[6].Add(pmm.GetMatchesPlayed()[4][i].GetOverallWinner());
        SetMatchesTopBottom(pmm.GetTeamsNeedMatches()[5], 5, leagueNum);
        SetMatchesTopBottom(pmm.GetTeamsNeedMatches()[6], 6, leagueNum);
        champsStage++;
        //Debug.Log("champs 3rd quals = " + pmm.GetMatchesPlayed()[5].Count);
        //Debug.Log("euros 3rd quals = " + pmm.GetMatchesPlayed()[6].Count);
    }
    private void PlayOff(int leagueNum)
    {
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());

        pmm.GetTeamsNeedMatches()[7] = OrganiseTeamNeedMatchesList(11, 12, 0);
        for (int i = 0; i < pmm.GetMatchesPlayed()[5].Count; i++)
            pmm.GetTeamsNeedMatches()[7].Add(pmm.GetMatchesPlayed()[5][i].GetOverallWinner()); // get winners from champs 2
        for (int i = 0; i < pmm.GetMatchesPlayed()[6].Count; i++)
            pmm.GetTeamsNeedMatches()[8].Add(pmm.GetMatchesPlayed()[6][i].GetOverallWinner()); // get winners from euros 2
        SetMatchesTopBottom(pmm.GetTeamsNeedMatches()[7], 7, leagueNum);
        SetMatchesTopBottom(pmm.GetTeamsNeedMatches()[8], 8, leagueNum);
        champsStage++;
        //Debug.Log("Champs play off = " + pmm.GetMatchesPlayed()[7].Count);
        //Debug.Log("Euros play off = " + pmm.GetMatchesPlayed()[8].Count);
    }
    private void Groups(int leagueNum) ///////// NEED THEM EUFE WINNERS!!!!
    {
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        // NEED UEFA champ league winner and UEFA europa league winner 
        //OrganiseTeamNeedMatchesList(0, 10, 0);
        for(int i = 0; i <= 10; i++) // gain WINNER THAT WE DON@T HAVE
        {
            pmm.GetTeamsNeedMatches()[9].Add(allTeams[i][0]);
        }
        //OrganiseTeamNeedMatchesList(0, 6, 1);
        for (int i = 0; i <= 6; i++) // gain WINNER THAT WE DON@T HAVE
        {
            pmm.GetTeamsNeedMatches()[9].Add(allTeams[i][1]);
        }
        //OrganiseTeamNeedMatchesList(0, 4, 2);
        for (int i = 0; i < 4; i++)
        {
            pmm.GetTeamsNeedMatches()[9].Add(allTeams[i][2]);
        }
        //OrganiseTeamNeedMatchesList(0, 4, 3);
        for (int i = 0; i < 4; i++)
        {
            pmm.GetTeamsNeedMatches()[9].Add(allTeams[i][3]);
        }
        for (int i = 0; i < pmm.GetMatchesPlayed()[7].Count; i++)
        {
            pmm.GetTeamsNeedMatches()[9].Add(pmm.GetMatchesPlayed()[7][i].GetOverallWinner()); // get winners from champs 2

        }
        for (int i = 0; i < pmm.GetMatchesPlayed()[8].Count; i++)
        {
            pmm.GetTeamsNeedMatches()[9].Add(pmm.GetMatchesPlayed()[8][i].GetOverallWinner()); // get winners from league 2 
        }
        int n = 0;
        //Debug.Log(pmm.GetTeamsNeedMatches()[9].Count);
        for (int x = 0; x < pmm.GetTeamsNeedMatches()[9].Count ; x += 4) // TODO:: way too many teams in!!!
        {
            for (int y = 0; y < 4; y++)
            {
                pmm.GetTeamsNeedMatches()[10 + n].Add(pmm.GetTeamsNeedMatches()[9][x + y]);
            }
            SetMatchesAllPlayAll(pmm.GetTeamsNeedMatches()[10 + n], 9 + n, leagueNum);
            n++;
        }
        champsStage++;
        //Debug.Log("9  = " + pmm.GetMatchesPlayed()[9].Count);
        //Debug.Log("10 = " + pmm.GetMatchesPlayed()[10].Count);
        //Debug.Log("11 = " + pmm.GetMatchesPlayed()[11].Count);
        //Debug.Log("12 = " + pmm.GetMatchesPlayed()[12].Count);
        //Debug.Log("13 = " + pmm.GetMatchesPlayed()[13].Count);
        //Debug.Log("14 = " + pmm.GetMatchesPlayed()[14].Count);
        //Debug.Log("15 = " + pmm.GetMatchesPlayed()[15].Count);
        //Debug.Log("16 = " + pmm.GetMatchesPlayed()[16].Count);
    }
    private void KnockOutOne(int leagueNum)
    {
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        for (int i = 0; i < 8; i++)
        {
            OrganiseGroupInWinOrder(pmm.GetTeamsNeedMatches()[10 + i]);
            pmm.GetTeamsNeedMatches()[18].Add(pmm.GetTeamsNeedMatches()[10 + i][0]);
            pmm.GetTeamsNeedMatches()[18].Add(pmm.GetTeamsNeedMatches()[10 + i][1]);
            //Debug.Log("first team = " + pmm.GetTeamsNeedMatches()[10 + i][0].GetTeamName() + "pos: " + (10 + i));
            //Debug.Log("Second team = " + pmm.GetTeamsNeedMatches()[10 + i][1].GetTeamName() + "pos: " + (10 + i));
        }
        SetMatchesTopBottom(pmm.GetTeamsNeedMatches()[18], 18, leagueNum);
        //Debug.Log("Teams need matches = " + pmm.GetTeamsNeedMatches()[18].Count);
        //Debug.Log("Knockouts first = " + pmm.GetMatchesPlayed()[18].Count);
        champsStage++;
    }
    private void KnockOutTwo(int leagueNum)
    {
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        SetMatchesTopBottom(GetWinners(pmm.GetMatchesPlayed()[18]), 19, leagueNum);
        //Debug.Log("Knockouts second = " + pmm.GetMatchesPlayed()[19].Count);
        champsStage++;
    }
    private void KnockOutThree(int leagueNum)
    {
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        SetMatchesTopBottom(GetWinners(pmm.GetMatchesPlayed()[19]), 20, leagueNum);
        //Debug.Log("Knockouts third = " + pmm.GetMatchesPlayed()[20].Count);
        champsStage++;
    }
    private void KnockOutFour(int leagueNum)
    {
        pmm.GetTeamsNeedMatches().Add(new List<Team>());
        pmm.GetMatchesPlayed().Add(new List<DoubleMatch>());
        SetMatchesTopBottom(GetWinners(pmm.GetMatchesPlayed()[20]), 21, leagueNum);
        //Debug.Log("Knockouts fourth = " + pmm.GetMatchesPlayed()[21].Count);
        // found our winner
        champsStage = 0;
        //Debug.Log("WINNER OF CHAMPS LEAGUE IS::: " + pmm.GetMatchesPlayed()[21][0].GetOverallWinner().GetTeamName());
    }
    private void SetMatchesTopBottom(List<Team> teams, int round, int leagueNum) // Sets up a list of games that needs to be cycled through and played. Top plays bottom
    {
        for(int i = 0; i < (teams.Count) / 2; i++)
        {
            pmm.GetMatchesPlayed()[round].Add(new DoubleMatch(teams[i], teams[teams.Count - i - 1], leagueNum));
        }
    }
    private void SetMatchesAllPlayAll(List<Team> teams, int round, int leagueNum) // Sets up a list of games that needs to be cycled through and played. all v all
    {
        for(int i = 0; i < teams.Count; i++)
        {
            int counter = i;
            //while (counter < 3)
            while (counter < teams.Count - 1)
            {
                pmm.GetMatchesPlayed()[round].Add(new DoubleMatch(teams[i], teams[counter + 1], leagueNum));
                //counter++; // dont't need?
            }
        }
    }
    private List<Team> OrganiseTeamNeedMatchesList(int start, int end, int level) // gets teams from countries. [0] is best team
    {
        List<Team> teamsNeedMatches = new List<Team>();
        for(int i = start; i <= end; i++)
        {
            teamsNeedMatches.Add(allTeams[i][level]);
        }
        return teamsNeedMatches;
    }
    private List<Team> GetWinners(List<DoubleMatch> matchesPlayed) // Find the winners of matches so we know who goes through
    {
        List<Team> teams = new List<Team>();
        for(int i = 0; i < matchesPlayed.Count; i++)
        {
            teams.Add(matchesPlayed[i].GetOverallWinner());
        }
        return teams;
    }
    private void OrganiseGroupInWinOrder(List<Team> teams) // organise groups so we know who did best or second best
    {
        if(teams[0].GetGroupScore() < teams[1].GetGroupScore())
            SwapTeams(teams, 0, 1);
        if (teams[2].GetGroupScore() < teams[3].GetGroupScore())
            SwapTeams(teams, 2, 3);
        if (teams[1].GetGroupScore() < teams[2].GetGroupScore())
            SwapTeams(teams, 1, 2);
        if (teams[0].GetGroupScore() < teams[3].GetGroupScore())
            SwapTeams(teams, 0, 3);
        if (teams[0].GetGroupScore() < teams[1].GetGroupScore())
            SwapTeams(teams, 0, 1);
        if (teams[2].GetGroupScore() < teams[3].GetGroupScore())
            SwapTeams(teams, 2, 3);
    }
    private void SwapTeams(List<Team> teams, int posA, int posB) // swap teams. Used to order the groups
    {
        Team temp = teams[posA];
        teams[posA] = teams[posB];
        teams[posB] = teams[posA];
    }
    private void SetUpRoundRobin(List<Team> teams, int leagueNum)
    {
        //for (int i = 0; i < teams.Count; i++)
        //    Debug.Log(teams[i].GetTeamName());
        bool evenTeams;
        if ((float)teams.Count % 2 == 0)
            evenTeams = true;
        else
            evenTeams = false;

        int numberOfTeams;
        if (evenTeams)
            numberOfTeams = teams.Count;
        else
            numberOfTeams = teams.Count + 1;

        int matchesPerWeek = numberOfTeams / 2;
        int numberOfGames = matchesPerWeek * (numberOfTeams - 1);
        int numberOfWeeks = numberOfGames / matchesPerWeek;

        int dateIncrement = 0;

        if (numberOfWeeks > 26)
            dateIncrement = 1;
        else if (numberOfWeeks > 17)
            dateIncrement = 2;
        else
            switch (numberOfWeeks)
            {
                case 1:
                    dateIncrement = 0;
                    break;
                case 2:
                    dateIncrement = 26;
                    break;
                case 3:
                    dateIncrement = 17;
                    break;
                case 4:
                    dateIncrement = 13;
                    break;
                case 5:
                    dateIncrement = 10;
                    break;
                case 6:
                    dateIncrement = 8;
                    break;
                case 7:
                    dateIncrement = 7;
                    break;
                case 8:
                    dateIncrement = 6;
                    break;
                case 9:
                case 10:
                    dateIncrement = 5;
                    break;
                case 11:
                case 12:
                case 13:
                    dateIncrement = 4;
                    break;
                case 14:
                case 15:
                case 16:
                case 17:
                    dateIncrement = 3;
                    break;
            }

        int dateOfMatch;
        int homeTeamCounter, awayTeamCounter;

        for (int i = 0; i < numberOfWeeks; i++)
        {
            dateOfMatch = 1 + (dateIncrement * i);
            if (evenTeams)
                switch (leagueNum)
                {
                    case 2:
                        pmm.GetSchoolMatches().Add(new Match(teams[i], teams[numberOfTeams - 1], dateOfMatch, leagueNum));
                        break;
                    case -1:
                        //Debug.Log("Home: " + i + ", Away; " + (numberOfTeams - 1) + ", Date: " + dateOfMatch);
                        break;
                }
            homeTeamCounter = awayTeamCounter = i;
            for (int j = 0; j < matchesPerWeek - 1; j++)
            {
                homeTeamCounter = LoopCounter(numberOfTeams - 2, homeTeamCounter, true);
                awayTeamCounter = LoopCounter(numberOfTeams - 2, awayTeamCounter, false);

                if (evenTeams || !evenTeams && (homeTeamCounter != numberOfTeams - 1 || awayTeamCounter != numberOfTeams - 1))
                    switch (leagueNum)
                    {
                        case 2:
                            pmm.GetSchoolMatches().Add(new Match(teams[homeTeamCounter], teams[awayTeamCounter], dateOfMatch, leagueNum));
                            break;
                        case -1:
                            //Debug.Log("Home: " + homeTeamCounter + ", Away; " + awayTeamCounter + ", Date: " + dateOfMatch);
                            break;
                    }
            }
        }
    }private void SetUpRoundRobin(List<Team> teams, int leagueNum, int round)
    {
        //for (int i = 0; i < teams.Count; i++)
        //    Debug.Log(teams[i].GetTeamName());
        bool evenTeams;
        if ((float)teams.Count % 2 == 0)
            evenTeams = true;
        else
            evenTeams = false;

        int numberOfTeams;
        if (evenTeams)
            numberOfTeams = teams.Count;
        else
            numberOfTeams = teams.Count + 1;

        int matchesPerWeek = numberOfTeams / 2;
        int numberOfGames = matchesPerWeek * (numberOfTeams - 1);
        int numberOfWeeks = numberOfGames / matchesPerWeek;

        int dateIncrement = 0;

        if (numberOfWeeks > 26)
            dateIncrement = 1;
        else if (numberOfWeeks > 17)
            dateIncrement = 2;
        else
            switch (numberOfWeeks)
            {
                case 1:
                    dateIncrement = 0;
                    break;
                case 2:
                    dateIncrement = 26;
                    break;
                case 3:
                    dateIncrement = 17;
                    break;
                case 4:
                    dateIncrement = 13;
                    break;
                case 5:
                    dateIncrement = 10;
                    break;
                case 6:
                    dateIncrement = 8;
                    break;
                case 7:
                    dateIncrement = 7;
                    break;
                case 8:
                    dateIncrement = 6;
                    break;
                case 9:
                case 10:
                    dateIncrement = 5;
                    break;
                case 11:
                case 12:
                case 13:
                    dateIncrement = 4;
                    break;
                case 14:
                case 15:
                case 16:
                case 17:
                    dateIncrement = 3;
                    break;
            }

        int dateOfMatch;
        int homeTeamCounter, awayTeamCounter;

        for (int i = 0; i < numberOfWeeks; i++)
        {
            dateOfMatch = 1 + (dateIncrement * i);
            if (evenTeams)
                switch (leagueNum)
                {
                    case 2:
                        pmm.GetSchoolMatches().Add(new Match(teams[i], teams[numberOfTeams - 1], dateOfMatch, leagueNum));
                        break;
                    case -1:
                        //Debug.Log("Home: " + i + ", Away; " + (numberOfTeams - 1) + ", Date: " + dateOfMatch);
                        break;
                }
            homeTeamCounter = awayTeamCounter = i;
            for (int j = 0; j < matchesPerWeek - 1; j++)
            {
                homeTeamCounter = LoopCounter(numberOfTeams - 2, homeTeamCounter, true);
                awayTeamCounter = LoopCounter(numberOfTeams - 2, awayTeamCounter, false);

                if (evenTeams || !evenTeams && (homeTeamCounter != numberOfTeams - 1 || awayTeamCounter != numberOfTeams - 1))
                    switch (leagueNum)
                    {
                        case 2:
                            pmm.GetSchoolMatches().Add(new Match(teams[homeTeamCounter], teams[awayTeamCounter], dateOfMatch, leagueNum));
                            break;
                        case -1:
                            //Debug.Log("Home: " + homeTeamCounter + ", Away; " + awayTeamCounter + ", Date: " + dateOfMatch);
                            break;
                    }
            }
        }
    }

    private int LoopCounter(int maxCounter, int counter, bool increment)
    {
        if (increment)
            counter++;
        else
            counter--;

        if (counter > maxCounter)
            counter -= maxCounter + 1;
        else if (counter < 0)
            counter += maxCounter + 1;

        return counter;
    }
}

// prelim - 4 champs from 52 - 55
// 4 teams play for one spot. Play same team twice, then winners face off

// 1st Qual - 33 champs from 18 - 51 - with prelim winner - 17 winners
// Top V Bottom

// 2nd Qual - 3 champs from 15 - 17, with 17 winners from 1st qual. - Gets 10 winners
// league - 6 runners up from 10 - 15 - 3 winners
// Champs Top V Bottom
// League Top V Bottom

// 3rd qual - 2 champs from 13 - 14 with 10 winners from 2nd qual - Gets 6 winners
//  league - 3 runners up from 7 - 9 and 2 third runners up from 5 - 6 with 3 winners from second quals league
// Top V Bottom
// Top V Bottom

// Play off - 2 champs from 11 - 12 with 6 winners from third quals - gets 4 winners
// league - 4 winners from third quals league - Gets 2 winners
// Top V Bottom
// Top V Bottom

// Group stage - UEFA champ league winner and UEFA europa league winner 
// and 10 champs from 1 - 10 and 6 runners up from 1 - 6 and 4 thirds from 1 - 4 and 4 fourth from 1 - 4
// with 4 winners from champs play off and 2 winners from league.
// 32 teams div into groups - 8 groups of 4   - Randomly picked groups
// Everyone faces everyone twice

// knock outs - 8 winners from group and 8 runners up from group
// 16 teams  - winner faces worst runner up twice. One at home, one away.
// etc. face twice all the way until the final which is played at a random location and played once.