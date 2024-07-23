using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Main Attributes
    private GameObject goalie, ball;

    private Goalie goalieScript;
    private Ball ballScript;
    private MainPlayer player;
    private StoryManager sm;

    private BTNManager btnm;

    private TeamManager teamManager;
    private PlayerMatchesManager pmm;
    private UIManager um;
    private AudioManager am;
    // TODO: Change to list of teammates
    private List<Player> teammates;

    private List<Player> opponents;
    private Goalie oppGoalie = new Goalie();

    private int teamScore = 0, opponentScore = 0;
    private int ballPosition = 3;

    private float matchTime;
    private float matchTimeCountdown;
    private int minutesCounter = 90;
    private bool playingMatch;
    private float matchTimeMultiplier;
    private Match curretTourn;

    private bool skipPlayerMatch = false;
    private bool isPlayerMatch = false;
    private bool isPlayerHome;
    private bool endMatchDelay = true;

    private int ballInSamePosCount;
    private const int maxBallInSamePosCount = 10;

    // Penalty Stats
    private bool playerScoreOpp = false;
    private int forcePenaltyMin;

    private int teamPenaltyCount, oppPenaltyCount;

    private float teamPenaltyChanceScale, oppPenaltyChanceScale;
    private const float penaltyChanceScale1 = 0.1f, penaltyChanceScale2 = 1.0f;
    private const float pcsL1 = 0.0f, pcsL2 = 198.0f;
    private float pcsGrad1;
    private const float pcsIntercept1 = penaltyChanceScale1;

    private float teamPenaltyTimerMult, oppPenaltyTimerMult;
    private float teamPenaltyTimer, oppPenaltyTimer;
    private const float penaltyTimerMult1 = 0.0f, penaltyTimerMult2 = 0.20f, penaltyTimerMult3 = 1.0f;
    private const float ptmT1 = 0.0f, ptmT2 = 25.0f, ptmT3 = 40.0f;
    private float ptmGrad1, ptmGrad2;
    private const float ptmIntercept1 = penaltyTimerMult1;
    private float ptmIntercept2;
    private bool teamPenaltyTimerActive = false, oppPenaltyTimerActive = false;
    private bool teamFoul, oppFoul;

    public const float maxPenaltyChance = 1.0f;

    #region Ball Progression Calculator Variables

    // Overall Scale Graph
    private const float overallScale1 = 0.0f, overallScale2 = 0.6f, overallScale3 = 0.85f, overallScale4 = 1.0f;
    private const float osL1 = 0.0f, osL2 = 40.0f, osL3 = 70.0f, osL4 = 99.0f;
    private float osGrad1, osGrad2, osGrad3;
    private const float osIntercept1 = overallScale1;
    private float osIntercept2, osIntercept3;

    // Difference Scale Graph
    private const float differenceScale1 = 0.0f, differenceScale2 = 0.2f, differenceScale3 = 0.8f, differenceScale4 = 1.0f;
    private const float dsL1 = -98.0f, dsL2 = -15.0f, dsL3 = 15.0f, dsL4 = 98.0f;
    private float dsGrad1, dsGrad2, dsGrad3;
    private float dsIntercept1, dsIntercept2, dsIntercept3;

    // Time Multiplier Graph
    private const float timeMultiplier1 = 1.0f, timeMultiplier2 = 0.8f, timeMultiplier3 = 0.0f;
    private const float tmT1 = 0.0f, tmT2 = 2.0f, tmT3 = 3.0f;
    private float tmGrad1, tmGrad2;
    private const float tmIntercept1 = timeMultiplier1;
    private float tmIntercept2;

    // Time Countdown Values
    private float teamTimerCountdown = 0.0f, oppTimerCountdown = 0.0f;
    private bool teamTimerActive = false, oppTimerActive = false;

    // Max Percentage Variables
    private const float maxOverallInfluencers = 10.0f;
    private const float maxSectionInfluencers = 20.0f;
    private const float maxGoalChance = 90.0f;
    private const float earlySectionMult = maxSectionInfluencers / 4.0f;
    private const float lateSectionMult = maxSectionInfluencers / 5.0f;

    // Stamina Calculation Variables
    private const float staminaMax = maxOverallInfluencers / 4.0f;
    private const float staminaAddition = 1.0f;
    private const float maxMatchMins = 90.0f;
    private float staminaMainScale, teamStaminaOS, oppStaminaOS;

    // Aggression Calculation Variables
    private const float aggressionMax = maxOverallInfluencers / 4.0f;
    private float goalDifference, aggGoalDiffMult, teamAggTimerMult, oppAggTimerMult;
    private const float maxGoalDiffMult = 6.0f;
    private float aggressionMainScale, teamAggressionDS, oppAggressionDS;

    // Motivation Calculation Variables
    private const float motivationMax = maxOverallInfluencers / 4.0f;
    private float motGoalDiffMult;
    private const float maxMotGoalDiffMult = 2.0f;
    private float motivationMainScale, teamMotivationOS, oppMotivationOS;

    // Confidence Calculation Variables
    private const float confidenceMax = maxOverallInfluencers / 4.0f;
    private const float confidenceMainScale = confidenceMax;
    private float teamConfidenceOS, oppConfidenceOS;

    // Section Specific Variables
    private float teamTimingOS, teamAccuracyOS;
    private float teamPassingDS, teamDribblingDS;
    private float teamAgilityDS, teamJumpingDS, teamPositioningDS;
    private float teamSpeedDS, teamStrengthDS;

    private float oppTimingOS, oppAccuracyOS;
    private float oppPassingDS, oppDribblingDS;
    private float oppAgilityDS, oppJumpingDS, oppPositioningDS;
    private float oppSpeedDS, oppStrengthDS;

    // Stat Values
    private float teamMeanStamina, teamMeanAggression, teamMeanMotivation;
    private float teamMeanConfidence, teamMeanAgility, teamMeanJumping;
    private float teamMeanTiming, teamMeanPositioning, teamMeanSpeed;
    private float teamMeanStrength, teamMeanPassing, teamMeanDribbling, teamMeanAccuracy, teamMeanOverallSts;

    private float oppMeanStamina, oppMeanAggression, oppMeanMotivation;
    private float oppMeanConfidence, oppMeanAgility, oppMeanJumping;
    private float oppMeanTiming, oppMeanPositioning, oppMeanSpeed;
    private float oppMeanStrength, oppMeanPassing, oppMeanDribbling, oppMeanAccuracy, oppMeanOverallSts;

    // Opponent Goal Chance Variables
    private const float goalAddition = maxGoalChance / 3.0f;
    private const float goalScale = maxGoalChance * 2.0f / 9.0f;
    private float teamGoalChanceAddition, oppGoalChanceAddition;

    #endregion

    // Match Stats
    // Stats: 0 = goalsScored, 1 = goalOpps, 2 = goal%, 3 = matchesWon, 4 = MatchesPlayed, 
    //        5 = Match%, 6 = BallInTeamPos, 7 = BallInOppPos, 8 = BallPossession
    private int teamGoalsScored, teamGoalOpps, oppGoalOpps, ballInTeamPos, ballInOppPos;

    // REMOVE LATER
    public bool testPercentages = false;

    // Functions
    private void Start()
    {
        btnm = this.gameObject.GetComponent<BTNManager>();
        pmm = this.gameObject.GetComponent<PlayerMatchesManager>();
        sm = this.gameObject.GetComponent<StoryManager>();
        um = this.gameObject.GetComponent<UIManager>();
        am = this.gameObject.GetComponent<AudioManager>();
        SetUpGraphs();

    }

    private void Update()
    {
        if (playingMatch && isPlayerMatch )
            PlayMatch();
    }

    private void PlayMatch()
    {
        if (playingMatch)
        {
            // Update Aggressive Timers
            if (teamTimerActive)
            {
                teamAggTimerMult = CalculateTimerMult(tmT3 - teamTimerCountdown);
                if (isPlayerMatch && !skipPlayerMatch)
                    teamTimerCountdown -= Time.deltaTime * matchTimeMultiplier;
                else
                    teamTimerCountdown -= 1.0f;
                if (teamTimerCountdown <= 0.0f)
                    teamTimerActive = false;
            }
            if (oppTimerActive)
            {
                oppAggTimerMult = CalculateTimerMult(tmT3 - oppTimerCountdown);
                if (isPlayerMatch && !skipPlayerMatch)
                    oppTimerCountdown -= Time.deltaTime * matchTimeMultiplier;
                else
                    oppTimerCountdown -= 1.0f;
                if (oppTimerCountdown <= 0.0f)
                    oppTimerActive = false;
            }
            if (teamPenaltyTimerActive)
            {
                teamPenaltyTimerMult = CalcPenaltyTimerMult(teamPenaltyTimer);

                if (isPlayerMatch && !skipPlayerMatch)
                    teamPenaltyTimer += Time.deltaTime * matchTimeMultiplier;
                else
                    teamPenaltyTimer += 1.0f;

                if (teamPenaltyTimerMult == 1.0f)
                    teamPenaltyTimerActive = false;
            }
            if (oppPenaltyTimerActive)
            {
                oppPenaltyTimerMult = CalcPenaltyTimerMult(oppPenaltyTimer);

                if (isPlayerMatch && !skipPlayerMatch)
                    oppPenaltyTimer += Time.deltaTime * matchTimeMultiplier;
                else
                    oppPenaltyTimer += 1.0f;

                if (oppPenaltyTimerMult == 1.0f)
                    oppPenaltyTimerActive = false;
            }

            // Update Match
            if (matchTime < 90.0f)
            {
                if (matchTimeCountdown >= 1.0f)
                {
                    float teamBallProgChance = CalcTeamBallProgChance();
                    float oppBallProgChance = CalcOppBallProgChance();
                    bool ballPosChanged = false;

                    float teamFoulChance = teamPenaltyChanceScale * teamPenaltyTimerMult * maxPenaltyChance;
                    float oppFoulChance = oppPenaltyChanceScale * oppPenaltyTimerMult * maxPenaltyChance;
                    //Debug.Log("Match Time: " + (matchTime - (matchTime % 1.0f)) + ", Team Foul Chance: " + teamFoulChance + ", Opp Foul Chance: " + oppFoulChance);

                    // Check For Foul
                    if (!teamFoul && !oppFoul)
                        if (Random.Range(0.0f, 100.0f) < teamFoulChance)
                            if (oppFoulChance > teamFoulChance && Random.Range(0.0f, 100.0f) < oppFoulChance)
                                oppFoul = true;
                            else
                                teamFoul = true;
                        else if (Random.Range(0.0f, 100.0f) < oppFoulChance)
                            oppFoul = true;

                    float teamRanNum = Random.Range(0.0f, 100.0f);
                    float oppRanNum1 = Random.Range(0.0f, 100.0f);
                    float oppRanNum2 = Random.Range(0.0f, 100.0f);
                    int outcomeNum = 0;
                    int prevBallPos = ballPosition;

                    if ((!isPlayerMatch || !(matchTime > (float)forcePenaltyMin) || playerScoreOpp || skipPlayerMatch) && !teamFoul && !oppFoul)
                    {
                        if (/*Random.Range(0.0f, 100.0f)*/teamRanNum < teamBallProgChance)
                            if (oppBallProgChance > teamBallProgChance && /*Random.Range(0.0f, 100.0f)*/oppRanNum1 < oppBallProgChance)
                            {
                                ballInSamePosCount = 0;
                                ballInOppPos++;
                                ballPosition--;
                                ballPosChanged = true;
                                outcomeNum = 1;
                            }
                            else
                            {
                                ballInSamePosCount = 0;
                                ballInTeamPos++;
                                ballPosition++;
                                ballPosChanged = true;
                                outcomeNum = 2;
                            }
                        else if (/*Random.Range(0.0f, 100.0f)*/oppRanNum2 < oppBallProgChance)
                        {
                            ballInSamePosCount = 0;
                            ballInOppPos++;
                            ballPosition--;
                            ballPosChanged = true;
                            outcomeNum = 3;
                        }
                        else
                        {
                            //Debug.Log("Same Pos");
                            ballInSamePosCount++;
                            if (ballInSamePosCount > maxBallInSamePosCount)
                                if (teamBallProgChance < oppBallProgChance)
                                {
                                    //Debug.Log("Ball move to opp");
                                    ballInSamePosCount = 0;
                                    ballInOppPos++;
                                    ballPosition--;
                                    ballPosChanged = true;
                                }
                                else
                                {
                                    //Debug.Log("Ball move to team");
                                    ballInSamePosCount = 0;
                                    ballInTeamPos++;
                                    ballPosition++;
                                    ballPosChanged = true;
                                }
                        }

                        if (isPlayerMatch && testPercentages)
                            Debug.Log("Minute: " + matchTime + ", Ball Pos: " + prevBallPos + ", Home Ball Prog Chance: " + teamBallProgChance + ", Away Ball Prog Chance: " + oppBallProgChance +
                                      ", Home Ran Num: " + teamRanNum + ", Opp Ran Num 1: " + oppRanNum1 + ", Opp Ran Num 2: " + oppRanNum2 + ", Outcome: " + outcomeNum + " ;D");

                        // Update Goal Check
                        if (ballPosChanged && ballPosition == 0)
                            OpponentChanceToScore(false);
                        if (ballPosChanged && ballPosition == 6)
                            TeamChanceToScore(false);
                    }
                    else
                    {
                        if ((isPlayerHome && !teamFoul && !oppFoul) || oppFoul)
                        {
                            ballInTeamPos++;
                            if (ballPosition == 5 || ballPosition == 6)
                            {
                                TeamChanceToScore(true);
                                teamPenaltyCount++;
                                oppFoul = false;
                                oppPenaltyTimer = 0.0f;
                                oppPenaltyTimerActive = true;
                            }
                            else
                            {
                                ballPosition++;
                                ballInSamePosCount = 0;
                            }
                        }
                        else
                        {
                            ballInOppPos++;
                            if (ballPosition == 0 || ballPosition == 1)
                            {
                                OpponentChanceToScore(true);
                                oppPenaltyCount++;
                                teamFoul = false;
                                teamPenaltyTimer = 0.0f;
                                teamPenaltyTimerActive = true;
                            }
                            else
                            {
                                ballPosition--;
                                ballInSamePosCount = 0;
                            }
                        }
                    }
                    matchTimeCountdown = matchTime % 1.0f;
                }

                if (isPlayerMatch && !skipPlayerMatch)
                {
                    matchTime += Time.deltaTime * matchTimeMultiplier;
                    matchTimeCountdown += Time.deltaTime * matchTimeMultiplier;
                }
                else
                {
                    matchTime += 1.0f;
                    matchTimeCountdown += 1.0f;
                }
            }
            else
            {
                if (isPlayerMatch && !skipPlayerMatch)
                {
                    if (endMatchDelay)
                    {
                        endMatchDelay = false;
                        if (opponentScore < teamScore)        // TODO: Tournament Draw??
                        {
                            StartCoroutine(um.ShowWhoWon("It's a win for \n" + curretTourn.GetHomeTeam().GetTeamName()));
                        }
                        else if (opponentScore > teamScore)
                        {
                            StartCoroutine(um.ShowWhoWon("It's a win for \n" + curretTourn.GetAwayTeam().GetTeamName()));
                        }
                        else if (isPlayerMatch)
                            StartCoroutine(um.ShowWhoWon("It's a draw!"));
                    }
                }
                else
                {
                    EndMatch();
                }
            }

        }
    }

    public void SetUpPlayerTeam(Team t)
    {
        teammates = t.GetTeam();

        if (!isPlayerHome)
        {
            // TODO: Team has two goalies
            //Goalie goalie = teammates[0];
            Goalie goalie = new Goalie();
            goalie.StartSetup();
            //goalie.SetUpStats(playerStats);
            teammates.Add(goalie);
            oppGoalie = goalie;
        }
    }

    public void SetUpOpponents(Team against)
    {
        opponents = against.GetTeam();

        if (isPlayerHome)
        {
            //int[] playerStats = player.GetStats();
            Goalie goalie = new Goalie();
            goalie.StartSetup();
            //goalie.SetUpStats(playerStats);
            opponents.Add(goalie);
            oppGoalie = goalie;
        }
    }

    public void ShowGameInfo()
    {

    }
    public void StartMatch(Match t, bool isPlayerMatch, bool skipPlayerMatch)
    {
        this.isPlayerMatch = isPlayerMatch;
        this.skipPlayerMatch = skipPlayerMatch;

        //Debug.Log("Date: " + t.GetDate() + ", Home Team: " + t.GetHomeTeam().GetTeamName() + ", Away Team: " + t.GetAwayTeam().GetTeamName());
        //Debug.Log("Start Match. isPlayerMatch: " + isPlayerMatch + "**************************************************************************************************************************************************************************************************");

        if (isPlayerMatch)
        {
            if (t.GetHomeTeam().GetTeamName() == player.GetTeamName())
            {
                isPlayerHome = true;
                SetUpPlayerTeam(t.GetHomeTeam());
                SetUpOpponents(t.GetAwayTeam());
            }
            else
            {
                isPlayerHome = false;
                SetUpPlayerTeam(t.GetAwayTeam());
                SetUpOpponents(t.GetHomeTeam());
            }

            playerScoreOpp = false;
            forcePenaltyMin = Random.Range(70, 80);
        }
        else
        {
            SetUpPlayerTeam(t.GetHomeTeam());
            SetUpOpponents(t.GetAwayTeam());
        }

        SetUpCalcValues();

        teamFoul = oppFoul = false;

        playingMatch = true;
        curretTourn = t;

        teamScore = 0;
        opponentScore = 0;
        ballPosition = 3;
        teamPenaltyCount = 0;
        oppPenaltyCount = 0;
        matchTime = 0.0f;
        matchTimeCountdown = 0.0f;
        teamPenaltyTimer = 0.0f;
        oppPenaltyTimer = 0.0f;
        teamPenaltyTimerActive = true;
        oppPenaltyTimerActive = true;
        if(!sm.GetNeedsTutorial())
            matchTimeMultiplier = 1.0f;

        teamGoalsScored = 0;
        teamGoalOpps = 0;
        oppGoalOpps = 0;
        ballInTeamPos = 0;
        ballInOppPos = 0;

        ballInSamePosCount = 0;

        if (!isPlayerMatch || skipPlayerMatch)
            for (int i = 0; i < minutesCounter + 1; i++)
                PlayMatch();
    }

    public void EndMatch()
    {
        // TODO: Display current match stats in this function -----------------------------------------------------
        // Team Successful Goals: teamScore ----------------   This is now used to output player stat increase. Needs to be used on the post game screen --
        // Team Goal Opportunities: teamGoalOpps -----------   This is now used to output player stat increase. Needs to be used on the post game screen --
        // Opponent Successful Goals: opponentScore --------   Needs to be used on the post game screen --
        // Opponent Goal Opportunities: oppGoalOpps --------   Needs to be used on the post game screen --
        // Team & Opponent Ball Possession Percentages (2 dp): Needs to be used on the post game screen --
        endMatchDelay = true;
        float teamBallPossession = ((float)ballInTeamPos / ((float)ballInOppPos + (float)ballInTeamPos)) * 100.0f;

        float oppBallPossession = 100.0f - teamBallPossession;
        // --------------------------------------------------------------------------------------------------------

        if (opponentScore < teamScore)        // TODO: Tournament Draw??
        {
            if (isPlayerMatch && isPlayerHome)
                player.AddStatistic(3, 1.0f);
            curretTourn.SetWhoWon(1);
            //Debug.Log("Setting the SetWhoWon(1)");
        }
        else if (opponentScore > teamScore)
        {
            if (isPlayerMatch && !isPlayerHome)
                player.AddStatistic(3, 1.0f);
            curretTourn.SetWhoWon(2);
            //Debug.Log("Setting the SetWhoWon(2)");
        }      
        else
        {
            curretTourn.SetWhoWon(3);
            if (isPlayerMatch)
                player.AddStatistic(4, 1.0f);
            //Debug.Log("Setting the SetWhoWon(3)");
        }

        if (isPlayerMatch)
        {
            player.AddStatistic(5, 1.0f);
            UpdatePlayerStats();
        }

        curretTourn.SetHomeScore(teamScore);
        curretTourn.SetAwayScore(opponentScore);

        curretTourn.SetEnded(true);
        playingMatch = false;     
        
        
        //um.DisplayAfterGameStats(isPlayerHome, curretTourn.GetAwayTeam().GetTeamName(), curretTourn.GetHomeTeam().GetTeamName(), teamScore, opponentScore, teamGoalOpps, oppGoalOpps, teamBallPossession, oppBallPossession);
        //sm.SetNewspaper(curretTourn.GetAwayTeam().GetTeamName(), curretTourn.GetHomeTeam().GetTeamName(), curretTourn.GetHomeScore(), curretTourn.GetHomeScore(), curretTourn.GetAwayScore()); // player doesn't have thier own score yet
        //btnm.EndGame();


        oppGoalie.SetSetUp(false);

        if (isPlayerMatch)
        {
            if (isPlayerHome)
            {
                sm.SetNewspaper(curretTourn.GetHomeTeam().GetTeamName(), curretTourn.GetAwayTeam().GetTeamName(), curretTourn.GetHomeScore(), curretTourn.GetHomeScore(), curretTourn.GetAwayScore()); // player doesn't have thier own score yet
                um.DisplayAfterGameStats(isPlayerHome, curretTourn.GetHomeTeam().GetTeamName(), curretTourn.GetAwayTeam().GetTeamName(), teamScore, opponentScore, teamGoalOpps, oppGoalOpps, teamPenaltyCount, oppPenaltyCount, teamBallPossession, oppBallPossession);
            }
            else
            {
                um.DisplayAfterGameStats(isPlayerHome, curretTourn.GetHomeTeam().GetTeamName(), curretTourn.GetAwayTeam().GetTeamName(), teamScore, opponentScore, teamGoalOpps, oppGoalOpps, teamPenaltyCount, oppPenaltyCount, teamBallPossession, oppBallPossession);
                sm.SetNewspaper(curretTourn.GetAwayTeam().GetTeamName(), curretTourn.GetHomeTeam().GetTeamName(), curretTourn.GetAwayScore(), curretTourn.GetAwayScore(), curretTourn.GetHomeScore()); // player doesn't have thier own score yet

            }
            btnm.EndGame();
           

            if (isPlayerHome)
            {
                curretTourn.GetHomeTeam().WeeklyStatInc(teamGoalOpps, teamScore);           //Through the teams main player needs finishing
                player.WeeklyStatInc(teamGoalOpps, teamScore);                              //Directly throuhgh global main player
            }                
            else
            {
                curretTourn.GetAwayTeam().WeeklyStatInc(oppGoalOpps, opponentScore);        //Through the teams main player needs finishing
                player.WeeklyStatInc(oppGoalOpps, opponentScore);                           //Directly through global main player
            }
        }

        pmm.PlayerMatchEnded(curretTourn, isPlayerMatch);


        if(curretTourn.GetIsSecondMatch())
        {
            pmm.CalendarYearOneQuick(sm.GetIntDate() + 1);
        }
    }

    private void UpdatePlayerStats()
    {
        if (isPlayerHome)
        {
            player.AddStatistic(0, (float)teamGoalsScored);
            player.AddStatistic(1, (float)teamGoalOpps);
            player.AddStatistic(8, (float)ballInTeamPos);
            player.AddStatistic(9, (float)ballInOppPos);
        }
        else
        {
            player.AddStatistic(0, (float)opponentScore);
            player.AddStatistic(1, (float)oppGoalOpps);
            player.AddStatistic(8, (float)ballInOppPos);
            player.AddStatistic(9, (float)ballInTeamPos);
        }

        player.UpdateStatisticPercentages();
    }

    private float CalcTeamBallProgChance()
    {
        float progressChance = 0.0f;

        // Overall Influencers
        progressChance += CalcTeamOverallInfluencer();

        // Section Specific Calculations;
        switch (ballPosition)
        {
            case 1:
                progressChance += (teamAgilityDS + teamJumpingDS + teamTimingOS + teamPositioningDS) * earlySectionMult;
                break;
            case 2:
                progressChance += (teamSpeedDS + teamStrengthDS + teamPositioningDS + teamPassingDS) * earlySectionMult;
                break;
            case 3:
                progressChance += (teamSpeedDS + teamAgilityDS + teamStrengthDS + teamPositioningDS + teamPassingDS) * lateSectionMult;
                break;
            case 4:
                progressChance += (teamSpeedDS + teamDribblingDS + teamStrengthDS + teamPositioningDS + teamPassingDS) * lateSectionMult;
                break;
            case 5:
                progressChance += (teamAgilityDS + teamJumpingDS + teamAccuracyOS + teamTimingOS + teamDribblingDS) * lateSectionMult;
                break;
        }

        return progressChance;
    }

    private float CalcOppBallProgChance()
    {
        float progressChance = 0.0f;

        // Overall Influencers
        progressChance += CalcOppOverallInfluencer();

        // Section Specific Calculations;
        switch (ballPosition)
        {
            case 0:
                progressChance += (oppAgilityDS + oppJumpingDS + oppTimingOS + oppPositioningDS) * earlySectionMult;
                break;
            case 1:
                progressChance += (oppSpeedDS + oppStrengthDS + oppPositioningDS + oppPassingDS) * earlySectionMult;
                break;
            case 2:
                progressChance += (oppSpeedDS + oppAgilityDS + oppStrengthDS + oppPositioningDS + oppPassingDS) * lateSectionMult;
                break;
            case 3:
                progressChance += (oppSpeedDS + oppDribblingDS + oppStrengthDS + oppPositioningDS + oppPassingDS) * lateSectionMult;
                break;
            case 4:
                progressChance += (oppAgilityDS + oppJumpingDS + oppAccuracyOS + oppTimingOS + oppDribblingDS) * lateSectionMult;
                break;
        }

        return progressChance;
    }

    private float CalcTeamOverallInfluencer()
    {
        float teamOverallInfluencer = 0.0f;

        // Stamina
        teamOverallInfluencer += (staminaAddition + (matchTime / maxMatchMins)) * staminaMainScale * teamStaminaOS;

        // Aggression
        if (goalDifference < 0)
            aggGoalDiffMult = 3.0f;
        else if (goalDifference < 2)
            aggGoalDiffMult = 5.0f;
        else
            aggGoalDiffMult = maxGoalDiffMult;
        teamOverallInfluencer += aggGoalDiffMult * teamAggTimerMult * aggressionMainScale * teamAggressionDS;

        // Motivation
        if (goalDifference < 0 && goalDifference < maxMotGoalDiffMult + 1)
            motGoalDiffMult = goalDifference;
        else
            motGoalDiffMult = 0;
        teamOverallInfluencer += motGoalDiffMult * motivationMainScale * teamMotivationOS;

        // Confidence
        teamOverallInfluencer += confidenceMainScale * teamConfidenceOS;

        return teamOverallInfluencer;
    }

    private float CalcOppOverallInfluencer()
    {
        float oppOverallInfluencer = 0.0f;

        // Stamina
        oppOverallInfluencer += (staminaAddition + (matchTime / maxMatchMins)) * staminaMainScale * oppStaminaOS;

        // Aggression
        if (goalDifference < 0)
            aggGoalDiffMult = 3.0f;
        else if (goalDifference < 2)
            aggGoalDiffMult = 5.0f;
        else
            aggGoalDiffMult = maxGoalDiffMult;
        oppOverallInfluencer += aggGoalDiffMult * oppAggTimerMult * aggressionMainScale * oppAggressionDS;

        // Motivation
        if (goalDifference < 0 && goalDifference < maxMotGoalDiffMult + 1)
            motGoalDiffMult = goalDifference;
        else
            motGoalDiffMult = 0;
        oppOverallInfluencer += motGoalDiffMult * motivationMainScale * oppMotivationOS;

        // Confidence
        oppOverallInfluencer += confidenceMainScale * oppConfidenceOS;

        return oppOverallInfluencer;
    }

    private void SetUpGraphs()      // Sets up the graphs for the level scaler
    {
        // Overall Scale
        osGrad1 = (overallScale2 - overallScale1) / (osL2 - osL1);
        osGrad2 = (overallScale3 - overallScale2) / (osL3 - osL2);
        osGrad3 = (overallScale4 - overallScale3) / (osL4 - osL3);
        osIntercept2 = overallScale2 - (osL2 * osGrad2);
        osIntercept3 = overallScale3 - (osL3 * osGrad3);

        // Difference Scale
        dsGrad1 = (differenceScale2 - differenceScale1) / (dsL2 - dsL1);
        dsGrad2 = (differenceScale3 - differenceScale2) / (dsL3 - dsL2);
        dsGrad3 = (differenceScale4 - differenceScale3) / (dsL4 - dsL3);
        dsIntercept1 = differenceScale2 - (dsL2 * dsGrad1);
        dsIntercept2 = differenceScale2 - (dsL2 * dsGrad2);
        dsIntercept3 = differenceScale3 - (dsL3 * dsGrad3);

        // Time Multiplier
        tmGrad1 = (timeMultiplier2 - timeMultiplier1) / (tmT2 - tmT1);
        tmGrad2 = (timeMultiplier3 - timeMultiplier2) / (tmT3 - tmT2);
        tmIntercept2 = timeMultiplier2 - (tmT2 * tmGrad2);

        // Penalty Chance
        pcsGrad1 = (penaltyChanceScale2 - penaltyChanceScale1) / (pcsL2 - pcsL1);
        ptmGrad1 = (penaltyTimerMult2 - penaltyTimerMult1) / (ptmT2 - ptmT1);
        ptmGrad2 = (penaltyTimerMult3 - penaltyTimerMult2) / (ptmT3 - ptmT2);
        ptmIntercept2 = penaltyTimerMult2 - (ptmT2 * ptmGrad2);
    }

    private void SetUpCalcValues()      // Sets up the values that determine the probablity the ball will progress up the pitch
    {
        // Main Scale Values
        staminaMainScale = staminaMax / (staminaAddition + 1.0f);
        aggressionMainScale = aggressionMax / maxGoalDiffMult;
        motivationMainScale = motivationMax / maxMotGoalDiffMult;

        // Teammates Mean Stat Values
        //CalcTeamMeanStats();
        

        // Opponents Mean Stat Values
        //CalcOppMeanStats();

        // Teammates Scale Values
        CalcTeamScaleValues();

        // Opponents Scale Values
        CalcOppScaleValues();

        if (!isPlayerMatch || isPlayerMatch && !isPlayerHome || skipPlayerMatch)
            CalcTeamGoalChanceAddition();

        // Opponent Goal Chance Addition Variable
        if (isPlayerMatch && isPlayerHome || skipPlayerMatch)
            CalcOppGoalChanceAddition();
    }

    private void CalcTeamMeanStats()
    {
        float teamTotStamina = 0.0f, teamTotAggression = 0.0f, teamTotMotivation = 0.0f;
        float teamTotConfidence = 0.0f, teamTotAgility = 0.0f, teamTotJumping = 0.0f;
        float teamTotTiming = 0.0f, teamTotPositioning = 0.0f, teamTotSpeed = 0.0f;
        float teamTotStrength = 0.0f, teamTotPassing = 0.0f, teamTotDribbling = 0.0f, teamTotAccuracy = 0.0f;

        if (isPlayerMatch && isPlayerHome)
        {
            teamTotStamina += player.GetStat(0);
            teamTotSpeed += player.GetStat(1);
            teamTotAgility += player.GetStat(2);
            teamTotStrength += player.GetStat(3);
            teamTotJumping += player.GetStat(4);
            teamTotAccuracy += player.GetStat(5);
            teamTotTiming += player.GetStat(6);
            teamTotPassing += player.GetStat(8);
            teamTotDribbling += player.GetStat(9);
            teamTotAggression += player.GetStat(10);
            teamTotMotivation += player.GetStat(11);
            teamTotPositioning += player.GetStat(12);
            teamTotConfidence += player.GetStat(14);


            for (int i = 0; i < 10; i++)
            {
                Player tempTeammate = teammates[i];
                teamTotStamina += tempTeammate.GetStat(0);
                teamTotSpeed += tempTeammate.GetStat(1);
                teamTotAgility += tempTeammate.GetStat(2);
                teamTotStrength += tempTeammate.GetStat(3);
                teamTotJumping += tempTeammate.GetStat(4);
                teamTotAccuracy += tempTeammate.GetStat(5);
                teamTotTiming += tempTeammate.GetStat(6);
                teamTotPassing += tempTeammate.GetStat(8);
                teamTotDribbling += tempTeammate.GetStat(9);
                teamTotAggression += tempTeammate.GetStat(10);
                teamTotMotivation += tempTeammate.GetStat(11);
                teamTotPositioning += tempTeammate.GetStat(12);
                teamTotConfidence += tempTeammate.GetStat(14);

            }
        }
        else
            for (int i = 0; i < 11; i++)
            {
                Player tempTeammate = teammates[i];
                teamTotStamina += tempTeammate.GetStat(0);
                teamTotSpeed += tempTeammate.GetStat(1);
                teamTotAgility += tempTeammate.GetStat(2);
                teamTotStrength += tempTeammate.GetStat(3);
                teamTotJumping += tempTeammate.GetStat(4);
                teamTotAccuracy += tempTeammate.GetStat(5);
                teamTotTiming += tempTeammate.GetStat(6);
                teamTotPassing += tempTeammate.GetStat(8);
                teamTotDribbling += tempTeammate.GetStat(9);
                teamTotAggression += tempTeammate.GetStat(10);
                teamTotMotivation += tempTeammate.GetStat(11);
                teamTotPositioning += tempTeammate.GetStat(12);
                teamTotConfidence += tempTeammate.GetStat(14);
            }

        teamMeanStamina = teamTotStamina / 11;
        teamMeanAggression = teamTotAccuracy / 11;
        teamMeanMotivation = teamTotMotivation / 11;
        teamMeanConfidence = teamTotConfidence / 11;
        teamMeanAgility = teamTotAgility / 11;
        teamMeanJumping = teamTotJumping / 11;
        teamMeanTiming = teamTotTiming / 11;
        teamMeanPositioning = teamTotPositioning / 11;
        teamMeanSpeed = teamTotSpeed / 11;
        teamMeanStrength = teamTotStrength / 11;
        teamMeanPassing = teamTotPassing / 11;
        teamMeanDribbling = teamTotDribbling / 11;
        teamMeanAccuracy = teamTotAccuracy / 11;

        teamMeanOverallSts = teamMeanStamina + teamMeanAggression + teamMeanMotivation + teamMeanConfidence + teamMeanAgility + teamMeanJumping + teamMeanTiming + teamMeanPositioning + teamMeanSpeed + teamMeanStrength + teamMeanPassing + teamMeanDribbling + teamMeanAccuracy;
        //Debug.Log("First Team overall stats= " + teamMeanOverallSts);
    }

    private void CalcOppMeanStats()
    {
        float oppTotStamina = 0.0f, oppTotAggression = 0.0f, oppTotMotivation = 0.0f;
        float oppTotConfidence = 0.0f, oppTotAgility = 0.0f, oppTotJumping = 0.0f;
        float oppTotTiming = 0.0f, oppTotPositioning = 0.0f, oppTotSpeed = 0.0f;
        float oppTotStrength = 0.0f, oppTotPassing = 0.0f, oppTotDribbling = 0.0f, oppTotAccuracy = 0.0f;

        if (isPlayerMatch && !isPlayerHome)
        {
            oppTotStamina += player.GetStat(0);
            oppTotSpeed += player.GetStat(1);
            oppTotAgility += player.GetStat(2);
            oppTotStrength += player.GetStat(3);
            oppTotJumping += player.GetStat(4);
            oppTotAccuracy += player.GetStat(5);
            oppTotTiming += player.GetStat(6);
            oppTotPassing += player.GetStat(8);
            oppTotDribbling += player.GetStat(9);
            oppTotAggression += player.GetStat(10);
            oppTotMotivation += player.GetStat(11);
            oppTotPositioning += player.GetStat(12);
            oppTotConfidence += player.GetStat(14);


            for (int i = 0; i < 10; i++)
            {
                Player tempOpponent = opponents[i];
                oppTotStamina += tempOpponent.GetStat(0);
                oppTotSpeed += tempOpponent.GetStat(1);
                oppTotAgility += tempOpponent.GetStat(2);
                oppTotStrength += tempOpponent.GetStat(3);
                oppTotJumping += tempOpponent.GetStat(4);
                oppTotAccuracy += tempOpponent.GetStat(5);
                oppTotTiming += tempOpponent.GetStat(6);
                oppTotPassing += tempOpponent.GetStat(8);
                oppTotDribbling += tempOpponent.GetStat(9);
                oppTotAggression += tempOpponent.GetStat(10);
                oppTotMotivation += tempOpponent.GetStat(11);
                oppTotPositioning += tempOpponent.GetStat(12);
                oppTotConfidence += tempOpponent.GetStat(14);

            }
        }
        else
            for (int i = 0; i < 11; i++)
            {
                Player tempOpponent = opponents[i];
                oppTotStamina += tempOpponent.GetStat(0);
                oppTotSpeed += tempOpponent.GetStat(1);
                oppTotAgility += tempOpponent.GetStat(2);
                oppTotStrength += tempOpponent.GetStat(3);
                oppTotJumping += tempOpponent.GetStat(4);
                oppTotAccuracy += tempOpponent.GetStat(5);
                oppTotTiming += tempOpponent.GetStat(6);
                oppTotPassing += tempOpponent.GetStat(8);
                oppTotDribbling += tempOpponent.GetStat(9);
                oppTotAggression += tempOpponent.GetStat(10);
                oppTotMotivation += tempOpponent.GetStat(11);
                oppTotConfidence += tempOpponent.GetStat(14);
                oppTotPositioning += tempOpponent.GetStat(12);
            }

        oppMeanStamina = oppTotStamina / 11.0f;
        oppMeanAggression = oppTotAccuracy / 11.0f;
        oppMeanMotivation = oppTotMotivation / 11.0f;
        oppMeanConfidence = oppTotConfidence / 11.0f;
        oppMeanAgility = oppTotAgility / 11.0f;
        oppMeanJumping = oppTotJumping / 11.0f;
        oppMeanTiming = oppTotTiming / 11.0f;
        oppMeanPositioning = oppTotPositioning / 11.0f;
        oppMeanSpeed = oppTotSpeed / 11.0f;
        oppMeanStrength = oppTotStrength / 11.0f;
        oppMeanPassing = oppTotPassing / 11.0f;
        oppMeanDribbling = oppTotDribbling / 11.0f;
        oppMeanAccuracy = oppTotAccuracy / 11.0f;

        oppMeanOverallSts = oppMeanStamina + oppMeanAggression + oppMeanMotivation + oppMeanConfidence + oppMeanAgility + oppMeanJumping + oppMeanTiming + oppMeanPositioning + oppMeanSpeed + oppMeanStrength + oppMeanPassing + oppMeanDribbling + oppMeanAccuracy;
        //Debug.Log("Opponent overall stats= " + oppMeanOverallSts);
    }

    private void CalcTeamScaleValues()
    {
        float differenceValue;

        // Stamina OS
        if (teamMeanStamina > osL3)
            teamStaminaOS = (osGrad3 * teamMeanStamina) + osIntercept3;
        else if (teamMeanStamina > osL2)
            teamStaminaOS = (osGrad2 * teamMeanStamina) + osIntercept2;
        else
            teamStaminaOS = (osGrad1 * teamMeanStamina) + osIntercept1;

        // Aggression DS
        differenceValue = teamMeanAggression - oppMeanAggression;
        if (differenceValue > dsL3)
            teamAggressionDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            teamAggressionDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            teamAggressionDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Motivation OS
        if (teamMeanMotivation > osL3)
            teamMotivationOS = (osGrad3 * teamMeanMotivation) + osIntercept3;
        else if (teamMeanMotivation > osL2)
            teamMotivationOS = (osGrad2 * teamMeanMotivation) + osIntercept2;
        else
            teamMotivationOS = (osGrad1 * teamMeanMotivation) + osIntercept1;

        // Confidence OS
        if (teamMeanConfidence > osL3)
            teamConfidenceOS = (osGrad3 * teamMeanConfidence) + osIntercept3;
        else if (teamMeanConfidence > osL2)
            teamConfidenceOS = (osGrad2 * teamMeanConfidence) + osIntercept2;
        else
            teamConfidenceOS = (osGrad1 * teamMeanConfidence) + osIntercept1;

        // Timing OS
        if (teamMeanTiming > osL3)
            teamTimingOS = (osGrad3 * teamMeanTiming) + osIntercept3;
        else if (teamMeanTiming > osL2)
            teamTimingOS = (osGrad2 * teamMeanTiming) + osIntercept2;
        else
            teamTimingOS = (osGrad1 * teamMeanTiming) + osIntercept1;

        // Accuracy OS
        if (teamMeanAccuracy > osL3)
            teamAccuracyOS = (osGrad3 * teamMeanAccuracy) + osIntercept3;
        else if (teamMeanAccuracy > osL2)
            teamAccuracyOS = (osGrad2 * teamMeanAccuracy) + osIntercept2;
        else
            teamAccuracyOS = (osGrad1 * teamMeanAccuracy) + osIntercept1;

        // Passing DS
        differenceValue = teamMeanPassing - ((oppMeanSpeed + oppMeanAgility) / 2.0f);
        if (differenceValue > dsL3)
            teamPassingDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            teamPassingDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            teamPassingDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Dribbling DS
        differenceValue = teamMeanDribbling - ((oppMeanAggression + oppMeanAgility) / 2.0f);
        if (differenceValue > dsL3)
            teamDribblingDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            teamDribblingDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            teamDribblingDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Agility DS
        differenceValue = teamMeanAgility - oppMeanAgility;
        if (differenceValue > dsL3)
            teamAgilityDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            teamAgilityDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            teamAgilityDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Jumping DS
        differenceValue = teamMeanJumping - oppMeanJumping;
        if (differenceValue > dsL3)
            teamJumpingDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            teamJumpingDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            teamJumpingDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Positioning DS
        differenceValue = teamMeanPositioning - oppMeanPositioning;
        if (differenceValue > dsL3)
            teamPositioningDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            teamPositioningDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            teamPositioningDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Speed DS
        differenceValue = teamMeanSpeed - oppMeanSpeed;
        if (differenceValue > dsL3)
            teamSpeedDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            teamSpeedDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            teamSpeedDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Strength DS
        differenceValue = teamMeanStrength - oppMeanStrength;
        if (differenceValue > dsL3)
            teamStrengthDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            teamStrengthDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            teamStrengthDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Penalty Chance
        teamPenaltyChanceScale = (pcsGrad1 * (teamMeanAggression + 99.0f - teamMeanPositioning)) + pcsIntercept1;
    }

    private void CalcOppScaleValues()
    {
        float differenceValue;

        // Stamina OS
        if (oppMeanStamina > osL3)
            oppStaminaOS = (osGrad3 * oppMeanStamina) + osIntercept3;
        else if (oppMeanStamina > osL2)
            oppStaminaOS = (osGrad2 * oppMeanStamina) + osIntercept2;
        else
            oppStaminaOS = (osGrad1 * oppMeanStamina) + osIntercept1;

        // Aggression DS
        differenceValue = oppMeanAggression - teamMeanAggression;
        if (differenceValue > dsL3)
            oppAggressionDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            oppAggressionDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            oppAggressionDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Motivation OS
        if (oppMeanMotivation > osL3)
            oppMotivationOS = (osGrad3 * oppMeanMotivation) + osIntercept3;
        else if (oppMeanMotivation > osL2)
            oppMotivationOS = (osGrad2 * oppMeanMotivation) + osIntercept2;
        else
            oppMotivationOS = (osGrad1 * oppMeanMotivation) + osIntercept1;

        // Confidence OS
        if (oppMeanConfidence > osL3)
            oppConfidenceOS = (osGrad3 * oppMeanConfidence) + osIntercept3;
        else if (oppMeanConfidence > osL2)
            oppConfidenceOS = (osGrad2 * oppMeanConfidence) + osIntercept2;
        else
            oppConfidenceOS = (osGrad1 * oppMeanConfidence) + osIntercept1;

        // Timing OS
        if (oppMeanTiming > osL3)
            oppTimingOS = (osGrad3 * oppMeanTiming) + osIntercept3;
        else if (oppMeanTiming > osL2)
            oppTimingOS = (osGrad2 * oppMeanTiming) + osIntercept2;
        else
            oppTimingOS = (osGrad1 * oppMeanTiming) + osIntercept1;

        // Accuracy OS
        if (oppMeanAccuracy > osL3)
            oppAccuracyOS = (osGrad3 * oppMeanAccuracy) + osIntercept3;
        else if (oppMeanAccuracy > osL2)
            oppAccuracyOS = (osGrad2 * oppMeanAccuracy) + osIntercept2;
        else
            oppAccuracyOS = (osGrad1 * oppMeanAccuracy) + osIntercept1;

        // Passing DS
        differenceValue = oppMeanPassing - ((teamMeanSpeed + teamMeanAgility) / 2.0f);
        if (differenceValue > dsL3)
            oppPassingDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            oppPassingDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            oppPassingDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Dribbling DS
        differenceValue = oppMeanDribbling - ((teamMeanAggression + teamMeanAgility) / 2.0f);
        if (differenceValue > dsL3)
            oppDribblingDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            oppDribblingDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            oppDribblingDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Agility DS
        differenceValue = oppMeanAgility - teamMeanAgility;
        if (differenceValue > dsL3)
            oppAgilityDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            oppAgilityDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            oppAgilityDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Jumping DS
        differenceValue = oppMeanJumping - teamMeanJumping;
        if (differenceValue > dsL3)
            oppJumpingDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            oppJumpingDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            oppJumpingDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Positioning DS
        differenceValue = oppMeanPositioning - teamMeanPositioning;
        if (differenceValue > dsL3)
            oppPositioningDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            oppPositioningDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            oppPositioningDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Speed DS
        differenceValue = oppMeanSpeed - teamMeanSpeed;
        if (differenceValue > dsL3)
            oppSpeedDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            oppSpeedDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            oppSpeedDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Strength DS
        differenceValue = oppMeanStrength - teamMeanStrength;
        if (differenceValue > dsL3)
            oppStrengthDS = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            oppStrengthDS = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            oppStrengthDS = (dsGrad1 * differenceValue) + dsIntercept1;

        // Penalty Chance
        oppPenaltyChanceScale = (pcsGrad1 * (oppMeanAggression + 99.0f - oppMeanPositioning)) + pcsIntercept1;
    }

    private void CalcTeamGoalChanceAddition()
    {
        float differenceValue = ((teamMeanSpeed + teamMeanStrength) / 2.0f) - ((oppMeanSpeed + oppMeanAgility + oppMeanJumping + oppMeanTiming) / 4.0f);
        float goalStatComp;

        if (differenceValue > dsL3)
            goalStatComp = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            goalStatComp = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            goalStatComp = (dsGrad1 * differenceValue) + dsIntercept1;

        teamGoalChanceAddition = goalAddition + (teamAccuracyOS * goalScale) + (goalStatComp * goalScale);
    }

    private void CalcOppGoalChanceAddition()
    {
        float differenceValue = ((oppMeanSpeed + oppMeanStrength) / 2.0f) - ((teamMeanSpeed + teamMeanAgility + teamMeanJumping + teamMeanTiming) / 4.0f);
        float goalStatComp;

        if (differenceValue > dsL3)
            goalStatComp = (dsGrad3 * differenceValue) + dsIntercept3;
        else if (differenceValue > dsL2)
            goalStatComp = (dsGrad2 * differenceValue) + dsIntercept2;
        else
            goalStatComp = (dsGrad1 * differenceValue) + dsIntercept1;

        oppGoalChanceAddition = goalAddition + (oppAccuracyOS * goalScale) + (goalStatComp * goalScale);
    }

    private void OpponentScore(bool goalSuccess)
    {
        if (goalSuccess)
        {
            opponentScore++;
            goalDifference = opponentScore - teamScore;
            teamTimerCountdown = tmT3;
            teamTimerActive = true;
        }
        ballPosition = 3;
        playingMatch = true;
    }

    public void TeamScore(bool goalSuccess)
    {
        if (goalSuccess)
        {
            teamGoalsScored++;
            teamScore++;
            goalDifference = opponentScore - teamScore;
            oppTimerCountdown = tmT3;
            oppTimerActive = true;
        }
        ballPosition = 3;
        playingMatch = true;
    }

    public void QTEEnded(bool goalSuccess)
    {
        if (isPlayerHome)
            TeamScore(goalSuccess);
        else
            OpponentScore(goalSuccess);
    }

    private float CalculateTimerMult(float inverseTimerCountdown)
    {
        float timerMultiplier;

        if (inverseTimerCountdown > tmT2)
            timerMultiplier = (tmGrad2 * inverseTimerCountdown) + tmIntercept2;
        else
            timerMultiplier = (tmGrad1 * inverseTimerCountdown) + tmIntercept1;

        return timerMultiplier;
    }

    private float CalcPenaltyTimerMult(float timerCountdown)
    {
        float timerMultiplier;

        if (timerCountdown < ptmT2)
            timerMultiplier = (ptmGrad1 * timerCountdown) + ptmIntercept1;
        else if (timerCountdown < ptmT3)
            timerMultiplier = (ptmGrad2 * timerCountdown) + ptmIntercept2;
        else
            timerMultiplier = penaltyTimerMult3;

        return timerMultiplier;
    }

    private void OpponentChanceToScore(bool penalty)
    {
        oppGoalOpps++;

        if (isPlayerMatch && !isPlayerHome && !skipPlayerMatch)
        {
            playingMatch = false;
            playerScoreOpp = true;
            btnm.DisplayQTE(penalty);
        }
        else
        {
            float goalProbability = oppGoalChanceAddition + (CalcOppOverallInfluencer() * goalScale);

            if (Random.Range(0.0f, 100.0f) < goalProbability)
                OpponentScore(true);
            else
                ballPosition = 3;
        }
    }

    private void TeamChanceToScore(bool penalty)
    {
        teamGoalOpps++;

        if (isPlayerMatch && isPlayerHome && !skipPlayerMatch)
        {
            playingMatch = false;
            playerScoreOpp = true;
            btnm.DisplayQTE(penalty);
        }
        else
        {
            float goalProbability = teamGoalChanceAddition + (CalcTeamOverallInfluencer() * goalScale);

            if (Random.Range(0.0f, 100.0f) < goalProbability)
                TeamScore(true);
            else
                ballPosition = 3;
        }
    }

    public void StartSetup()
    {
        player = this.gameObject.GetComponent<MainPlayer>();     // Get player
    }

    public int GetBallPosition()
    {
        return ballPosition;
    }

    public float GetMatchTime()
    {
        return matchTime;
    }

    public void SetMatchTimeSpeed(int amount)
    {
        matchTimeMultiplier = amount;
    }

    public bool GetMatchOnGoing()
    {
        return playingMatch;
    }

    public int GetTeamScore()
    {
        return teamScore;
    }

    public int GetOpponentScore()
    {
        return opponentScore;
    }

    public Goalie GetOppGoalie()
    {
        return oppGoalie;
    }
}
