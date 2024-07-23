using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BTNManager : MonoBehaviour
{
    private bool btnPressed = false;
    // Attributes
    public GameObject room;

    private bool btnShake = false;
    private int btnShakeNo;

    public GameObject matchPage;

    public GameObject personalPage, financesPage;
    public GameObject personalSkillsPage, mentalSkillsPage, skillSkillsPage, inGameShopPage, realMoneyShopPage, relationshipsPage,relationshipPopUpPage, internationalTournementsPage, preGameMenu, playerNamesMenu, teamStatsMenu, afterGameMenu;
    public GameObject personalSkillsPageGlow, mentalSkillsPageGlow, skillSkillsPageGlow;
    public GameObject relationshipGlow0, relationshipGlow1, relationshipGlow2, relationshipGlow3, relationshipGlow4, relationshipGlow5, relationshipGlow6, relationshipGlow7, relationshipGlow8, relationshipGlow9;
    public GameObject domesticTournementsPage, statsPage, taskPopUp, newspaper;

    public GameObject stillBall, movingBall;

    public GameObject laptopFlash;

    public GameObject popUpOptionOne, popUpOptionTwo, popUpOptionThree, popUpOptionFour, popUpOptionFive, popUpOptionSix;
    //public GameObject newspaperTitle, newspaperDescription;

    public GameObject staminaBtn, speedBtn, agilityBtn, strengthBtn, jumpingSkillBtn;
    public Text staminaBtnTxt, speedBtnTxt, agilityBtnTxt, strengthBtnTxt, jumpingSkillBtnTxt;
    
    public GameObject accuracyBtn, timingBtn, freekicksBtn, passingBtn, dribblingBtn;
    public Text accuracyBtnTxt, timingBtnTxt, freekicksBtnTxt, passingBtnTxt, dribblingBtnTxt;

    public GameObject aggressionBtn, motivationBtn, positioningBtn, teachingBtn, confidenceBtn;
    public Text aggressionBtnTxt, motivationBtnTxt, positioningBtnTxt, teachingBtnTxt, confidenceBtnTxt;

    public GameObject inputField, goBackBtn, mainMenu, playerMenu, skillsHeaderBtns;

    public InputField intputFieldFirstName, inputFieldLastName, inputFieldMumsName, inputFieldDadsName;
    public GameObject mumsNameRandBtn, dadsNameRandBtn, playerFirstNameRandBtn, playerLastNameRndBtn;

    public GameObject tripleTask, doubleTask, singleTask;

    private string iFieldText, intputFieldFirstNameText, inputFieldLastNameText, inputFieldMumsNameText, inputFieldDadsNameText;
    public Text intputFieldFirstNamePlaceholder, inputFieldLastNamePlaceholder, inputFieldMumsNamePlaceholder, inputFieldDadsNamePlaceholder, genderBtnText;
    public InputField iFI;

    public GameObject playerNamesBtnGlow, teamStatsBtnGlow;

    public GameObject mainCamera;
    private CameraBehaviour cb;

    //game
    public GameObject match, qte, arrow, updown, shrinkCircle;
    public GameObject ball, ballShadow;
    public float buttonShake = 1.0f;

    private MainPlayer player;
    private AllStory allStory;

    private AudioManager am;
    private StoryManager sm;
    private UIManager ui;
    private Utilities utilities = new Utilities();
    private GameManager gm;
    private MinigameManager mm;
    private PlayerMatchesManager pmm;
    private TeamManager tm;
    private bool gameSetup = false;
    private int phase = 1;

    private bool onMainMenu;
    private bool switchToPractice = false;
    private bool playerCreation = true;

    // tutorial
    public int tutorialStage = 0;
    readonly private int tutorialEnd = 36; // set to the last step
    //public GameObject tutDateNextMatch, tutMatchesListPage, tutSkillsPage, tutStatsPage, tutRelationshipsPage, tutShopPage,
    //    tutQTEAngle, tutQTEPower, tutQTELifeRight, tutQTEUpDown, tutQTEAccuracy, tutQTEAim,
    //    tutMatchTeams, tutMatchBallPos, tutMatchTime, tutMatchSpeed, tutBackBTN,
    //    tutTask, tutMatchesList, tutRelationships, tutShop, tutSkills, tutNextWeek;
    private int tutQTEClicks = 0, tutQTEMaxClick = 6;
    public GameObject tutBed, tutPreMatch, tutPossession, tutTeamScore, tutTimer, tutSpeed, tutAngle, tutPower, tutHighLow, tutCurve, tutAccuracy,
    tutAfterMatch, tutIncome, tutBanner, tutFootball, tutMatchList, tutBackBtn, tutBooks, tutSkillsHeader, tutSkillUpgrade, tutLaptop,
    tutStatsLeague, tutPhone, tutRelationships, tutSportParent, tutPiggyBank, tutShop, tutDilema, tutEnd;

    private bool tutCloseBtnDone = false, tutQTESpeedDone = false, tutLevelUpDone = false;
    // Functions
    public GameObject schoolLeague;

    public GameObject bootsBtn, booksBtn, weightsBtn, ballBtn, bedBtn, phoneBtn, lampBtn, moneyJarBtn, laptopBtn, doorBtn, blindsBtn;

    private bool tutorialOff = false;     // TODO:: Set to false for release!
    private bool soundsOff = false;       // TODO:: Set to false for release!

    public GameObject penaltyTitle;
    public GameObject endOfDemoPage;
    private int matchesplayedCounter = 0;
    private bool tutorialEnded = false;
    public GameObject scorePopUp, simulateBtn;
    private bool pleaseDontGoBack = false;
    private bool canUseBackBtn = true;
    public GameObject newspaperAnimation, newspaperAnimationUnroll;
    public GameObject chooseSportyParentMenu, choiceExplaination, dadChosenTxt, mumChosenTxt;
    private bool parentChosen = false, choiceSubmitted = false, doneSetUp = false;

    private void Start()
    {
        cb = mainCamera.GetComponent<CameraBehaviour>();
        sm = this.gameObject.GetComponent<StoryManager>();
        ui = this.gameObject.GetComponent<UIManager>();
        gm = this.gameObject.GetComponent<GameManager>();
        mm = this.gameObject.GetComponent<MinigameManager>();
        pmm = this.gameObject.GetComponent<PlayerMatchesManager>();
        am = this.gameObject.GetComponent<AudioManager>();
        player = this.gameObject.GetComponent<MainPlayer>();
        tm = this.gameObject.GetComponent<TeamManager>();
        allStory = sm.GetAllStory();
        SetStatsBtnsInactive();
        onMainMenu = true;
    }
    private void Update()
    {
        if (onMainMenu && phase == 6 && !cb.IsAnimateCamera())
        {
            //StartGame();
            if (sm.GetIntDate() == 0 && !choiceSubmitted)
                chooseSportyParentMenu.SetActive(true);
            else if (doneSetUp)
                StartGame();
            // TODO: Use this switch when animation is added to main menu
            //switch (phase)
            //{
            //    // Start Game Menu
            //    case 6:
            //        StartGame();
            //        break;
            //    // Options Menu
            //    case 7:
            //        break;
            //}
        }

        if (switchToPractice && !cb.IsAnimateCamera())
            SwitchToPractice();
    }
    public void SubmitSportyParent()
    {
        // play animation, 
        // at animation end StartGame();
        if(parentChosen && phase == 6)
        {
            choiceSubmitted = true;
            //StartGame();
            chooseSportyParentMenu.SetActive(false);
            choiceExplaination.SetActive(true);
            if(sm.GetSatWithDad())
            {
                dadChosenTxt.SetActive(true);
                mumChosenTxt.SetActive(false);
            }
            else
            {
                mumChosenTxt.SetActive(true);
                dadChosenTxt.SetActive(false);
            }
        }
    }
    public void DisplaySchoolLeagueInOrder()
    {
        phase = 4;
        UISetInactive();
        ShowBackBtn(true);
        schoolLeague.SetActive(true);
        ui.DisplayLeagueStats();
    }
    public void IncTutorial()
    {
        if (sm.GetNeedsTutorial())
        {
            //am.PlaySingle(am.btnPress);
            Tutorial();
            tutorialStage++;
            if (tutorialStage >= tutorialEnd)
            {
                sm.SetNeedsTutorial(false);
                tutorialOff = true;
                tutorialEnded = true;
            }
        }
    }
    public bool GetTutorialEnded()
    {
        return tutorialEnded;
    }
    public void IncTutorialSpecial(int i)
    {
        //am.PlaySingle(am.btnPress);			//Button sound   
        if(sm.GetNeedsTutorial())
        switch (i)
        {
            case 0: // qte
                tutQTEClicks++;
                if (tutQTEClicks < tutQTEMaxClick)
                {
                    IncTutorial();
                }
                break;
            case 1: // close btn
                if (!tutCloseBtnDone && (tutorialStage == 14 || tutorialStage == 17 || tutorialStage == 22 || tutorialStage == 23 || tutorialStage == 24))
                {
                    tutCloseBtnDone = true;
                    IncTutorial();
                }
                break;
            case 2:
                if(!tutQTESpeedDone)
                {
                    tutQTESpeedDone = true;
                    IncTutorial();
                }
                break;
            case 3:
                if (!tutLevelUpDone)
                {
                    tutLevelUpDone = true;
                    IncTutorial();
                }
                break;
        }
    }
    private void Tutorial() //TODO:: activate on character creation
    {
        // 0 sat with you
        //   animation
        // 1 bed
        // 2 pre match
        // 3 possession
        // 4 teams/ score
        // 5 timer
        // 6 speed
        // 7 angle
        // 8  power
        // 9  highlow
        // 10 curve
        // 11 accuracy
        // 12 after match
        // 13 income
        // 14 banner
        // 15 football
        // 16 match list
        // 17 back btn
        // 18 books
        // 19 skills header
        // 20 upgradeskills
        // 21 backbtn
        // 22 laptop
        // 23 stats and league
        // 24 back btn
        // 25 phone
        // 26 relationships
        // 27 back btn
        // 28 sporty relationship
        // 29 backbtn
        // 30 piggybank
        // 31 shop 
        // 32 back btn
        // 33 bed
        // 34 dilema
        // 35 end tutorial
        //TutorialHideRoomBtns(4);
        if (sm.GetNeedsTutorial())
            switch (tutorialStage)
            {
                case 0:
                    TutorialHideRoomBtns(4);
                    tutBed.SetActive(true);
                    break;
                case 1:
                    tutBed.SetActive(false);
                    tutPreMatch.SetActive(true);
                    break;
                case 2:
                    tutPreMatch.SetActive(false);
                    tutPossession.SetActive(true);
                    break;
                case 3:
                    tutPossession.SetActive(false);
                    tutTeamScore.SetActive(true);
                    break;
                case 4:
                    tutTeamScore.SetActive(false);
                    tutTimer.SetActive(true);
                    break;
                case 5:
                    tutTimer.SetActive(false);
                    tutSpeed.SetActive(true);
                    break;
                case 6:
                    tutSpeed.SetActive(false);
                    tutAngle.SetActive(true);
                    break;
                case 7:
                    tutAngle.SetActive(false);
                    tutPower.SetActive(true);
                    break;
                case 8:
                    tutPower.SetActive(false);
                    tutHighLow.SetActive(true);
                    break;
                case 9:
                    tutHighLow.SetActive(false);
                    tutCurve.SetActive(true);
                    break;
                case 10:
                    tutCurve.SetActive(false);
                    tutAccuracy.SetActive(true);
                    break;
                case 11:
                    tutAccuracy.SetActive(false);
                    tutAfterMatch.SetActive(true);
                    break;
                case 12: // 
                    tutAfterMatch.SetActive(false);
                    tutIncome.SetActive(true);
                    break;
                case 13:
                    tutIncome.SetActive(false);
                    TutorialHideRoomBtns(15);
                    tutBanner.SetActive(true);
                    break;
                case 14:
                    tutBanner.SetActive(false);
                    TutorialHideRoomBtns(3);
                    tutFootball.SetActive(true);
                    break;
                case 15:
                    tutFootball.SetActive(false);
                    tutMatchList.SetActive(true);
                    pleaseDontGoBack = true;
                    ShowBackBtn(false);
                    canUseBackBtn = false;
                    break;
                case 16:
                    tutMatchList.SetActive(false);
                    tutBackBtn.SetActive(true);
                    pleaseDontGoBack = false;
                    ShowBackBtn(true);

                    break;
                case 17:
                    tutBackBtn.SetActive(false);
                    canUseBackBtn = true;
                    TutorialHideRoomBtns(1);
                    tutBooks.SetActive(true);
                    break;
                case 18:
                    tutBooks.SetActive(false);
                    pleaseDontGoBack = true;
                    ShowBackBtn(false);
                    canUseBackBtn = false;
                    tutSkillsHeader.SetActive(true);
                    break;
                case 19:
                    tutSkillsHeader.SetActive(false);
                    tutSkillUpgrade.SetActive(true);
                    break;
                case 20:
                    tutSkillUpgrade.SetActive(false);
                    pleaseDontGoBack = false;
                    ShowBackBtn(true);
                    tutBackBtn.SetActive(true);
                    break;
                case 21:
                    tutBackBtn.SetActive(false);
                    canUseBackBtn = true;
                    TutorialHideRoomBtns(8);
                    tutLaptop.SetActive(true);
                    break;
                case 22:
                    tutLaptop.SetActive(false);
                    pleaseDontGoBack = true;
                    ShowBackBtn(false);
                    tutStatsLeague.SetActive(true);
                    canUseBackBtn = false;
                    break;
                case 23:
                    tutStatsLeague.SetActive(false);
                    tutBackBtn.SetActive(true);
                    pleaseDontGoBack = false;
                    ShowBackBtn(true);
                    break;
                case 24:
                    tutBackBtn.SetActive(false);
                    canUseBackBtn = true;
                    TutorialHideRoomBtns(5);
                    tutPhone.SetActive(true);
                    break;
                case 25:
                    tutPhone.SetActive(false);
                    pleaseDontGoBack = true;
                    ShowBackBtn(false);
                    tutRelationships.SetActive(true);
                    canUseBackBtn = false;
                    break;
                case 26:
                    tutRelationships.SetActive(false);
                    tutSportParent.SetActive(true);
                    break;
                case 27:
                    tutSportParent.SetActive(false);
                    tutBackBtn.SetActive(true);
                    pleaseDontGoBack = false;
                    ShowBackBtn(true);
                    break;
                case 28:
                    tutBackBtn.SetActive(false);
                    canUseBackBtn = true;
                    TutorialHideRoomBtns(7);
                    tutPiggyBank.SetActive(true);
                    break;
                case 29:
                    tutPiggyBank.SetActive(false);
                    tutShop.SetActive(true);
                    pleaseDontGoBack = true;
                    ShowBackBtn(false);
                    canUseBackBtn = false;
                    break;
                case 30:
                    tutShop.SetActive(false);
                    pleaseDontGoBack = false;
                    tutBackBtn.SetActive(true);
                    TutorialHideRoomBtns(4);
                    ShowBackBtn(true);
                    break;
                case 31:
                    tutBackBtn.SetActive(false);
                    canUseBackBtn = true;
                    tutBed.SetActive(true);
                    break;
                case 32:
                    tutBed.SetActive(false);
                    tutDilema.SetActive(true);
                    break;
                case 33:
                    tutDilema.SetActive(false);
                    TutorialHideRoomBtns(15);
                    tutEnd.SetActive(true);
                    break;
                case 34:
                    TutorialHideRoomBtns(14);
                    tutEnd.SetActive(false);
                    break;
            }

    }




    private void SetStatsBtnsInactive()
    {
        staminaBtn.SetActive(false);
        speedBtn.SetActive(false);
        agilityBtn.SetActive(false);
        strengthBtn.SetActive(false);
        jumpingSkillBtn.SetActive(false);
        accuracyBtn.SetActive(false);
        timingBtn.SetActive(false);
        freekicksBtn.SetActive(false);
        passingBtn.SetActive(false);
        dribblingBtn.SetActive(false);
        aggressionBtn.SetActive(false);
        motivationBtn.SetActive(false);
        positioningBtn.SetActive(false);
        teachingBtn.SetActive(false);
        confidenceBtn.SetActive(false);
    }

    public void GoPersonalPage()
    {
        UISetInactive();
        personalPage.SetActive(true);
        room.SetActive(true);
        skillsHeaderBtns.SetActive(false);
        ShowBackBtn(true);
        ui.UpdateAll();
        phase = 3;
        if(sm.GetStillGotTasks())
        {
            DisplayTask();
        }
    }
    public void ShowBackBtn(bool showIt)
    {
        if (!pleaseDontGoBack)
            goBackBtn.SetActive(showIt);
        else
            goBackBtn.SetActive(false);
    }
    public void GoPersonalSkillsPage()
    {
        phase = 4;
        UISetInactive();
        ShowBackBtn(true);
        skillsHeaderBtns.SetActive(true);
        personalSkillsPage.SetActive(true);

        personalSkillsPageGlow.SetActive(true);

        room.SetActive(false);

        ui.DisplayPhysicalSkills();
        ui.UpdateMoneyOnSkillsPage();
    }
    public void GoMentalSkillsPage()
    {
        phase = 4;
        UISetInactive();
        ShowBackBtn(true);
        skillsHeaderBtns.SetActive(true);
        mentalSkillsPage.SetActive(true);

        skillSkillsPageGlow.SetActive(true);

        room.SetActive(false);

        ui.DisplayMentalSkills();
        ui.UpdateMoneyOnSkillsPage();
    }
    public void GoSkillSkillsPage()
    {
        phase = 4;
        UISetInactive();
        ShowBackBtn(true);
        skillsHeaderBtns.SetActive(true);
        skillSkillsPage.SetActive(true);
        mentalSkillsPageGlow.SetActive(true);
        room.SetActive(false);

        ui.DisplaySkillSkills();
        ui.UpdateMoneyOnSkillsPage();
    }
    public void GoInGameShop()
    {
        phase = 4;
        UISetInactive();
        ShowBackBtn(true);
        inGameShopPage.SetActive(true);
    }
    public void GoRealMoneyPage()
    {
        phase = 4;
        UISetInactive();
        ShowBackBtn(true);
        realMoneyShopPage.SetActive(true);
    }
    public void GoFinancesPage()
    {
        phase = 4;
        UISetInactive();
        ShowBackBtn(true);
        financesPage.SetActive(true);

    }
    public void GoRelationshipsPage()
    {
        phase = 4;
        UISetInactive();
        ShowBackBtn(true);
        relationshipsPage.SetActive(true);
        ui.DisplayRelationships();
    }
    public void DisplayRelationshipGlow(int rn)
    {
        switch (rn)
        {
            case 0:
                TurnOffRelGlow();
                relationshipGlow0.SetActive(true);
                break;
            case 1:
                TurnOffRelGlow();
                relationshipGlow1.SetActive(true);
                break;
            case 2:
                TurnOffRelGlow();
                relationshipGlow2.SetActive(true);
                break;
            case 3:
                TurnOffRelGlow();
                relationshipGlow3.SetActive(true);
                break;
            case 4:
                TurnOffRelGlow();
                relationshipGlow4.SetActive(true);
                break;
            case 5:
                TurnOffRelGlow();
                relationshipGlow5.SetActive(true);
                break;
            case 6:
                TurnOffRelGlow();
                relationshipGlow6.SetActive(true);
                break;
            case 7:
                TurnOffRelGlow();
                relationshipGlow7.SetActive(true);
                break;
            case 8:
                TurnOffRelGlow();
                relationshipGlow8.SetActive(true);
                break;
            case 9:
                TurnOffRelGlow();
                relationshipGlow9.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void GoRelationshipPopUpPage(int rn)
    {
        relationshipPopUpPage.SetActive(true);
        ui.DisplayLeftRightRelationshipSlider(rn);
    }
    public void HideRelationshipPopUpPage()
    {
        relationshipPopUpPage.SetActive(false);
    }
    public void GoInternationalTournementsPage()
    {
        phase = 4;
        UISetInactive();
        ui.DisplayInterTournement();
        ShowBackBtn(true);
        internationalTournementsPage.SetActive(true);
    }
    public void GoDomesticTournementsPage()
    {
        phase = 4;
        UISetInactive();
        ui.DisplayDomTournement();
        ShowBackBtn(true);
        domesticTournementsPage.SetActive(true);
    }
    public void GoStatsPage()
    {
        phase = 4;
        ui.DisplayStatistics();
        UISetInactive();
        ShowBackBtn(true);
        statsPage.SetActive(true);
    }
    public void ClickedBlinds()
    {
        ui.ToggleLightMode();
    }
    public void NextWeek()
    {
        // change week
        if (!sm.IncDate())
        {
            ui.UpdateAll();
            //GoPersonalPage();
            sm.StartNewWeekTasks();
        }
    }
    public void DisplayPreGameMenuPlayerNames()
    {
        btnPressed = false;
        room.SetActive(false);
        personalPage.SetActive(false);
        preGameMenu.SetActive(true);
        if(sm.GetNeedsTutorial())
        {
            simulateBtn.SetActive(false);
        }
        else
            simulateBtn.SetActive(true);
        playerNamesMenu.SetActive(true);
        teamStatsMenu.SetActive(false);
        playerNamesBtnGlow.SetActive(true);
        teamStatsBtnGlow.SetActive(false);
        phase = 4;
    }
    public void DisplayPreGamerMenuTeamStats()
    {
        btnPressed = true;
        playerNamesMenu.SetActive(false);
        teamStatsMenu.SetActive(true);
        playerNamesBtnGlow.SetActive(false);
        teamStatsBtnGlow.SetActive(true);
        phase = 4;
    }
    public void DisplayAfterGameMenu()
    {
        afterGameMenu.SetActive(true);
    }
    public void HideafterGameMenu()
    {
        afterGameMenu.SetActive(false);
        sm.StartNewWeekTasks();
        phase = 4;
    }
    public void EndGame()
    {
        phase = 3;
        ui.UpdateAll();
        //GoPersonalPage();
        //sm.StartNewWeekTasks();
        gameSetup = false;
    }
    public void StoryOptionPicked(int op)
    {
        sm.RemoveTask(op);

        if (sm.GetStillGotTasks())
        {
            ShowBackBtn(false);
            phase = 0;
        }
        else
        {
            ShowBackBtn(true);
            phase = 3;
        }
    }
    public void StoryOptionPickedIField(int op)
    {
        sm.RemoveTask(op);

            if (sm.GetStillGotTasks())
            {
            ShowBackBtn(false);
            phase = 0;
            }
            else
            {
            ShowBackBtn(true);
            phase = 3;
            }
    }
    public void DisplayTask() // need?
    {
        UISetInactive();
        taskPopUp.SetActive(true);
        ShowBackBtn(false);
        phase = 0;
    }

    public void DisplayIField()
    {
        inputField.SetActive(true);
        phase = 0;
    }
    public void SubmitIField(int rn)
    {
       if(iFI.text != "")
        {
            iFieldText = iFI.text;
            sm.GrabIfieldText();
            HideIField();
            iFI.text = "";
        }

    }
    public string GetIFieldText()
    {
        return iFieldText;
    }
    public void HideIField()
    {
       if (iFI.text != "")
        {
            inputField.SetActive(false);
        }

    }
    public void SetInputFieldFirstNameText()
    {
        am.PlaySingle(am.diceRoll);
        if (player.GetMale())
            intputFieldFirstNamePlaceholder.text = utilities.GetMaleName();
        else
            intputFieldFirstNamePlaceholder.text = utilities.GetFemaleName();
        //Debug.Log("Input field text = " + intputFieldFirstNamePlaceholder.text);
        intputFieldFirstName.text = intputFieldFirstNamePlaceholder.text;
    }
    public string GetIntputFieldFirstNameText()
    {       
        return intputFieldFirstNameText;
    }
    public void SetInputFieldLastNameText()
    {
        am.PlaySingle(am.diceRoll);
        inputFieldLastNamePlaceholder.text = utilities.GetSecondName();
        //Debug.Log("Input field text = " + inputFieldLastNamePlaceholder.text);
        inputFieldLastName.text = inputFieldLastNamePlaceholder.text;
    }
    public string GetIntputFieldLastNameText()
    {
        return inputFieldLastNameText;
    }
    public void SetInputFieldMumsNameText()
    {
        am.PlaySingle(am.diceRoll);
        inputFieldMumsNamePlaceholder.text = utilities.GetFemaleName();
        //Debug.Log("Input field text = " + inputFieldMumsNamePlaceholder.text);
        inputFieldMumsName.text = inputFieldMumsNamePlaceholder.text;
    }
    public string GetIntputFieldMumsNameText()
    {
        return inputFieldMumsNameText;
    }
    public void SetInputFieldDadsNameText()
    {
        am.PlaySingle(am.diceRoll);
        inputFieldDadsNamePlaceholder.text = utilities.GetMaleName();
        //Debug.Log("Input field text = " + inputFieldDadsNamePlaceholder.text);
        inputFieldDadsName.text = inputFieldDadsNamePlaceholder.text;
    }
    public string GetIntputFieldDadsNameText()
    {
        return inputFieldDadsNameText;
    }
    public void SetGender()
    {
        intputFieldFirstName.text = "";
        intputFieldFirstNamePlaceholder.text = "";
        player.SetMale(!player.GetMale());
        if (player.GetMale())
        {
            genderBtnText.text = "Male";            
        }
        else
        {
            genderBtnText.text = "Female";            
        }        
    }
    public void DisplayPlayerMenu()
    {
        playerMenu.SetActive(true);
        phase = 5;
    }
    public void SwitchToPractice()
    {
        //goBackBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(3.36f, 7.92f);
        switchToPractice = false;
        cb.SetCameraValues(5);
        DisplayQTE(false);
        mainMenu.SetActive(false);
        onMainMenu = false;
        ShowBackBtn(true);
        phase = 2;
    }
    public void StartGame()
    {
        doneSetUp = true;
        choiceExplaination.SetActive(false);
        dadChosenTxt.SetActive(false);
        mumChosenTxt.SetActive(false);
        //goBackBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(3.36f, 7.92f);
        mainMenu.SetActive(false);
        onMainMenu = false;
        cb.SetCameraValues(5);
        
        if (playerCreation)
            DisplayPlayerMenu();
        else
        {
            GoPersonalPage();
            if (sm.GetNeedsTutorial())
            {
                Debug.Log(sm.GetNeedsTutorial());
                tutorialStage--;
                HideAllTutorial();
                IncTutorial(); // TODO:: and uncomment this!!!!  
            }
            else
                HideAllTutorial();
        }
    }
    public void SubmitPlayer()
    {
        if (intputFieldFirstName.text != "" && inputFieldLastName.text != "" && inputFieldDadsName.text != "" && inputFieldMumsName.text != "")
        {
            playerCreation = false;
            playerMenu.SetActive(false);
            player.SetName(intputFieldFirstName.text + " " + inputFieldLastName.text);
            player.SetFirstName(intputFieldFirstName.text);
            player.SetMumsName(inputFieldMumsName.text);
            player.SetDadsName(inputFieldDadsName.text);

            if (sm.GetSatWithDad())
            {
                player.GetRelationship(0).SetName(player.GetDadsName());
                player.GetRelationship(0).SetTitle("Dad");
                player.GetRelationship(1).SetName(player.GetMumsName());
                player.GetRelationship(1).SetTitle("Mum");
            }
            else
            {
                player.GetRelationship(0).SetName(player.GetMumsName());
                player.GetRelationship(0).SetTitle("Mum");
                player.GetRelationship(1).SetName(player.GetDadsName());
                player.GetRelationship(1).SetTitle("Dad");
            }
            //Debug.Log("Calling playerGenders");
            tm.SetUpPlayerGenders();
            tm.AddPlayerToTeam();
            if (!tutorialOff)
            {
                sm.SetNeedsTutorial(true); // TODO:: Set to true to have a tutorial
                IncTutorial(); // TODO:: and uncomment this!!!!  
            }
            GoPersonalPage();
        }
    }
    public void HideNewspaper()
    {
        //newspaper.SetActive(false);
        newspaperAnimation.SetActive(false);
        newspaperAnimationUnroll.SetActive(true);
        StartCoroutine(NewsPaperUnroll());
    }
    IEnumerator NewsPaperUnroll()
    {
        yield return new WaitForSeconds(0.3f);
        newspaper.SetActive(false);
        newspaperAnimationUnroll.SetActive(false);
    }
    public void DisplayTask(int opAmount, bool isNewspaper)
    {
        UISetInactive();
        taskPopUp.SetActive(true);
        if(!isNewspaper)
        {
            if(opAmount == 2)
            {
                singleTask.SetActive(false);
                doubleTask.SetActive(true);
                tripleTask.SetActive(false);
            }
            else if (opAmount == 3)
            {
                singleTask.SetActive(false);
                doubleTask.SetActive(false);
                tripleTask.SetActive(true);
            }
            else
            {
                singleTask.SetActive(true);
                doubleTask.SetActive(false);
                tripleTask.SetActive(false);
            }
        }
        else
        {
            singleTask.SetActive(false);
            doubleTask.SetActive(false);
            tripleTask.SetActive(false);
            newspaper.SetActive(true);
            newspaperAnimation.SetActive(true);
        }
        ShowBackBtn(false);
        phase = 0;
    }
    private void UISetInactive()
    {
        room.SetActive(false);
        personalPage.SetActive(false);
        personalSkillsPage.SetActive(false);
        personalSkillsPageGlow.SetActive(false);
        mentalSkillsPage.SetActive(false);
        skillSkillsPageGlow.SetActive(false);
        skillSkillsPage.SetActive(false);
        mentalSkillsPageGlow.SetActive(false);
        inGameShopPage.SetActive(false);
        realMoneyShopPage.SetActive(false);
        relationshipsPage.SetActive(false);
        relationshipPopUpPage.SetActive(false);
        TurnOffRelGlow();
        internationalTournementsPage.SetActive(false);
        domesticTournementsPage.SetActive(false);
        statsPage.SetActive(false);
        financesPage.SetActive(false);
        taskPopUp.SetActive(false);
        matchPage.SetActive(false);
        qte.SetActive(false);

        //newspaper.SetActive(false);
        mainMenu.SetActive(false);
        onMainMenu = false;
        playerMenu.SetActive(false);
        schoolLeague.SetActive(false);

    }
    private void TurnOffRelGlow()
    {
        relationshipGlow0.SetActive(false);
        relationshipGlow1.SetActive(false);
        relationshipGlow2.SetActive(false);
        relationshipGlow3.SetActive(false);
        relationshipGlow4.SetActive(false);
        relationshipGlow5.SetActive(false);
        relationshipGlow6.SetActive(false);
        relationshipGlow7.SetActive(false);
        relationshipGlow8.SetActive(false);
        relationshipGlow9.SetActive(false);
    }

    private void SwitchToGame(Match t, bool skipMatch)
    {
        phase = 0;
        ShowBackBtn(false);

        room.SetActive(false);
        ui.SetUpTeamText(t);

        if (!skipMatch)
            DisplayMatch();

        if (!gameSetup)
        {
            gm.StartSetup();
            gameSetup = true;
        }

        gm.StartMatch(t, true, skipMatch);
    }
    public void IncAvailible(int skill)
    {
        switch(skill)
        {
            case 0:
                staminaBtn.SetActive(true);
                break;
            case 1:
                speedBtn.SetActive(true);
                break;
            case 2:
                agilityBtn.SetActive(true);
                break;
            case 3:
                strengthBtn.SetActive(true);
                break;
            case 4:
                jumpingSkillBtn.SetActive(true);
                break;
            case 5:
                accuracyBtn.SetActive(true);
                break;
            case 6:
                timingBtn.SetActive(true);
                break;
            case 7:
                freekicksBtn.SetActive(true);
                break;
            case 8:
                passingBtn.SetActive(true);
                break;
            case 9:
                dribblingBtn.SetActive(true);
                break;
            case 10:
                aggressionBtn.SetActive(true);
                break;
            case 11:
                motivationBtn.SetActive(true);
                break;
            case 12:
                positioningBtn.SetActive(true);
                break;
            case 13:
                teachingBtn.SetActive(true);
                break;
            case 14:
                confidenceBtn.SetActive(true);
                break;
        }
    }
    public void IncNotAvailible(int skill)
    {
        switch (skill)
        {
            case 0:
                staminaBtn.SetActive(false);
                break;
            case 1:
                speedBtn.SetActive(false);
                break;
            case 2:
                agilityBtn.SetActive(false);
                break;
            case 3:
                strengthBtn.SetActive(false);
                break;
            case 4:
                jumpingSkillBtn.SetActive(false);
                break;
            case 5:
                accuracyBtn.SetActive(false);
                break;
            case 6:
                timingBtn.SetActive(false);
                break;
            case 7:
                freekicksBtn.SetActive(false);
                break;
            case 8:
                passingBtn.SetActive(false);
                break;
            case 9:
                dribblingBtn.SetActive(false);
                break;
            case 10:
                aggressionBtn.SetActive(false);
                break;
            case 11:
                motivationBtn.SetActive(false);
                break;
            case 12:
                positioningBtn.SetActive(false);
                break;
            case 13:
                teachingBtn.SetActive(false);
                break;
            case 14:
                confidenceBtn.SetActive(false);
                break;
        }
    }
    public void StartTournement(Match t, bool skipMatch)
    {
        UISetInactive();
        // start Adams stuff
        SwitchToGame(t, skipMatch);
    }
    public void GetAllInterTourns(bool skipMatch)
    {
        //Debug.Log("Pressed the button to turn of PreGameMenu");
        preGameMenu.SetActive(false);
        playerNamesBtnGlow.SetActive(false);
        teamStatsBtnGlow.SetActive(false);
        //Debug.Log("Output the date inc " + sm.GetIntDate());
        //Debug.Log("Tournament count " + pmm.GetAllInterTournements().Count);
        //Debug.Log("inter matches count " + pmm.GetAllInterTournements().Count);
        //Debug.Log("date trying for " + (sm.GetIntDate() - 1));
        StartTournement(pmm.GetAllInterTournements()[matchesplayedCounter], skipMatch);     //Not working
        matchesplayedCounter++;
    }
    public void GoBack()
    {
        //Debug.Log("Tut stage : " + tutorialStage);
        //Debug.Log("Go Back Phase: " + phase);        
        // 0 = Inactive, 1 = Main Menu, 2 = Practice, 3 = Room, 4 = Standard Menu, 5 = Player Creation Menu, 6 = Start Game TV, 7 = Options Bookcase
        //if(!sm.GetNeedsTutorial() || tutorialStage == 0 || tutorialStage == 15 || tutorialStage == 18 || tutorialStage == 23 || tutorialStage == 24 || tutorialStage == 25 || tutorialStage == 26)
        if(canUseBackBtn)
        switch (phase)
        {
            case 0:
                break;
            case 1:
                if (!cb.IsAnimateCamera())
                    Application.Quit();
                break;
            case 2:
                cb.SetCameraValues(5);
                cb.SetMovemementPhase(0);
                phase = 1;
                mm.EndGame();
                ui.ResetQTE();
                ForceExitQTE();
                qte.SetActive(false);
                mainMenu.SetActive(true);
                onMainMenu = true;
                ball.SetActive(false);
                ballShadow.SetActive(false);
                ShowBackBtn(false);
                break;
            case 3:
                cb.SetCameraValues(5);
                cb.SetMovemementPhase(0);
                phase = 1;
                personalPage.SetActive(false);
                room.SetActive(false);
                ShowBackBtn(false);
                mainMenu.SetActive(true);
                onMainMenu = true;
                break;
            case 4:
                GoPersonalPage();
                break;
            case 5:
                ShowBackBtn(false);
                cb.SetCameraValues(5);
                cb.SetMovemementPhase(0);
                phase = 1;
                mainMenu.SetActive(true);
                onMainMenu = true;
                playerMenu.SetActive(false);
                break;
            case 6:
                if (!cb.IsAnimateCamera())
                {
                    phase = 1;
                    cb.SetMovemementPhase(4);
                }
                break;
            case 7:
                if (!cb.IsAnimateCamera())
                {
                    phase = 1;
                    cb.SetMovemementPhase(5);
                }
                break;
        }
    }
   
    public void IncSkill(int skill)
    {
        if (player.GetMoney() >= player.GetStatCost(skill))
        {
            player.IncMoney(-player.GetStatCost(skill));
            player.IncStatLevel(skill);
            IncNotAvailible(skill);
            if (skill < 5)
                ui.DisplayPhysicalSkills();
            else if (skill < 10)
                ui.DisplaySkillSkills();
            else if (skill < 15)
                ui.DisplayMentalSkills();
            ui.UpdateMoneyOnSkillsPage();
        }
        else
        {
            switch (skill)
            {
                case 0:
                    StartCoroutine(ButtonShake(staminaBtn, staminaBtnTxt));                    
                    break;
                case 1:                                   
                    StartCoroutine(ButtonShake(speedBtn, speedBtnTxt));                 
                    break;
                case 2:                     
                    StartCoroutine(ButtonShake(agilityBtn, agilityBtnTxt));                 
                    break;
                case 3:                    
                    StartCoroutine(ButtonShake(strengthBtn, strengthBtnTxt));                   
                    break;
                case 4:
                    StartCoroutine(ButtonShake(jumpingSkillBtn, jumpingSkillBtnTxt));                   
                    break;
                case 5:                   
                    StartCoroutine(ButtonShake(accuracyBtn, accuracyBtnTxt));                   
                    break;
                case 6:                
                    StartCoroutine(ButtonShake(timingBtn, timingBtnTxt));                 
                    break;
                case 7:                  
                    StartCoroutine(ButtonShake(freekicksBtn, freekicksBtnTxt));                   
                    break;
                case 8:
                    StartCoroutine(ButtonShake(passingBtn, passingBtnTxt));                   
                    break;
                case 9:
                    StartCoroutine(ButtonShake(dribblingBtn, dribblingBtnTxt));                    
                    break;
                case 10:
                    StartCoroutine(ButtonShake(aggressionBtn, aggressionBtnTxt));                   
                    break;
                case 11:
                    StartCoroutine(ButtonShake(motivationBtn, motivationBtnTxt));                 
                    break;
                case 12:
                    StartCoroutine(ButtonShake(positioningBtn, positioningBtnTxt));               
                    break;
                case 13:
                    StartCoroutine(ButtonShake(teachingBtn, teachingBtnTxt));                   
                    break;
                case 14:
                    StartCoroutine(ButtonShake(confidenceBtn, confidenceBtnTxt));                   
                    break;
            }
            
        }

    }
    IEnumerator ButtonShake(GameObject btn, Text btnText)
    {
        Color32 originalColor = new Color32(202,202,202,255);
        Vector3 oPosition = btn.transform.localPosition ;
        btnText.color = new Color32(255, 0, 0, 255);
        int toggle = -1;
        for(int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.1f);
            btn.transform.localPosition = new Vector3(oPosition.x + (0.5f * toggle), oPosition.y, oPosition.z);
            toggle *= -1;
        }
        yield return new WaitForSeconds(0.1f);
        btn.transform.localPosition = oPosition;
        btnText.color = originalColor;
        /*yield return new WaitForSeconds(0.1f);
        btn.transform.localPosition = new Vector3(oPosition.x - (0.5f), oPosition.y, oPosition.z);

        yield return new WaitForSeconds(0.1f);
        //btn.transform.localPosition = oPosition;
        btn.transform.localPosition = new Vector3(oPosition.x + (0.5f), oPosition.y, oPosition.z);

        yield return new WaitForSeconds(0.1f);
        //btn.transform.localPosition = oPosition;
        btn.transform.localPosition = new Vector3(oPosition.x - (0.5f), oPosition.y, oPosition.z);

        yield return new WaitForSeconds(0.1f);
        //btn.transform.localPosition = oPosition;
        btn.transform.localPosition = new Vector3(oPosition.x + (0.5f), oPosition.y, oPosition.z);*/

    }
    
    public void DisplayQTE(bool penalty)
    {
        mainMenu.SetActive(false);
        onMainMenu = false;
        UISetInactive();
        qte.SetActive(true);
        arrow.SetActive(true);
        DisplayBall();
        ui.SetQTEStart(penalty);
        if (penalty)
            StartCoroutine(PenaltyTitle());
    }
    IEnumerator PenaltyTitle()
    {
        penaltyTitle.SetActive(true);
        yield return new WaitForSeconds(2f);
        penaltyTitle.SetActive(false);
    }
    public void ReplayQTEPractice()
    {
        arrow.SetActive(true);
        ui.SetQTEStart(false);
        DisplayBall();
        ui.SetQTEStart(false);
    }
    public void DisplayQTEDirectionArrow()
    {
        arrow.SetActive(true);
    }
    public void DisplayQTEUDLR()
    {
        updown.SetActive(true);
    }
    private void ForceExitQTE()
    {
        updown.SetActive(false);
        ball.SetActive(false);
        ballShadow.SetActive(false);
    }
    public void DisplayAccuracy()
    {
        shrinkCircle.SetActive(true);
    }
    public void DisplayBall()
    {
        //arrow.SetActive(false);
        //updown.SetActive(false);
        //shrinkCircle.SetActive(false);
        mm.MoveBall();
        ball.SetActive(true);
        ballShadow.SetActive(true);
    }
    public void DisplayBallMove()
    {
        arrow.SetActive(false);
        updown.SetActive(false);
        shrinkCircle.SetActive(false);
        //ball.SetActive(true);
        //ballShadow.SetActive(true);
    }
    public void DisplayMatch()
    {
        UISetInactive();
        ball.SetActive(false);
        ballShadow.SetActive(false);
        match.SetActive(true);
    }

    public void SetGameSpeed(int amount)
    {
        gm.SetMatchTimeSpeed(amount);
    }
    public void SetLaptopFlashing()
    {

    }

    public void TutorialHideRoomBtns(int i)
    {
        bootsBtn.SetActive(false);
        booksBtn.SetActive(false);
        weightsBtn.SetActive(false);
        ballBtn.SetActive(false);
        bedBtn.SetActive(false);
        phoneBtn.SetActive(false);
        lampBtn.SetActive(false);
        moneyJarBtn.SetActive(false);
        laptopBtn.SetActive(false);
        doorBtn.SetActive(false);
        blindsBtn.SetActive(false);
        switch(i)
        {
            case 0:
                bootsBtn.SetActive(true);
                break;
            case 1:
                booksBtn.SetActive(true);
                break;
            case 2:
                weightsBtn.SetActive(true);
                break;
            case 3:
                ballBtn.SetActive(true);
                break;
            case 4:
                bedBtn.SetActive(true);
                break;
            case 5:
                phoneBtn.SetActive(true);
                break;
            case 6:
                lampBtn.SetActive(true);
                break;
            case 7:
                moneyJarBtn.SetActive(true);
                break;
            case 8:
                laptopBtn.SetActive(true);
                break;
            case 9:
                doorBtn.SetActive(true);
                break;
            case 10:
                blindsBtn.SetActive(true);
                break;
            case 14: // dont hide anything
                bootsBtn.SetActive(true);
                booksBtn.SetActive(true);
                weightsBtn.SetActive(true);
                ballBtn.SetActive(true);
                bedBtn.SetActive(true);
                phoneBtn.SetActive(true);
                lampBtn.SetActive(true);
                moneyJarBtn.SetActive(true);
                laptopBtn.SetActive(true);
                doorBtn.SetActive(true);
                blindsBtn.SetActive(true);
                break;
            case 15: // hide everything 
                break;
        }
    }
    public void PracticeBtnClicked()
    {
        if (!cb.IsAnimateCamera())
            cb.SetMovemementPhase(3);
        switchToPractice = true;
    }

    public void StartGameBtnClicked()
    {
        if (!cb.IsAnimateCamera())
        {
            //goBackBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(-8.1f, 6.6f);
            cb.SetMovemementPhase(1);
            phase = 6;
        }
    }

    public void OptionsBtnClicked()
    {
        if (!cb.IsAnimateCamera())
        {
            //goBackBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(11.6f, 5.2f);
            cb.SetMovemementPhase(2);
            phase = 7;
        }
    }
    public void DisplayRoom(bool toggle)
    {
        room.SetActive(toggle);
    }
    public void ToggleOffSound()
    {
        if (!cb.IsAnimateCamera())
        {
            soundsOff = !soundsOff;
            ui.UpdateOptions();
        }
    }
    public void ToggleOffTutorial()
    {
        if (!cb.IsAnimateCamera())
        {
            if (tutorialOff)
            {
                tutorialOff = false;
                sm.SetNeedsTutorial(true);
            }
            else
            {
                tutorialOff = true;
                sm.SetNeedsTutorial(false);
                HideAllTutorial();
                TutorialHideRoomBtns(14);
            }
            ui.UpdateOptions();
        }
        //Debug.Log("toggled: " + sm.GetNeedsTutorial() + " " + tutorialOff);
    }
    public void HideAllTutorial()
    {
        //tutSatWithYou.SetActive(false);
        tutBed.SetActive(false);
        tutPreMatch.SetActive(false);
        tutPossession.SetActive(false);
        tutTeamScore.SetActive(false);
        tutTimer.SetActive(false);
        tutSpeed.SetActive(false);
        tutAngle.SetActive(false);
        tutPower.SetActive(false);
        tutHighLow.SetActive(false);
        tutCurve.SetActive(false);
        tutAccuracy.SetActive(false);
        tutAfterMatch.SetActive(false);
        tutIncome.SetActive(false);
        tutBanner.SetActive(false);
        tutFootball.SetActive(false);
        tutMatchList.SetActive(false);
        tutBackBtn.SetActive(false);
        tutBooks.SetActive(false);
        tutSkillsHeader.SetActive(false);
        tutSkillUpgrade.SetActive(false);
        tutLaptop.SetActive(false);
        tutStatsLeague.SetActive(false);
        tutPhone.SetActive(false);
        tutRelationships.SetActive(false);
        tutSportParent.SetActive(false);
        tutPiggyBank.SetActive(false);
        tutShop.SetActive(false);
        tutDilema.SetActive(false);
        tutEnd.SetActive(false);
    }
    public bool GetTutorialOff()
    {
        return tutorialOff;
    }
    public bool GetSoundsOff()
    {
        return soundsOff;
    }
    public void DisplayEndOfDemoPage()
    {
        endOfDemoPage.SetActive(true);
        ShowBackBtn(true);
        phase = 1;
    }
    public void GoTOLink()
    {
        Application.OpenURL("https://www.surveymonkey.co.uk/r/HZPYKJK");
    }
    public void SetPhase(int phase)
    {
        this.phase = phase;
        if (phase == 0)
            ShowBackBtn(false);
        //else
        //    goBackBtn.SetActive(true);
    }
    public void DisplayBallSpriteMove()
    {
        stillBall.SetActive(false);
        movingBall.SetActive(true);
    }
    public void DisplayStillBall()
    {
        stillBall.SetActive(true);
        movingBall.SetActive(false);
    }
    public void DisplayScorePopUp()
    {
        scorePopUp.SetActive(true);
    }
    public void HideScorePopUp()
    {
        scorePopUp.SetActive(false);
    }
    public void DiClicked(GameObject di)
    {
        StartCoroutine(ScaleClick(di));
    }
    IEnumerator ScaleClick(GameObject di)
    {
        Vector3 temp = di.transform.localScale;
        di.transform.localScale *= 0.8f;
        yield return new WaitForSeconds(0.1f);
        di.transform.localScale = temp;
    }
    public void PlaySound(int i)
    {
        am.PlaySingle(i);
    }
    public void SetSatWithDad(bool withDad)
    {
        if (phase == 6)
        {
            parentChosen = true;
            sm.SetSatWithDad(withDad);
        }
    }
}