using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public List<string> leagueName;
    public List<string> maleFirstName;
    public List<string> femaleFirstName;
    public List<string> secondName;
    public List<string> nationality;

    string[] teamDescription = new string[10];
    string[] playerDescription = new string[10];
    int[] stats = new int[15];
    
    public Utilities()
    {
        leagueName = new List<string>();
        maleFirstName = new List<string>();
        femaleFirstName = new List<string>();
        secondName = new List<string>();
        nationality = new List<string>();
        SetUpFemaleFirstName();
        SetUpMaleFirstName();
        SetUpSecondName();
        SetUpNationality();
    }

    public void SetUpMaleFirstName()
    {
        maleFirstName.Add("Connor"); maleFirstName.Add("Daniel"); maleFirstName.Add("Ellis"); maleFirstName.Add("Alexander"); maleFirstName.Add("Michael"); maleFirstName.Add("Jackson");
        maleFirstName.Add("Adam"); maleFirstName.Add("Andrew"); maleFirstName.Add("Philip"); maleFirstName.Add("Aiden"); maleFirstName.Add("Matthew"); maleFirstName.Add("Sam");
        maleFirstName.Add("Paul"); maleFirstName.Add("Drew"); maleFirstName.Add("Owen"); maleFirstName.Add("Samuel"); maleFirstName.Add("Dave"); maleFirstName.Add("David");
        maleFirstName.Add("Steven"); maleFirstName.Add("Kieran"); maleFirstName.Add("Brian"); maleFirstName.Add("Wyatt"); maleFirstName.Add("John"); maleFirstName.Add("Luke");
        maleFirstName.Add("Josh"); maleFirstName.Add("Stephen"); maleFirstName.Add("Alan"); maleFirstName.Add("Jayden"); maleFirstName.Add("Dylan"); maleFirstName.Add("Levi");
        maleFirstName.Add("Gary"); maleFirstName.Add("Henry"); maleFirstName.Add("Rhys"); maleFirstName.Add("Gabriel"); maleFirstName.Add("Julian"); maleFirstName.Add("Mateo");
        maleFirstName.Add("Edward"); maleFirstName.Add("Liam"); maleFirstName.Add("Jacob"); maleFirstName.Add("Isaac"); maleFirstName.Add("Anthony"); maleFirstName.Add("Joshua");
        maleFirstName.Add("Ben"); maleFirstName.Add("Benjamin"); maleFirstName.Add("Elijah"); maleFirstName.Add("Chris"); maleFirstName.Add("Christopher"); maleFirstName.Add("Theo");
        maleFirstName.Add("Mason"); maleFirstName.Add("William"); maleFirstName.Add("James"); maleFirstName.Add("Caleb"); maleFirstName.Add("Ryan"); maleFirstName.Add("Asher");
        maleFirstName.Add("Oliver"); maleFirstName.Add("Harvey"); maleFirstName.Add("Mike"); maleFirstName.Add("Nathan"); maleFirstName.Add("Tom"); maleFirstName.Add("Nathan");
        maleFirstName.Add("Jack"); maleFirstName.Add("Ethan"); maleFirstName.Add("Alex"); maleFirstName.Add("Joe"); maleFirstName.Add("Joseph"); maleFirstName.Add("Carter");
        maleFirstName.Add("Thomas"); maleFirstName.Add("Charles"); maleFirstName.Add("Christian"); maleFirstName.Add("Tim"); maleFirstName.Add("Timothy"); maleFirstName.Add("Roman");
        maleFirstName.Add("Daniel"); maleFirstName.Add("Aaron"); maleFirstName.Add("Aron"); maleFirstName.Add("Axel"); maleFirstName.Add("Miles"); maleFirstName.Add("Declan");
        maleFirstName.Add("Adrian"); maleFirstName.Add("Rocky"); maleFirstName.Add("Ash"); maleFirstName.Add("Art"); maleFirstName.Add("Arthur"); maleFirstName.Add("Hayden");
        maleFirstName.Add("Jonathan"); maleFirstName.Add("Crash"); maleFirstName.Add("Talion"); maleFirstName.Add("Tyler"); maleFirstName.Add("Luca"); maleFirstName.Add("Vincent");
        maleFirstName.Add("Landon"); maleFirstName.Add("Cameron"); maleFirstName.Add("Rob"); maleFirstName.Add("Damien"); maleFirstName.Add("Silas"); maleFirstName.Add("Gavin");
        maleFirstName.Add("Robert"); maleFirstName.Add("Nicholas"); maleFirstName.Add("Nick"); maleFirstName.Add("Kai"); maleFirstName.Add("Emmet"); maleFirstName.Add("Harrison");
        maleFirstName.Add("Zack"); maleFirstName.Add("Zak"); maleFirstName.Add("Roman"); maleFirstName.Add("Nathaniel"); maleFirstName.Add("Cole"); maleFirstName.Add("Luis");
        maleFirstName.Add("Jordan"); maleFirstName.Add("Ezekial"); maleFirstName.Add("Xavier"); maleFirstName.Add("George"); maleFirstName.Add("Rowan"); maleFirstName.Add("Diego");
        maleFirstName.Add("Jose"); maleFirstName.Add("Muhammad"); maleFirstName.Add("Mohammad"); maleFirstName.Add("Maxwell"); maleFirstName.Add("Juan"); maleFirstName.Add("Carlos");
        maleFirstName.Add("Kyle"); maleFirstName.Add("Evan"); maleFirstName.Add("Dominic"); maleFirstName.Add("Ivan"); maleFirstName.Add("Justin"); maleFirstName.Add("Calvin");
        maleFirstName.Add("Dom"); maleFirstName.Add("Don"); maleFirstName.Add("Donald"); maleFirstName.Add("Giovanni"); maleFirstName.Add("Abel"); maleFirstName.Add("Jesus");
        maleFirstName.Add("Amir"); maleFirstName.Add("Jasper"); maleFirstName.Add("Malachi"); maleFirstName.Add("Matias"); maleFirstName.Add("Jeremy"); maleFirstName.Add("Preston");
        maleFirstName.Add("Brody"); maleFirstName.Add("Blake"); maleFirstName.Add("Emmanuel"); maleFirstName.Add("Oscar"); maleFirstName.Add("Sadio"); maleFirstName.Add("Kaleb");
        maleFirstName.Add("Eric"); maleFirstName.Add("Antonio"); maleFirstName.Add("Elliot"); maleFirstName.Add("Peter"); maleFirstName.Add("Maximus"); maleFirstName.Add("Jax");
        maleFirstName.Add("Finn"); maleFirstName.Add("Rhett"); maleFirstName.Add("Xander"); maleFirstName.Add("Andre"); maleFirstName.Add("Andres"); maleFirstName.Add("Charlie");
        maleFirstName.Add("Alan"); maleFirstName.Add("Christiano"); maleFirstName.Add("Leo"); maleFirstName.Add("Paxton"); maleFirstName.Add("Enzo"); maleFirstName.Add("Felix");
        maleFirstName.Add("Roberto"); maleFirstName.Add("Dean"); maleFirstName.Add("Lorenzo"); maleFirstName.Add("Lukas"); maleFirstName.Add("Leon"); maleFirstName.Add("Archer");
        maleFirstName.Add("Victor"); maleFirstName.Add("Viktor"); maleFirstName.Add("Milo"); maleFirstName.Add("Alejandro"); maleFirstName.Add("Marcus"); maleFirstName.Add("Mark");
        maleFirstName.Add("Miguel"); maleFirstName.Add("Graham"); maleFirstName.Add("Grayden"); maleFirstName.Add("Omar"); maleFirstName.Add("Javier"); maleFirstName.Add("Jaden");
        maleFirstName.Add("Grant"); maleFirstName.Add("Zion"); maleFirstName.Add("Joel"); maleFirstName.Add("Emilio"); maleFirstName.Add("Riley"); maleFirstName.Add("Colin");
        maleFirstName.Add("Richard"); maleFirstName.Add("Patrick"); maleFirstName.Add("Patryk"); maleFirstName.Add("Derek"); maleFirstName.Add("Rafael"); maleFirstName.Add("Louis");
        maleFirstName.Add("Myles"); maleFirstName.Add("Thiago"); maleFirstName.Add("Zane"); maleFirstName.Add("Jake"); maleFirstName.Add("Sean"); maleFirstName.Add("Martin");
        maleFirstName.Add("Finley"); maleFirstName.Add("Tobias"); maleFirstName.Add("Killian"); maleFirstName.Add("Tyson"); maleFirstName.Add("Nasir"); maleFirstName.Add("Adonis");
        maleFirstName.Add("Emerson"); maleFirstName.Add("Jensen"); maleFirstName.Add("Ronan"); maleFirstName.Add("Malik"); maleFirstName.Add("Ari"); maleFirstName.Add("Nico");
        maleFirstName.Add("Orion"); maleFirstName.Add("Ali"); maleFirstName.Add("Alistair"); maleFirstName.Add("Seth"); maleFirstName.Add("Clark"); maleFirstName.Add("Erik");
        maleFirstName.Add("Alisdair"); maleFirstName.Add("Ricardo"); maleFirstName.Add("Fernando"); maleFirstName.Add("Trevor"); maleFirstName.Add("Malakai"); maleFirstName.Add("Sullivan");
        maleFirstName.Add("Titus"); maleFirstName.Add("Sol"); maleFirstName.Add("Tony"); maleFirstName.Add("Leonel"); maleFirstName.Add("Ismael"); maleFirstName.Add("Marco");
        maleFirstName.Add("Mario"); maleFirstName.Add("Cruz"); maleFirstName.Add("Hector"); maleFirstName.Add("Solomon"); maleFirstName.Add("Fabian"); maleFirstName.Add("Pedro");
        maleFirstName.Add("Angelo"); maleFirstName.Add("Jeffrey"); maleFirstName.Add("Edwin"); maleFirstName.Add("Frank"); maleFirstName.Add("Malcolm"); maleFirstName.Add("Khalil");
        maleFirstName.Add("Cesar"); maleFirstName.Add("Devin"); maleFirstName.Add("Warren"); maleFirstName.Add("Nehemiah"); maleFirstName.Add("Mathias"); maleFirstName.Add("Ibrahim");
        maleFirstName.Add("Odin"); maleFirstName.Add("Thor"); maleFirstName.Add("Romeo"); maleFirstName.Add("Peyton"); maleFirstName.Add("Winston"); maleFirstName.Add("Noel");
        maleFirstName.Add("Joaquin"); maleFirstName.Add("Julius"); maleFirstName.Add("Hayes"); maleFirstName.Add("Elian"); maleFirstName.Add("Russell"); maleFirstName.Add("Kendrick");
        maleFirstName.Add("Jaxton"); maleFirstName.Add("Sergio"); maleFirstName.Add("Marshall"); maleFirstName.Add("Pablo"); maleFirstName.Add("Allen"); maleFirstName.Add("Hugo");
        maleFirstName.Add("Gianni"); maleFirstName.Add("Roben"); maleFirstName.Add("Ruben"); maleFirstName.Add("Arjun"); maleFirstName.Add("Eden"); maleFirstName.Add("Armando");
        maleFirstName.Add("Ezequiel"); maleFirstName.Add("Otto"); maleFirstName.Add("Abram"); maleFirstName.Add("Kairo"); maleFirstName.Add("Uriel"); maleFirstName.Add("Rodrigo");
        maleFirstName.Add("Jonas"); maleFirstName.Add("Esteban"); maleFirstName.Add("Maximillian"); maleFirstName.Add("Davis"); maleFirstName.Add("Asa"); maleFirstName.Add("Darius");
        maleFirstName.Add("Memphis"); maleFirstName.Add("Augustus"); maleFirstName.Add("Moses"); maleFirstName.Add("Iasias"); maleFirstName.Add("Jaime"); maleFirstName.Add("Raul");
        maleFirstName.Add("Armani"); maleFirstName.Add("Corey"); maleFirstName.Add("Gunnar"); maleFirstName.Add("Scott"); maleFirstName.Add("Raphael"); maleFirstName.Add("Saul");
        maleFirstName.Add("Deacon"); maleFirstName.Add("Zachariah"); maleFirstName.Add("Nikolai"); maleFirstName.Add("Moshe"); maleFirstName.Add("Ahmed"); maleFirstName.Add("Ayaan");
        maleFirstName.Add("Bruce"); maleFirstName.Add("Enrique"); maleFirstName.Add("Dexter"); maleFirstName.Add("Duke"); maleFirstName.Add("Ryland"); maleFirstName.Add("Danny");
        maleFirstName.Add("Collin"); maleFirstName.Add("Troy"); maleFirstName.Add("Nasir"); maleFirstName.Add("Adonis"); maleFirstName.Add("Jared"); maleFirstName.Add("Rory");
        maleFirstName.Add("Andy"); maleFirstName.Add("Jace"); maleFirstName.Add("Shane"); maleFirstName.Add("Ari"); maleFirstName.Add("Reed"); maleFirstName.Add("Seth");
        maleFirstName.Add("Trevor"); maleFirstName.Add("Nico"); maleFirstName.Add("Cade"); maleFirstName.Add("Soloman"); maleFirstName.Add("Cyrus"); maleFirstName.Add("Fabian");
        maleFirstName.Add("Pedro"); maleFirstName.Add("Malcolm"); maleFirstName.Add("Mathias"); maleFirstName.Add("Jay"); maleFirstName.Add("Peyton"); maleFirstName.Add("Winston");
        maleFirstName.Add("Noel"); maleFirstName.Add("Gregory"); maleFirstName.Add("Ruben"); maleFirstName.Add("Raiden"); maleFirstName.Add("Damon"); maleFirstName.Add("Remy");
        maleFirstName.Add("Russell"); maleFirstName.Add("Otto"); maleFirstName.Add("Marcos"); maleFirstName.Add("Abram"); maleFirstName.Add("Royce"); maleFirstName.Add("Jonas");
        maleFirstName.Add("Philip"); maleFirstName.Add("Drake"); maleFirstName.Add("Harvey"); maleFirstName.Add("Roberto"); maleFirstName.Add("Adan"); maleFirstName.Add("Hank");
        maleFirstName.Add("Oakley"); maleFirstName.Add("Drew"); maleFirstName.Add("Rhys"); maleFirstName.Add("Benson"); maleFirstName.Add("Jayson"); maleFirstName.Add("Corey");
        maleFirstName.Add("Gunnar"); maleFirstName.Add("Alonzo"); maleFirstName.Add("Landen"); maleFirstName.Add("Dexter"); maleFirstName.Add("Rocco"); maleFirstName.Add("Arjun");
        maleFirstName.Add("Eden"); maleFirstName.Add("Pierce"); maleFirstName.Add("Ronald"); maleFirstName.Add("Frederick"); maleFirstName.Add("Kieran"); maleFirstName.Add("Leonidas");
        maleFirstName.Add("Nixon"); maleFirstName.Add("Keith"); maleFirstName.Add("Chandler"); maleFirstName.Add("Davis"); maleFirstName.Add("Darius"); maleFirstName.Add("Isaias");
        maleFirstName.Add("Apollo"); maleFirstName.Add("Dorian"); maleFirstName.Add("Dustin"); maleFirstName.Add("Duke"); maleFirstName.Add("Quentin"); maleFirstName.Add("Alec");
        maleFirstName.Add("Lewis"); maleFirstName.Add("Brock"); maleFirstName.Add("Ahmad"); maleFirstName.Add("Dennis"); maleFirstName.Add("Callum"); maleFirstName.Add("Soren");
        maleFirstName.Add("Rayan"); maleFirstName.Add("Gerardo"); maleFirstName.Add("Ares"); maleFirstName.Add("Brendan"); maleFirstName.Add("Yusuf"); maleFirstName.Add("Issac");
        maleFirstName.Add("Callen"); maleFirstName.Add("Forrest"); maleFirstName.Add("Makai"); maleFirstName.Add("Kobe"); maleFirstName.Add("Bo"); maleFirstName.Add("Braden");
        maleFirstName.Add("Marvin"); maleFirstName.Add("Zaid"); maleFirstName.Add("Stetson"); maleFirstName.Add("Casey"); maleFirstName.Add("Ty"); maleFirstName.Add("Dillon");

    }
    public void SetUpFemaleFirstName()
    {
        femaleFirstName.Add("Isabella"); femaleFirstName.Add("Emma"); femaleFirstName.Add("Olivia"); femaleFirstName.Add("Ava"); femaleFirstName.Add("Sophia");
        femaleFirstName.Add("Charlotte"); femaleFirstName.Add("Mia"); femaleFirstName.Add("Amelia"); femaleFirstName.Add("Harper"); femaleFirstName.Add("Evelyn");
        femaleFirstName.Add("Abigail"); femaleFirstName.Add("Emily"); femaleFirstName.Add("Elizabeth"); femaleFirstName.Add("Mila"); femaleFirstName.Add("Ella");
        femaleFirstName.Add("Avery"); femaleFirstName.Add("Sofia"); femaleFirstName.Add("Camila"); femaleFirstName.Add("Aria"); femaleFirstName.Add("Scarlett");
        femaleFirstName.Add("Victoria"); femaleFirstName.Add("Madison"); femaleFirstName.Add("Luna"); femaleFirstName.Add("Grace"); femaleFirstName.Add("Chloe");
        femaleFirstName.Add("Penelope"); femaleFirstName.Add("layla"); femaleFirstName.Add("Riley"); femaleFirstName.Add("Zoey"); femaleFirstName.Add("Nora");
        femaleFirstName.Add("Lily"); femaleFirstName.Add("Eleanor"); femaleFirstName.Add("Hannah"); femaleFirstName.Add("Lillian"); femaleFirstName.Add("Addison");
        femaleFirstName.Add("Aubrey"); femaleFirstName.Add("Ellie"); femaleFirstName.Add("Stella"); femaleFirstName.Add("Natalie"); femaleFirstName.Add("Zoe");
        femaleFirstName.Add("Leah"); femaleFirstName.Add("Hazel"); femaleFirstName.Add("Violet"); femaleFirstName.Add("Aurora"); femaleFirstName.Add("Savannah");
        femaleFirstName.Add("Audrey"); femaleFirstName.Add("Brooklyn"); femaleFirstName.Add("Bella"); femaleFirstName.Add("Claire"); femaleFirstName.Add("Lucy");
        femaleFirstName.Add("Everly"); femaleFirstName.Add("Anna"); femaleFirstName.Add("Caroline"); femaleFirstName.Add("Nova"); femaleFirstName.Add("Emilia");
        femaleFirstName.Add("Samantha"); femaleFirstName.Add("Maya"); femaleFirstName.Add("Willow"); femaleFirstName.Add("Kinsley"); femaleFirstName.Add("Noami");
        femaleFirstName.Add("Aaliyah"); femaleFirstName.Add("Elena"); femaleFirstName.Add("Sarah"); femaleFirstName.Add("Ariana"); femaleFirstName.Add("Allison");
        femaleFirstName.Add("Gabriella"); femaleFirstName.Add("Alice"); femaleFirstName.Add("Madelyn"); femaleFirstName.Add("Cora"); femaleFirstName.Add("Ruby");
        femaleFirstName.Add("Eva"); femaleFirstName.Add("Autumn"); femaleFirstName.Add("Adeline"); femaleFirstName.Add("Hailey"); femaleFirstName.Add("Gianna");
        femaleFirstName.Add("Valentina"); femaleFirstName.Add("Isla"); femaleFirstName.Add("Eliana"); femaleFirstName.Add("Quinn"); femaleFirstName.Add("Nevaeh");
        femaleFirstName.Add("Ivy"); femaleFirstName.Add("Sadie"); femaleFirstName.Add("Piper"); femaleFirstName.Add("Lydia"); femaleFirstName.Add("Alexa");
        femaleFirstName.Add("Julia"); femaleFirstName.Add("Delilah"); femaleFirstName.Add("Arianna"); femaleFirstName.Add("Vivian"); femaleFirstName.Add("Kaylee");
        femaleFirstName.Add("Brielle"); femaleFirstName.Add("Madeline"); femaleFirstName.Add("Peyton"); femaleFirstName.Add("Rylee"); femaleFirstName.Add("Clara");
        femaleFirstName.Add("Hadley"); femaleFirstName.Add("Melanie"); femaleFirstName.Add("Mackenzie"); femaleFirstName.Add("Reagan"); femaleFirstName.Add("Adalynn");
        femaleFirstName.Add("Liliana"); femaleFirstName.Add("Aubree"); femaleFirstName.Add("Jade"); femaleFirstName.Add("Katherine"); femaleFirstName.Add("Isabelle");
        femaleFirstName.Add("Natalia"); femaleFirstName.Add("Raelynn"); femaleFirstName.Add("Maria"); femaleFirstName.Add("Arya"); femaleFirstName.Add("Athena");
        femaleFirstName.Add("Leilani"); femaleFirstName.Add("Taylor"); femaleFirstName.Add("Faith"); femaleFirstName.Add("Rose"); femaleFirstName.Add("Kylie");
        femaleFirstName.Add("Alexandra"); femaleFirstName.Add("Mary"); femaleFirstName.Add("Margaret"); femaleFirstName.Add("Lyla"); femaleFirstName.Add("Ashley");
        femaleFirstName.Add("Amaya"); femaleFirstName.Add("Eliza"); femaleFirstName.Add("Brianna"); femaleFirstName.Add("Bailey"); femaleFirstName.Add("Andrea");
        femaleFirstName.Add("Khloe"); femaleFirstName.Add("Jasmine"); femaleFirstName.Add("Melody"); femaleFirstName.Add("Iris"); femaleFirstName.Add("Isabel");
        femaleFirstName.Add("Annabelle"); femaleFirstName.Add("Valeria"); femaleFirstName.Add("Adalyn"); femaleFirstName.Add("Ryleigh"); femaleFirstName.Add("Eden");
        femaleFirstName.Add("Anastasia"); femaleFirstName.Add("Kayla"); femaleFirstName.Add("Alyssa"); femaleFirstName.Add("Juliana"); femaleFirstName.Add("Charlie");
        femaleFirstName.Add("Esther"); femaleFirstName.Add("Ariel"); femaleFirstName.Add("Cecilia"); femaleFirstName.Add("Valerie"); femaleFirstName.Add("Alina");
        femaleFirstName.Add("Cecilia"); femaleFirstName.Add("Valerie"); femaleFirstName.Add("Molly"); femaleFirstName.Add("Aliyah"); femaleFirstName.Add("Lilly");
        femaleFirstName.Add("Morgan"); femaleFirstName.Add("Sydney"); femaleFirstName.Add("Jordyn"); femaleFirstName.Add("Eloise"); femaleFirstName.Add("Trinity");
        femaleFirstName.Add("Daisy"); femaleFirstName.Add("Kimberly"); femaleFirstName.Add("Lauren"); femaleFirstName.Add("Genevieve"); femaleFirstName.Add("Sara");
        femaleFirstName.Add("Arabella"); femaleFirstName.Add("Harmony"); femaleFirstName.Add("Elise"); femaleFirstName.Add("Teagan"); femaleFirstName.Add("Alexis");
        femaleFirstName.Add("Sloane"); femaleFirstName.Add("Laila"); femaleFirstName.Add("Lucia"); femaleFirstName.Add("Juliette"); femaleFirstName.Add("Diana");
        femaleFirstName.Add("Sienna"); femaleFirstName.Add("Josie"); femaleFirstName.Add("Alaina"); femaleFirstName.Add("Mckenzi"); femaleFirstName.Add("Everleigh");
        femaleFirstName.Add("Ember"); femaleFirstName.Add("Joanna"); femaleFirstName.Add("Nicole"); femaleFirstName.Add("Payton"); femaleFirstName.Add("Paige");
        femaleFirstName.Add("Mariah"); femaleFirstName.Add("Georgia"); femaleFirstName.Add("Jasmine"); femaleFirstName.Add("Yasmine"); femaleFirstName.Add("Niamh");
        femaleFirstName.Add("Lila"); femaleFirstName.Add("Adelyn"); femaleFirstName.Add("Alivia"); femaleFirstName.Add("Noelle"); femaleFirstName.Add("Vanessa");
        femaleFirstName.Add("Makayla"); femaleFirstName.Add("Angelina"); femaleFirstName.Add("Adaline"); femaleFirstName.Add("Juliet"); femaleFirstName.Add("Tessa");
        femaleFirstName.Add("Dakota"); femaleFirstName.Add("Ada"); femaleFirstName.Add("Hope"); femaleFirstName.Add("Selena"); femaleFirstName.Add("Zara");
        femaleFirstName.Add("Izabella"); femaleFirstName.Add("Raegan"); femaleFirstName.Add("Michelle"); femaleFirstName.Add("Thea"); femaleFirstName.Add("Freya");
        femaleFirstName.Add("Elaina"); femaleFirstName.Add("Olive"); femaleFirstName.Add("Aspen"); femaleFirstName.Add("Kali"); femaleFirstName.Add("Amiyah");
        femaleFirstName.Add("Elsie"); femaleFirstName.Add("Alexandria"); femaleFirstName.Add("Ariella"); femaleFirstName.Add("Mariana"); femaleFirstName.Add("Lilah");
        femaleFirstName.Add("Nyla"); femaleFirstName.Add("Jane"); femaleFirstName.Add("Zuri"); femaleFirstName.Add("Lucille"); femaleFirstName.Add("Leia");
        femaleFirstName.Add("Giselle"); femaleFirstName.Add("Miriam"); femaleFirstName.Add("Gabrielle"); femaleFirstName.Add("Sage"); femaleFirstName.Add("Annie");
        femaleFirstName.Add("Lilliana"); femaleFirstName.Add("Haven"); femaleFirstName.Add("Kaia"); femaleFirstName.Add("Magnolia"); femaleFirstName.Add("Amira");
        femaleFirstName.Add("Adelynn"); femaleFirstName.Add("Nina"); femaleFirstName.Add("Arielle"); femaleFirstName.Add("Evie"); femaleFirstName.Add("Paris");
        femaleFirstName.Add("Gracelyn"); femaleFirstName.Add("Grace"); femaleFirstName.Add("Talia"); femaleFirstName.Add("Maeve"); femaleFirstName.Add("Rylie");
        femaleFirstName.Add("Lexi"); femaleFirstName.Add("Ariah"); femaleFirstName.Add("Fatima"); femaleFirstName.Add("Kehlani"); femaleFirstName.Add("Alani");
        femaleFirstName.Add("Ariyah"); femaleFirstName.Add("Luciana"); femaleFirstName.Add("Heidi"); femaleFirstName.Add("Maci"); femaleFirstName.Add("Joy");
        femaleFirstName.Add("Lana"); femaleFirstName.Add("Keira"); femaleFirstName.Add("Angel"); femaleFirstName.Add("Daniella"); femaleFirstName.Add("Ophelia");
        femaleFirstName.Add("Megan"); femaleFirstName.Add("Victoria"); femaleFirstName.Add("Eliza"); femaleFirstName.Add("Courtney"); femaleFirstName.Add("Yennifer");
        femaleFirstName.Add("Helen"); femaleFirstName.Add("Regina"); femaleFirstName.Add("Sarai"); femaleFirstName.Add("Dahlia"); femaleFirstName.Add("Nayeli");
        femaleFirstName.Add("Raven"); femaleFirstName.Add("Averie"); femaleFirstName.Add("Kelsey"); femaleFirstName.Add("Maliyah"); femaleFirstName.Add("Erin");
        femaleFirstName.Add("Viviana"); femaleFirstName.Add("Jenna"); femaleFirstName.Add("Anaya"); femaleFirstName.Add("Carolina"); femaleFirstName.Add("Sabrina");
        femaleFirstName.Add("Octavia"); femaleFirstName.Add("Carmen"); femaleFirstName.Add("Yaretzi"); femaleFirstName.Add("Zariah"); femaleFirstName.Add("Mabel");
        femaleFirstName.Add("Christina"); femaleFirstName.Add("Selah"); femaleFirstName.Add("Celeste"); femaleFirstName.Add("Eve"); femaleFirstName.Add("Milani");
        femaleFirstName.Add("Frances"); femaleFirstName.Add("Kathleen"); femaleFirstName.Add("Jimena"); femaleFirstName.Add("Katie"); femaleFirstName.Add("Kayleigh");
        femaleFirstName.Add("Sierra"); femaleFirstName.Add("Rosemary"); femaleFirstName.Add("Jolene"); femaleFirstName.Add("Elisa"); femaleFirstName.Add("Hallie");
        femaleFirstName.Add("Lainey"); femaleFirstName.Add("Avah"); femaleFirstName.Add("Siobahn"); femaleFirstName.Add("Mira"); femaleFirstName.Add("Cheyenne");
        femaleFirstName.Add("Francesca"); femaleFirstName.Add("Wren"); femaleFirstName.Add("Amber"); femaleFirstName.Add("Nia"); femaleFirstName.Add("Abby");
        femaleFirstName.Add("April"); femaleFirstName.Add("Emelia"); femaleFirstName.Add("Carter"); femaleFirstName.Add("Aylin"); femaleFirstName.Add("Cataleya");
        femaleFirstName.Add("Bethany"); femaleFirstName.Add("Marlee"); femaleFirstName.Add("Carly"); femaleFirstName.Add("Kaylani"); femaleFirstName.Add("Liana");
        femaleFirstName.Add("Madelynn"); femaleFirstName.Add("Cadence"); femaleFirstName.Add("Matilda"); femaleFirstName.Add("Sylvia"); femaleFirstName.Add("Myra");
        femaleFirstName.Add("Elianna"); femaleFirstName.Add("Hattie"); femaleFirstName.Add("Dayana"); femaleFirstName.Add("Kendra"); femaleFirstName.Add("Maisie");
        femaleFirstName.Add("Kara"); femaleFirstName.Add("Katelyn"); femaleFirstName.Add("Maia"); femaleFirstName.Add("Celine"); femaleFirstName.Add("Renata");
        femaleFirstName.Add("Jayleen"); femaleFirstName.Add("Charli"); femaleFirstName.Add("Emmalyn"); femaleFirstName.Add("Holly"); femaleFirstName.Add("Azalea");
        femaleFirstName.Add("Leona"); femaleFirstName.Add("Alejandra"); femaleFirstName.Add("Imani"); femaleFirstName.Add("Meadow"); femaleFirstName.Add("Alexia");
        femaleFirstName.Add("Edith"); femaleFirstName.Add("Leslie"); femaleFirstName.Add("Lilith"); femaleFirstName.Add("Kora"); femaleFirstName.Add("Aisha");
        femaleFirstName.Add("Meredith"); femaleFirstName.Add("Danna"); femaleFirstName.Add("Emberly"); femaleFirstName.Add("Julieta"); femaleFirstName.Add("Michaela");
        femaleFirstName.Add("Alayah"); femaleFirstName.Add("Jemma"); femaleFirstName.Add("Colette"); femaleFirstName.Add("Johanna"); femaleFirstName.Add("Virginia");
        femaleFirstName.Add("Briana"); femaleFirstName.Add("Adelina"); femaleFirstName.Add("Angelica"); femaleFirstName.Add("Mariam"); femaleFirstName.Add("Macie");
        femaleFirstName.Add("Mae"); femaleFirstName.Add("Mallory"); femaleFirstName.Add("Esme"); femaleFirstName.Add("Madilynn"); femaleFirstName.Add("Charley");
        femaleFirstName.Add("Allyson"); femaleFirstName.Add("Hanna"); femaleFirstName.Add("Maryam"); femaleFirstName.Add("Ivanna"); femaleFirstName.Add("Ashlynn");
        femaleFirstName.Add("Amora"); femaleFirstName.Add("Ashlyn"); femaleFirstName.Add("Sasha"); femaleFirstName.Add("Baylee"); femaleFirstName.Add("Beatrice");
        femaleFirstName.Add("Priscilla"); femaleFirstName.Add("Marie"); femaleFirstName.Add("Jayda"); femaleFirstName.Add("Alessia"); femaleFirstName.Add("Alaia");
        femaleFirstName.Add("Janelle"); femaleFirstName.Add("Kalani"); femaleFirstName.Add("Gloria"); femaleFirstName.Add("Sloan"); femaleFirstName.Add("Dorothy");
        femaleFirstName.Add("Greta"); femaleFirstName.Add("Savanna"); femaleFirstName.Add("Annabella"); femaleFirstName.Add("Poppy"); femaleFirstName.Add("Amalia");
        femaleFirstName.Add("Cecelia"); femaleFirstName.Add("Coraline"); femaleFirstName.Add("Kimber"); femaleFirstName.Add("Emmie"); femaleFirstName.Add("Anne");
        femaleFirstName.Add("Karina"); femaleFirstName.Add("Kassidy"); femaleFirstName.Add("Jazmin"); femaleFirstName.Add("Maren"); femaleFirstName.Add("Monica");
        femaleFirstName.Add("Siena"); femaleFirstName.Add("Kyra"); femaleFirstName.Add("Lilian"); femaleFirstName.Add("Melany"); femaleFirstName.Add("Alaya");
        femaleFirstName.Add("Kelly"); femaleFirstName.Add("Rosie"); femaleFirstName.Add("Laurel"); femaleFirstName.Add("Mina"); femaleFirstName.Add("Karla");
        femaleFirstName.Add("Aubrie"); femaleFirstName.Add("Katalina"); femaleFirstName.Add("Melina"); femaleFirstName.Add("Elaine"); femaleFirstName.Add("Karen");
    }
    public void SetUpSecondName()
    {
        secondName.Add("Andrews"); secondName.Add("Adams"); secondName.Add("Townsend"); secondName.Add("Wood"); secondName.Add("Murray"); secondName.Add("Banner");
        secondName.Add("Parker"); secondName.Add("Lomax"); secondName.Add("Lomas"); secondName.Add("Newsome"); secondName.Add("Lynham"); secondName.Add("Kitchen");
        secondName.Add("Hoxha"); secondName.Add("Shehu"); secondName.Add("Leka"); secondName.Add("Luka"); secondName.Add("Murati"); secondName.Add("Hassan");
        secondName.Add("Hassani"); secondName.Add("Marku"); secondName.Add("Sinani"); secondName.Add("Gruber"); secondName.Add("Bauer"); secondName.Add("Muller");
        secondName.Add("Mayer"); secondName.Add("Fuchs"); secondName.Add("Hofer"); secondName.Add("Eder"); secondName.Add("Fischer"); secondName.Add("Schmid");
        secondName.Add("Stark");secondName.Add("Schwarz"); secondName.Add("Schmidt"); secondName.Add("Lechner"); secondName.Add("Lang"); secondName.Add("Haas"); 
        secondName.Add("Koller"); secondName.Add("Weiland"); secondName.Add("Wold"); secondName.Add("Peters"); secondName.Add("Peeters"); secondName.Add("Janssens");
        secondName.Add("Jacobs"); secondName.Add("Mertens"); secondName.Add("Williams"); secondName.Add("Willems"); secondName.Add("Claes"); secondName.Add("Claus");
        secondName.Add("Wouters"); secondName.Add("Dubois"); secondName.Add("Joshua"); secondName.Add("Dupont"); secondName.Add("Dupont"); secondName.Add("Simon");
        secondName.Add("Terzic"); secondName.Add("Zukic"); secondName.Add("Delic"); secondName.Add("Lukic"); secondName.Add("Radic"); secondName.Add("Novak");
        secondName.Add("Matic"); secondName.Add("Petrovic"); secondName.Add("Tomic"); secondName.Add("Kovac"); secondName.Add("Bozic"); secondName.Add("Nielsen");
        secondName.Add("Jensen"); secondName.Add("Hansen"); secondName.Add("Pederson"); secondName.Add("Anderson"); secondName.Add("Christensen"); secondName.Add("Larsen");
        secondName.Add("Sorensen"); secondName.Add("Olsen"); secondName.Add("Madsen"); secondName.Add("Thomsen"); secondName.Add("Johansen"); secondName.Add("Pedersen");
        secondName.Add("Tamm"); secondName.Add("Kask"); secondName.Add("Saar"); secondName.Add("Sepp"); secondName.Add("Ivanov"); secondName.Add("Petrov"); secondName.Add("Pavlov");
        secondName.Add("Mikkelsen"); secondName.Add("Sorensen"); secondName.Add("Johansen"); secondName.Add("Nielsen"); secondName.Add("Poulsen"); secondName.Add("Niemi");
        secondName.Add("Saarinen"); secondName.Add("Lindholm"); secondName.Add("Karlsson"); secondName.Add("Bernard"); secondName.Add("Durand"); secondName.Add("Robert");
        secondName.Add("Leroy"); secondName.Add("Bertrand"); secondName.Add("Roux"); secondName.Add("Vincent"); secondName.Add("Michel"); secondName.Add("David");
        secondName.Add("Garcia"); secondName.Add("Laurent"); secondName.Add("Fournier"); secondName.Add("Morel"); secondName.Add("Andre"); secondName.Add("Mercier");
        secondName.Add("Martinez"); secondName.Add("Meyer"); secondName.Add("Schulz"); secondName.Add("Wagner"); secondName.Add("Becker"); secondName.Add("Hoffman");
        secondName.Add("Weber"); secondName.Add("Samaras"); secondName.Add("Kritikos"); secondName.Add("Koufos"); secondName.Add("Giannidis"); secondName.Add("Giannakos");
        secondName.Add("Kelly"); secondName.Add("O'Kelly"); secondName.Add("Sullivan"); secondName.Add("O'Sullivan"); secondName.Add("O'Brien"); secondName.Add("O'Byrne");
        secondName.Add("O'Ryan"); secondName.Add("O'Connor"); secondName.Add("Connor"); secondName.Add("O'Neill"); secondName.Add("O'Reilly"); secondName.Add("Doyle");
        secondName.Add("McCarthy"); secondName.Add("O'Gallagher"); secondName.Add("O'Doherty"); secondName.Add("Rossi"); secondName.Add("Russo"); secondName.Add("Romano");
        secondName.Add("Ricci"); secondName.Add("De Luca"); secondName.Add("Conti"); secondName.Add("Mancini"); secondName.Add("Rizzo"); secondName.Add("Lombardi");
        secondName.Add("Moretti"); secondName.Add("Fontana"); secondName.Add("Ferrara"); secondName.Add("Testa"); secondName.Add("De Rosa"); secondName.Add("Rossetti");
        secondName.Add("De Jong"); secondName.Add("De Vries"); secondName.Add("Van den Berg"); secondName.Add("Van Dijk"); secondName.Add("Bakker"); secondName.Add("Visser");
        secondName.Add("De Boer"); secondName.Add("Van Leeuwen"); secondName.Add("Hendriks"); secondName.Add("Larsen"); secondName.Add("Eriksen"); secondName.Add("Berg");
        secondName.Add("Hagen"); secondName.Add("Jorgensen"); secondName.Add("Karlsen"); secondName.Add("Lund"); secondName.Add("Nowak"); secondName.Add("Wozniak");
        secondName.Add("Jankowski"); secondName.Add("Silva"); secondName.Add("Santos"); secondName.Add("Ferreira"); secondName.Add("Costa"); secondName.Add("Martins");
        secondName.Add("Jesus"); secondName.Add("Sousa"); secondName.Add("Fernandes"); secondName.Add("Gomes"); secondName.Add("Lopes"); secondName.Add("Torres");
        secondName.Add("Rodrigues"); secondName.Add("Alves"); secondName.Add("Carvalho"); secondName.Add("Texeira"); secondName.Add("Moreira"); secondName.Add("Cruz");
        secondName.Add("Reis"); secondName.Add("Castro"); secondName.Add("Stam"); secondName.Add("Popov"); secondName.Add("Kozlov"); secondName.Add("Petrov"); 
        secondName.Add("Ortiz"); secondName.Add("Morales"); secondName.Add("Garcia"); secondName.Add("Diaz"); secondName.Add("Delgado"); secondName.Add("Fernandez"); 
        secondName.Add("Santana"); secondName.Add("Alonso"); secondName.Add("Gutierrez"); secondName.Add("Reyes"); secondName.Add("Alvarez"); secondName.Add("Svensson"); 
        secondName.Add("Lindberg"); secondName.Add("Magnusson"); secondName.Add("Jonsson"); secondName.Add("Nilsson"); secondName.Add("Schevchenko"); secondName.Add("Melnyk"); 
        secondName.Add("Bondar"); secondName.Add("Marchenko"); secondName.Add("Petrenko"); secondName.Add("Kovalenko"); secondName.Add("Smith"); secondName.Add("Jones"); 
        secondName.Add("Brown"); secondName.Add("Wilson"); secondName.Add("Johnson"); secondName.Add("Davies"); secondName.Add("Robinson"); secondName.Add("Wright"); 
        secondName.Add("Evans"); secondName.Add("Green"); secondName.Add("Black"); secondName.Add("Evans"); secondName.Add("Hall"); secondName.Add("Jackson"); 
        secondName.Add("Patel"); secondName.Add("Kahn"); secondName.Add("Ali"); secondName.Add("Mitchell"); secondName.Add("Lewis"); secondName.Add("Rose"); 
        secondName.Add("Moore"); secondName.Add("Hamilton"); secondName.Add("Hughes"); secondName.Add("Robertson"); secondName.Add("Reid"); secondName.Add("Stewart"); 
        secondName.Add("Watson"); secondName.Add("Jones"); secondName.Add("Griffiths"); secondName.Add("Rees"); secondName.Add("Jenkins"); secondName.Add("Price"); 
        secondName.Add("O'Driscoll"); secondName.Add("Roy"); secondName.Add("Hernandez"); secondName.Add("Rodriguez"); secondName.Add("Gonzalez"); secondName.Add("Ramirez"); 
        secondName.Add("Perez"); secondName.Add("Sanchez"); secondName.Add("Vasquez"); secondName.Add("Rojas"); secondName.Add("Herrera"); secondName.Add("Lopez"); 
        secondName.Add("Pena"); secondName.Add("Castillo"); secondName.Add("Guzman"); secondName.Add("De la Cruz"); secondName.Add("Gomez"); secondName.Add("Nunez"); 
        secondName.Add("Mendez"); secondName.Add("Moreno"); secondName.Add("Rivera"); secondName.Add("Ortega"); secondName.Add("Luna"); secondName.Add("Cortez"); 
        secondName.Add("Harris"); secondName.Add("Samson"); secondName.Add("Young"); secondName.Add("Green"); secondName.Add("Baker"); secondName.Add("Stewart");  
        secondName.Add("Cooper"); secondName.Add("Reed"); secondName.Add("Cox"); secondName.Add("Ward"); secondName.Add("Bell"); secondName.Add("Richardson"); 
        secondName.Add("Myers"); secondName.Add("Powell"); secondName.Add("Butler"); secondName.Add("Allen"); secondName.Add("King"); secondName.Add("Petty");  
        secondName.Add("Stephens"); secondName.Add("Seaward"); secondName.Add("Lindop"); secondName.Add("James"); secondName.Add("Bruz"); secondName.Add("Iglesias"); 
        secondName.Add("Dixon"); secondName.Add("Dickons"); secondName.Add("Reeves"); secondName.Add("Snow"); secondName.Add("Skywalker"); secondName.Add("Bolton"); 
        secondName.Add("Aguero"); secondName.Add("Quinn"); secondName.Add("Maguire"); secondName.Add("Cardoso"); secondName.Add("Cardosa"); secondName.Add("Melo"); 
        secondName.Add("Schuster"); secondName.Add("Crow"); secondName.Add("Ramos"); secondName.Add("Leon"); secondName.Add("Taylor"); secondName.Add("Koval");
        secondName.Add("Gustafsson"); secondName.Add("Clarke"); secondName.Add("Thompson"); secondName.Add("Walker"); secondName.Add("Mason"); secondName.Add("Campbell");
        secondName.Add("Medina"); secondName.Add("Ross"); secondName.Add("Young"); secondName.Add("Mora"); secondName.Add("Madrigal"); secondName.Add("Alvarez");
        secondName.Add("De Los Santos"); secondName.Add("Vargas"); secondName.Add("Miller"); secondName.Add("White"); secondName.Add("Lee"); secondName.Add("Morris");
        secondName.Add("Cook"); secondName.Add("Morgan"); secondName.Add("Watson"); secondName.Add("Brooks"); secondName.Add("Hughes"); secondName.Add("Pretty");
        secondName.Add("Flores"); secondName.Add("Gimenez"); secondName.Add("Varela"); secondName.Add("Buxton"); secondName.Add("Baggins"); secondName.Add("Underhill");
        secondName.Add("Montes"); secondName.Add("Featherstone");secondName.Add("Balboa");secondName.Add("Shannow"); secondName.Add("Potter");secondName.Add("Durden");

    }
    public void SetUpNationality()
    {
        nationality.Add("Afghanistan"); nationality.Add("Australia"); nationality.Add("Bahrain"); nationality.Add("Bangladesh"); nationality.Add("Bhutan"); nationality.Add("Brunei");
        nationality.Add("Cambodia"); nationality.Add("China"); nationality.Add("Guam"); nationality.Add("Hong Kong"); nationality.Add("India"); nationality.Add("Indonesia"); nationality.Add("Iran");
        nationality.Add("Iraq"); nationality.Add("Japan"); nationality.Add("Jordan"); nationality.Add("Kuwait"); nationality.Add("Kyrgyzstan"); nationality.Add("Laos"); nationality.Add("Lebanon");
        nationality.Add("Macau"); nationality.Add("Malaysia"); nationality.Add("Maldives"); nationality.Add("Mongolia"); nationality.Add("Myanmar"); nationality.Add("North Korea"); nationality.Add("Nepal");
        nationality.Add("Oman"); nationality.Add("Pakistan"); nationality.Add("Phillipines"); nationality.Add("Palestine"); nationality.Add("Qatar"); nationality.Add("South Korea"); nationality.Add("Sri Lanka");
        nationality.Add("Saudi Arabia"); nationality.Add("Singapore"); nationality.Add("Syria"); nationality.Add("Chinese Taipei"); nationality.Add("Tajikistan"); nationality.Add("Thailand"); nationality.Add("Timor-Leste");
        nationality.Add("Turkmenistan"); nationality.Add("UAE"); nationality.Add("Uzbekistan"); nationality.Add("Vietnam"); nationality.Add("Yemen"); nationality.Add("Algeria"); nationality.Add("Angola"); nationality.Add("Benin");
        nationality.Add("Botswana"); nationality.Add("Burkina Faso"); nationality.Add("Burundi"); nationality.Add("Cape Verde"); nationality.Add("Central African Republic"); nationality.Add("Chad"); nationality.Add("Cameroon");
        nationality.Add("Comoros"); nationality.Add("Congo"); nationality.Add("Djibouti"); nationality.Add("Dr Congo"); nationality.Add("Egypt"); nationality.Add("Equatorial Guinea"); nationality.Add("Eritrea");
        nationality.Add("Ethiopia"); nationality.Add("Gabon"); nationality.Add("Gambia"); nationality.Add("Guinea-Bissau"); nationality.Add("Ghana"); nationality.Add("Guinea"); nationality.Add("Côte D'Ivoire"); nationality.Add("Kenya");
        nationality.Add("Lesotho"); nationality.Add("Liberia");nationality.Add("Libya"); nationality.Add("Mauritania"); nationality.Add("Madagascar"); nationality.Add("Malawi"); nationality.Add("Mali"); nationality.Add("Morocco");
        nationality.Add("Mozambique"); nationality.Add("Mauritius"); nationality.Add("Namibia"); nationality.Add("Niger"); nationality.Add("Nigeria"); nationality.Add("Rwanda"); nationality.Add("South Africa"); nationality.Add("São Tomé and Príncipe");
        nationality.Add("Senegal"); nationality.Add("Seychelles"); nationality.Add("Sierra Leone"); nationality.Add("Somalia"); nationality.Add("Sudan"); nationality.Add("Swaziland"); nationality.Add("Tanzania"); nationality.Add("Togo");
        nationality.Add("Tunisia"); nationality.Add("Uganda"); nationality.Add("Zambia"); nationality.Add("Zimbabwe"); nationality.Add("Anguilla"); nationality.Add("Antigua and Barbuda"); nationality.Add("Aruba"); nationality.Add("Bahamas");
        nationality.Add("Belize"); nationality.Add("Bermuda"); nationality.Add("Barbados"); nationality.Add("British Virgin Islands"); nationality.Add("Costa Rica"); nationality.Add("Canada"); nationality.Add("Cayman Islands");
        nationality.Add("Cuba"); nationality.Add("Curacao"); nationality.Add("Dominica"); nationality.Add("Dominican Republic"); nationality.Add("El Salvador"); nationality.Add("Guadeloupe"); nationality.Add("Grenada"); nationality.Add("Guatemala");
        nationality.Add("Guyana"); nationality.Add("Haiti"); nationality.Add("Honduras"); nationality.Add("Jamaica"); nationality.Add("Mexico"); nationality.Add("Montserrat"); nationality.Add("Nicaragua"); nationality.Add("Puerto Rico");
        nationality.Add("Panama"); nationality.Add("St Vincents and Grenadines"); nationality.Add("St Kitts and Nevis"); nationality.Add("St Lucia"); nationality.Add("Suriname"); nationality.Add("Trinidad and Tobago"); nationality.Add("Turks and Caicos Islands");
        nationality.Add("US Virgin Islands"); nationality.Add("USA"); nationality.Add("Argentina"); nationality.Add("Bolivia"); nationality.Add("Brazil"); nationality.Add("Chile"); nationality.Add("Colombia"); nationality.Add("Ecuador");
        nationality.Add("Peru"); nationality.Add("Paraguay"); nationality.Add("Uruguay"); nationality.Add("Venezuela"); nationality.Add("American Samoa"); nationality.Add("Cook Islands"); nationality.Add("Fiji"); nationality.Add("New Caledonia");
        nationality.Add("New Zealand"); nationality.Add("Papua New Guinea"); nationality.Add("Albania"); nationality.Add("Andorra"); nationality.Add("Armenia"); nationality.Add("Austria"); nationality.Add("Azerbaijan"); nationality.Add("Belarus");
        nationality.Add("Belgium"); nationality.Add("Bosnia"); nationality.Add("Bulgaria"); nationality.Add("Croatia"); nationality.Add("Cyprus"); nationality.Add("Czech Republic"); nationality.Add("Denmark"); nationality.Add("England");
        nationality.Add("Estonia"); nationality.Add("Faroe Islands"); nationality.Add("Finland"); nationality.Add("France"); nationality.Add("Gibraltar"); nationality.Add("Georgia"); nationality.Add("Germany"); nationality.Add("Greece");
        nationality.Add("Hungary"); nationality.Add("Iceland"); nationality.Add("Israel"); nationality.Add("Italy"); nationality.Add("Kazakhstan"); nationality.Add("Kosovo"); nationality.Add("Latvia"); nationality.Add("Liechtenstein");
        nationality.Add("Lithuania"); nationality.Add("Luxembourg"); nationality.Add("Macedonia"); nationality.Add("Malta"); nationality.Add("Moldova"); nationality.Add("Montengro"); nationality.Add("Northern Ireland"); nationality.Add("Netherlands");
        nationality.Add("Norway"); nationality.Add("Poland"); nationality.Add("Portugal"); nationality.Add("Ireland"); nationality.Add("Romania"); nationality.Add("Russia"); nationality.Add("San Marino"); nationality.Add("Scotland"); nationality.Add("Serbia");
        nationality.Add("Slovakia"); nationality.Add("Slovenia"); nationality.Add("Spain"); nationality.Add("Sweden"); nationality.Add("Switzerland"); nationality.Add("Turkey"); nationality.Add("Ukraine"); nationality.Add("Wales");
    }
    public void SetUpLeagueName()
    {
        leagueName.Add("Albanian Superlega");leagueName.Add("Andoran Primera Divisio");leagueName.Add("Armenian Premier League");leagueName.Add("Austrian Bundesliga");
        leagueName.Add("Azerbaijan Premier League");leagueName.Add("Belarus Premier league");leagueName.Add("Belgium First Division");leagueName.Add("Premier League of Bosnia");
        leagueName.Add("Bulgaria First Pro League");leagueName.Add("Croatian First League");leagueName.Add("Cypriot First Division");leagueName.Add("Czech First League");
        leagueName.Add("Danish Supaliga");leagueName.Add("English Premier League");leagueName.Add("English Championship");leagueName.Add("English League 1");
        leagueName.Add("English League 2");leagueName.Add("English Conference");leagueName.Add("Estonian Meistriligia");leagueName.Add("Faroe Premier League");
        leagueName.Add("Finnish Viekkausliga");leagueName.Add("French Ligue 1");leagueName.Add("French Ligue 2");leagueName.Add("Gibraltar Premier League");
        leagueName.Add("Georgian Erovnuli Liga");leagueName.Add("German Bundersliga"); leagueName.Add("German Bundersliga 2"); leagueName.Add("Greek Superleague");
        leagueName.Add("Hungary Nemzeti Bajnoksag"); leagueName.Add("Icelandic Urvalsdelid"); leagueName.Add("Israeli Premier League");leagueName.Add("Italian Serie A");
        leagueName.Add("Italian Serie B"); leagueName.Add("Kazakhstan Premier League");leagueName.Add("Kosovo Superleague"); leagueName.Add("Latvian Virsliga");
        leagueName.Add("Liechtenstein Premier League"); leagueName.Add("Latvian Virsliga"); leagueName.Add("Lithuanian A lyga"); leagueName.Add("Latvian Virsliga");
        leagueName.Add("Luxembourg first Division"); leagueName.Add("Nrth Macedonian First League"); leagueName.Add("Maltese Premier League"); leagueName.Add("Moldovan First Division");
        leagueName.Add("Montenegrin First League"); leagueName.Add("NIFL Premier League"); leagueName.Add("Latvian Virsliga");leagueName.Add("Netherlands Eredivisie");
        leagueName.Add("Norwegian Eliteserien");leagueName.Add("Polish Ekstraklasa"); leagueName.Add("Portuguese Premiera League"); leagueName.Add("Irish Premier Division");
        leagueName.Add("Romanian Liga 1"); leagueName.Add("Russian Premier League"); leagueName.Add("San Marino First  League"); leagueName.Add("Scottish Premier League");
        leagueName.Add("Serbian SuperLiga"); leagueName.Add("Slovak Super Liga"); leagueName.Add("Slovenian PrvaLiga"); leagueName.Add("Spanish La Liga");
        leagueName.Add("Spanish La liga B"); leagueName.Add("Swedish Allsvensken");leagueName.Add("Swiss Super League"); leagueName.Add("Turkish Super Lig");
        leagueName.Add("Ukrainian Premier League");leagueName.Add("Welsh Cymru Premier League");
    }
    
    public int[] SetUpStats(int i)
    {
        
        for (int j = 0; j <= 14; j++)
        {
            stats[j] = (85 - (i * 5) + (Random.Range(-5,15)));
        }
        
        return stats;
    }
    public string GetMaleName()
    {
        //Debug.Log("Trying to get a male name");   
        int i = Random.Range(0, 395);
        return maleFirstName[i];
    }
    public string GetFemaleName()
    {
        int i = Random.Range(0, 409);
        return femaleFirstName[i];
    }
    public string GetSecondName()
    {
        int i = Random.Range(0, 348);
        return secondName[i];
    }
    public string GetNationality()
    {
        int i = Random.Range(0, 205);
        return nationality[i];
    }
    public string GetDescription(int i)
    {
        int goalDiff = i;
        return teamDescription[goalDiff];
    }
    public string GetPlayerDescription(int i)
    {
        int playerGoals = i;
        return teamDescription[playerGoals];
    }
    public int SetAge()
    {
        int i = Random.Range(16, 50);
        return i;
    }
    public string SortDate(int _date)
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
        return weeks + "/" + months + "/" + years;
    }
}

