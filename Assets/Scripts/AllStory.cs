using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllStory
{
    List<Task> story = new List<Task>();        // list of all Tasks
    List<Task> dilemmas = new List<Task>();
    List<Task> dilemmasLeft;
    readonly List<Task> dilemmasLeftInt = new List<Task>();

    List<Task> sportyParentGoodStory = new List<Task>();
    List<Task> nonSportyParentGoodStory = new List<Task>();
    List<Task> partnerGoodStory = new List<Task>();
    List<Task> fansGoodStory = new List<Task>();
    List<Task> teamGoodStory = new List<Task>();
    List<Task> coachGoodStory = new List<Task>();
    List<Task> managerGoodStory = new List<Task>();
    List<Task> agentGoodStory = new List<Task>();
    List<Task> rivalGoodStory = new List<Task>();
    List<Task> sportyParentBadStory = new List<Task>();
    List<Task> nonSportyParentBadStory = new List<Task>();
    List<Task> partnerBadStory = new List<Task>();
    List<Task> fansBadStory = new List<Task>();
    List<Task> teamBadStory = new List<Task>();
    List<Task> coachBadStory = new List<Task>();
    List<Task> managerBadStory = new List<Task>();
    List<Task> agentBadStory = new List<Task>();
    List<Task> rivalBadStory = new List<Task>();

    List<List<Task>> relationshipGoodStories = new List<List<Task>>();
    List<List<Task>> relationshipBadStories = new List<List<Task>>();

    private MainPlayer player;

    public AllStory(MainPlayer p)           // An archive of all the story and options
    {
        player = p;

        relationshipGoodStories.Add(sportyParentGoodStory );
        relationshipGoodStories.Add(nonSportyParentGoodStory);
        relationshipGoodStories.Add(partnerGoodStory );
        relationshipGoodStories.Add(fansGoodStory);
        relationshipGoodStories.Add(teamGoodStory );
        relationshipGoodStories.Add(coachGoodStory);
        relationshipGoodStories.Add(managerGoodStory);
        relationshipGoodStories.Add(agentGoodStory);
        relationshipGoodStories.Add(rivalGoodStory);

        relationshipGoodStories.Add(sportyParentBadStory);
        relationshipGoodStories.Add(nonSportyParentBadStory);
        relationshipGoodStories.Add(partnerBadStory);
        relationshipGoodStories.Add(fansBadStory);
        relationshipGoodStories.Add(teamBadStory);
        relationshipGoodStories.Add(coachBadStory);
        relationshipGoodStories.Add(managerBadStory);
        relationshipGoodStories.Add(agentBadStory);
        relationshipGoodStories.Add(rivalBadStory);

        //story.Add(new Task(1, "Euros 2016", "One of your parents sat through the Euro's with you. Was it  \n\n A.Your Mum  \n\n B.Your Dad", 2, "A", "B", 44, 45));        
        story.Add(new Task(2, "Rival", "Your Headteacher calls you and one of your teammates into the office. He tells you both that he's expecting big things. What is the other players name?", 3, "It is...", 111, true));
        story.Add(new Task(3, "Lets get a pet", "Your " + player.GetRelationship(1).GetTitle() + " asks you if you'd like a pet. You leap at the chance and head down to the local pet shop. You run inside ready to locate your chosen pet! Which way do you go? \n\n A.Go left. \n\n B.Go towards the center \n\n C.Go right", 4, "A", "B", "C", 23, 24, 25));
        story.Add(new Task(5, "Academy 101", "You get two letters through the door. Your parent explains one is a smaller academy with less facilities but the coaches will be working with less players giving them more targeted training time. Do you choose \n\n A.Big Academy \n\n B.Small Academy", 5, "A", "B", 3, 4));
        story.Add(new Task(8, "Meet your coach", "Your new coach calls you in to the office at the academy. He gives you a run down of normal procedures here at the academy. 'Pleasantries over, I need you to be honest with me. What comes first football or school?' Do you choose \n\n A.Football \n\n B.School", 8, "A", "B", 1, 2));
        story.Add(new Task(12, "Football friends", "You get invited to a school friends house to play some football, before you respond to the message one of your academy friends invites you for a game of footy. Do you go with \n\n A.School friends \n\n B.Academy friends", 12, "A", "B", 7, 8));
        story.Add(new Task(16, "Choose wisely", "Just as you are leaving training, the coach grabs you and hands you a card “Make sure you yourself an agent”. When you get home you show " + player.GetRelationship(0).GetName() + ", “I’ve been looking into agents too” they respond, they show you an agents card. Who do you choose? \n\n A.Coaches agent \n\n B." + player.GetRelationship(0).GetTitle() + "'s agent",16,"A","B", 5, 6));
        story.Add(new Task(20, "Just holding hands", "Just as you are leaving school someone catches your eye and you turn to see who it is. Was it \n\n A. A boy \n\n B. A girl", 20, "A", "B", 9, 10));
        story.Add(new Task(25, "Stay safe kids", "Once again as you are leaving school, you see them waiting. You can't quite remember what their name was... ", 25, "You can't remember...", 11, true));
        story.Add(new Task(30, "Destined to be together...", "You see " + player.GetRelationship(2).GetName() + " by the front of the school, you think about going over and talking to them but you are nervous. What do you do? \n\n A.Ask them out \n\n B.Ask them out. \n\nTeenage you definitely wants to ask them out.", 30, "A", "B", 14, 14));
        //story.Add(new Task(34, "School season breakdown", "So the school season has come to an end. Congratulations on finishing ...", 34, "A", "B", 54, 54));
        story.Add(new Task(35, "Games after games", "After one of your training sessions you over hear some of the players chatting about a new game thats just come out. It's some sort of 5 vs 5 Moba style game. You wonder if you should check it out later. \n\n A.Check it out later \n\n B.Check it out right now", 35, "A", "B", 105, 106));
        story.Add(new Task(38, "Weekend detention", "You arrive at detention and look around, you see a jock, A nerd, A punk, A popular girl and a shy girl. The teacher leaves you alone and the other members of the club begin to talk and mess around. How do you respond? \n\n A.Join in \n\n B.Tell them to keep it down", 38, "A", "B", 48, 49));
        story.Add(new Task(40, "In the public eye", "A local newspaper comes into school to get some interviews with the team that won the inter high tournament. They ask you what you thought was the most important factor leading to the teams success? \n\n A.I was. \n\n B.The manager \n\n C.The team", 40, "A", "B", "C", 15, 16, 17));
        story.Add(new Task(45, "Sports Day", "With sports day coming up there is a staff vs students game of football. You have been asked to play? It always gets very competitive and you could get injured. How do you respond? \n\n A.Yeah I'd love to play. \n\n B.Sorry I'm busy", 45, "A", "B", 46, 47));
        story.Add(new Task(50, "Parents evening", "Your" + player.GetRelationship(1).GetName() + " asks you if you are able to make the parents evening tonight. You know that you have an academy game this evening. What do you do? \n\n A.Go to Parents evening \n\n B.Go to the game", 50, "A", "B", 18, 19));
        story.Add(new Task(52, "End of Tutorial", "We want to say a big THANKYOU!\n You have reached the end of our demo, we hope you have enjoyed it! \n\n Coming up for the games final release:\n> Manage an ESports team\n>Compete in the Euros and Champions league\n>Play for your own chosen Country\n>And much more!!!", 52, "Join our discord", "Give Feedback", "No Thanks", 20, 21, 22));


        // Connor add your story here!

        dilemmas.Add(new Task(1, "Look at all that money", "Your agent comes to you and pitches the contract your manager has offered you. He advises you that he could potentially get more. What do you do? \n\n A.Accept the offer \n\n B.Push for more", 2, "A", "B", 108, 109));
        dilemmas.Add(new Task(2, "Clean those boots", "You get back from training and your boots are covered in mud. It's late and it's been a very long day. What do you do? \n\n A.Clean your boots \n\nB.Clean them tomorrow",2, "A", "B", 70, 71));        
        dilemmas.Add(new Task(3, "Citizens arrest", "You are walking home from training holding a football, as you glance to the side you see a man stealing a lady's purse... What do you do? \n\n A.Do nothing. \n\n B.Give chase \n\n C.Kick your football at the thief", 3, "A", "B", "C", 41, 42, 43));
        dilemmas.Add(new Task(4, "Aunty's birthday", "It's your Aunt's birthday, with your Aunt being a doctor you know she'll spend the entire time lecturing you on how being a footballer isn't a real career. Your " + player.GetRelationship(1).GetTitle() + " asks you to go. What do you do? \n\n A.Yes \n\n B.Hell no!", 4, "A", "B", 50, 51));
        dilemmas.Add(new Task(5, "It's " + player.GetRelationship(8).GetName() + "'s birthday", "It's " + player.GetRelationship(8).GetName() + "'s birthday and he's invited you and some mates to play a friendly game of footy in the park... Do you go? \n\n A.Yes \n\n B.No",5, "A", "B", 52, 53));
        dilemmas.Add(new Task(6, "TakeAway", "You happen to be with your parents who decide that they'll get a takeaway tonight. What do you do? \n\n A.Have TakeAway \n\n B.Go out and buy food", 5, "A", "B", 55, 56));
        dilemmas.Add(new Task(7, "Banter at training", "Some of the other players hide your shoes after training. What do you do? \n\n A.Laugh about it and wait for them to return them. \n\n B.Get Angry. \n\n C.Start walking out with no shoes.", 5, "A", "B","C", 57, 58,59));
        //dilemmas.Add(new Task(8, "New era of games", "You are leaving training and you over hear some of the other players talking about a new game. What do you do? \n\n A.Ask them about it \n\n B.Check it out when you get home", 5, "A", "B", 60, 61));
        dilemmas.Add(new Task(9, "New player", "A new player arrives at the academy today. How do you greet him? \n\n A.Go over and say hello \n\n B.Show him the league is a tough one \n\n C.Just go about your business", 5, "A", "B","C", 62, 63, 64));
        //dilemmas.Add(new Task(10, "Your computer breaks", "Your computer breaks mid gaming session. Your mother calls a mechanic out to come look at your PC. The mechanic recognises you and talks your ear off for ages about football. Eventually he gets round to fixing your PC. What do you do? \n\n A.Thank him  \n\n B.Tip him  \n\n C.Give him an autograph", 5, "A", "B", "C", 65,66,67));
        dilemmas.Add(new Task(11, "A fan", "You are heading to training and you bump into someone on your way. 'By Azura, it's " + player.GetName() + "! I can't believe it's you! Standing here, next to me!' How do you respond? \n\n A.Be my adoring fan \n\n B.Are you ok?", 5, "A", "B", 68, 69));
        if (player.GetRelationship(2).GetDating()) 
            dilemmas.Add(new Task(12, "I need more time! ", player.GetRelationship(2).GetName() + " misses you. They want to come round tonight to see you before training. You'll be late for training if you see them. What do you do? \n\n A. See them anyway \n\n B.Tell them you can't", 12, "A", "B", 72, 73));
        dilemmas.Add(new Task(13, "Escape the room!","You and your friends go to an Escape room. You split into two teams, the game heats up and both teams have almost finished. You find the last key and all you need to do is unlock the door to escape. Which door do you try? \n\n A.The right door \n\n B.The left door", 13,"A","B", 74, 75));
        dilemmas.Add(new Task(14, "Family competition", "You are visiting your family, things get competitive when the food comes out. An eating contest starts. What do you do? \n\n A.Try and win \n\n B.Don't participate", 14, "A", "B", 76, 77));
        dilemmas.Add(new Task(15, "Broken phone", "You are on your way back from training and you drop your phone. The screen cracks, when you get home your mum tells you that you should have bought a screen protector. How do you respond? \n\n A.Thank her sarcastically \n\n B.Brush it off", 15, "A", "B", 78, 79));
        dilemmas.Add(new Task(16, "Radio bit", "You are invited to talk about football on a local radio station. How do you respond? \n\n A.Politely decline \n\n B.Do a talk for them", 16, "A", "B", 80, 81));
        dilemmas.Add(new Task(17, "Training ground clash", "You have a loud disagreement with one of your team mates. He pushes you, and you stumble backwards. How do you respond \n\n A.Push them back \n\n B.Walk it off", 17, "A", "B", 112, 113));
        dilemmas.Add(new Task(18, "Team Interview", "You participate in a fun relaxed team interview. They ask you who's the most motivated player in your team. How do you respond? \n\n A.Say it's you \n\n B.Say it's someone else \n\n C.My name is Jeff", 18, "A", "B", "C", 114, 115, 116));
        dilemmas.Add(new Task(19, "Stolen phone", "You finish training and your phone is missing. What do you do? \n\n A.Find out who it is! \n\n B.Nothing It'll turn up", 19, "A", "B", 117, 118));
        dilemmas.Add(new Task(20, "Pet is sick", "Your pet is sick but you have training tonight. What do you do? \n\n A.Skip training to look after your pet \n\n B.Go to training anyway", 20, "A", "B", 119, 120));

        if (!player.GetSponsorships(0).HasSponsor)
            dilemmas.Add(new Task(21, "Boots Sponsorship", "A football boot company gets in contact with you through your agent. They like the way you play and they want to offer you a pair of boots as sponsorship. How do you respond? \n\n A.Politely decline \n\n B.Agree \n\nC.Ask them if you get money as well", 21, "A", "B","C", 85, 86,87));
        else
            dilemmas.Add(new Task(22, "Niky Sponsorship", "You get contacted by your agent, he says he's managed to get you a better boots sponsorship. Your agent wants you to meet with them today. How do you respond? \n\n A.Accept the meeting \n\n B.Decline and meet with your old sponsor", 22, "A", "B", 88, 89));       
        if (!player.GetSponsorships(1).HasSponsor)
            dilemmas.Add(new Task(23, "Watch Sponsorship", "You get a call from a local watch maker. They support your team and they want to offer you a watch sponsorship. How do you respond? \n\n A.Politely decline \n\n B.Agree \n\nC.Ask them if you get money as well", 23, "A", "B", "C", 95, 96, 97));
        else
            dilemmas.Add(new Task(24, "Caso Sponsorship", "You get contacted by your agent, he says he's managed to get you a better car sponsorship. Your agent wants you to meet with them today. How do you respond? \n\n A.Accept the meeting \n\n B.Decline and meet with your old sponsor", 24, "A", "B", 98, 99));
        if (!player.GetSponsorships(2).HasSponsor)
            dilemmas.Add(new Task(25, "Computer Sponsorship", "You get a call from a computer company. They find out you like playing games, they offer to provide you with a rig and setup if you promote their company. How do you respond? \n\n A.Politely decline \n\n B.Agree \n\nC.Ask them if you get money as well", 25, "A", "B", "C", 82, 83, 84));
        else
            dilemmas.Add(new Task(26, "Ndidia Sponsorship", "You get contacted by your agent, he says he's managed to get you a better computer sponsorship. Your agent wants you to meet with them today. How do you respond? \n\n A.Accept the meeting \n\n B.Decline and meet with your old sponsor", 26, "A", "B", 92, 93));
        if (!player.GetSponsorships(3).HasSponsor)
            dilemmas.Add(new Task(27, "Car Sponsorship", "You get a call from a local car dealer. They want to sponsor you, they are willing to offer you a car all they want is you to drive it and mention them if anyone ever asks about your car. How do you respond? \n\n A.Politely decline \n\n B.Agree \n\nC.Ask them if you get money as well", 27, "A", "B", "C", 90, 91, 100));
        else
            dilemmas.Add(new Task(28, "Audl Sponsorship", "You get contacted by your agent, he says he's managed to get you a better car sponsorship. Your agent wants you to meet with them today. How do you respond? \n\n A.Accept the meeting \n\n B.Decline and meet with your old sponsor", 28, "A", "B", 109, 110));
        if (!player.GetSponsorships(4).HasSponsor)
            dilemmas.Add(new Task(29, "Food Sponsorship", "You get a call from a local pie shop. The shop is near the stadium you play in, the shop want to sponsor you. They are offering you and your friends free pies and all you need to do is mention them in interviews sometimes.How do you respond? \n\n A.Politely decline \n\n B.Agree \n\nC.Ask them if you get money as well", 29, "A", "B", "C", 101, 102, 103));
        else
            dilemmas.Add(new Task(30, "Subwoy Sponsorship", "You get contacted by your agent, he says he's managed to get you a better food sponsorship. Your agent wants you to meet with them today. How do you respond? \n\n A.Accept the meeting \n\n B.Decline and meet with your old sponsor", 30, "A", "B", 104, 105));

        dilemmas.Add(new Task(31, "Run a training session", "Your " + player.GetRelationship(1).GetTitle() + " asks you to run a football training session for one of their friends sons football team. You'll be late to your own training session. What do you do? \n\n A.Run the session \n\n B.Apologise, you can't be late", 31, "A", "B", 121, 122));
        dilemmas.Add(new Task(32, "Go for a run", "When you get back in from training your " + player.GetRelationship(0).GetTitle() + " asks you to go on a jog with them. How do you respond \n\n A.Yeah sure I'll go \n\nB.Sorry I'm too tired", 32, "A", "B", 123, 124));
        dilemmas.Add(new Task(33, "Cousin's birthday", "You looking forward to a weekend off from playing football, thats when you remember that it's one of your cousins birthdays. What do you do?  \n\n A.I'm tired I don't want to go \n\n B.Go even though I'm tired", 34, "A", "B", 125, 126));
        dilemmas.Add(new Task(34, "Chess competition", "You see a leaflet for a chess competition near by. It's on a day that you are free. Do you go?  \n\n A.Yeah why the hell not \n\n B.Nah I don't want to", 35, "A", "B", 140, 141));
        //dilemmas.Add(new Task(35, "It's " + player.GetRelationship(8).GetName() + "'s birthday", "It's " + player.GetRelationship(8).GetName() + "'s birthday and he's invited you and some mates to play a friendly game of footy in the park... Do you go? \n\n A.Yes \n\n B.No", 5, "A", "B", 52, 53));
        //dilemmas.Add(new Task(36, "TakeAway", "You happen to be with your parents who decide that they'll get a takeaway tonight. What do you do? \n\n A.Have TakeAway \n\n B.Go out and buy food", 5, "A", "B", 55, 56));
        //dilemmas.Add(new Task(37, "Banter at training", "Some of the other players hide your shoes after training. What do you do? \n\n A.Laugh about it and wait for them to return them. \n\n B.Get Angry. \n\n C.Start walking out with no shoes.", 5, "A", "B", "C", 57, 58, 59));
        //dilemmas.Add(new Task(38, "New era of games", "You are leaving training and you over hear some of the other players talking about a new game. What do you do? \n\n A.Ask them about it \n\n B.Check it out when you get home", 5, "A", "B", 60, 61));
        //dilemmas.Add(new Task(39, "New player", "A new player arrives at the academy today. How do you greet him? \n\n A.Go over and say hello \n\n B.Show him the league is a tough one \n\n C.Just go about your business", 5, "A", "B", "C", 62, 63, 64));
        //dilemmas.Add(new Task(40, "Your computer breaks", "Your computer breaks mid gaming session. Your mother calls a mechanic out to come look at your PC. The mechanic recognises you and talks your ear off for ages about football. Eventually he gets round to fixing your PC. What do you do? \n\n A.Thank him  \n\n B.Tip him  \n\n C.Give him an autograph", 5, "A", "B", "C", 65,66,67));
        //dilemmas.Add(new Task(41, "A fan", "You are heading to training and you bump into someone on your way. 'By Azura, it's " + player.GetName() + "! I can't believe it's you! Standing here, next to me!' How do you respond? \n\n A.Be my adoring fan \n\n B.Are you ok?", 5, "A", "B", 68, 69));
        //if (player.GetRelationship(2).GetDating())
        //    dilemmas.Add(new Task(42, "I need more time! ", player.GetRelationship(2).GetName() + " misses you. They want to come round tonight to see you before training. You'll be late for training if you see them. What do you do? \n\n A. See them anyway \n\n B.Tell them you can't", 12, "A", "B", 72, 73));
        //dilemmas.Add(new Task(43, "Escape the room!", "You and your friends go to an Escape room. You split into two teams, the game heats up and both teams have almost finished. You find the last key and all you need to do is unlock the door to escape. Which door do you try? \n\n A.The right door \n\n B.The left door", 13, "A", "B", 74, 75));
        //dilemmas.Add(new Task(44, "Family competition", "You are visiting your family, things get competitive when the food comes out. An eating contest starts. What do you do? \n\n A.Try and win \n\n B.Don't participate", 14, "A", "B", 76, 77));
        //dilemmas.Add(new Task(45, "Broken phone", "You are on your way back from training and you drop your phone. The screen cracks, when you get home your mum tells you that you should have bought a screen protector. How do you respond? \n\n A.Thank her sarcastically \n\n B.Brush it off", 15, "A", "B", 78, 79));
        //dilemmas.Add(new Task(46, "Radio bit", "You are invited to talk about football on a local radio station. How do you respond? \n\n A.Politely decline \n\n B.Do a talk for them", 16, "A", "B", 80, 81));
        //dilemmas.Add(new Task(47, "Training ground clash", "You have a loud disagreement with one of your team mates. He pushes you, and you stumble backwards. How do you respond \n\n A.Push them back \n\n B.Walk it off", 17, "A", "B", 112, 113));
        //dilemmas.Add(new Task(48, "Team Interview", "You participate in a fun relaxed team interview. They ask you who's the most motivated player in your team. How do you respond? \n\n A.Say it's you \n\n B.Say it's someone else \n\n C.My name is Jeff", 18, "A", "B", "C", 114, 115, 116));
        //dilemmas.Add(new Task(49, "Stolen phone", "You finish training and your phone is missing. What do you do? \n\n A.Find out who it is! \n\n B.Nothing It'll turn up", 19, "A", "B", 117, 118));
        //dilemmas.Add(new Task(50, "Pet is sick", "Your pet is sick but you have training tonight. What do you do? \n\n A.Skip training to look after your pet \n\n B.Go to training anyway", 20, "A", "B", 80, 81));


        //New lots of story for the seasons
        //if (player.GetRelationship(2).GetMale())
        //dilemmas.Add(new Task(34, "Walking home", "A boy from your class is walking home and you know he lives near you. You see him from across the road. You wonder if you should walk with him some of the way? \n\n A.Yes \n\n B.No", 4, "A", "B", 127, 128));
        //else
        //    dilemmas.Add(new Task(34, "Walking home", "A girl from your class is walking home and you know she lives near you. You see her from across the road. You wonder if you should walk with her some of the way? \n\n A.Yes \n\n B.No", 4, "A", "B", 127, 128));
        

        //Euro Story not fully certain of the date
        //You know that the Euro's are coming up soon. You know you won't be considered for the team because you are too inexperienced but you still allow yourself to hope that there might be a possibility.
        //You could hardly believe it when you get a call from your agent saying that you've been called up to the national side. But the craziest thing is they've given you a choice, they've called you up to the U21's squad and also the senior squad
        //You decide to stick with the U21's side, you believe that you aren't quite skilled enough for the senior squad and believe that your career will benefit more from the oppurtunity within the U21's squad.
        //With the domestic seson mostly over you start participating in some of the national teams training sessions. You recognise many of the players and you are excited to get involved and get stuck into the training.
        //As the tournament inches ever closer you have been performing better and better in training sessions. Your skills have been improving at a rapid rate, you are also getting used to all of the team and you are helping others integrate themselves within the team.
        //Before the first game of the tournament the manager comes to you and pulls you aside. He asks you if you'd be up for the challenge of captaining the team throughout the tournament? Choose to captain the team, politely decline 
        //
        
        
        //You can't hold in your excitement at the oppurtunity that's been presented to you. You don't even contemplate playing for the U21's you can barely hold in your excitement you tell your agent to contact the national side and except the senior squad position! 


        dilemmasLeft = new List<Task>(dilemmas);


        
    }


    public List<Task> GetDilemasLeft()
    {
        return dilemmasLeft;
    }
    public void SetDilemasLeft(List<Task> _dilemas) // endless cycle of dilemas 
    {
        dilemmasLeft = _dilemas;
    }
    public List<Task> GetWeekTasks(int date) 
    {
        List<Task> weekTasks = new List<Task>();

        foreach (Task t in story)      // Get story mission
        {
            if (t.GetDate() == date)
            {
                weekTasks.Add(t);
            }
        }
        if(dilemmasLeft.Count < 3) // when running out of dilemas, refresh the list
        {
            dilemmasLeft = new List<Task>(dilemmas); // be this efficent enough?
        }
        if(weekTasks.Count == 0 && Random.Range(0,2) == 0 && date != 1) // if no story was on this week then get a random dilema
        {
            int num = Random.Range(0, dilemmasLeft.Count - 1);
            weekTasks.Add(dilemmasLeft[num]);
            dilemmasLeft.RemoveAt(num);
        }
        return weekTasks;
    }
    public List<Task> GetRelationshipGoodStory(int i)
    {
        return relationshipGoodStories[0];
    }
    public List<Task> GetRelationshipBadStory(int i)
    {
        return relationshipBadStories[0];
    }
}
