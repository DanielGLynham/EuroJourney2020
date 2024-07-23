using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class StoryManager : MonoBehaviour
{
    // tell UI manager how many options there are
    // output options
    private bool SatWithDad;
    readonly private Utilities utilities;
    private string playerDesc, newspaperBrief, newspaperTitle;
    int intDate;   
    string date;
    private bool stillGotTasks; 
    private bool weeklyIncomeBool = true;
    StoryManager sm;
    UIManager uim;
    BTNManager btnm;
    MainPlayer player;
    AllStory allStory;
    LeagueManager lm;
    List<Match> displayedTournements = new List<Match>(); // collection of 20 tournements, delete when done, then add end new tournement
    List<Match> displayedDomTournements = new List<Match>();
    private PlayerMatchesManager pmm;

    List<Task> tasks = new List<Task>(); // collection of tasks for each week. Can only move on when all done.
    List<Task> tasksComplete = new List<Task>();

    int currentTournement;
    int currentDomTournement;

    int relationshipInQuestion;

    private bool needsTutorial = false;

    private void Start()
    {
        sm = this.gameObject.GetComponent<StoryManager>();
        uim = this.gameObject.GetComponent<UIManager>();
        btnm = this.gameObject.GetComponent<BTNManager>();
        player = this.gameObject.GetComponent<MainPlayer>();
        pmm = this.gameObject.GetComponent<PlayerMatchesManager>();
        lm = this.gameObject.GetComponent<LeagueManager>();

        //player.SetUpValues();
        allStory = new AllStory(player);

        currentTournement = 0;
        currentDomTournement = 0;
        intDate = 0;

        pmm.CalendarYearOneQuick(intDate);
        pmm.SchoolYear(2);

        //for (int i = intDate; i < displayedTournements.Count; i++)
        //{
        //    displayedTournements.Add(pmm.GetTournement(i));
        //}
        //for(int i = intDate; i < displayedDomTournements.Count; i++)
        //{
        //    displayedDomTournements.Add(pmm.GetDomTournement(i));
        //}
        //LoadPlayer();
    }
    public void SetNeedsTutorial(bool needs)
    {
        if(!btnm.GetTutorialEnded())
            needsTutorial = needs;
    }
    public bool GetNeedsTutorial()
    {
        return needsTutorial;
    }
    public PlayerMatchesManager GetPlayerMatchManager()
    {
        return pmm;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SavePlayer();
        }
    }
    public AllStory GetAllStory()
    {
        return allStory;
    }
    public void RemoveTask(int opChosen)
    {
        if (!(tasks[0].GetIFieldRequired() && btnm.iFI.text == ""))
        {
            // update UI
            if (opChosen == 0)
            {
                btnm.HideNewspaper();
            }
            ClickedOption(opChosen);
            tasksComplete.Add(tasks[0]);
            tasks.RemoveAt(0);

            if (tasks.Count > 0)
            {
                //Debug.Log(tasks.Count);
                //Debug.Log(tasks[0].GetTitle());
                uim.DisplayTask(tasks[0]);
                if (tasks[0].GetIFieldRequired())
                {
                    btnm.DisplayIField();
                }
                stillGotTasks = true;
                btnm.DisplayRoom(false);
            }
            else
            {
                if (weeklyIncomeBool == false)
                {
                    stillGotTasks = false;
                    btnm.GoPersonalPage();
                    weeklyIncomeBool = true;
                }
                else
                {
                    tasks.Add(new Task("Weekly Gains", "This week, you gained: \n" + player.GetIncome() + " G!", "Continue", 54));
                    uim.DisplayTask(tasks[0]);
                    weeklyIncomeBool = false;
                }

            }

        }
    }
    public void StartNewWeekTasks()
    {
        for (int i = 0; i < tasks.Count - 1; i++)
            if(tasks.Count != 1)
                tasks.RemoveAt(0);
        // talk to story manager and get tasks
        allStory = new AllStory(player);
        List<Task> temp = allStory.GetWeekTasks(intDate);
        for (int i = 0; i < temp.Count; i++)
            tasks.Add(temp[i]);
        //for(int i = 0; i < player.GetRelationships().Length; i++)
        //{
        //    if (player.GetRelationship(i).GetGoodStoryAvalible())
        //    {
        //        tasks.Add(allStory.GetRelationshipGoodStory(i)[player.GetRelationship(i).GetCurrentMilestone()]);
        //        player.GetRelationship(i).SetGoodStoryAvalible(false);
        //    }
        //    if (player.GetRelationship(i).GetBadStoryAvalible())
        //    {
        //        tasks.Add(allStory.GetRelationshipBadStory(i)[player.GetRelationship(i).GetCurrentMilestone()]);
        //        player.GetRelationship(i).SetBadStoryAvalible(false);
        //    }
        //}
        
        if (tasks.Count > 0)
        {
            uim.DisplayTask(tasks[0]);
            if(tasks[0].GetIFieldRequired())
            {
                btnm.DisplayIField();
            }
            stillGotTasks = true;
        }
        else
        {
            //Debug.Log("count is 0");
            if (weeklyIncomeBool == false)
            {
                stillGotTasks = false;
                btnm.GoPersonalPage();
                Debug.Log("new week");
                weeklyIncomeBool = true;
            }
            else
            {
                //Debug.Log("Weekly Income bool is true");
                tasks.Add(new Task("Weekly Gains", "This week, you gained: \n" + player.GetIncome() + " G!", "Continue", 54));
                uim.DisplayTask(tasks[0]);
                weeklyIncomeBool = false;
            }
            
        }
    }
    public bool GetStillGotTasks()
    {
        return stillGotTasks;
    }

    public Match GetTournement(int i)
    {
        return displayedTournements[i];
    }
    public Match GetDomTournement(int i)
    {
        return displayedDomTournements[i];
    }
    public List<Match> GetAllTournements()
    {
        return displayedTournements;
    }
    public List<Match> GetAllDomTournements()
    {
        return displayedDomTournements;
    }
    public void AddInterTourn(Match t)
    {
        displayedTournements.Add(t);
        for(int i = 0; i < displayedTournements.Count; i++)
        {
            if (displayedTournements[i].GetIntDate() <= intDate)
            {
                displayedTournements.RemoveAt(i);
            }
        }
        //Debug.Log(displayedTournements.Count);
    }
    public void SortInterMatches()
    {
        for (int i = 0; i < displayedTournements.Count; i++)
        {
            if (displayedTournements[i].GetIntDate() <= intDate)
            {
                displayedTournements.RemoveAt(i);
            }
        }
    }
    public void AddDomTourn(Match t)
    {
        displayedDomTournements.Add(t);
    }
    private void SortDate()
    {
        int weeks = 1;
        int months = 1;
        int years = 2008;
        int temp = intDate;
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
    public bool IncDate()
    {
        intDate++;
        //pmm.CalendarYearOne(intDate); // need this to play games!!!!!!!
        pmm.PlaySchoolYear();
        lm.SortSchoolWinner();
        SortDate();
        player.IncMoney(player.GetIncome());
        SortInterMatches();

        for (int i = 0; i < pmm.GetAllInterTournements().Count; i++)
        {
            if (pmm.GetAllInterTournements()[i].GetIntDate() == intDate)
            {
                btnm.SetPhase(0);
                btnm.DisplayPreGameMenuPlayerNames();
                uim.DisplayPreGameMenuPlayerNames(pmm.GetAllInterTournements()[i].GetAwayTeam(), pmm.GetAllInterTournements()[i].GetHomeTeam());
                uim.DisplayPreGameMenuTeamStats(pmm.GetAllInterTournements()[i].GetAwayTeam(), pmm.GetAllInterTournements()[i].GetHomeTeam());
                //btnm.StartTournement(pmm.GetAllInterTournements()[i]);  //Place in btn in DisplayPreGame
                return true;
            }

        }
        return false;
    }
    public string GetDate()
    {
        SortDate();
        return date;
    }
    public int GetIntDate()
    {
        return intDate;
    }
    public void ClickedOption(int opNum)      // On button clicked
    {
        int choiceNum = 1;
        if (opNum == 1)
            choiceNum = tasks[0].GetChoiceOne();
        else if (opNum == 2)
            choiceNum = tasks[0].GetChoiceTwo();
        else if (opNum == 3)
            choiceNum = tasks[0].GetChoiceThree();

        switch (choiceNum)
        {
            case 1:                                                         //Side with football
                player.GetRelationship(5).SetBond(5);
                player.GetRelationship(6).SetBond(5);
                player.GetRelationship(0).SetBond(5);
                player.GetRelationship(1).SetBond(-5);
                player.IncStat(11, 20);                                      //Increase motivation stat                               
                player.IncStat(13, -50);
                break;
            case 2:                                                         //Side with school
                player.GetRelationship(5).SetBond(-1);
                player.GetRelationship(6).SetBond(-1);
                player.GetRelationship(0).SetBond(-5);
                player.GetRelationship(1).SetBond(5);
                player.IncStat(11, -20);
                player.IncStat(13, 50);                                      //Increase teaching stat
                break;
            case 3:                                                         //Big Academy
                tasks.Add(new Task("Big Academy", "You go for a tour and the facilities are amazing but you never meet the coach or even see the manager", "Continue", 54));
                player.GetRelationship(6).SetBond(5);
                player.GetRelationship(4).SetBond(5);
                player.IncStat(11, 20);
                break;
            case 4:                                                         //Small Academy
                tasks.Add(new Task("Small Academy", "You go for a tour, the facilities are underwhelming but the manager comes over, shakes your hand and calls you by name. The coach also takes a break from his session to come say hello", "Continue", 54));
                player.GetRelationship(6).SetBond(10);
                player.GetRelationship(4).SetBond(10);
                player.IncStat(11, -20);
                break;
            case 5:                                                                             //Coaches Agent
                player.GetRelationship(0).SetBond(3);
                player.GetRelationship(5).SetBond(-2);
                player.GetRelationship(7).SetBond(5);
                break;
            case 6:                                                                             //Sporty parents agent
                player.GetRelationship(0).SetBond(-2);
                player.GetRelationship(5).SetBond(3);
                player.GetRelationship(7).SetBond(5);
                break;
            case 7:                                                                             //School friends
                tasks.Add(new Task("School friends", "It's nice to see your friends again and playing with them makes you feel unbelievably confident in your footballing ability", "Continue", 54));
                player.GetRelationship(4).SetBond(-2);
                player.GetRelationship(3).SetBond(5);
                player.IncStat(14, 50);
                break;
            case 8:                                                                             //Academy friends
                tasks.Add(new Task("Academy friends", "Playing with your team mates is fun and incredibly competitive. You realise you have a long way to go and feel more motivated than before", "Continue", 54));
                player.GetRelationship(4).SetBond(5);
                player.GetRelationship(3).SetBond(-2);
                player.IncStat(11, 30);
                break;
            case 9:                                                                             //Set Partner to male
                player.GetRelationship(2).SetMale(true);                
                //Debug.Log(player.GetRelationship(2).GetName());
                break;
            case 10:                                                                           //Set partner to female
                player.GetRelationship(2).SetMale(false);
                break;
            case 11:
                //player.GetRelationship(2).SetName(btnm.SubmitIField(2));
                relationshipInQuestion = 2;
                //Debug.Log("RelationshipIQ set up");
                break;
            case 12:                                                                           //Taking a football on holiday with you.
                player.IncStat(11, 5);
                player.GetRelationship(0).SetBond(1);
                player.GetRelationship(1).SetBond(-2);
                int i = Random.Range(0, 1);
                if (i == 1)
                {
                    tasks.Add(new Task(10, "Football with randoms", "Having taken your football with you on holiday, you head to the local park where some lads are playing football. Do you try to play with them? \n\n A.Yes \n\n B.No", 5, "A", "B", 52, 53));
                }
                break;
            case 13:                                                                            //Not taking a football on holiday with you.
                player.IncStat(11, -3);
                player.GetRelationship(0).SetBond(5);
                player.GetRelationship(1).SetBond(5);
                break;
            case 14:                                                                            //Ask them out
                tasks.Add(new Task("Dating", "You chat to " + player.GetRelationship(2).GetName() + " for five minutes trying to work up the courage to ask them out. They get bored of waiting and ask you out instead, you eagerly say yes. Mission passed", "Continue", 54));
                player.GetRelationship(2).SetDating(true);
                player.GetRelationship(2).SetBond(5);
                break;
            case 15:                                                                            //Me
                tasks.Add(new Task("Press interaction", "This is one of your first interactions with the press, everything you tell them will reach the ears of your fans. Be careful what you say to them!", "Continue", 54));
                player.GetRelationship(3).SetBond(5);
                player.GetRelationship(4).SetBond(-1);
                player.GetRelationship(6).SetBond(-3);
                player.IncStat(11, 5);
                break;
            case 16:                                                                            //Manager
                tasks.Add(new Task("Press interaction", "This is one of your first interactions with the press, everything you tell them will reach the ears of your fans. Be careful what you say to them!", "Continue", 54));
                player.GetRelationship(3).SetBond(-3);
                player.GetRelationship(4).SetBond(1);
                player.GetRelationship(6).SetBond(5);
                break;
            case 17:                                                                            //Team
                tasks.Add(new Task("Press interaction", "This is one of your first interactions with the press, everything you tell them will reach the ears of your fans. Be careful what you say to them!", "Continue", 54));
                player.GetRelationship(3).SetBond(-3);
                player.GetRelationship(4).SetBond(5);
                player.GetRelationship(6).SetBond(1);
                break;
            case 18:
                tasks.Add(new Task("Consequences", "You get a call from your academy manager. He's seriously mad, he tells you that you aren't taking this seriously and that you no longer have a place at this academy once the season is over", "Continue", 54));
                player.SetFootballInterest(false);
                //parents evening
                break;
            case 19:
                tasks.Add(new Task("Consequences", "You get home from the game and " + player.GetRelationship(1).GetName() + " is furious, 'you don't even come to your own parents evening!' Why do you even bother with school, you may aswell not go!", "Continue", 54));
                player.SetFootballInterest(true);
                //Football game
                break;
            case 20:
                //Go to buying the game
                Application.OpenURL("https://discord.gg/yyJcGW8");
                tasks.Add(new Task(52, "End of Tutorial", "We want to say a big THANKYOU!\n You have reached the end of our demo, we hope you have enjoyed it! \n\n Coming up for the games final release:\n> Manage an ESports team\n>Compete in the Euros and Champions league\n>Play for your own chosen Country\n>And much more!!!", 52, "Join our discord", "Give Feedback", "No Thanks", 20, 21, 22));
                break;
            case 21:
                //Go to reviewing the game and links to social media and stuff
                Application.OpenURL("https://www.surveymonkey.co.uk/r/HZPYKJK");
                tasks.Add(new Task(52, "End of Tutorial", "We want to say a big THANKYOU!\n You have reached the end of our demo, we hope you have enjoyed it! \n\n Coming up for the games final release:\n> Manage an ESports team\n>Compete in the Euros and Champions league\n>Play for your own chosen Country\n>And much more!!!", 52, "Join our discord", "Give Feedback", "No Thanks", 20, 21, 22));
                break;
            case 22:
                //Block the rest of the game off
                Application.Quit();
                break;
            case 23:
                tasks.Add(new Task(2, "Which pet", "You find yourself with a choice of three pets: \n\n A.Dog \n\n B.Cat \n\n C.Axolotl", 3, "A", "B", "C", 27, 26, 28));
                break;
            case 24:
                tasks.Add(new Task(2, "Where next", "You find yourself further inside of the pet shop unsure of where to go next? \n\n A.Go left \n\n B.Go towards the center  \n\n C.Go right", 3, "A", "B", "C", 31, 32, 30));
                break;
            case 25:
                tasks.Add(new Task(2, "Which pet", "You find yourself with a choice of three pets: \n\n A.Goldfish \n\n B.Rabbit \n\n C.Blue Hedgehog", 3, "A", "B", "C", 26, 26, 28));
                break;
            case 26:
                tasks.Add(new Task(2, "What are they called", "Having chosen your pet you face what is now possibly an even more difficult task... What do you name them?", 2, "Name them", 54, true));                
                relationshipInQuestion = 9;
                allStory = new AllStory(player);
                player.GetRelationship(9).SetBond(20);
                //set stats to the stats of a tier 1 pet   
                break;
            case 27:
                tasks.Add(new Task(2, "What are they called", "Having chosen your pet you face what is now possibly an even more difficult task... What do you name them?", 2, "Name them", 54, true));                
                relationshipInQuestion = 9;
                allStory = new AllStory(player);
                player.GetRelationship(9).SetBond(40);
                //set stats to the stats of a tier 2 pet
                break;
            case 28:
                tasks.Add(new Task(2, "What are they called", "Having chosen your pet you face what is now possibly an even more difficult task... What do you name them?", 2, "Name them", 54, true));                
                relationshipInQuestion = 9;
                allStory = new AllStory(player);
                player.GetRelationship(9).SetBond(60);
                //set stats to the stats of a tier 3
                break;
            case 29:
                tasks.Add(new Task(2, "What are they called", "Having chosen your pet you face what is now possibly an even more difficult task... What do you name them?", 2, "Name them", 54, true));
                allStory = new AllStory(player);
                relationshipInQuestion = 9;
                player.GetRelationship(9).SetBond(80);
                
                //set stats to the stats of a tier 4
                break;
            case 30:
                tasks.Add(new Task(2, "Which pet", "You find yourself with a choice of three pets: \n\n A.Tarantula \n\n B.Snake \n\n C.A barrel throwing Gorilla", 3, "A", "B", "C", 26, 26, 28));
                break;
            case 31:
                tasks.Add(new Task(2, "Which pet", "You find yourself with a choice of three pets: \n\n A.Parrot \n\n B. Lizard \n\n C.A falcon wearing boxing gloves", 3, "A", "B", "C", 27, 26, 28));
                break;
            case 32:
                tasks.Add(new Task(2, "Deeper into the store", "You find yourself further inside of the pet shop unsure of where to go next? \n\n A.Go left \n\n B.Go towards the center \n\n C.Go right", 3, "A", "B", "C", 35, 34, 33));
                break;
            case 33:
                tasks.Add(new Task(2, "Which pet", "You find yourself with a choice of three pets: \n\n A.Ants \n\n B.Rat \n\n C.A worm holding a bazuka", 3, "A", "B", "C", 27, 26, 28));
                break;
            case 34:
                tasks.Add(new Task(2, "Which pet", "You find yourself with a choice of three pets: \n\n A.Frog \n\n B.Hamster \n\n C.Three headed dog that loves music", 3, "A", "B", "C", 26, 27, 28));
                break;
            case 35:
                tasks.Add(new Task(2, "Even deeper into the store", "You find yourself further inside of the pet shop unsure of where to go next? \n\n A.Go left \n\n B.Go towards the center \n\n C.Go right", 3, "A", "B", "C", 38, 36, 37));
                break;
            case 36:
                tasks.Add(new Task(2, "Which pet", "You find yourself with a choice of three pets: \n\n A.Guinea Pig \n\n B.Ferret \n\n C.A penguin holding a sign which says 'Your account has been banned'", 3, "A", "B", "C", 26, 26, 28));
                break;
            case 37:
                tasks.Add(new Task(2, "In the center of the store", "You find yourself with a choice of three pets: \n\n A.A little animal with a blue shirt and green hair walking towards the edge... \n\n B.An ugly duck \n\n C.A fish wielding a trident", 3, "A", "B", "C", 26, 29, 26));
                break;
            case 38:
                tasks.Add(new Task(2, "Which pet", "You find yourself with a choice of three pets: \n\n A.Fox \n\n B.Starfish \n\n C.A little purple dragon", 3, "Fox", "Starfish", "A little purple dragon", 27, 27, 28));
                break;
            case 39:
                tasks.Add(new Task(50, "Call from the manager", "Just as you arrive home after parents evening your phone starts to ring. You answer " + player.GetName() + "I can't have you missing these games anymore. You need to decide right now. Football or School", 2, "Football", "School", 39, 40));
                break;
            case 40:
                tasks.Add(new Task(50, "Talk with" + player.GetRelationship(1).GetName(), "Just as you get home" + player.GetRelationship(1).GetName() + "sits you down" + player.GetName() + "we have to talk about your studies. you aren't trying hard enough. You need to choose now, Football or School", 2, "Football", "School", 39, 40));
                break;
            case 41:                                                                        //Do nothing when you see the robber
                tasks.Add(new Task("Staying safe", "You don't give chase because the guy could have a knife and it's not safe. You go to see how the lady is doing", "Continue", 54));
                player.GetRelationship(1).SetBond(5);
                player.GetRelationship(3).SetBond(-5);
                break;
            case 42:                                                                        //Give chase when you see the robber
                if (player.GetStatLevel(1) > 25)
                {
                    tasks.Add(new Task("Run forest Run!", "You begin to catch up with the robber! He see's you catching him and he decides to throw the bag over a fence and run off. You go and fetch the bag and take it back to the women, she's very greatful", "Continue", 54));
                    player.GetRelationship(1).SetBond(-5);
                    player.GetRelationship(3).SetBond(5);
                }
                else
                {
                    tasks.Add(new Task("Run forest Run!", "You chase the robber for a while but you begin to tire. Eventually he turns down a few alleys and you lose him. You dejectedly head back to the lady and apologise for not getting her bag. She is greatful you tried to help", "Continue", 54));
                    player.GetRelationship(1).SetBond(-5);
                    player.GetRelationship(3).SetBond(3);
                }
                break;
            case 43:                                                                        //Kick your football at the robber
                if (player.GetStatLevel(5) > 22)
                {
                    tasks.Add(new Task("Nice shot", "You kick your football and it flies straight and true and hits the robber at full power right on his arm. He drops the purse in surprise and then runs off! People will here about this", "Continue", 54));
                    player.GetRelationship(3).SetBond(5);
                }
                else
                {
                    tasks.Add(new Task("Nice accuracy", "You kick your football and it flies straight and true straight into the lady's face, the robber runs off into the distance. You panic and run away leaving your football. People will here about this", "Continue", 54));
                    player.GetRelationship(3).SetBond(-5);
                }

                break;
            case 44:                  // TODO:: Don't need now                                  //Your mum
                player.GetRelationship(0).SetName(player.GetMumsName());
                player.GetRelationship(0).SetTitle("Mum");                
                player.GetRelationship(1).SetName(player.GetDadsName());
                player.GetRelationship(1).SetTitle("Dad");
                allStory = new AllStory(player);
                tasks.Add(new Task("Choices", "Euro Journey 2020 has many choices that you'll have to make. These choices will all impact different things, for now you've just chosen that your " + player.GetRelationship(0).GetTitle() + " will be your sporty parent! and your " + player.GetRelationship(1).GetTitle() + " will be your non-sporty parent", "Continue", 54));
                break;
            case 45:                     // TODO:: Don't need now                                //Your Dad                   
                player.GetRelationship(0).SetName(player.GetDadsName());
                player.GetRelationship(0).SetTitle("Dad");                
                player.GetRelationship(1).SetName(player.GetMumsName());
                player.GetRelationship(1).SetTitle("Mum");
                allStory = new AllStory(player);
                tasks.Add(new Task("Choices", "Euro Journey 2020 has many choices that you'll have to make. These choices will all impact different things, for now you've just chosen that your " + player.GetRelationship(0).GetTitle() + " will be your sporty parent! and your " + player.GetRelationship(1).GetTitle() + " will be your non-sporty parent", "Continue", 54));
                break;
            case 46:                                                    //Yeah I'd love to play in the staff vs student game
                tasks.Add(new Task("Student VS Staff", "You join in with the game, you have a nervy start. But soon your superior skill begins to show, you score twice and the students cruise to victory with you as their captain", "Continue", 54));
                player.GetRelationship(3).SetBond(5);
                player.GetRelationship(5).SetBond(-3);
                player.IncStat(11, 50);
                break;
            case 47:                                                    //No thanks I can't play in the staff vs student game
                tasks.Add(new Task("Student VS Staff", "You officiate the game and you watch your team lose, the staffs physicality is too much your team to handle. Your fellow students look mad that you didn't play", "Continue", 54));
                player.GetRelationship(3).SetBond(-5);
                player.GetRelationship(5).SetBond(4);
                player.GetRelationship(6).SetBond(3);
                player.IncStat(11, -30);
                break;
            case 48:            //Join in with the breakfast club
                tasks.Add(new Task("Breakfast club", "You join in with the other five and become great friends. As you are leaving for the day it feels like music should be playing in the background...", "Continue", 54));
                player.GetRelationship(3).SetBond(5);
                player.IncStat(11, 50);
                break;
            case 49:            //Tell the breakfast club to quiet down
                tasks.Add(new Task("No breakfast club", "You sit and stay quiet for the day, you watch the other five run and around and have a great time. You feel like this could almost be a film...", "Continue", 54));
                player.GetRelationship(0).SetBond(5);
                player.GetRelationship(1).SetBond(5);
                player.IncStat(11, -20);
                break;
            case 50:                                                                    //Go to Aunt's birthday
                tasks.Add(new Task("Motivation destroyer", "You go to the party and spend the entire time listening to how playing football isn't a real career... Time well spent", "Continue", 54));
                player.IncStat(11, -50);
                player.IncStat(13, 50);
                player.GetRelationship(1).SetBond(3);
                player.GetRelationship(0).SetBond(-2);
                break;
            case 51:                                                                    //Don't go to Aunt's birthday
                tasks.Add(new Task("Thanks Son", "Your " + player.GetRelationship(0).GetTitle() +  " offers to stay at home with you so your " + player.GetRelationship(1).GetTitle() + " can go to the party. As soon as your " + player.GetRelationship(1).GetTitle() + " leaves your " + player.GetRelationship(0).GetTitle() + " comes and thanks you, he gives you £20 and says 'never liked her anyway'", "Continue", 54));                
                player.IncStat(11, 50);
                player.IncMoney(20);
                player.GetRelationship(1).SetBond(-3);
                player.GetRelationship(0).SetBond(3);
                break;
            case 52:                                                                    //Go to rivals birthday                
                if (player.GetStat(3) < 25)
                {
                    tasks.Add(new Task("Football with " + player.GetRelationship(8).GetName() + " friends", "Having decided to play with them, they quickly recognise you are more skilled than them. The game gets so physical you stop in case you get injured. You leave the game feeling less motivated", "Continue", 54));
                    player.IncStat(11, -10);
                    player.GetRelationship(8).SetBond(5);
                }
                else
                {
                    tasks.Add(new Task("Football with " + player.GetRelationship(8).GetName() + " friends", "Having decided to play with them, they quickly recognise you are more skilled than them. The game gets physical but you are strong enough to hold them off and school them all over the pitch", "Continue", 54));
                    player.IncStat(11, 50);
                    player.GetRelationship(8).SetBond(-5);
                }
                break;
            case 53:                                                                    //Don't go to rivals birthday
                player.IncStat(11, -2);
                player.GetRelationship(8).SetBond(-5);
                break;
            case 54:
                                                                                        //Continue on as if nothing. Barely an inconvience
                break;
            case 55:                                                                    //Player decides to have a takeAway
                tasks.Add(new Task("Takeaway", "You have a lovely evening with your parents, you definitely get the protein you need. But maybe more fat than was ideal, you'll notice this on the pitch", "Continue", 54));
                player.IncStat(11, -30);
                player.IncStat(1, -20);
                player.IncStat(3, 50);
                player.GetRelationship(0).SetBond(5);
                player.GetRelationship(1).SetBond(5);
                break;
            case 56:                                                                    //Player spends own money to do his own thing.
                tasks.Add(new Task("Home cooking", "You end up cooking for yourself, it costs you some extra money but you'll see the benefit", "Continue", 54));
                player.IncStat(11, 50);
                player.IncStat(1, 10);
                player.IncStat(2, 10);
                player.IncMoney(-20);
                break;
            case 57:                                                                                        //Laugh about it and wait for them to return your shoes
                tasks.Add(new Task("Laugh it off", "The team eventually give up and end up just giving you your shoes back. You realise it's easy to brush things off", "Continue", 54));
                player.IncStat(14, 50);                                                 //Confidence goes up
                player.IncStat(10, -50);                                                //Aggression goes down
                break;
            case 58:                                                                                       //Get angry and demand your shoes back
                tasks.Add(new Task("Get angry", "The team laugh at how angry you get, they tease you for a while and then eventually give your shoes back. They won't like you when you are angry", "Continue", 54));
                player.IncStat(14, -50);                                                //Confidence goes down
                player.IncStat(10, 50);                                                 //Aggression goes Up
                break;
            case 59:                                                                                        //Walk home without shoes
                tasks.Add(new Task("Long shoeless walk", "One of your teammates ends up chasing you  in order to give you your shoes back. You laugh about it and then set off home. The team thought you were pretty funny", "Continue", 54));
                player.IncStat(14, 80);                                                 //Confidence goes up
                player.IncStat(10, -20);                                                //Aggression goes down
                player.GetRelationship(4).SetBond(5);
                break;
            case 60:
                tasks.Add(new Task("Gaming Era", "You ask Ellis about this new game. He's very keen to chat to you about it. He tells you to add him when you get back", "Continue", 54));  
                //Make Ellis a usable player
                btnm.SetLaptopFlashing();
                //Mini Game Set computer to flash
                break;
            case 61:
                btnm.SetLaptopFlashing();
                //Mini Game Set computer to flash
                break;
            case 62:                                                                        //New player, go and say hello
                tasks.Add(new Task("Freekick Maestro", "Turns out the new player is a freekick specialist, he shows you a few things in training and your freekicks have definitely improved", "Continue", 54));
                player.IncStat(14, 50);
                player.IncStat(7, 30);                                                                            
                break;                                                                                            
            case 63:                                                                        //New player show him how tough the league is
                tasks.Add(new Task("Rough housing", "The other player is incredibly skilful so you use your brawn to show him a thing or two. He starts to pass the ball more and avoid you whenever possible.", "Continue", 54));
                player.IncStat(10, 50);
                player.IncStat(11, 20);
                break;
            case 64:                                                                        //New player ignore him and do your thing
                tasks.Add(new Task("Impressed", "The new player comes and talks to you after training. He says it's refreshing to see another hard worker at training and he looks forward to being in the same team one day", "Continue", 54));
                player.IncStat(11, 50);                                                     
                player.GetRelationship(4).SetBond(5);
                break;
            case 65:                                                                        //Thank the mechanic
                tasks.Add(new Task("You thank the mechanic", "You know your mum will pay him so you thank him for doing his job. He tells you that you are welcome and then heads out", "Continue", 54));
                player.GetRelationship(3).SetBond(5);                
                break;
            case 66:                                                                        //Tip the mechanic
                tasks.Add(new Task("Thanks", "The mechanic is truly greatful! He heads out and your wallet is a little lighter for it", "Continue", 54));
                player.GetRelationship(3).SetBond(10);
                player.SetMoney(-10);                
                break;
            case 67:                                                                        //Give the mechanic an autograph
                tasks.Add(new Task("New Teammate", "As the mechanic thanks you for the autograph he sees you loading up the game! No way " + player.GetName() + " I play too! Make sure you add me", "Continue", 54));
                player.GetRelationship(3).SetBond(10);
                //Make the mechanic a usable player                
                break;
            case 68:                                                                                 //Be my adoring fan
                tasks.Add(new Task("New Fan", "Looks like you've managed to get yourself one truly dedicated fan", "Continue", 54));
                player.GetRelationship(3).SetBond(5);
                player.IncStat(14, 40);               
                break;
            case 69:                                                                               //Are you ok mate?
                tasks.Add(new Task("Who even was that?", "Seriously who even was that?", "Continue", 54));
                player.GetRelationship(3).SetBond(-5);
                player.IncStat(12, 40);                                                                                             
                break;
            case 70:                                                                            //Clean your boots
                tasks.Add(new Task("Easy clean", "The dirt comes off really easily and you quickly get your boots sparkling clean", "Continue", 54));
                player.GetRelationship(3).SetBond(2);
                player.GetRelationship(0).SetBond(-2);
                player.GetRelationship(1).SetBond(2);
                player.IncStat(11, 40);                                                                                                
                break;                                                                                                
            case 71:                                                                            //Clean your boots tomorrow
                tasks.Add(new Task("Encrusted dirt", "You have to scrub your boots harder and for longer than you would have yesterday, but atleast it's done now", "Continue", 54));
                player.GetRelationship(3).SetBond(-2);
                player.GetRelationship(0).SetBond(-2);
                player.GetRelationship(1).SetBond(2);
                player.IncStat(11, -10);
                player.IncStat(14, 30);
                break;
            case 72:                                                                            //See Partner
                tasks.Add(new Task("You chose wisely", "You see your partner, you have a lovely time and feel much better after seeing them. You rush off to training afterwards trying not to be too late", "Continue", 54));
                player.GetRelationship(2).SetBond(5);
                player.GetRelationship(4).SetBond(-2);
                player.GetRelationship(5).SetBond(-2);
                player.GetRelationship(6).SetBond(-2);
                break;
            case 73:                                                                            //Don't see Partner
                tasks.Add(new Task("I'm fine", "You try to call after training, but you are told there's nothing to worry about because they are fine", "Continue", 54));
                player.GetRelationship(2).SetBond(-5);
                player.GetRelationship(4).SetBond(2);
                player.GetRelationship(5).SetBond(2);
                player.GetRelationship(6).SetBond(2);
                break;
            case 74:                                                                            //Right door escape room
                tasks.Add(new Task("Wrong door", "You pick the wrong door, you vow never to let it happen again. You feel more motivated after your loss", "Continue", 54));
                player.IncStat(10, 40);
                player.IncStat(11, 20);
                break;
            case 75:                                                                            //Left door escape room
                tasks.Add(new Task("Right door", "You leap into action and manage to get to the door with speed you didn't know you had. You feel like you've gotten faster. Your team wins the £50 reward for fastest time of the week", "Continue", 54));
                player.IncStat(1, 40);
                player.IncStat(2, 40);
                player.IncMoney(50);
                break;
            case 76:                                                                           //Try and win eating contest
                if (player.GetStat(3) > 25)
                {
                    player.IncStat(3, 100);
                    player.GetRelationship(3).SetBond(3);
                    tasks.Add(new Task("God of food", "No one can come close, you demolish plate after plate. When everyone finally gives up you go up for more just to show you can", "Continue", 54));
                }
                else
                {
                    player.IncStat(3, 50);
                    player.GetRelationship(3).SetBond(3);
                    tasks.Add(new Task("Food coma", "You eat until you are going to be sick, but to be honest you just couldn't keep up with your mum and your uncle who are dueling for the metaphorical food crown. You go find a sofa to sleep through this food coma", "Continue", 54));
                }

                break;
            case 77:                                                                           //Ignore the eating competition
                tasks.Add(new Task("Weight watching", "You don't join in the competition... Is it cause of fear? The family call you a chicken for the next five minutes before they forget about it", "Continue", 54));
                player.IncStat(1, 20);
                player.IncStat(11, 30);
                player.GetRelationship(3).SetBond(-3);
                break;
            case 78:
                tasks.Add(new Task("You chose poorly", "You spend the entire evening having to apologise to your mother for your unneccessary sass, she was only trying to help after all", "Continue", 54));
                player.IncStat(11, -20);
                //Thank her sarcastically
                break;
            case 79:
                tasks.Add(new Task("You chose wisely", "Your mum allows you to walk free this time", "Continue", 54));
                player.IncStat(2, 50);
                //Brush it off
                break;
            case 80:
                tasks.Add(new Task("Less fans", "Your fans hear about the fact you didn't speak on the radio. They are disappointed with your decision", "Continue", 54));
                player.GetRelationship(3).SetBond(-5);
                player.IncStat(11, 10);
                //Politely decline radio
                break;
            case 81:
                tasks.Add(new Task("More fans", "You speak honestly about your love for football and hopes for the future. You hope to have gained some new fans", "Continue", 54));
                player.GetRelationship(3).SetBond(5);
                //Do a radio bit
                break;
            case 82:
                if (player.GetRelationship(5).GetBondToPlayer() > 55)
                {
                    tasks.Add(new Task("Next day", "The coach calls you into the office and tells you that he's sorted you out a computer sponsorship with a friend of his and he says he's got you a great deal. 'One of the team told me your PC is old'", "Continue", 54));
                    player.SetHasSponsorAtPos(2, true);
                    player.SetIncomeAtPos(2, 70);
                }
                //Decline PC sponsorship
                break;
            case 83:
                tasks.Add(new Task("Bit by bit", "You've managed to secure yourself a PC sponsorship!", "Continue", 54));
                player.SetHasSponsorAtPos(2, true);
                //Accept PC sponsorship
                break;
            case 84:
                player.SetHasSponsorAtPos(2, true);
                if (player.GetStatLevel(14) > 25)
                {
                    player.SetIncomeAtPos(2, 50);
                    tasks.Add(new Task("More money", "The computer company are really impressed with your attitude and your agent. They agree to give you an income of  £50 a week", "Continue", 54));
                }
                //Ask for an income PC sponsorship
                break;
            case 85:                                                                                                //refuse boots sponsorship
                if (player.GetRelationship(6).GetBondToPlayer() > 55)
                {
                    tasks.Add(new Task("Next day", "The manager calls you into the office and tells you that he's sorted you out a boots sponsorship with a friend of his and he says he's got you a great deal", "Continue", 54));
                    player.SetHasSponsorAtPos(0, true);
                    player.SetIncomeAtPos(0, 70);
                }
                break;
            case 86:                                                                                                //Get boots sponsorship
                tasks.Add(new Task("Bootiful oppurtunity", "You've managed to secure yourself a boots sponsorship", "Continue", 54));
                player.SetHasSponsorAtPos(0, true);
                break;
            case 87:                                                                                                //Get boots sponsorship and ask for money
                player.SetHasSponsorAtPos(0, true);
                if (player.GetStatLevel(14) > 25)
                {
                    player.SetIncomeAtPos(0, 50);
                    tasks.Add(new Task("More money", "The boots company are really impressed with your attitude and your agent. They agree to give you an income of  £50 a week", "Continue", 54));
                }
                else
                    tasks.Add(new Task("Nope Nope", "The boots company aren't convinced by you and your agent. They tell you they can't spare the funds. Your agent accepts the deal", "Continue", 54));
                break;
            case 88:                                                                                                //Sponsorship with Nike
               if (player.GetStatLevel(14) > 25)
                {                    
                    i = player.GetIncomeAtPos(0);
                    if (i == 0)
                        i = 10;
                    player.SetIncomeAtPos(0, (i * 8));
                    tasks.Add(new Task("More money", "Niky have told me to secure you at all costs. We think you could be a superstar one day. I'll offer you eight times what you are getting now. You and your agent sign immediately ", "Continue", 54));
                }
               else
                {
                    i = player.GetIncomeAtPos(0);
                    if (i == 0)
                        i = 10;
                    player.SetIncomeAtPos(0, (i * 5));
                    tasks.Add(new Task("More money", "Niky have told me to secure you. We think you could be a star one day. I'll offer you five times what you are getting now. You and your agent sign immediately ", "Continue", 54));
                }
                break;
            case 89:                                                                                                //Old boots sponsorship
                tasks.Add(new Task("Old sponsor meeting", "Niky have told me they want to sponsor me, I wanted to come to you first. Your old sponsor tells you sales have boomed and they can offer you ten times what they originally offered you", "Continue", 54));
                i = player.GetIncomeAtPos(0);
                if (i == 0)
                    i = 10;
                player.SetIncomeAtPos(0, (i * 10));
                break;
            case 90:                                                                                                //Decline car
                if (player.GetRelationship(8).GetBondToPlayer() > 55)
                {
                    tasks.Add(new Task("Next day", "Your rival calls you an tells you that he's sorted you out a car sponsorship with a friend of his and he says he's got you a great deal", "Continue", 54));
                    player.SetHasSponsorAtPos(3, true);
                    player.SetIncomeAtPos(3, 70);
                }
                break;
            case 91:                                                                                                //Accept car
                tasks.Add(new Task("Wheely good deal", "You've managed to secure yourself a car sponsorship!", "Continue", 54));
                player.SetHasSponsorAtPos(3, true);
                break;
            case 92:                                                                                                //Ndidia sponsorship
                if (player.GetStatLevel(14) > 25)
                {
                    i = player.GetIncomeAtPos(2);
                    if (i == 0)
                        i = 10;
                    player.SetIncomeAtPos(2, (i * 8));
                    tasks.Add(new Task("More money", "Ndidia have told me to secure you at all costs. We think you could be a superstar one day. I'll offer you eight times what you are getting now. You and your agent sign immediately ", "Continue", 54));
                }
                else
                {
                    i = player.GetIncomeAtPos(2);
                    if (i == 0)
                        i = 10;
                    player.SetIncomeAtPos(2, (i * 5));
                    tasks.Add(new Task("More money", "Ndidia have told me to secure you. We think you could be a star one day. I'll offer you five times what you are getting now. You and your agent sign immediately ", "Continue", 54));
                }
                break;
            case 93:                                                                                                //Old computer sponsorship
                tasks.Add(new Task("Old sponsor meeting", "Niky have told me they want to sponsor me, I wanted to come to you first. Your old sponsor tells you sales have boomed and they can offer you ten times what they originally offered you", "Continue", 54));
                i = player.GetIncomeAtPos(0);
                if (i == 0)
                    i = 10;
                player.SetIncomeAtPos(0, (i * 10));
                break;
            case 94:
                break;
            case 95:                                                                                                //Decline Watch Sponsorship
                if (player.GetRelationship(3).GetBondToPlayer() > 55)
                {
                    tasks.Add(new Task("Next day", "Your agent calls you and informs you a fan has reached out and offered you a watch sponsorship and £70 a week. Your agent agreed on your behalf", "Continue", 54));
                    player.SetHasSponsorAtPos(1, true);
                    player.SetIncomeAtPos(0, 70);
                }
                break;
            case 96:                                                                                                //Agree
                tasks.Add(new Task("They better watch out", "You've secured yourself a watch sponsorship!", "Continue", 54));
                player.SetHasSponsorAtPos(1, true);
                break;
            case 97:                                                                                                //Ask for money
                if (player.GetStatLevel(14) > 25)
                {
                    player.SetIncomeAtPos(0, 50);
                    tasks.Add(new Task("More money", "The watch maker is really impressed with your attitude and your agent. They agree to give you an income of  £50 a week", "Continue", 54));
                    player.SetHasSponsorAtPos(1, true);
                }
                else
                    tasks.Add(new Task("Nope Nope", "The watch maker isn't convinced by you and your agent. They tell you they can't spare the funds. Your agent accepts the deal", "Continue", 54));
                break;                
            case 98:                                                                                                //Accept Caso
                if (player.GetStatLevel(14) > 25)
                {
                    i = player.GetIncomeAtPos(1);
                    if (i == 0)
                        i = 10;
                    player.SetIncomeAtPos(1, (i * 8));
                    tasks.Add(new Task("More money", "Caso have told me to secure you at all costs. We think you could be a superstar one day. I'll offer you eight times what you are getting now. You and your agent sign immediately ", "Continue", 54));
                }
                else
                {
                    i = player.GetIncomeAtPos(0);
                    if (i == 0)
                        i = 10;
                    player.SetIncomeAtPos(0, (i * 5));
                    tasks.Add(new Task("More money", "Caso have told me to secure you. We think you could be a star one day. I'll offer you five times what you are getting now. You and your agent sign immediately ", "Continue", 54));
                }
                break;
            case 99:                                                                                                //Decline and meet with watch maker
                tasks.Add(new Task("Old sponsor meeting", "Caso have told me they want to sponsor me, I wanted to come to you first. Your old sponsor tells you sales have boomed and they can offer you ten times what they originally offered you", "Continue", 54));
                i = player.GetIncomeAtPos(1);
                if (i == 0)
                    i = 10;
                player.SetIncomeAtPos(1, (i * 10));
                break;
            case 100:                                                                                               //Accept car and ask for more
                player.SetHasSponsorAtPos(2, true);
                if (player.GetStatLevel(14) > 25)
                {
                    player.SetIncomeAtPos(2, 50);
                    tasks.Add(new Task("More money", "The car dealer was really impressed with your attitude and your agent. They agree to give you an income of  £50 a week", "Continue", 54));
                }
                else
                    tasks.Add(new Task("Nope Nope", "The car dealer wasn't convinced by you and your agent. They tell you they can't spare the funds. Your agent accepts the deal", "Continue", 54));
                break;                
            case 101:                                                                   //Decline Food
                if (player.GetRelationship(3).GetBondToPlayer() > 55)
                {
                    tasks.Add(new Task("Next day", "Your agent calls you and informs you a fan has reached out and offered you a food sponsorship and £70 a week. Your agent agreed on your behalf", "Continue", 54));
                    player.SetHasSponsorAtPos(4, true);
                    player.SetIncomeAtPos(4, 70);
                }
                break;
            case 102:                                                                   //Agree Food
                tasks.Add(new Task("Free food", "You've gone and got yourself a food sponsorship!", "Continue", 54));
                player.SetHasSponsorAtPos(4, true);
                break;
            case 103:                                                                   //Ask for money food
                player.SetHasSponsorAtPos(1, true);
                if (player.GetStatLevel(14) > 25)
                {
                    player.SetIncomeAtPos(0, 50);
                    tasks.Add(new Task("More money", "The local pie maker is really impressed with your attitude and your agent. They agree to give you an income of  £50 a week", "Continue", 54));
                }
                else
                    tasks.Add(new Task("Nope Nope", "The local pie maker isn't convinced by you and your agent. They tell you they can't spare the funds. Your agent accepts the deal", "Continue", 54));
                break;
            case 104:                                                                   //Accept Subway
                if (player.GetStatLevel(14) > 25)
                {
                    i = player.GetIncomeAtPos(4);
                    if (i == 0)
                        i = 10;
                    player.SetIncomeAtPos(4, (i * 8));
                    tasks.Add(new Task("More money", "Subwoy have told me to secure you at all costs. We think you could be a superstar one day. I'll offer you eight times what you are getting now. You and your agent sign immediately ", "Continue", 54));
                }
                else
                {
                    i = player.GetIncomeAtPos(4);
                    if (i == 0)
                        i = 10;
                    player.SetIncomeAtPos(4, (i * 5));
                    tasks.Add(new Task("More money", "Subwoy have told me to secure you. We think you could be a star one day. I'll offer you five times what you are getting now. You and your agent sign immediately ", "Continue", 54));
                }
                break;
            case 105:                                                                   //Go to old pie sponsor
                tasks.Add(new Task("Old sponsor meeting", "Subwoy have told me they want to sponsor me, I wanted to come to you first. Your old sponsor tells you sales have boomed and they can offer you ten times what they originally offered you", "Continue", 54));
                i = player.GetIncomeAtPos(4);
                if (i == 0)
                    i = 10;
                player.SetIncomeAtPos(4, (i * 10));
                break;
            case 106:                                                                   //Check it out later
                tasks.Add(new Task("Esports is back", "Sorry about this, we hope to implement a minigame you can play to build an esports team. It's not in yet... Sorry!", "Continue", 54));
                break;
            case 107:                                                                   //Check it out right now
                tasks.Add(new Task("Esports is back", "Sorry about this, we hope to implement a minigame you can play to build an esports team. It's not in yet... Sorry!", "Continue", 54));
                break;
            case 108:                                                                  //Push for more
                if (player.GetStatLevel(14) > 25)
                {
                    tasks.Add(new Task("Confidence is key", "You come across as confident rather than cocky and you manage to persuade your manager that your wage should be increased", "Continue", 54));
                    player.IncIncome(30);
                }
                else
                    tasks.Add(new Task("Lack of confidence", "You come across as a cocky little kid trying his luck at getting more money, your agent tried his best but your lack of confidence really came across", "Continue", 54));
                break;
            case 109:                                                                   //Accept the Audl offer
                if (player.GetStatLevel(14) > 25)
                {
                    i = player.GetIncomeAtPos(3);
                    if (i == 0)
                        i = 10;
                    player.SetIncomeAtPos(3, (i * 8));
                    tasks.Add(new Task("More money", "Audl have told me to secure you at all costs. We think you could be a superstar one day. I'll offer you eight times what you are getting now. You and your agent sign immediately ", "Continue", 54));
                }
                else
                {
                    i = player.GetIncomeAtPos(3);
                    if (i == 0)
                        i = 10;
                    player.SetIncomeAtPos(3, (i * 5));
                    tasks.Add(new Task("More money", "Audl have told me to secure you. We think you could be a star one day. I'll offer you five times what you are getting now. You and your agent sign immediately ", "Continue", 54));
                }
                break;
            case 110:                                                                  //Old car sponsorship
                tasks.Add(new Task("Old sponsor meeting", "Audl have told me they want to sponsor me, I wanted to come to you first. Your old sponsor tells you sales have boomed and they can offer you ten times what they originally offered you", "Continue", 54));
                i = player.GetIncomeAtPos(1);
                if (i == 0)
                    i = 10;
                player.SetIncomeAtPos(1, (i * 10));
                break;
            case 111:   
                relationshipInQuestion = 8;
                tasks.Add(new Task("Rival Mockery", "The other student responds before you can and says 'Suppose the only thing we need to worry about is whether or not " + player.GetFirstName() + " can keep up with the rest of us!' He laughs as you are dismissed by the headteacher", "Continue", 54));
                break;
            case 112:                                                                   //Push them back
                tasks.Add(new Task("No one pushes me around", "You can't let them get away with that so you push them back, this is just before some of the team seperate the two of you", "Continue", 54));
                player.IncStat(11, 50);
                player.GetRelationship(4).SetBond(-1);
                player.GetRelationship(5).SetBond(-1);
                player.GetRelationship(6).SetBond(-1);                
                break;
            case 113:                                                                   //Walk it off  
                tasks.Add(new Task("High horse", "You look at them and stop yourself from doing anything. You know you did the right thing but you really wanted to push them back...", "Continue", 54));
                player.GetRelationship(4).SetBond(3);
                player.GetRelationship(5).SetBond(3);
                player.GetRelationship(6).SetBond(3);
                break;
            case 114:                                                                   //Player is the most motivated
                if (player.GetStatLevel(11) > 25)
                {
                    tasks.Add(new Task("Motivated", "All of your team laugh and agree. 'That's an understatement!", "Continue", 54));
                    player.IncStat(11, 50);
                }
                else
                {
                    tasks.Add(new Task("Motivated", "All of your team look around at each other nervously. 'Sure you are " + player.GetName() + "'", "Continue", 54));
                    player.IncStat(11, 70);
                }
                break;
            case 115:                                                                   //Someone else is the most motivated
                if (player.GetStatLevel(11) > 25)
                {
                    tasks.Add(new Task("Motivated", "All of your team laugh and disagree. 'It's obviously you " + player.GetName() + "'", "Continue", 54));
                    player.IncStat(11, 100);
                }
                else
                {
                    tasks.Add(new Task("Motivated", "All of your team agree with your assesment. You were hoping they'd say it was you", "Continue", 54));
                    player.IncStat(11, 50);
                }
                break;
            case 116:                                                                   //Inside joke
                tasks.Add(new Task("Inside Joke", "All of your team laugh getting the inside joke immediately, the public loves seeing how well you fit into the team", "Continue", 54));
                player.GetRelationship(3).SetBond(3);
                player.GetRelationship(4).SetBond(3);
                player.GetRelationship(5).SetBond(3);
                player.GetRelationship(6).SetBond(3);
                break;
            case 117:                                                                   //Find who took my phone
                tasks.Add(new Task("Who done it?", "You spend 10 minutes grilling people before you eventually give up... Just as you pick up your stuff to leave you see your phone under your bag. This doesn't go down well", "Continue", 54));                
                player.GetRelationship(4).SetBond(-3);
                break;
            case 118:                                                                   //My phone will turn up
                tasks.Add(new Task("Found it", "You get ready to leave and as you pick your bag up you realise your phone was underneath it, you and the team find this pretty funny", "Continue", 54));
                player.GetRelationship(4).SetBond(3);
                break;
            case 119:                                                                   //Look after pet
                tasks.Add(new Task("Feeling better", "You stay at home to look after your pet. It seems to perk up after some good old TLC!", "Continue", 54));
                player.GetRelationship(3).SetBond(5);
                player.GetRelationship(9).SetBond(5);
                player.GetRelationship(4).SetBond(-1);
                player.GetRelationship(5).SetBond(-2);
                player.GetRelationship(6).SetBond(-2);
                break;
            case 120:                                                                   //Go to training anyway
                tasks.Add(new Task("Glad you came", "Your teammates appreciate you making the effort to come to training. You spend the training thinking about " + player.GetRelationship(9).GetName(), "Continue", 54));
                player.GetRelationship(3).SetBond(-3);
                player.GetRelationship(9).SetBond(-5);
                player.GetRelationship(4).SetBond(3);
                player.GetRelationship(5).SetBond(2);
                player.GetRelationship(6).SetBond(2);
                break;
            case 121:                                                                   //run the training session
                tasks.Add(new Task("Helping hand", "You run the training session for the younger age group, it's a big ego boost. Your " + player.GetRelationship(1).GetTitle() + " thanks you for the help, you then dash off to training", "Continue", 54));
                player.GetRelationship(0).SetBond(-3);
                player.GetRelationship(4).SetBond(-2);
                player.GetRelationship(1).SetBond(3);
                player.GetRelationship(3).SetBond(5);                
                break;
            case 122:                                                                   //Don't be late for training
                tasks.Add(new Task("Made it to training", "Your Manager calls you over part way through training, 'Your dedication is noted " + player.GetName() + " . Now get back to training", "Continue", 54));
                player.GetRelationship(0).SetBond(3);
                player.GetRelationship(3).SetBond(3);
                player.GetRelationship(4).SetBond(2);
                player.GetRelationship(1).SetBond(-3);
                break;
            case 123:                                                                   //Go on a run with your sporty parent
                tasks.Add(new Task("Running day", "You go on a run with your " + player.GetRelationship(0).GetTitle() + ", you have a really nice time and definitely push yourself to keep up with your " + player.GetRelationship(0).GetTitle(), "Continue", 54));
                player.IncStat(0, 50);
                player.IncStat(1, 50);
                player.GetRelationship(0).SetBond(5);
                break;
            case 124:                                                                   //Don't go on a run with your sporty parent
                tasks.Add(new Task("Movie night", "Instead of going running you decide to stay at home, you end up watching a film with your " + player.GetRelationship(1).GetTitle() + ", you have a really nice time and so does your " + player.GetRelationship(1).GetTitle(), "Continue", 54));
                player.GetRelationship(0).SetBond(-1);
                player.GetRelationship(1).SetBond(5);
                break;
            case 125:                                                                   //Don't go to cousins party
                tasks.Add(new Task("Relax", "Instead of going to your cousins birthday, you spend the entire weekend chilling and relaxing", "Continue", 54));
                player.GetRelationship(0).SetBond(-1);
                player.GetRelationship(1).SetBond(-1);
                player.IncStat(14, 20);
                break;
            case 126:                                                                   //Go to cousins party
                tasks.Add(new Task("Cousin's party", "You join you Mum and Dad and go to your cousins party. You have a great time even though you didn't really want to go", "Continue", 54));
                player.GetRelationship(0).SetBond(3);
                player.GetRelationship(1).SetBond(3);
                player.IncStat(11, 30);
                break;
            case 127:                                                                   //Walk home the girl - story
                if (player.GetRelationship(2).GetDating())
                {
                    if (player.GetRelationship(2).GetMale())
                    tasks.Add(new Task("Walking home", "You decide to walk the boy home. You get chatting and find out her name is Alice, she seems very nice. After you reach her house you continue on back towards your house", "Continue", 128));
                    player.GetRelationship(3).SetBond(-3);
                    player.IncStat(14, 50);
                }
                else
                {
                    tasks.Add(new Task("Walking home", "As you are trying to decide what to do the girl spots you staring at her, she sees you and smiles and waves. You wave back she then turns and walks off", "Continue", 129));
                    player.GetRelationship(3).SetBond(-3);
                    player.IncStat(14, 50);
                }
                break;
            case 128:                                                                   //Don't walk the girl home - story
                tasks.Add(new Task("Making headlines", "You get up and head downstairs, you see a newspaper thats been posted through the letter box. You open it up and read the headline, " + player.GetFirstName() + " has been seen on a romantic stroll with someone besides " + player.GetRelationship(2).GetName(), "Continue", 130));
                player.GetRelationship(0).SetBond(-3);
                player.GetRelationship(1).SetBond(-3);
                break;
            case 129:                                                                   //Walked Alice home Newspaper - story
                tasks.Add(new Task("Making headlines", "You get up and head downstairs, you see a newspaper thats been posted through the letter box. You open it up and read the headline, " + player.GetFirstName() + " has been seen stealing glances at someone besides " + player.GetRelationship(2).GetName(), "Continue", 131));
                player.GetRelationship(0).SetBond(-2);
                player.GetRelationship(1).SetBond(-2);
                break;
            case 130:                                                                   //After the romantic stroll
                break;
            case 131:                                                                   //After the stealing glances
                break;
            case 140:                                                                   //Play chess tournament
                tasks.Add(new Task("Sons of Bishops", "You decide that you'll do it. When the day finally comes around you are nervous which surprises you. The tournament has 32 competitors, you find yourself in the first round.", "Continue", 142));
                break;
            case 141:                                                                   //Don't play chess
                if (player.GetChessTourn() == 0)              
                    tasks.Add(new Task("I see what you did there", "You get home and you see your " + player.GetRelationship(1).GetTitle() + ", 'Hey " + player.GetName() + " just to let you know I signed you up for the local chess tournament. You should do something besides football sometimes", "Continue", 140));              
                else
                    tasks.Add(new Task("I don't even like chess", "You decide to relax instead. You watch some TV and chill out a bit, in the end you jump online to watch the stream of the local chess tournament to see who wins this time!", "Continue", 140));
                break;
            case 142:
                if (player.GetChessTourn() == 0)
                    tasks.Add(new Task(1, "Round 32", "You sit down to play your first opponent. You are unsure how they play. How do you want to play? \n\nA.Aggressively \n\nB.Defensively \n\nC.Normally", 1 , "A", "B", "C", 143, 144, 145)); 
                else
                    tasks.Add(new Task(1, "Round 32", "You sit down to play your first opponent. You remember that they have an aggressive style of play. How do you want to play? \n\nA.Aggressively \n\nB.Defensively \n\nC.Normally", 1, "A", "B", "C", 143, 144, 145));
                break;
            case 143:                                                       //Aggressively
                if ((player.GetStat(12) -3) > 25)
                    tasks.Add(new Task("Winning!", "You manage to win the first round, your opponent played aggressively as well. You think you should have played a bit more cautiously but a win is a win!", "Continue", 146));
                else
                    tasks.Add(new Task("Poor pawn", "You lose the first round, you both play aggressively. Your aggression definitely left you open and you made lots of silly mistakes and your opponent capitilised on the mistakes", "Continue", 54));
                break;
            case 144:                                                       //Deffensively
                if ((player.GetStat(12) + 3) > 25)
                    tasks.Add(new Task("Winning!", "You manage to win the first round, your opponent played aggressively. Your defensive style was a perfect counter to his style of play!", "Continue", 146));
                else
                    tasks.Add(new Task("Poor pawn", "You lose the first round, you play deffensively and capitilise on some of his mistakes. Even though you do well at the beginning his skill at the game shows and he eventually beats you", "Continue", 54));
                break;
            case 145:                                                       //Normally
                if (player.GetStatLevel(12) > 25)                   
                    tasks.Add(new Task("Winning!", "You've done it! You've managed to beat them. Your opponent played aggressively and you played normally maybe if you'd played more defensively you could have capitilised more. But it doesn't matter you are through to the next round!", "Continue", 146));
                else                    
                    tasks.Add(new Task("Poor pawn", "You lose the first round, your opponent plays very aggressively and you aren't playing defensively enough to capitilise. Eventually their greater skill helps them beat you", "Continue", 54));
                break;
            case 146:                                                       //Round 16 how do you want to play
                if (player.GetChessProgress() > 16)
                    tasks.Add(new Task(1, "Round 16", "You sit down to play your second opponent. You are unsure how they play. How do you want to play? \n\nA.Aggressively \n\nB.Defensively \n\nC.Normally", 1, "A", "B", "C", 147, 148, 149));
                else
                    tasks.Add(new Task(1, "Round 16", "You sit down to play your second opponent. You remember they have a aggressive play style. How do you want to play? \n\nA.Aggressively \n\nB.Defensively \n\nC.Normally", 1, "A", "B", "C", 147, 148, 149));
                player.IncChessProgress();
                break;
            case 147:                                                       //Round of 16 play aggressive
                if ((player.GetStatLevel(12) - 3) > 45)
                    tasks.Add(new Task("Round 16", "You've done it! You've managed to beat them. You both had an aggressive play style which you don't think helped your cause. But eventually they just made a few more mistakes than you did", "Continue", 150));
                else
                    tasks.Add(new Task("Poor knight", "You lose the second round, you both play aggressively. Your aggression definitely left you open and you made lots of silly mistakes and your opponent capitilised on them", "Continue", 54));
                break;
            case 148:                                                       //Round of 16 play deffensively
                if ((player.GetStatLevel(12) + 3) > 45)
                    tasks.Add(new Task("Round 16", "You've done it! You've managed to beat them. Your opponent played aggressively and your defensive style was a perfect counter. You capitilised on his small mistakes", "Continue", 150));
                else
                    tasks.Add(new Task("Poor knight", "You lose the second round, you play deffensively and capitilise on some of his mistakes. Even though you do well at the beginning his skill at the game shows and he eventually beats you", "Continue", 54));
                break;
            case 149:                                                       //Round of 16 play normally
                if (player.GetStatLevel(12) > 45)
                    tasks.Add(new Task("Round 16", "You've done it! You've managed to beat them. Your opponent played aggressively and you played normally maybe if you'd played more defensively you could have capitilised more. But it doesn't matter you are through to the next round!", "Continue", 150));
                else                    
                    tasks.Add(new Task("Poor knight", "You lose the second round, your opponent plays very aggressively and you aren't playing defensively enough to capitilise. Eventually their greater skill helps them beat you", "Continue", 54));
                break;
            case 150:                                                       //Quarter finals 
                if (player.GetChessProgress() > 8)
                    tasks.Add(new Task(1, "Quarter finals", "You sit down to play your third opponent. You are unsure how they play. How do you want to play? \n\nA.Aggressively \n\nB.Defensively \n\nC.Normally", 1, "A", "B", "C", 151, 152, 153));
                else
                    tasks.Add(new Task(1, "Quarter finals", "You sit down to play your third opponent. You remember they have a defensive play style. How do you want to play? \n\nA.Aggressively \n\nB.Defensively \n\nC.Normally", 1, "A", "B", "C", 151, 152, 153));
                player.IncChessProgress();
                break;
            case 151:                                                       //Quarter final Agressive play style
                if ((player.GetStatLevel(12) + 3) > 65)
                    tasks.Add(new Task("Quarter final", "You've done it! You've managed to beat them. They played very defensively which suited you perfectly, it left lots of space for your aggressive play style. On to the Semis!", "Continue", 154));
                else
                    tasks.Add(new Task("Poor rook", "You lose the Quarter finals, you play aggressively and fall into lots of traps his defensive style creates. You think you choose the right style you just came up against an opponent that was better than you", "Continue", 54));
                break;
            case 152:                                                       //Quarter final Defensive play style
                if ((player.GetStatLevel(12) - 3) > 65)
                    tasks.Add(new Task("Quarter final", "You've done it! You've managed to beat them. Your opponent played defensively your defensive style choice wasn't the best, but in the end your skill carried you through and secured you the win", "Continue", 154));
                else
                    tasks.Add(new Task("Poor rook", "You lose the Quarter finals, you play deffensively but so do they. Your choice to play defensively gives them too much space, it makes it easy for them and they eventually manage to beat you", "Continue", 54));
                break;
            case 153:                                                       //Quarter final Normal play style
                if (player.GetStatLevel(12) > 65)
                    tasks.Add(new Task("Quarter final", "You've done it! You've managed to beat them. Your opponent played defensively and you played normally maybe if you'd played more aggresively you could have capitilised more. But it doesn't matter you are through to the Semi final!", "Continue", 154));
                else
                    tasks.Add(new Task("Poor rook", "You lose the Quarter final, your opponent plays very defensively and you aren't playing aggresively enough to capitilise. Eventually their greater skill helps them beat you", "Continue", 54));
                break;
            case 154:                                                       //Semi Finals
                if (player.GetChessProgress() > 4)
                    tasks.Add(new Task(1, "Semi finals", "You sit down to play your fourth opponent. You are unsure how they play. How do you want to play? \n\nA.Aggressively \n\nB.Defensively \n\nC.Normally", 1, "A", "B", "C", 155, 156, 157));
                else
                    tasks.Add(new Task(1, "Semi finals", "You sit down to play your fourth opponent. You remember they have a defensive play style. How do you want to play? \n\nA.Aggressively \n\nB.Defensively \n\nC.Normally", 1, "A", "B", "C", 155, 156, 157));
                player.IncChessProgress();
                break;
            case 155:                                                       //Semi finals aggressive play style
                if ((player.GetStatLevel(12) + 3) > 80)
                    tasks.Add(new Task("Semi final", "You've done it! You've managed to beat them. They played very defensively which suited you perfectly, it left lots of space for your aggressive play style. On to the Semis!", "Continue", 158));
                else
                    tasks.Add(new Task("Poor Queen", "You lose the Semi finals, you play aggressively and fall into lots of traps his defensive style creates. You think you choose the right style you just came up against an opponent that was better than you", "Continue", 54));
                break;
            case 156:                                                       //Semi finals defensive play style
                if ((player.GetStatLevel(12) - 3) > 80)
                    tasks.Add(new Task("Semi final", "You've done it! You've managed to beat them. Your opponent played defensively your defensive style choice wasn't the best, but in the end your skill carried you through and secured you the win", "Continue", 158));
                else
                    tasks.Add(new Task("Poor Queen", "You lose the Semi finals, you play deffensively but so do they. Your choice to play defensively gives them too much space, it makes it easy for them and they eventually manage to beat you", "Continue", 54));
                break;
            case 157:                                                       //Semi finals normal play style
                if (player.GetStatLevel(12) > 80)
                    tasks.Add(new Task("Semi final", "You've done it! You've managed to beat them. Your opponent played defensively and you played normally maybe if you'd played more aggresively you could have capitilised more. But it doesn't matter you are through to the Semi final!", "Continue", 158));
                else
                    tasks.Add(new Task("Poor Queen", "You lose the Semi final, your opponent plays very defensively and you aren't playing aggresively enough to capitilise. Eventually their greater skill helps them beat you", "Continue", 54));
                break;
            case 158:                                                       //The final
                if (player.GetChessProgress() > 2)
                    tasks.Add(new Task(1, "The Final", "You sit down to play your final opponent. You are unsure how they play. How do you want to play? \n\nA.Aggressively \n\nB.Defensively \n\nC.Normally", 1, "A", "B", "C", 159, 160, 161));
                else
                    tasks.Add(new Task("The Final", "You sit down to play your final opponent. You remember they have a play style unlike any other. How do you want to play? \n\nA.Super secret play style you created to defeat him", "A", 162));
                player.IncChessProgress();
                break;
            case 159:                                                       //Final play aggressive
                if ((player.GetStatLevel(12) - 4) > 94)
                    tasks.Add(new Task("The final", "You've done it! You've managed to beat them. Your opponent played an incredibly strange play style and constantly caught you off guard. But you managed to push through and claw out the victory. Time to go collect your winnings", "Continue", 168));
                else
                    tasks.Add(new Task("Poor King", "You lose the final, you play aggressively and fall into lots of traps his unique style creates. You think you'll need to come up with a new strategy if you want to have any chance of beating them... Next year is my year", "Continue", 167));
                break;
            case 160:                                                       //Final play deffensive
                if ((player.GetStatLevel(12) - 4) > 94)
                    tasks.Add(new Task("The final", "You've done it! You've managed to beat them. Your opponent played an incredibly strange play style and constantly caught you off guard. But you managed to push through and claw out the victory. Time to go collect your winnings", "Continue", 168));
                else
                    tasks.Add(new Task("Poor King", "You lose the final, you play defensively and fall into lots of traps his unique style creates. You think you'll need to come up with a new strategy if you want to have any chance of beating them... Next year is my year", "Continue", 167));
                break;
            case 161:                                                       //Final play Normally
                if (player.GetStatLevel(12) > 94)
                    tasks.Add(new Task("The final", "You've done it! You've managed to beat them. Your opponent played an incredibly strange play style and constantly caught you off guard. But you managed to push through and claw out the victory. Time to go collect your winnings", "Continue", 168));
                else
                    tasks.Add(new Task("Poor King", "You lose the final, you play normally and fall into lots of traps his unique style creates. You think you'll need to come up with a new strategy if you want to have any chance of beating them... Next year is my year", "Continue", 167));
                break;
            case 162:                                                       //Final Super secret play style
                if ((player.GetStatLevel(12) + 5 > 94))
                    tasks.Add(new Task("The final", "You've done it! You've managed to beat them. Your opponent played an incredibly strange play style, but you were ready for it. You've created your own style just for today and it was perfect! Time to go collect your winnings", "Continue", 168));
                else
                    tasks.Add(new Task("The final", "You couldn't do it, you couldn't beat them. Your opponent played an incredibly strange play style, but you were ready for it. You've created your own style just for today and it was perfect! But even your new style wasn't quite good enough to over come them. Next time will be your time", "Continue", 168));
                break;
            case 163:                                                       //Round 32 loss reward
                tasks.Add(new Task("The round 16 loss", "You couldn't do it, you couldn't beat them. But you did manage to come top sixteen which nets you a 10 Duck Dollars! Maybe next year I can do better you think to yourself", "Continue", 54));
                player.IncMoney(10);
                break;
            case 164:                                                       //Round 16 loss reward
                tasks.Add(new Task("The round 16 loss", "You couldn't do it, you couldn't beat them. But you did manage to come top sixteen which nets you a 25 Duck Dollars! Maybe next year I can do better you think to yourself", "Continue", 54));
                player.IncMoney(25);
                break;
            case 165:                                                       //Quarter final loss reward
                tasks.Add(new Task("The Quarter final loss", "You couldn't do it, you couldn't beat them. But you did manage to come top eight which nets you a pretty nice 50 Duck Dollars! Maybe next year I can do better you think to yourself", "Continue", 54));
                player.IncMoney(50);
                break;
            case 166:                                                       //Semi final loss reward
                tasks.Add(new Task("The Semi final loss", "You couldn't do it, you couldn't beat them. But you did manage to come top four which nets you a pretty nice 100 Duck Dollars! Maybe next year I can do better you think to yourself", "Continue", 54));
                player.IncMoney(100);
                break;
            case 167:                                                       //Final loss reward
                tasks.Add(new Task("The final loss", "You couldn't do it, you couldn't beat them. But you did manage to come second which nets you a tasty 150 Duck Dollars! Maybe next year I can do better you think to yourself", "Continue", 54));
                player.IncMoney(150);
                break;
            case 168:                                                       //Winning the final reward
                tasks.Add(new Task("The king's reward", "You did it, you beat them all. Winning yourself the amazing 200 Duck Dollars. As you are about to leave the winner of the chess tournament comes to you and says 'I enjoyed our game today, but I prefer watching your team play football. Take these I hope you can find a use for them", "Continue", 169));
                player.IncMoney(200);
                break;
            case 169:
                tasks.Add(new Task("The King's throne", "You open the box and find an incredible pair of football boots. They are red and black and look incredible, you straight away google the person you played in the chess final. Who even is Stevie G?", "Continue", 54));
                break;
        }
    }
    public void GrabIfieldText()
    {
        player.GetRelationship(relationshipInQuestion).SetName(btnm.GetIFieldText());
        //Debug.Log(relationshipInQuestion);
    }
    public void SetNewspaper(string playerTeam, string oppTeam, int teamGoals, int playerGoals, int oppositionGoals/*, int tournamentID*/)
    {
        playerDesc = "";

        newspaperTitle = playerTeam + "\n| vs |\n" + oppTeam;
        
        if (playerGoals <= 0)
        {
            playerDesc = " was frustrated tonight unable to find the back of the net. Not the impact that they'd have hoped for. ";
        }
        if (playerGoals == 1)
        {
            playerDesc = " was able to find the net once thats all you can ask for. ";
        }
        if(playerGoals == 2)
        {
            playerDesc = " was able to grab a brace today, they had their shooting boots on. The defence couldn't stop them. ";
        }
        if(playerGoals >= 3)
        {
            playerDesc = " was a force on the pitch today, they seemed a level above the rest of the players. They'll be taking the match ball home tonight.";
        }
        int teamWin;
        int choiceNum;
        int goalDiff;
        if ((teamGoals - oppositionGoals) > 0)
        {
            teamWin = 4;
            goalDiff = teamGoals - oppositionGoals;
        }
        else
        {
            teamWin = 4;
            goalDiff = teamGoals - oppositionGoals;
        }
        choiceNum = teamWin + goalDiff;
        if (choiceNum < 1)
        {
            choiceNum = 1;
        }
        if (choiceNum > 7)
        {
            choiceNum = 7;
        }
        switch (choiceNum)
        {
            case 1:
                newspaperBrief = "Woeful performance from " + player.GetTeamName() + ". They never looked like a team capable of wining. They looked more like a sunday league team. They could find themselves with a string of bad results. "  + player.GetName() + playerDesc;
                break;
            case 2:
                newspaperBrief = "Dissapointing performance from " + player.GetTeamName() + ". They were soundly beaten today. They couldn't keep up with the pace of the game. " + player.GetName() + playerDesc ;
                break;
            case 3:
                newspaperBrief = "Close loss for " + player.GetTeamName() + ". They fought hard but couldn't quite get anything from the game. " + player.GetName() + playerDesc;
                break;
            case 4:
                newspaperBrief = "Only a draw for " + player.GetTeamName() + ", for a while it looked like they might be able to squeeze out a result. " + player.GetName() + playerDesc;
                break;
            case 5:
                newspaperBrief = "Close win for " + player.GetTeamName() + ", for a while it looked like it might end all square. " + player.GetTeamName() + "'s grit and determination helped them carve out a result. " + player.GetName() + playerDesc;
                break;
            case 6:
                newspaperBrief = "Convincing win for " + player.GetTeamName() + "." + " " + oppTeam + " were off the pace today. " + player.GetTeamName() + " made them look average. " + player.GetName()  + playerDesc;
                break;
            case 7:
                newspaperBrief = "Big win for " + player.GetTeamName() + "." + " " + oppTeam + " just couldn't handle them. There was a gulf in class between the teams today. " + player.GetName() + playerDesc;
                break;
            
            
        }
        tasks.Add(new Task(newspaperTitle, newspaperBrief));
    }

    public void SavePlayer()
    {
        SaveSytem.SavePlayer(intDate, player.GetMoney(), allStory.GetDilemasLeft(), player.GetStats(), player.GetStatLevels(), player.GetRelationships());
    }
    public void LoadPlayer()
    {
        // save items, dice, levels, 
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            PlayersData data = SaveSytem.LoadPlayer();

            intDate = data._date;
            player.SetMoney(data._money);
            allStory.SetDilemasLeft(data._completeDilemas);
            player.SetStats(data._playerStats);
            player.SetStatLevels(data._playerStatLevels);
            player.SetRelationships(data._playerRelationShips);
           
        }
    }
    public void SetSatWithDad(bool withDad)
    {
        SatWithDad = withDad;
    }
    public bool GetSatWithDad()
    {
        return SatWithDad;
    }
}