//0 Afghanistan                                ////102 Bahamas         
//1 Australia                                  ////103 Belize
//2 Bahrain                                    ////104 Bermuda
//3 Bangladesh                                 ////105 Barbados
//4 Bhutan                                     ////106 British Virgin Islands
//5 Brunei                                     ////107 Costa Rica
//6 Cambodia                                   ////108 Canada
//7 China                                      ////109 Cayman Islands
//8 Guam                                       ////110 Cuba
//9 Hong Kong                                  ////111 Curacao
//10 India                                     ////112 Dominica
//11 Indonesia                                 ////113 Dominian Republic
//12 Iran                                      ////114 El Salvador
//13 Iraq                                      ////115 Guadeloupe
//14 Japan                                     ////116 Grenada
//15 Jordan                                    ////117 Guatemala
//16 Kuwait                                    ////118 Guyana
//17 Kyrgyzstan                                ////119 Haiti
//18 Laos                                      ////120 Honduras
//19 Lebananon                                 ////121 Jamaica
//20 Macau                                     ////122 Mexico
//21 Malaysia                                  ////123 Montserrat
//22 Maldives                                  ////124 Nicaragua
//23 Mongolia                                  ////125 Puerto Rico
//24 Myanmar                                   ////126 Panama
//25 North Korea                               ////127 St Vincents and Grenadines
//26 Nepal                                     ////128 St Kitts and Nevis
//27 Oman                                      ////129 St Lucia
//28 Pakistan                                  ////130 Suriname
//29 Phillipines                               ////131 Trinidad and Tobago
//30 Palestine                                 ////132 Turks and Caicos Islands
//31 Qatar                                     ////133 US Virgin Islands
//32 South Korea                               ////134 USA
//33 Sri Lanka                                 ////135 Argentina 
//34 Saudi Arabia                              ////136 Bolivia
//35 Singapore                                 ////137 Brazil
//36 Syria                                     ////138 Chile
//37 Chinese Taipei                            ////139 Columbia
//38 Tajikistan                                ////140 Ecuador
//39 Thailand                                  ////141 Peru
//40 Timor-Leste                               ////142 Paraguay
//41 Turkmenistan                              ////143 Uruguay
//42 UAE                                       ////144 Venezuela
//43 Uzbekistan                                ////145 American Samoa
//44 Vietnam                                   ////146 Cook Islands
//45 Yemen                                     ////147 Fiji
//46 Algeria                                   ////148 New Caledonia
//47 Angola                                    ////149 New Zealand
//48 Benin                                     ////150 Papua New Guinea
//49 Botswana                                  ////151 Albania
//50 Burkino Faso                              ////152 Andorra
//51 Burundi                                   ////153 Armenia
//52 Cape Verde                                ////154 Austria
//53 Central African Republic                  ////155 Azerbaijan
//54 Chad                                      ////156 Belarus
//55 Cameroon                                  ////157 Belgium
//56 Comoros                                   ////158 Bosnia
//57 Congo                                     ////159 Bulgaria
//58 Djibouti                                  ////160 Croatia
//59 Dr Congo                                  ////161 Cyprus
//60 Egypt                                     ////162 Czech Republic
//61 Equatorial Guinea                         ////163 Denmark
//62 Eritrea                                   ////164 England
//63 Ethiopia                                  ////165 Estonia
//64 Gabon                                     ////166 Faroe Islands
//65 Gambia                                    ////167 Finland
//66 Guinea-Bissau                             ////168 France
//67 Ghana                                     ////169 Gibraltar
//68 Guinea                                    ////170 Georgia
//69 Cote D'Ivoire                             ////171 Germany
//70 Kenya                                     ////172 Greece
//71 Lesotho                                   ////173 Hungary
//72 Liberia                                   ////174 Iceland
//73 Libya                                     ////175 Israel
//74 Mauritania                                ////176 Italy
//75 Madagascar                                ////177 Kazakhstan
//76 Malawi                                    ////178 Kosovo
//77 Mali                                      ////179 Latvia
//78 Morocco                                   ////180 Liechtenstein
//79 Mozambique                                ////181 Lithuania
//80 Mauritius                                 ////182 Luxembourg
//81 Namibia                                   ////183 Macedonia
//82 Niger                                     ////184 Malta
//83 Nigeria                                   ////185 Moldova
//84 Rwanda                                    ////186 Montengro
//85 South Africa                              ////187 Northen Ireland
//86 São Tomé and Príncipe                     ////188 Netherlands
//87 Senegal                                   ////189 Norway
//88 Seychelles                                ////190 Poland
//89 Sierra Leone                              ////191 Portugal
//90 Somalia                                   ////192 Ireland
//91 Sudan                                     ////193 Romania
//92 Swaziland                                 ////194 Russia
//93 Tanzania                                  ////195 San Marino
//94 Togo                                      ////196 Scotland
//95 Tunisia                                   ////197 Serbia
//96 Uganda                                    ////198 Slovakia
//97 Zambia                                    ////199 Slovenia
//98 Zimbabwe                                  ////200 Spain
//99 Anguilla                                  ////201 Sweden
//100 Antigua and Barbuda                      ////202 Switzerland
//101 Aruba                                    ////203 Turkey
//102 Bahamas                                  ////204 Ukaraine
                                                ////205 Wales
                                                

    