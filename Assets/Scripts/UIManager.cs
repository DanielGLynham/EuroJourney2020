using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Attributes
    private int minValue = 0, maxValue = 100;
    public Text date, playerMoney, nextTournement;

    public Text popUpTitle, popUpDescription, popUpOpOne, popUpOpTwo, popUpOpThree;
    public Slider stamina, speed, agility, strength, jumpingSkill;
    public Text staminaCost, speedCost, agilityCost, strengthCost, jumpingSkillCost;
    public Slider accuracy, timing, freekicks, passing, dribbling;
    public Text accuracyCost, timingCost, freekicksCost, passingCost, dribblingCost;
    public Slider aggression, motivation, positioning, teaching, confidence;
    public Text aggressionCost, motivationCost, positioningCost, teachingCost, confidenceCost;
    public Text staminaTxt, speedTxt, agilityTxt, strengthTxt, jumpingSkillTxt;
    public Text accuracyTxt, timingTxt, freekicksTxt, passingTxt, dribblingTxt;
    public Text aggressionTxt, motivationTxt, positioningTxt, teachingTxt, confidenceTxt;
    public Text displayTeamsTxt;
    public GameObject lamp;
    //public Text 

    public Text newspaperTitle, newspaperDescription;

    // Match Stats
    public Text goalsScored, goalOpps, goalPercentage, matchesWon, matchesDrawn,
                matchesPlayed, matchWinPercentage, matchDrawPercentage, ballPosPercentage;
    //Match players and teams
    public Text team1,teamStatsteam1, player1Team1, player2Team1, player3Team1, player4Team1, player5Team1, player6Team1, player7Team1, player8Team1, player9Team1, player10Team1, player11Team1,
                team2, teamStatsteam2, player1Team2, player2Team2, player3Team2, player4Team2, player5Team2, player6Team2, player7Team2, player8Team2, player9Team2, player10Team2, player11Team2;

    public Text team1Stat0, team1Stat1, team1Stat2, team1Stat3, team1Stat4, team1Stat5, team1Stat6, team1Stat7, team1Stat8, team1Stat9, team1Stat10, team1Stat11, team1Stat12, team1Stat14,
                team2Stat0, team2Stat1, team2Stat2, team2Stat3, team2Stat4, team2Stat5, team2Stat6, team2Stat7, team2Stat8, team2Stat9, team2Stat10, team2Stat11, team2Stat12, team2Stat14;

    private int team1OverallStat0, team1OverallStat1, team1OverallStat2, team1OverallStat3, team1OverallStat4, team1OverallStat5, team1OverallStat6, team1OverallStat7, team1OverallStat8, team1OverallStat9, team1OverallStat10, team1OverallStat11, team1OverallStat12, team1OverallStat14,
                team2OverallStat0, team2OverallStat1, team2OverallStat2, team2OverallStat3, team2OverallStat4, team2OverallStat5, team2OverallStat6, team2OverallStat7, team2OverallStat8, team2OverallStat9, team2OverallStat10, team2OverallStat11, team2OverallStat12, team2OverallStat14;

    public Text afterGameStat0, afterGameStat1, afterGameStat2, afterGameStat3;

    public Text afterGameTeam1, afterGameTeam1Stat0, afterGameTeam1Stat1, afterGameTeam1Stat2, afterGameTeam1Stat3, afterGameTeam2, afterGameTeam2Stat0, afterGameTeam2Stat1, afterGameTeam2Stat2, afterGameTeam2Stat3;

    public Text sportyParent, nonSportyParent, partner, fans, team, coach, manager, agent, rival, pet;
    public Image sportyParentImg, nonSportyParentImg, partnerImg, fansImg, teamImg, coachImg, managerImg, agentImg, rivalImg, petImg;
    public Text relationshipName;
    public Slider RelationshipLeftRightSlider;
    readonly private Image[] relationshipImgs = new Image[10];
    public InputField inputField;

    //Match
    public GameObject qteArrow, qteShrinkSphere;
    public Text matchTimer;
    public Slider arrowSlider, qteUpDown, qteLeftRight, ballPossessionSlider;
 
    public Light directionalLight;
    private bool lightModeActive;
    public Text Score, tutScoreText;

    private Match currentTourn;
    private StoryManager sm;
    private LeagueManager lm;
    private BTNManager btnm;
    private MainPlayer player;
    private GameManager gm;
    private MinigameManager mm;
    private PlayerMatchesManager pmm;
    float x = 0, b = 1;
    private Vector3 shrinkSphereStartScale;

    private bool qteArrowRotateActive = false, qteArrowPowerActive, qteUpDownActive, qteLeftRightActive, qteShrinkActive;
    private bool setGoalieActive = true;

    //public Text matchWinners;
    public GameObject displayTournsParent, DisplayTournPrefab;
    public GameObject displaySchoolPrefab, displaySchoolParent;
    private List<GameObject> displayedTournsList = new List<GameObject>();
    private List<GameObject> displayedSchoolsList = new List<GameObject>();
    public Text tutDate, tutNT, tutPM;
    public Text tutorialOffText, soundsOffText;
    public GameObject fireplace;
    public Text whoWOnText;
    public GameObject whoWon;

    public Text playerMoneySkillsPage;

    public GameObject roomClouds, mmClouds;

    private void Start()
    {
        sm = this.gameObject.GetComponent<StoryManager>();
        btnm = this.gameObject.GetComponent<BTNManager>();
        player = this.gameObject.GetComponent<MainPlayer>();
        gm = this.gameObject.GetComponent<GameManager>();
        mm = this.gameObject.GetComponent<MinigameManager>();
        pmm = this.gameObject.GetComponent<PlayerMatchesManager>();
        lm = this.gameObject.GetComponent<LeagueManager>();

        lightModeActive = true;
        arrowSlider.maxValue = maxValue;
        arrowSlider.minValue = minValue;
        qteUpDown.maxValue = maxValue;
        qteUpDown.minValue = minValue;
        qteUpDown.value = qteUpDown.maxValue / 2;
        RelationshipLeftRightSlider.maxValue = maxValue;
        RelationshipLeftRightSlider.minValue = minValue;
        qteLeftRight.maxValue = maxValue;
        qteLeftRight.minValue = minValue;
        qteLeftRight.value = qteLeftRight.maxValue / 2;
        shrinkSphereStartScale = qteShrinkSphere.transform.localScale;

        relationshipImgs[0] = sportyParentImg;
        relationshipImgs[1] = nonSportyParentImg;
        relationshipImgs[2] = partnerImg;
        relationshipImgs[3] = fansImg;
        relationshipImgs[4] = teamImg;
        relationshipImgs[5] = coachImg;
        relationshipImgs[6] = managerImg;
        relationshipImgs[7] = agentImg;
        relationshipImgs[8] = rivalImg;
        relationshipImgs[9] = petImg;

        stamina.maxValue = maxValue;
        stamina.minValue = minValue;
        speed.maxValue = maxValue;
        speed.minValue = minValue;
        agility.maxValue = maxValue;
        agility.minValue = minValue;
        strength.maxValue = maxValue;
        strength.minValue = minValue;
        jumpingSkill.maxValue = maxValue;
        jumpingSkill.minValue = minValue;
        accuracy.maxValue = maxValue;
        accuracy.minValue = minValue;
        timing.maxValue = maxValue;
        timing.minValue = minValue;
        freekicks.maxValue = maxValue;
        freekicks.minValue = minValue;
        passing.maxValue = maxValue;
        passing.minValue = minValue;
        dribbling.maxValue = maxValue;
        dribbling.minValue = minValue;
        aggression.maxValue = maxValue;
        aggression.minValue = minValue;
        motivation.maxValue = maxValue;
        motivation.minValue = minValue;
        positioning.maxValue = maxValue;
        positioning.minValue = minValue;
        teaching.maxValue = maxValue;
        teaching.minValue = minValue;
        confidence.maxValue = maxValue;
        confidence.minValue = minValue;
        UpdateAll();
    }

    public void Update()
    {
        if (gm.GetMatchOnGoing())
        {
            float matchTime = gm.GetMatchTime();
            matchTime -= matchTime % 1.0f;
            matchTimer.text = "" + matchTime;

            ballPossessionSlider.value = gm.GetBallPosition();

            Score.text = "" + currentTourn.GetHomeTeam().GetTeamAbbreviation() + " " + gm.GetTeamScore() + " - " + gm.GetOpponentScore() + " " + currentTourn.GetAwayTeam().GetTeamAbbreviation();
            if (sm.GetNeedsTutorial())
                tutScoreText.text = Score.text;
        }


        if(qteArrowRotateActive)
        {
            if (setGoalieActive)
            {
                mm.ActivateGoalie();
                setGoalieActive = false;
            }
            int speed = 50;
            x += b * Time.deltaTime * speed;
            qteArrow.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, x)), 1);
            if (qteArrow.transform.rotation.z <= Mathf.Deg2Rad * -15)
            {
                b = 1;
            }
            else if (qteArrow.transform.rotation.z >= Mathf.Deg2Rad * 15)
            {
                b = -1;
            }
            if (Input.GetMouseButtonDown(0)) // right click for now
            {
                qteArrowRotateActive = false;
                qteArrowPowerActive = true;
                x = 0;
                b = 1;
                mm.SetXZAngle(-qteArrow.transform.rotation.z / Mathf.Deg2Rad);
                btnm.DisplayQTEDirectionArrow();
                btnm.IncTutorialSpecial(0);
                btnm.PlaySound(1);
            }
        }
        else if(qteArrowPowerActive)
        {
            int speed = 80;
            x += b * Time.deltaTime * speed;
            arrowSlider.value = x;

            if(arrowSlider.value == arrowSlider.maxValue)
            {
                b = -1;
            }
            else if(arrowSlider.value == arrowSlider.minValue)
            {
                b = 1;
            }
            if (Input.GetMouseButtonDown(0)) // right click for now
            {
                qteArrowPowerActive = false;
                qteUpDownActive = true;
                x = qteUpDown.maxValue / 2;
                b = 1;
                mm.SetSpeed(arrowSlider.value);
                btnm.DisplayQTEUDLR();
                btnm.IncTutorialSpecial(0);
                btnm.PlaySound(1);
            }

        }
        else if (qteUpDownActive)
        {
            int speed = 120;
            x += b * Time.deltaTime * speed;
            qteUpDown.value = x;

            if (qteUpDown.value == qteUpDown.maxValue)
            {
                b = -1;
            }
            else if (qteUpDown.value == qteUpDown.minValue)
            {
                b = 1;
            }
            if (Input.GetMouseButtonDown(0)) // right click for now
            {
                qteUpDownActive = false;
                qteLeftRightActive = true;
                x = qteLeftRight.maxValue / 2;
                mm.SetPY(qteUpDown.value);
                btnm.IncTutorialSpecial(0);
                btnm.PlaySound(1);
            }
        }
        else if(qteLeftRightActive)
        {
            int speed = 120;
            x += b * Time.deltaTime * speed;
            qteLeftRight.value = x;

            if (qteLeftRight.value == qteLeftRight.maxValue)
            {
                b = -1;
            }
            else if (qteLeftRight.value == qteLeftRight.minValue)
            {
                b = 1;
            }
            if (Input.GetMouseButtonDown(0)) // right click for now
            {
                qteLeftRightActive = false;
                qteShrinkActive = true;
                x = 0;
                b = 1;
                mm.SetPX(qteLeftRight.value);
                btnm.DisplayAccuracy();
                btnm.IncTutorialSpecial(0);
                btnm.PlaySound(1);
            }
        }
        else if(qteShrinkActive)
        {
            const float maxScale = 125;
            const float minScale = 30;
            x += b * Time.deltaTime * 15;
            qteShrinkSphere.transform.localScale = new Vector3(qteShrinkSphere.transform.localScale.x + x, qteShrinkSphere.transform.localScale.y + x, qteShrinkSphere.transform.localScale.z + x);
            if (qteShrinkSphere.transform.localScale.x > maxScale)
            {
                b = -1;
                x = 0;
            }
            else if (qteShrinkSphere.transform.localScale.x < minScale)
            {
                b = 1;
                x = 0;
            }

                if (Input.GetMouseButtonDown(0)) 
            {
                btnm.DisplayBallMove();

                mm.BeginMoveBall();

                ResetQTE();
                btnm.IncTutorialSpecial(0);
                btnm.PlaySound(1);
            }
        }
    }

    public void ResetQTE()
    {
        btnm.HideScorePopUp();
        setGoalieActive = true;
        qteArrowRotateActive = false;
        qteArrowPowerActive = false;
        qteUpDownActive = false;
        qteLeftRightActive = false;
        qteShrinkActive = false;
        qteArrow.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), 1);
        arrowSlider.value = 0;
        qteUpDown.value = qteUpDown.maxValue / 2;
        qteLeftRight.value = qteLeftRight.maxValue / 2;
        qteShrinkSphere.transform.localScale = shrinkSphereStartScale;
        x = 0;
        b = 1;
    }

    public void UpdateAll()
    {
        date.text = sm.GetDate();
        if(sm.GetAllTournements().Count != 0)
            nextTournement.text = sm.GetTournement(0).GetDate();
        playerMoney.text = "" + player.GetMoney(); 
        if(sm.GetNeedsTutorial())
        {
            tutDate.text = date.text;
            tutNT.text = nextTournement.text;
            tutPM.text = playerMoney.text;
        }
        UpdateOptions();
    }
    public void UpdateMoneyOnSkillsPage()
    {
        playerMoneySkillsPage.text = "" + player.GetMoney();
    }
    public void DisplayTask(Task currentTask)
    {
        // display info
        // display enough buttons for options
        btnm.DisplayTask(currentTask.GetOpAmount(), currentTask.GetIsNewspaper());
        if(!currentTask.GetIsNewspaper())
        {
            popUpDescription.text = currentTask.GetBrief();
            popUpTitle.text = currentTask.GetTitle();
            popUpOpOne.text = currentTask.GetOpOne();
            popUpOpTwo.text = currentTask.GetOpTwo();
            popUpOpThree.text = currentTask.GetOpThree();
        }
        else
        {
            newspaperDescription.text = currentTask.GetNewspaperBrief();
            newspaperTitle.text = currentTask.GetNewspaperTitle();
        }
    } 
    public void DisplayPreGameMenuPlayerNames( Team at, Team ht)
    {

        team1.text = "" + ht.GetTeamName();
        player1Team1.text = "" + ht.GetPlayer(0).GetName();
        player2Team1.text = "" + ht.GetPlayer(1).GetName();
        player3Team1.text = "" + ht.GetPlayer(2).GetName();
        player4Team1.text = "" + ht.GetPlayer(3).GetName();
        player5Team1.text = "" + ht.GetPlayer(4).GetName();
        player6Team1.text = "" + ht.GetPlayer(5).GetName();
        player7Team1.text = "" + ht.GetPlayer(6).GetName();
        player8Team1.text = "" + ht.GetPlayer(7).GetName();
        player9Team1.text = "" + ht.GetPlayer(8).GetName();
        player10Team1.text = "" + ht.GetPlayer(9).GetName();
        player11Team1.text = "" + ht.GetPlayer(10).GetName();

        team2.text = "" + at.GetTeamName();
        player1Team2.text = "" + at.GetPlayer(0).GetName();
        player2Team2.text = "" + at.GetPlayer(1).GetName();
        player3Team2.text = "" + at.GetPlayer(2).GetName();
        player4Team2.text = "" + at.GetPlayer(3).GetName();
        player5Team2.text = "" + at.GetPlayer(4).GetName();
        player6Team2.text = "" + at.GetPlayer(5).GetName();
        player7Team2.text = "" + at.GetPlayer(6).GetName();
        player8Team2.text = "" + at.GetPlayer(7).GetName();
        player9Team2.text = "" + at.GetPlayer(8).GetName();
        player10Team2.text = "" + at.GetPlayer(9).GetName();
        player11Team2.text = "" + at.GetPlayer(10).GetName();

         // Move into button manager
    }
    public void DisplayPreGameMenuTeamStats(Team at, Team ht)
    {
        for (int i = 0; i < 11; i++)
        {           
                team1OverallStat0 += ht.GetPlayer(i).GetStatLevel(0);
                team1OverallStat1 += ht.GetPlayer(i).GetStatLevel(1);
                team1OverallStat2 += ht.GetPlayer(i).GetStatLevel(2);
                team1OverallStat3 += ht.GetPlayer(i).GetStatLevel(3);
                team1OverallStat4 += ht.GetPlayer(i).GetStatLevel(4);
                team1OverallStat5 += ht.GetPlayer(i).GetStatLevel(5);
                team1OverallStat6 += ht.GetPlayer(i).GetStatLevel(6);
                team1OverallStat7 += ht.GetPlayer(i).GetStatLevel(7);
                team1OverallStat8 += ht.GetPlayer(i).GetStatLevel(8);
                team1OverallStat9 += ht.GetPlayer(i).GetStatLevel(9);
                team1OverallStat10 += ht.GetPlayer(i).GetStatLevel(10);
                team1OverallStat11 += ht.GetPlayer(i).GetStatLevel(11);
                team1OverallStat12 += ht.GetPlayer(i).GetStatLevel(12);
                team1OverallStat14 += ht.GetPlayer(i).GetStatLevel(14);          
            
        }
        for (int i = 0; i < 11; i++)
        {    
                team2OverallStat0 += at.GetPlayer(i).GetStatLevel(0);
                team2OverallStat1 += at.GetPlayer(i).GetStatLevel(1);
                team2OverallStat2 += at.GetPlayer(i).GetStatLevel(2);
                team2OverallStat3 += at.GetPlayer(i).GetStatLevel(3);
                team2OverallStat4 += at.GetPlayer(i).GetStatLevel(4);
                team2OverallStat5 += at.GetPlayer(i).GetStatLevel(5);
                team2OverallStat6 += at.GetPlayer(i).GetStatLevel(6);
                team2OverallStat7 += at.GetPlayer(i).GetStatLevel(7);
                team2OverallStat8 += at.GetPlayer(i).GetStatLevel(8);
                team2OverallStat9 += at.GetPlayer(i).GetStatLevel(9);
                team2OverallStat10 += at.GetPlayer(i).GetStatLevel(10);
                team2OverallStat11 += at.GetPlayer(i).GetStatLevel(11);
                team2OverallStat12 += at.GetPlayer(i).GetStatLevel(12);
                team2OverallStat14 += at.GetPlayer(i).GetStatLevel(14);            
        }
        
        teamStatsteam1.text = "" + ht.GetTeamName();
        team1Stat0.text = "" + (team1OverallStat0 / 11);
        team1Stat1.text = "" + (team1OverallStat1 / 11);
        team1Stat2.text = "" + (team1OverallStat2 / 11);
        team1Stat3.text = "" + (team1OverallStat3 / 11);
        team1Stat4.text = "" + (team1OverallStat4 / 11);
        team1Stat5.text = "" + (team1OverallStat5 / 11);
        team1Stat6.text = "" + (team1OverallStat6 / 11);
        team1Stat7.text = "" + (team1OverallStat7 / 11);
        team1Stat8.text = "" + (team1OverallStat8 / 11);
        team1Stat9.text = "" + (team1OverallStat9 / 11);
        team1Stat10.text = "" + (team1OverallStat10 / 11);
        team1Stat11.text = "" + (team1OverallStat11 / 11);
        team1Stat12.text = "" + (team1OverallStat12 / 11);
        team1Stat14.text = "" + (team1OverallStat14 / 11);

        teamStatsteam2.text = "" + at.GetTeamName();
        team2Stat0.text = "" + (team2OverallStat0 / 11);
        team2Stat1.text = "" + (team2OverallStat1 / 11);
        team2Stat2.text = "" + (team2OverallStat2 / 11);
        team2Stat3.text = "" + (team2OverallStat3 / 11);
        team2Stat4.text = "" + (team2OverallStat4 / 11);
        team2Stat5.text = "" + (team2OverallStat5 / 11);
        team2Stat6.text = "" + (team2OverallStat6 / 11);
        team2Stat7.text = "" + (team2OverallStat7 / 11);
        team2Stat8.text = "" + (team2OverallStat8 / 11);
        team2Stat9.text = "" + (team2OverallStat9 / 11);
        team2Stat10.text = "" + (team2OverallStat10 / 11);
        team2Stat11.text = "" + (team2OverallStat11 / 11);
        team2Stat12.text = "" + (team2OverallStat12 / 11);
        team2Stat14.text = "" + (team2OverallStat14 / 11);

        team1OverallStat0 = 0; team1OverallStat1 = 0; team1OverallStat2 = 0; team1OverallStat3 = 0; team1OverallStat4 = 0; team1OverallStat5 = 0; team1OverallStat6 = 0;
        team1OverallStat7 = 0; team1OverallStat8 = 0; team1OverallStat9 = 0; team1OverallStat10 = 0; team1OverallStat11 = 0; team1OverallStat12 = 0; team1OverallStat14 = 0;

        team2OverallStat0 = 0; team2OverallStat1 = 0; team2OverallStat2 = 0; team2OverallStat3 = 0; team2OverallStat4 = 0; team2OverallStat5 = 0; team2OverallStat6 = 0;
        team2OverallStat7 = 0; team2OverallStat8 = 0; team2OverallStat9 = 0; team2OverallStat10 = 0; team2OverallStat11 = 0; team2OverallStat12 = 0; team2OverallStat14 = 0;

    }
    public void DisplayAfterGameStats(bool isPlayerHome, string t1name, string t2name, int homeTeamGoals, int awayTeamGoals, int homeTeamChances, int awayTeamChances, int homePenaltyChances, int awayPenaltyChances, float homeTeamPossesion, float awayTeamPossesion)
    {
        if (homeTeamPossesion % 1.0f < 0.5f)
        {
            homeTeamPossesion -= homeTeamPossesion % 1.0f;
            awayTeamPossesion = 100.0f - homeTeamPossesion;
        }
        else
        {
            awayTeamPossesion -= awayTeamPossesion % 1.0f;
            homeTeamPossesion = 100.0f - awayTeamPossesion;
        }

        btnm.DisplayAfterGameMenu();
        //int pTeamPossesionInt, oppTeamPossessionInt;
        afterGameStat0.text = "Goals";
        afterGameStat1.text = "Shots at goal";
        afterGameStat2.text = "Penalty Kicks";
        afterGameStat3.text = "Possesion (%)";
        if (isPlayerHome)
        {
            afterGameTeam1.text = t1name;
            afterGameTeam1Stat0.text = "" + homeTeamGoals;
            afterGameTeam1Stat1.text = "" + homeTeamChances;
            afterGameTeam1Stat2.text = "" + homePenaltyChances;
            afterGameTeam1Stat3.text = "" + (homeTeamPossesion - (homeTeamPossesion % 1));

            afterGameTeam2.text = t2name;
            afterGameTeam2Stat0.text = "" + awayTeamGoals;
            afterGameTeam2Stat1.text = "" + awayTeamChances;
            afterGameTeam2Stat2.text = "" + awayPenaltyChances;
            afterGameTeam2Stat3.text = "" + (awayTeamPossesion - (awayTeamPossesion % 1));

            //sm.SetNewspaper(t1name, t2name, pTeamGoals, pTeamGoals, oppTeamGoals);
        }
        else
        {
            afterGameTeam1.text = t2name;
            afterGameTeam1Stat0.text = "" + awayTeamGoals;
            afterGameTeam1Stat1.text = "" + awayTeamChances;
            afterGameTeam1Stat2.text = "" + awayPenaltyChances;
            afterGameTeam1Stat3.text = "" + (awayTeamPossesion - (awayTeamPossesion % 1));

            afterGameTeam2.text = t1name;
            afterGameTeam2Stat0.text = "" + homeTeamGoals;
            afterGameTeam2Stat1.text = "" + homeTeamChances;
            afterGameTeam2Stat2.text = "" + homePenaltyChances;
            afterGameTeam2Stat3.text = "" + (homeTeamPossesion - (homeTeamPossesion % 1));

            //sm.SetNewspaper(t2name, t1name, pTeamGoals, pTeamGoals, oppTeamGoals);
        }
        
        
    }
    public void DisplayPhysicalSkills()
    {
        stamina.value = player.GetStat(0);
        staminaCost.text = "" + player.GetStatCost(0);
        speed.value = player.GetStat(1);
        speedCost.text = "" + player.GetStatCost(1);
        agility.value = player.GetStat(2);
        agilityCost.text = "" + player.GetStatCost(2);
        strength.value = player.GetStat(3);
        strengthCost.text = "" + player.GetStatCost(3);
        jumpingSkill.value = player.GetStat(4);
        jumpingSkillCost.text = "" + player.GetStatCost(4);

        staminaTxt.text = "Level: " + player.GetStatLevel(0);
        speedTxt.text = "Level: " + player.GetStatLevel(1);
        agilityTxt.text = "Level: " + player.GetStatLevel(2);
        strengthTxt.text = "Level: " + player.GetStatLevel(3);
        jumpingSkillTxt.text = "Level: " + player.GetStatLevel(4);
    }
    public void DisplaySkillSkills()
    {
        accuracy.value = player.GetStat(5);
        accuracyCost.text = "" + player.GetStatCost(5);
        timing.value = player.GetStat(6);
        timingCost.text = "" + player.GetStatCost(6);
        freekicks.value = player.GetStat(7);
        freekicksCost.text = "" + player.GetStatCost(7);
        passing.value = player.GetStat(8);
        passingCost.text = "" + player.GetStatCost(8);
        dribbling.value = player.GetStat(9);
        dribblingCost.text = "" + player.GetStatCost(9);

        accuracyTxt.text = "Level: " + player.GetStatLevel(5);
        timingTxt.text = "Level: " + player.GetStatLevel(6);
        freekicksTxt.text = "Level: " + player.GetStatLevel(7);
        passingTxt.text = "Level: " + player.GetStatLevel(8);
        dribblingTxt.text = "Level: " + player.GetStatLevel(9);
    }
    public void DisplayMentalSkills()
    {
        aggression.value = player.GetStat(10);
        aggressionCost.text = "" + player.GetStatCost(10);
        motivation.value = player.GetStat(11);
        motivationCost.text = "" + player.GetStatCost(11);
        positioning.value = player.GetStat(12);
        positioningCost.text = "" + player.GetStatCost(12);
        teaching.value = player.GetStat(13);
        teachingCost.text = "" + player.GetStatCost(13);
        confidence.value = player.GetStat(14);
        confidenceCost.text = "" + player.GetStatCost(14);

        aggressionTxt.text = "Level: " + player.GetStatLevel(10);
        motivationTxt.text = "Level: " + player.GetStatLevel(11);
        positioningTxt.text = "Level: " + player.GetStatLevel(12);
        teachingTxt.text = "Level: " + player.GetStatLevel(13);
        confidenceTxt.text = "Level: " + player.GetStatLevel(14);
    }
    public void DisplayInterTournement()
    {
        for (int j = 0; j < displayedTournsList.Count; j++)
            displayedTournsList[j].gameObject.SetActive(false);

        for (int i = 0; i < sm.GetAllTournements().Count; i++)
        {
            if ((i < 21 && i >= displayedTournsList.Count) || (i == 0 && displayedTournsList.Count == 0))
            {
                int x = -50;
                int y = -30;
                GameObject temp = DisplayTournPrefab;

                displayedTournsList.Add(temp);
                displayedTournsList[i].gameObject.SetActive(true);
                displayedTournsList[i] = Instantiate(temp, displayTournsParent.transform, false);
                displayedTournsList[i].transform.localPosition = new Vector3(0,  (y * i) + x, 0);
                displayedTournsList[i].transform.Find("Date").GetComponent<Text>().text = "" + sm.GetAllTournements()[i].GetDate();
                if (sm.GetAllTournements()[i].GetHomeTeam().GetTeamName() == player.GetTeam().GetTeamName())
                {
                    displayedTournsList[i].transform.Find("HomeOrAway").GetComponent<Text>().text = "Home";
                    displayedTournsList[i].transform.Find("Against").GetComponent<Text>().text = "" + sm.GetAllTournements()[i].GetAwayTeam().GetTeamName();
                }
                else
                {
                    displayedTournsList[i].transform.Find("HomeOrAway").GetComponent<Text>().text = "Away";
                    displayedTournsList[i].transform.Find("Against").GetComponent<Text>().text = "" + sm.GetAllTournements()[i].GetHomeTeam().GetTeamName();
                }
                //displayedTournsList[i].transform.Find("Against").GetComponent<Text>().text = "" + sm.GetAllTournements()[i].GetAwayTeam().GetTeamName();


            }
            else if (i < 21 && i < displayedTournsList.Count)
            {
                displayedTournsList[i].gameObject.SetActive(true);
                displayedTournsList[i].transform.Find("Date").GetComponent<Text>().text = "" + sm.GetAllTournements()[i].GetDate();
                if (sm.GetAllTournements()[i].GetHomeTeam().GetTeamName() == player.GetTeam().GetTeamName())
                {
                    displayedTournsList[i].transform.Find("HomeOrAway").GetComponent<Text>().text = "Home";
                    displayedTournsList[i].transform.Find("Against").GetComponent<Text>().text = "" + sm.GetAllTournements()[i].GetAwayTeam().GetTeamName();
                }
                else
                {
                    displayedTournsList[i].transform.Find("HomeOrAway").GetComponent<Text>().text = "Away";
                    displayedTournsList[i].transform.Find("Against").GetComponent<Text>().text = "" + sm.GetAllTournements()[i].GetHomeTeam().GetTeamName();
                }
            }
        }
    }
    public void DisplayDomTournement()
    {

    }
    public void DisplayLeagueStats()
    {
        lm.SortSchoolWinner();
        for (int i = 0; i < lm.GetSchoolTeams().Count; i++)
        {
            if ((i < 21 && i >= displayedSchoolsList.Count) || (i == 0 && displayedSchoolsList.Count == 0))
            {
                int x = 20;
                int y = -20;
                GameObject temp = displaySchoolPrefab;

                displayedSchoolsList.Add(temp);
                displayedSchoolsList[i] = Instantiate(temp, displaySchoolParent.transform, false);
                displayedSchoolsList[i].transform.localPosition = new Vector3(0, (y * i) + x, 0);

                displayedSchoolsList[i].transform.Find("Text").GetComponent<Text>().text = "" + lm.GetSchoolTeams()[i].GetTeamName();
                displayedSchoolsList[i].transform.Find("Points").GetComponent<Text>().text = "" + lm.GetSchoolTeams()[i].GetSchoolScore();
            }
            else if (i < 21 && i < displayedSchoolsList.Count)
            {
                displayedSchoolsList[i].transform.Find("Text").GetComponent<Text>().text = "" + lm.GetSchoolTeams()[i].GetTeamName();
                displayedSchoolsList[i].transform.Find("Points").GetComponent<Text>().text = "" + lm.GetSchoolTeams()[i].GetSchoolScore();
            }
        }
    }
    //public void DisplaySchoolLeague(int matchClicked) // TODO:: Finish this
    //{
    //    for(int i = 0; i < lm.GetSchoolTeams().Count; i++)
    //    {
    //        matchWinners.text += "\n" + lm.GetSchoolTeams()[i].GetTeamName();
    //        for(int x = 0; x < 20 - lm.GetSchoolTeams()[i].GetTeamName().Length; x++)
    //        {
    //            matchWinners.text += " ";
    //        }
    //        matchWinners.text += lm.GetSchoolTeams()[i].GetSchoolScore();
    //    }
    //}
    public void SetUpTeamText(Match t)       
    {
        currentTourn = t;
        //displayTeamsTxt.text = "" + t.GetHomeTeam().GetTeamAbbreviation() + " vs " + t.GetAwayTeam().GetTeamAbbreviation();
    }

    public void DisplayStatistics()
    {
        // Stats: 0 = goalsScored, 1 = goalOpps, 2 = goal%, 3 = matchesWon, 4 = matchesDrawn, 5 = matchesPlayed, 
        //        6 = matchesWon%, 7 = matchesDrawn%, 8 = ballInTeamPos, 9 = ballInOppPos, 10 = ballPossession%
        float goalOpps = player.GetStatistics(1);
        float matchesPlayed = player.GetStatistics(5);

        goalsScored.text = "" + player.GetStatistics(0);
        matchesWon.text = "" + player.GetStatistics(3);
        matchesDrawn.text = "" + player.GetStatistics(4);
        this.goalOpps.text = "" + goalOpps;
        this.matchesPlayed.text = "" + matchesPlayed;

        if (goalOpps == 0.0f)
            goalPercentage.text = "--";
        else
            goalPercentage.text = "" + player.GetStatistics(2) + "%";

        if (matchesPlayed == 0.0f)
        {
            matchWinPercentage.text = "--";
            matchDrawPercentage.text = "--";
            ballPosPercentage.text = "--";
        }
        else
        {
            matchWinPercentage.text = "" + player.GetStatistics(6) + "%";
            matchDrawPercentage.text = "" + player.GetStatistics(7) + "%";
            ballPosPercentage.text = "" + player.GetStatistics(10) + "%";
        }
    }
    public void DisplayRelationships()
    {
        sportyParent.text = "Sporty Parent" ;
        nonSportyParent.text = "Non Sporty Parent";
        partner.text = "Partner";
        fans.text = "Fans";
        team.text = "Team";
        coach.text = "Coach";
        manager.text = "Manager";
        agent.text = "Agent";
        rival.text = "Rival";
        pet.text = "Pet";
        
        for (int i = 0; i < 10; i++)
        {
            int bond = player.GetRelationshipBond(i);
            if(bond > 75)
            {
                // Green
                relationshipImgs[i].color = new Color32(0,200,0,200);
            }
            else if (bond > 26 && bond < 74)
            {
                // Orange 
                relationshipImgs[i].color = new Color32(250, 130, 25, 255);
            }
            else
            {
                // Red
                relationshipImgs[i].color = new Color32(200, 0, 0, 200);
            }
        }
    }
    public void DisplayLeftRightRelationshipSlider(int rn)
    {
        //Debug.Log(rn);
        if (rn == 0 || rn == 1)        
            relationshipName.text = "" + player.GetRelationship(rn).GetTitle();             //Call them mum or dad instead of their first name
       else
            relationshipName.text = "" + player.GetRelationship(rn).GetName();
        
        btnm.DisplayRelationshipGlow(rn);
        if (relationshipName.text == "")
        {
            switch (rn)
            {
                case 0:
                    relationshipName.text = "Sporty Parent";
                    break;
                case 1:
                    relationshipName.text = "Non Sporty Parent";
                    break;
                case 2:
                    relationshipName.text = "Partner";
                    break;
                case 3:
                    relationshipName.text = "Fans";
                    break;
                case 4:
                    relationshipName.text = "Team";
                    break;
                case 5:
                    relationshipName.text = "Coach";
                    break;
                case 6:
                    relationshipName.text = "Manager";
                    break;
                case 7:
                    relationshipName.text = "Agent";
                    break;
                case 8:
                    relationshipName.text = "Rival";
                    break;
                case 9:
                    relationshipName.text = "No pet";
                    break;
            }

        }

        RelationshipLeftRightSlider.value = player.GetRelationshipBond(rn);
        //Debug.Log("Pet name" + player.GetRelationship(9).GetName());
        
    }
    public void ToggleLightMode()
    {
        lightModeActive = !lightModeActive;
        if (lightModeActive)
        {
            fireplace.SetActive(false);
            lamp.SetActive(false);
            roomClouds.SetActive(true);
            mmClouds.SetActive(true);
            directionalLight.color = Color.white;
            directionalLight.transform.rotation = Quaternion.Euler(new Vector3(170,160,0));
        }
        else
        {
            mmClouds.SetActive(false);
            roomClouds.SetActive(false);
            fireplace.SetActive(true);
            lamp.SetActive(true);
            directionalLight.color = Color.black;
            directionalLight.transform.rotation = Quaternion.Euler(new Vector3(-170, 200, 0));
        }
    }
    public void SetQTEStart(bool penalty)
    {
        btnm.DisplayStillBall();
        qteArrowRotateActive = true;
        mm.SetPenalty(penalty);
    }
    public void UpdateOptions()
    {
        if (btnm.GetSoundsOff())
            soundsOffText.text = "Sounds: Off";
        else
            soundsOffText.text = "Sounds: On";
        if (btnm.GetTutorialOff())
            tutorialOffText.text = "Tutorial: Off";
        else
            tutorialOffText.text = "Tutorial: On";

    }
    public IEnumerator ShowWhoWon(string name)
    {
        whoWon.SetActive(true);
        whoWOnText.text = name;
        yield return new WaitForSeconds(3f);
        gm.EndMatch();
        whoWon.SetActive(false);
    }

}
