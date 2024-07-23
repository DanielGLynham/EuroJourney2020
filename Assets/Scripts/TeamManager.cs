using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{

    private List<Team> allTeams = new List<Team>();
    private List<Team> schoolTeams = new List<Team>();
    private List<List<Team>> teamsInCountry = new List<List<Team>>();
    private List<Team> countries = new List<Team>();
    private Team playersTeam;
    private MainPlayer player;
    // Start is called before the first frame update
    public void Initialise()
    {
        player = this.gameObject.GetComponent<MainPlayer>();
        CreateTeams();
        OrganiseTeamsIntoCountries();
        for (int i = 0; i < schoolTeams.Count; i++)
        {
            if (schoolTeams[i].GetTeamName() == player.GetTeamName())
            {
                player.SetTeam(schoolTeams[i]);
                schoolTeams[i].SetPlayersTeam(true);
            }
            else
                schoolTeams[i].SetPlayersTeam(false);
        }
    }
    int count = 0;
    int countTwo = 0;
    int countThree = 0;
    public void OrganiseTeamsIntoCountries()
    {
        for(int x = 0; x < 206; x++) // all countries possible
        {
            List<Team> tempTeam = new List<Team>();

            for(int y = 0; y < allTeams.Count; y++) // cycle through our list of teams - very large list
            {
                if (allTeams[y].GetNationID() == x && allTeams[y].GetTeamName() == player.GetTeamName() && player.GetTeam() == null) 
                {
                    // y is 307
                    count++;
                    tempTeam.Add(allTeams[y]);
                    allTeams[y].SetPlayersTeam(true);
                    if (allTeams[y].GetNation() == allTeams[y].GetTeamName())
                    {
                        countries.Add(allTeams[y]);
                    }
                    player.SetTeam(allTeams[y]);
                }
                else if (allTeams[y].GetNationID() == x && allTeams[y].GetTeamName() != player.GetTeamName())
                {
                    if (allTeams[y].GetNation() == allTeams[y].GetTeamName())
                    {
                        countries.Add(allTeams[y]);
                    }
                    else
                    {
                        count++;
                        tempTeam.Add(allTeams[y]);
                        allTeams[y].SetPlayersTeam(false);
                    }
                }
            }
            if(tempTeam.Count > 1)
            {
                countTwo++;
                teamsInCountry.Add(tempTeam);
            }
        }
    }
    public List<List<Team>> GetAllTeams()
    {
        return teamsInCountry;
    }
    public List<Team> GetAllCountires()
    {
        return countries;
    }
    public List<Team> GetSchoolTeams()
    {
        return schoolTeams;
    }
    // Start is called before the first frame update
    void CreateTeams()
    {
        schoolTeams.Add(new Team(14, 0, "St Laurence", "STL"));         schoolTeams.Add(new Team(16, 10, "Pine Hill", "PINE"));
        schoolTeams.Add(new Team(15, 1, "Willow Creed", "WILL"));       schoolTeams.Add(new Team(16, 11, "Greenfield", "GREE"));
        schoolTeams.Add(new Team(16, 2, "Golden Grammar", "GOLD"));     schoolTeams.Add(new Team(17, 12, "Mountain Oak", "MOUN"));
        schoolTeams.Add(new Team(15, 3, "Hercules School", "HERC"));    schoolTeams.Add(new Team(17, 13, "Grand Ridge", "GRAND"));
        schoolTeams.Add(new Team(16, 4, "Eastwood", "EAST"));           schoolTeams.Add(new Team(17, 14, "West Bridge", "WEST"));
        schoolTeams.Add(new Team(17, 5, "St Adams", "ADAM"));           schoolTeams.Add(new Team(16, 15, "RiverBank", "BANK"));
        schoolTeams.Add(new Team(17, 6, "Long Beach", "LONG"));         schoolTeams.Add(new Team(16, 16, "Timber Creek High", "TIMB"));
        schoolTeams.Add(new Team(17, 7, "St Coners", "CONER"));         schoolTeams.Add(new Team(16, 17, "Sacred Heart", "HEAR"));
        schoolTeams.Add(new Team(15, 8, "Laguna Bay", "LAGU"));         schoolTeams.Add(new Team(15, 18, "Seal Coast", "SEAL"));
        schoolTeams.Add(new Team(16, 9, "BayShore", "SHOR"));           schoolTeams.Add(new Team(16, 19, "Oyster Harbour", "OYST"));




        allTeams.Add(new Team(2, 0, "Wales", "Wales", 205, "WAL"));
        allTeams.Add(new Team(1, 1, "L'pool", "England", 164, "LIV")); allTeams.Add(new Team(1, 2, "Man U", "England", 164, "MAN U")); allTeams.Add(new Team(1, 3, "Arsnl", "England", 164, "ARS"));
        allTeams.Add(new Team(1, 4, "Leic C", "England", 164, "LEC")); allTeams.Add(new Team(1, 5, "Man C", "England", 164, "MAN C")); allTeams.Add(new Team(1, 6, "Chels", "England", 164, "CHE"));
        allTeams.Add(new Team(1, 7, "Spurs", "England", 164, "TOT")); allTeams.Add(new Team(2, 8, "Palace", "England", 164, "CPR")); allTeams.Add(new Team(2, 9, "Sheff U", "England", 164, "SHF U"));
        allTeams.Add(new Team(2, 10, "Wolves", "England", 164, "WOL")); allTeams.Add(new Team(2, 11, "Burnly", "England", 164, "BRN")); allTeams.Add(new Team(2, 12, "Bmouth", "England", 164, "BTH"));
        allTeams.Add(new Team(2, 13, "W Ham", "England", 164, "WHU")); allTeams.Add(new Team(2, 14, "Newcast", "England", 164, "NEW")); allTeams.Add(new Team(2, 15, "A Villa", "England", 164, "AVFC"));
        allTeams.Add(new Team(2, 16, "Brghtn", "England", 164, "BRTN")); allTeams.Add(new Team(3, 17, "Southampton", "England", 164, "SOU")); allTeams.Add(new Team(3, 18, "Everton", "England", 164, "EVE"));
        allTeams.Add(new Team(3, 19, "Norwch", "England", 164, "NWH")); allTeams.Add(new Team(3, 20, "Watfrd", "England", 164, "WAT")); allTeams.Add(new Team(3, 21, "WBA", "England", 164, "WBA"));
        allTeams.Add(new Team(3, 22, "Leeds", "England", 164, "LEE")); allTeams.Add(new Team(3, 23, "Fulham", "England", 164, "FHM")); allTeams.Add(new Team(3, 24, "Forest", "England", 164, "FOR"));
        allTeams.Add(new Team(4, 25, "Bris C", "England", 164, "BRS")); allTeams.Add(new Team(4, 26, "PNE", "England", 164, "PNE")); allTeams.Add(new Team(4, 27, "Brntfd", "England", 164, "BTFD"));
        allTeams.Add(new Team(4, 28, "Swnsea", "England", 164, "SWA")); allTeams.Add(new Team(4, 29, "Sheff W", "England", 164, "SHF W")); allTeams.Add(new Team(4, 30, "CardifF", "England", 164, "CAR"));
        allTeams.Add(new Team(4, 31, "Blackb", "England", 164, "BCKB")); allTeams.Add(new Team(4, 32, "Hull C", "England", 164, "HULL")); allTeams.Add(new Team(4, 33, "M'Wall", "England", 164, "MWAL"));
        allTeams.Add(new Team(4, 34, "Derby", "England", 164, "DER")); allTeams.Add(new Team(4, 35, "Birm", "England", 164, "BRM")); allTeams.Add(new Team(4, 36, "QPR", "England", 164, "QPR"));
        allTeams.Add(new Team(4, 37, "Charlt", "England", 164, "CHTN")); allTeams.Add(new Team(4, 38, "Readng", "England", 164, "RDNG")); allTeams.Add(new Team(5, 39, "Hudsfd", "England", 164, "HUD"));
        allTeams.Add(new Team(5, 40, "Mboro", "England", 164, "MID")); allTeams.Add(new Team(5, 41, "Luton", "England", 164, "LUT")); allTeams.Add(new Team(5, 42, "Wigan", "England", 164, "WIG"));
        allTeams.Add(new Team(5, 43, "Stoke", "England", 164, "STK")); allTeams.Add(new Team(5, 44, "Barns", "England", 164, "BARN")); allTeams.Add(new Team(5, 45, "Wycomb", "England", 164, "WYC"));
        allTeams.Add(new Team(5, 46, "Ipswch", "England", 164, "IPS")); allTeams.Add(new Team(5, 47, "Pboro", "England", 164, "PET")); allTeams.Add(new Team(5, 48, "Rothrham", "England", 164, "ROT"));
        allTeams.Add(new Team(6, 49, "Cvntry", "England", 164, "CVTY")); allTeams.Add(new Team(6, 50, "Oxford", "England", 164, "OXF")); allTeams.Add(new Team(6, 51, "Fltwood", "England", 164, "FLT"));
        allTeams.Add(new Team(6, 52, "Bl'pool", "England", 164, "BPL")); allTeams.Add(new Team(6, 53, "Brstol R", "England", 164, "BRIL")); allTeams.Add(new Team(6, 54, "Pormouth", "England", 164, "PRTS"));
        allTeams.Add(new Team(6, 55, "Sunland", "England", 164, "SUN")); allTeams.Add(new Team(6, 56, "Burton", "England", 164, "BUR")); allTeams.Add(new Team(6, 57, "Shr'bury", "England", 164, "SHRW"));
        allTeams.Add(new Team(6, 58, "Doncster", "England", 164, "DONC")); allTeams.Add(new Team(6, 59, "G'lingham", "England", 164, "GIL")); allTeams.Add(new Team(6, 60, "Rchdale", "England", 164, "ROC"));
        allTeams.Add(new Team(6, 61, "Stnley", "England", 164, "STN")); allTeams.Add(new Team(6, 62, "Lincoln", "England", 164, "LINC")); allTeams.Add(new Team(7, 63, "AFC Wimdon", "England", 164, "AFCW"));
        allTeams.Add(new Team(7, 64, "Trmere", "England", 164, "TRA")); allTeams.Add(new Team(7, 65, "MK D", "England", 164, "MKD")); allTeams.Add(new Team(7, 66, "South U", "England", 164, "STH U"));
        allTeams.Add(new Team(7, 67, "Boltn", "England", 164, "BTN")); allTeams.Add(new Team(7, 68, "Swindn TWN", "England", 164, "SWN")); allTeams.Add(new Team(7, 69, "Forest G", "England", 164, "FOR G"));
        allTeams.Add(new Team(7, 70, "Crewe", "England", 164, "CRW")); allTeams.Add(new Team(7, 71, "Exeter", "England", 164, "EXE")); allTeams.Add(new Team(8, 72, "Cheltenhm", "England", 164, "CHM"));
        allTeams.Add(new Team(8, 73, "Northamptn", "England", 164, "NHAM")); allTeams.Add(new Team(8, 74, "Bradfrd", "England", 164, "BRDF")); allTeams.Add(new Team(8, 75, "Plymouth", "England", 164, "PLY"));
        allTeams.Add(new Team(8, 76, "Port V", "England", 164, "POR V")); allTeams.Add(new Team(8, 77, "Colcstr", "England", 164, "COL")); allTeams.Add(new Team(8, 78, "Newprt", "England", 164, "NEW"));
        allTeams.Add(new Team(8, 79, "Salfrd", "England", 164, "SAL")); allTeams.Add(new Team(8, 80, "Cambrdge", "England", 164, "CAM")); allTeams.Add(new Team(8, 81, "Macclesfield", "England", 164, "MAC"));
        allTeams.Add(new Team(8, 82, "Mansfield", "England", 164, "MANS")); allTeams.Add(new Team(8, 83, "Scunthorpe", "England", 164, "SCU")); allTeams.Add(new Team(8, 84, "Crwley", "England", 164, "CRAW"));
        allTeams.Add(new Team(8, 85, "Grimsby", "England", 164, "GRM")); allTeams.Add(new Team(8, 86, "Leyton O", "England", 164, "LEY")); allTeams.Add(new Team(9, 87, "Oldhm", "England", 164, "OLD"));
        allTeams.Add(new Team(9, 88, "Carlisle", "England", 164, "CAR")); allTeams.Add(new Team(9, 89, "Walsall", "England", 164, "WAL")); allTeams.Add(new Team(9, 90, "Stevenage", "England", 164, "STE"));
        allTeams.Add(new Team(9, 91, "Morecambe", "England", 164, "MOR")); allTeams.Add(new Team(9, 92, "Barrw", "England", 164, "BRW")); allTeams.Add(new Team(9, 93, "Bromly", "England", 164, "BROM"));
        allTeams.Add(new Team(9, 94, "Solihll Mrs", "England", 164, "SOLI")); allTeams.Add(new Team(9, 95, "Yeovl Twn", "England", 164, "YEO")); allTeams.Add(new Team(10, 96, "Wokng", "England", 164, "WOK"));
        allTeams.Add(new Team(10, 97, "Halifax", "England", 164, "HAL")); allTeams.Add(new Team(10, 98, "Harrogte", "England", 164, "HARR")); allTeams.Add(new Team(10, 99, "Stckprt", "England", 164, "STCK"));
        allTeams.Add(new Team(10, 100, "Borehm Wood", "England", 164, "BORE")); allTeams.Add(new Team(10, 101, "Torquay U", "England", 164, "TORQ")); allTeams.Add(new Team(10, 102, "Notts C", "England", 164, "NOTS C"));
        allTeams.Add(new Team(10, 103, "Hartl'pool U", "England", 164, "HART")); allTeams.Add(new Team(10, 104, "Dover", "England", 164, "DOVE")); allTeams.Add(new Team(10, 105, "Eastlgh", "England", 164, "EAST"));
        allTeams.Add(new Team(10, 106, "Barnt", "England", 164, "BRNT")); allTeams.Add(new Team(10, 107, "Dag & Red", "England", 164, "D&R")); allTeams.Add(new Team(10, 108, "Maidnhd U", "England", 164, "MDNH"));
        allTeams.Add(new Team(10, 109, "AFC flyd", "England", 164, "FLY")); allTeams.Add(new Team(10, 110, "Aldrsht", "England", 164, "ALD")); allTeams.Add(new Team(10, 111, "Sutton U", "England", 164, "SUT"));
        allTeams.Add(new Team(11, 112, "Wrxhm", "England", 164, "WRX")); allTeams.Add(new Team(11, 113, "Chestr'field", "England", 164, "CHFD")); allTeams.Add(new Team(11, 114, "Chrley", "England", 164, "CHRL"));
        allTeams.Add(new Team(11, 115, "Ebbsflt U", "England", 164, "EBB")); allTeams.Add(new Team(1, 116, "Barcrlna", "Spain", 200, "BAR")); allTeams.Add(new Team(1, 117, "Real Mdrd", "Spain", 200, "MAD"));
        allTeams.Add(new Team(1, 118, "Sevlla", "Spain", 200, "SVLA")); allTeams.Add(new Team(1, 119, "Atletic Mdrd", "Spain", 200, "ATL")); allTeams.Add(new Team(2, 120, "Ath Blbao", "Spain", 200, "A BIL"));
        allTeams.Add(new Team(2, 121, "Getfe", "Spain", 200, "GET")); allTeams.Add(new Team(2, 122, "Valncia", "Spain", 200, "VAL")); allTeams.Add(new Team(2, 123, "Ossuna", "Spain", 200, "OSS"));
        allTeams.Add(new Team(2, 124, "Granda", "Spain", 200, "GRA")); allTeams.Add(new Team(2, 125, "Levnte", "Spain", 200, "LEV")); allTeams.Add(new Team(2, 126, "Real Bets", "Spain", 200, "BETS"));
        allTeams.Add(new Team(2, 127, "Villral", "Spain", 200, "VIL")); allTeams.Add(new Team(2, 128, "Alavs", "Spain", 200, "ALV")); allTeams.Add(new Team(2, 129, "Valldolid", "Spain", 200, "VALD"));
        allTeams.Add(new Team(3, 130, "Eibr", "Spain", 200, "EBR")); allTeams.Add(new Team(3, 131, "RCD Mallrca", "Spain", 200, "RCDM")); allTeams.Add(new Team(3, 132, "Celta Vgo", "Spain", 200, "CTVG"));
        allTeams.Add(new Team(3, 133, "Espanyol", "Spain", 200, "ESP")); allTeams.Add(new Team(3, 134, "Leganes", "Spain", 200, "LEG")); allTeams.Add(new Team(3, 135, "Cdiz", "Spain", 200, "CDZ"));
        allTeams.Add(new Team(3, 136, "Almria", "Spain", 200, "ALM")); allTeams.Add(new Team(3, 137, "Huesca", "Spain", 200, "HUE")); allTeams.Add(new Team(3, 138, "Fuenbrada", "Spain", 200, "FBDA"));
        allTeams.Add(new Team(4, 139, "Girna", "Spain", 200, "GRNA")); allTeams.Add(new Team(4, 140, "Zargoza", "Spain", 200, "ZAR")); allTeams.Add(new Team(4, 141, "Eche", "Spain", 200, "ECHE"));
        allTeams.Add(new Team(4, 142, "Numncia", "Spain", 200, "NUMC")); allTeams.Add(new Team(4, 143, "Albcete", "Spain", 200, "ALB")); allTeams.Add(new Team(4, 144, "Alcrcon", "Spain", 200, "ALCN"));
        allTeams.Add(new Team(4, 145, "Las Plmas", "Spain", 200, "PALM")); allTeams.Add(new Team(4, 146, "Mirndes", "Spain", 200, "MIRN")); allTeams.Add(new Team(4, 147, "Ponferrdina", "Spain", 200, "PONF"));
        allTeams.Add(new Team(4, 148, "Rayo Vallcano", "Spain", 200, "RVAL")); allTeams.Add(new Team(4, 149, "Lugo", "Spain", 200, "LUGO")); allTeams.Add(new Team(4, 150, "Sporting Gjon", "Spain", 200, "SGJN"));
        allTeams.Add(new Team(4, 151, "Tenerife", "Spain", 200, "TENE")); allTeams.Add(new Team(5, 152, "Ovido", "Spain", 200, "OVDO")); allTeams.Add(new Team(5, 153, "Malga", "Spain", 200, "MALG"));
        allTeams.Add(new Team(5, 154, "Racing", "Spain", 200, "RAC")); allTeams.Add(new Team(5, 155, "Extremdura", "Spain", 200, "EXTR")); allTeams.Add(new Team(5, 156, "Depotivo", "Spain", 200, "DEPO"));
        allTeams.Add(new Team(1, 157, "Inter Mln", "Italy", 176, "INT")); allTeams.Add(new Team(1, 158, "Juvntus", "Italy", 176, "JUV")); allTeams.Add(new Team(1, 159, "Lazo", "Italy", 176, "LAZO"));
        allTeams.Add(new Team(1, 160, "Roma", "Italy", 176, "RMA")); allTeams.Add(new Team(2, 161, "Cagliri", "Italy", 176, "CAGL")); allTeams.Add(new Team(2, 162, "Atlnta", "Italy", 176, "ATLA"));
        allTeams.Add(new Team(2, 163, "Napli", "Italy", 176, "NAPO")); allTeams.Add(new Team(2, 164, "Prma", "Italy", 176, "PRMA")); allTeams.Add(new Team(2, 165, "Verna", "Italy", 176, "VERN"));
        allTeams.Add(new Team(2, 166, "Trino", "Italy", 176, "TRIN")); allTeams.Add(new Team(2, 167, "Mln AC", "Italy", 176, "AC M")); allTeams.Add(new Team(2, 168, "Bolgna", "Italy", 176, "BOLG"));
        allTeams.Add(new Team(2, 169, "Fiorntina", "Italy", 176, "FIOR")); allTeams.Add(new Team(2, 170, "Sassulo", "Italy", 176, "SASS")); allTeams.Add(new Team(2, 171, "Lece", "Italy", 176, "LECE"));
        allTeams.Add(new Team(2, 172, "Udnese", "Italy", 176, "UDN")); allTeams.Add(new Team(3, 173, "Sampdria", "Italy", 176, "SAMP")); allTeams.Add(new Team(3, 174, "Gnoa", "Italy", 176, "GENO"));
        allTeams.Add(new Team(3, 175, "SPAL", "Italy", 176, "SPAL")); allTeams.Add(new Team(3, 176, "Brscia", "Italy", 176, "BRSC")); allTeams.Add(new Team(3, 177, "Benvento", "Italy", 176, "BENV"));
        allTeams.Add(new Team(3, 178, "Cittdella", "Italy", 176, "CITT")); allTeams.Add(new Team(3, 179, "Pordnone", "Italy", 176, "PORD")); allTeams.Add(new Team(3, 180, "Pergia", "Italy", 176, "PERG"));
        allTeams.Add(new Team(4, 181, "Crtone", "Italy", 176, "CRTN")); allTeams.Add(new Team(4, 182, "Chevo", "Italy", 176, "CHVO")); allTeams.Add(new Team(4, 183, "Ascli", "Italy", 176, "ASCL"));
        allTeams.Add(new Team(4, 184, "Pescra", "Italy", 176, "PESC")); allTeams.Add(new Team(4, 185, "Pisa", "Italy", 176, "PISA")); allTeams.Add(new Team(4, 186, "Frosnone", "Italy", 176, "FROS"));
        allTeams.Add(new Team(4, 187, "Salrnitana", "Italy", 176, "SALN")); allTeams.Add(new Team(4, 188, "Virts Entlla", "Italy", 176, "VIRT")); allTeams.Add(new Team(4, 189, "Empli", "Italy", 176, "EMPL"));
        allTeams.Add(new Team(4, 190, "Cremnese", "Italy", 176, "CREM")); allTeams.Add(new Team(4, 191, "Venezia", "Italy", 176, "VENE")); allTeams.Add(new Team(4, 192, "Spzia", "Italy", 176, "SPZ"));
        allTeams.Add(new Team(5, 193, "Juve Stbia", "Italy", 176, "J STB")); allTeams.Add(new Team(5, 194, "Cosnza", "Italy", 176, "COSN")); allTeams.Add(new Team(5, 195, "Trapni", "Italy", 176, "TRAP"));
        allTeams.Add(new Team(5, 196, "Livrno", "Italy", 176, "LIVN")); allTeams.Add(new Team(1, 197, "Bayrn Munch", "Germany", 171, "BAY")); allTeams.Add(new Team(1, 198, "Drtmund", "Germany", 171, "DRT"));
        allTeams.Add(new Team(1, 199, "Monchengladbach", "Germany", 171, "MONC")); allTeams.Add(new Team(1, 200, "RB Lepzig", "Germany", 171, "RB LEP")); allTeams.Add(new Team(1, 201, "Schlke", "Germany", 171, "SCHA"));
        allTeams.Add(new Team(2, 202, "SC Freburg", "Germany", 171, "FRED")); allTeams.Add(new Team(2, 203, "Byer", "Germany", 171, "BYER")); allTeams.Add(new Team(2, 204, "Hoffnheim", "Germany", 171, "HOFF"));
        allTeams.Add(new Team(2, 205, "Wolfsbrg", "Germany", 171, "WOLF")); allTeams.Add(new Team(2, 206, "Eintrct", "Germany", 171, "EINT")); allTeams.Add(new Team(2, 207, "Union Brlin", "Germany", 171, "BERL"));
        allTeams.Add(new Team(2, 208, "Manz", "Germany", 171, "MANZ")); allTeams.Add(new Team(2, 209, "Wrder", "Germany", 171, "WERDR")); allTeams.Add(new Team(2, 210, "Augburg", "Germany", 171, "AUGB"));
        allTeams.Add(new Team(3, 211, "Fortna", "Germany", 171, "FORT")); allTeams.Add(new Team(3, 212, "Hrtha", "Germany", 171, "HRTH")); allTeams.Add(new Team(3, 213, "FC Kln", "Germany", 171, "KOLN"));
        allTeams.Add(new Team(3, 214, "Padrborn", "Germany", 171, "PRDB")); allTeams.Add(new Team(3, 215, "Armnia Bielfeld", "Germany", 171, "ARMA")); allTeams.Add(new Team(3, 216, "Hambrg SV", "Germany", 171, "HAMB"));
        allTeams.Add(new Team(3, 217, "VfB Stutgrt", "Germany", 171, "STUT")); allTeams.Add(new Team(4, 218, "FC Heidnheim", "Germany", 171, "HEID")); allTeams.Add(new Team(4, 219, "FC Erzgbirge", "Germany", 171, "ERZ"));
        allTeams.Add(new Team(4, 220, "Holsten Kel", "Germany", 171, "HOLS")); allTeams.Add(new Team(4, 221, "SV Sandhasen", "Germany", 171, "SAND")); allTeams.Add(new Team(4, 222, "SSV Jahn Regnsburg", "Germany", 171, "REGN"));
        allTeams.Add(new Team(4, 223, "VFL Osnbruck", "Germany", 171, "OSNA")); allTeams.Add(new Team(4, 224, "Karlsrher", "Germany", 171, "KARL")); allTeams.Add(new Team(4, 225, "SpVgg Grether Frth", "Germany", 171, "FURTH"));
        allTeams.Add(new Team(4, 226, "SV Darmstdt", "Germany", 171, "DARM")); allTeams.Add(new Team(4, 227, "VFL Bochm", "Germany", 171, "BOCH")); allTeams.Add(new Team(4, 228, "Hannver", "Germany", 171, "HNVR"));
        allTeams.Add(new Team(5, 229, "St Pali", "Germany", 171, "PALI")); allTeams.Add(new Team(5, 230, "Nurnbrg", "Germany", 171, "NURN")); allTeams.Add(new Team(5, 231, "SV Wehn Wiesbden", "Germany", 171, "WIES"));
        allTeams.Add(new Team(5, 232, "Dynmo Dresdn", "Germany", 171, "DRES")); allTeams.Add(new Team(1, 233, "Paris SG", "France", 168, "PSG")); allTeams.Add(new Team(1, 234, "Marselle", "France", 168, "MARS"));
        allTeams.Add(new Team(1, 235, "Lile", "France", 168, "LILE")); allTeams.Add(new Team(2, 236, "Bordaux", "France", 168, "BORD")); allTeams.Add(new Team(2, 237, "St Etenne", "France", 168, "ST ET"));
        allTeams.Add(new Team(2, 238, "Montpllier", "France", 168, "MONT")); allTeams.Add(new Team(2, 239, "Renes", "France", 168, "RENE")); allTeams.Add(new Team(2, 240, "Angrs", "France", 168, "ANG"));
        allTeams.Add(new Team(2, 241, "Nants", "France", 168, "NANT")); allTeams.Add(new Team(2, 242, "Lyon", "France", 168, "LYON")); allTeams.Add(new Team(2, 243, "Stade Rems", "France", 168, "ST RE"));
        allTeams.Add(new Team(2, 244, "Brst", "France", 168, "BRST")); allTeams.Add(new Team(2, 245, "Monco", "France", 168, "MON")); allTeams.Add(new Team(2, 246, "Nice", "France", 168, "NICE"));
        allTeams.Add(new Team(2, 247, "Strsbourg", "France", 168, "STRS")); allTeams.Add(new Team(2, 248, "Djon", "France", 168, "DJON")); allTeams.Add(new Team(3, 249, "Amins", "France", 168, "AMIN"));
        allTeams.Add(new Team(3, 250, "Mets", "France", 168, "METS")); allTeams.Add(new Team(3, 251, "Nimes", "France", 168, "NIME")); allTeams.Add(new Team(3, 252, "Touluse", "France", 168, "TOUL"));
        allTeams.Add(new Team(3, 253, "Lorent", "France", 168, "LORE")); allTeams.Add(new Team(3, 254, "Lens", "France", 168, "LENS")); allTeams.Add(new Team(4, 255, "Ajccio", "France", 168, "AJC"));
        allTeams.Add(new Team(4, 256, "Tryes", "France", 168, "TRYE")); allTeams.Add(new Team(4, 257, "Le Hvre", "France", 168, "HVRE")); allTeams.Add(new Team(4, 258, "Sochux", "France", 168, "SOCH"));
        allTeams.Add(new Team(4, 259, "Clermont Ft", "France", 168, "CLMT")); allTeams.Add(new Team(4, 260, "Gungamp", "France", 168, "GUNG")); allTeams.Add(new Team(4, 261, "Valencennes", "France", 168, "VALE"));
        allTeams.Add(new Team(4, 262, "AS Nancy Lorrne", "France", 168, "NY LRN")); allTeams.Add(new Team(4, 263, "Grenoble Ft", "France", 168, "GREN")); allTeams.Add(new Team(4, 264, "Can", "France", 168, "CAN"));
        allTeams.Add(new Team(4, 265, "Auxrre", "France", 168, "AUXE")); allTeams.Add(new Team(4, 266, "Rdez", "France", 168, "RDEZ")); allTeams.Add(new Team(4, 267, "Chatroux", "France", 168, "CHAT"));
        allTeams.Add(new Team(4, 268, "Nort", "France", 168, "NORT")); allTeams.Add(new Team(5, 269, "Chmbly", "France", 168, "CHMB")); allTeams.Add(new Team(5, 270, "Paris FC", "France", 168, "PARS"));
        allTeams.Add(new Team(5, 271, "Le Mns", "France", 168, "LE MANS")); allTeams.Add(new Team(5, 272, "US Orlans", "France", 168, "ORLNS")); allTeams.Add(new Team(2, 273, "Zent", "Russia", 194, "ZENT"));
        allTeams.Add(new Team(2, 274, "Lokomotiv", "Russia", 194, "LOKO")); allTeams.Add(new Team(3, 275, "Krasndar", "Russia", 194, "KRAS")); allTeams.Add(new Team(3, 276, "CSKA Mscw", "Russia", 194, "CSKA"));
        allTeams.Add(new Team(4, 277, "Rostv", "Russia", 194, "ROST")); allTeams.Add(new Team(4, 278, "Dynmo Mscw", "Russia", 194, "DYN MCW")); allTeams.Add(new Team(4, 279, "Arsnl Tula", "Russia", 194, "AR TUL"));
        allTeams.Add(new Team(4, 280, "FC Ufa", "Russia", 194, "UFA")); allTeams.Add(new Team(4, 281, "Sprtk Mscw", "Russia", 194, "SPR MCW")); allTeams.Add(new Team(4, 282, "Url", "Russia", 194, "URL"));
        allTeams.Add(new Team(4, 283, "Akhmt Grzny", "Russia", 194, "GRZN")); allTeams.Add(new Team(4, 284, "Ornburg", "Russia", 194, "ORNB")); allTeams.Add(new Team(4, 245, "Kryya Sovtov", "Russia", 194, "SVTV"));
        allTeams.Add(new Team(5, 286, "Rubin Kzan", "Russia", 194, "RUB K")); allTeams.Add(new Team(5, 287, "Tambv", "Russia", 194, "TAMB")); allTeams.Add(new Team(5, 288, "PFC Schi", "Russia", 194, "SCHI"));
        allTeams.Add(new Team(2, 289, "Benfca", "Portugal", 191, "BENF")); allTeams.Add(new Team(2, 290, "Prto", "Portugal", 191, "PRTO")); allTeams.Add(new Team(2, 291, "Famlicao", "Portugal", 191, "FAML"));
        allTeams.Add(new Team(2, 292, "Sprting", "Portugal", 191, "SPRT")); allTeams.Add(new Team(2, 293, "Bovista", "Portugal", 191, "BOVI")); allTeams.Add(new Team(2, 294, "Brga", "Portugal", 191, "BRGA"));
        allTeams.Add(new Team(2, 295, "Vitria", "Portugal", 191, "VITR")); allTeams.Add(new Team(2, 296, "Gil Vcente", "Portugal", 191, "GIL V")); allTeams.Add(new Team(3, 297, "Rio Ave", "Portugal", 191, "RIO A"));
        allTeams.Add(new Team(3, 298, "Tondla", "Portugal", 191, "TOND")); allTeams.Add(new Team(3, 299, "Morerense", "Portugal", 191, "MORE")); allTeams.Add(new Team(3, 300, "Belnenses", "Portugal", 191, "BELN"));
        allTeams.Add(new Team(3, 301, "Santa Clara", "Portugal", 191, "SNT C")); allTeams.Add(new Team(3, 302, "Setbal", "Portugal", 191, "STBL")); allTeams.Add(new Team(3, 303, "Portmonense", "Portugal", 191, "PRTMO"));
        allTeams.Add(new Team(4, 304, "Martimo", "Portugal", 191, "MART")); allTeams.Add(new Team(4, 305, "Pacos Ferreira", "Portugal", 191, "FERR")); allTeams.Add(new Team(4, 306, "Aves", "Portugal", 191, "AVES"));
        allTeams.Add(new Team(2, 307, "Shakhtr Dontsk", "Ukraine", 204, "SHK DON")); allTeams.Add(new Team(3, 308, "Dynmo Kyiv", "Ukraine", 204, "DYN KY")); allTeams.Add(new Team(3, 309, "Zora", "Ukraine", 204, "ZORA"));
        allTeams.Add(new Team(3, 310, "Desna", "Ukraine", 204, "DESN")); allTeams.Add(new Team(4, 311, "Oleksandriya", "Ukraine", 204, "OLEK")); allTeams.Add(new Team(4, 312, "Maripol", "Ukraine", 204, "MARI"));
        allTeams.Add(new Team(4, 313, "Olimpk Dontsk ", "Ukraine", 204, "OL DSK")); allTeams.Add(new Team(4, 314, "Dnpro", "Ukraine", 204, "DPRO")); allTeams.Add(new Team(4, 315, "Kolos", "Ukraine", 204, "KOLS"));
        allTeams.Add(new Team(5, 316, "L'viv", "Ukraine", 204, "LVIV")); allTeams.Add(new Team(5, 317, "Karpty", "Ukraine", 204, "KARP")); allTeams.Add(new Team(5, 318, "Vrskla", "Ukraine", 204, "VRSK"));
        allTeams.Add(new Team(3, 319, "Club Brgge", "Belgium", 157, "BRUGG")); allTeams.Add(new Team(3, 320, "Standrd Lige", "Belgium", 157, "LIEG")); allTeams.Add(new Team(3, 321, "Gnt", "Belgium", 157, "GENT"));
        allTeams.Add(new Team(3, 322, "Chrleroi", "Belgium", 157, "CHRL")); allTeams.Add(new Team(3, 323, "Antwrp", "Belgium", 157, "ANTW")); allTeams.Add(new Team(3, 324, "Zlte Wargem", "Belgium", 157, "WARG"));
        allTeams.Add(new Team(4, 325, "Mechlen", "Belgium", 157, "MECH")); allTeams.Add(new Team(4, 326, "Genk", "Belgium", 157, "GENK")); allTeams.Add(new Team(4, 327, "Snt-Truden", "Belgium", 157, "ST TRU"));
        allTeams.Add(new Team(5, 328, "R. Exel Moscron", "Belgium", 157, "EXMO")); allTeams.Add(new Team(5, 329, "Andrlecht", "Belgium", 157, "LECT")); allTeams.Add(new Team(5, 330, "Epen", "Belgium", 157, "EPEN"));
        allTeams.Add(new Team(5, 331, "Krtrijk", "Belgium", 157, "KRTK")); allTeams.Add(new Team(5, 332, "Oostnde", "Belgium", 157, "ONDE")); allTeams.Add(new Team(5, 333, "Wasland-Bveren", "Belgium", 157, "BVER"));
        allTeams.Add(new Team(6, 334, "Crcle Brugge", "Belgium", 157, "C BRUG")); allTeams.Add(new Team(2, 335, "Besktas", "Turkey", 203, "BES")); allTeams.Add(new Team(2, 336, "Fenrbache", "Turkey", 203, "FEN"));
        allTeams.Add(new Team(3, 337, "Sivsspor", "Turkey", 203, "SIVS")); allTeams.Add(new Team(3, 338, "Istanbul Basksehir", "Turkey", 203, "I BASK")); allTeams.Add(new Team(3, 339, "Trabznspor", "Turkey", 203, "TRAB"));
        allTeams.Add(new Team(3, 340, "Alanyspor", "Turkey", 203, "ALPR")); allTeams.Add(new Team(3, 341, "Yeni Maltyspor", "Turkey", 203, "Y MALT")); allTeams.Add(new Team(3, 342, "Galatasary", "Turkey", 203, "GAL"));
        allTeams.Add(new Team(4, 343, "Denzlispor", "Turkey", 203, "DENZ")); allTeams.Add(new Team(4, 344, "Goztpe", "Turkey", 203, "GOZT")); allTeams.Add(new Team(4, 345, "Gazantep", "Turkey", 203, "GAZA"));
        allTeams.Add(new Team(4, 346, "Genclrbirligi", "Turkey", 203, "GENC")); allTeams.Add(new Team(4, 347, "Konyspor", "Turkey", 203, "KONY")); allTeams.Add(new Team(5, 348, "Kasmpasa", "Turkey", 203, "KASM"));
        allTeams.Add(new Team(5, 349, "Antlyaspor", "Turkey", 203, "ANTL")); allTeams.Add(new Team(5, 350, "Ankargucu", "Turkey", 203, "ANKA")); allTeams.Add(new Team(5, 351, "Kayserspor", "Turkey", 203, "KAYE"));
        allTeams.Add(new Team(3, 352, "Red Bull", "Austria", 154, "RB")); allTeams.Add(new Team(3, 353, "LSK", "Austria", 154, "LSK")); allTeams.Add(new Team(4, 354, "Wolfsberg", "Austria", 154, "WFBG"));
        allTeams.Add(new Team(4, 355, "Rapid Win", "Austria", 154, "RDWN")); allTeams.Add(new Team(4, 356, "SK Strm grz", "Austria", 154, "STRM")); allTeams.Add(new Team(4, 357, "Hrtberg", "Austria", 154, "HRTB"));
        allTeams.Add(new Team(5, 358, "Austria Win", "Austria", 154, "WIN")); allTeams.Add(new Team(5, 359, "St Plten", "Austria", 154, "PLTN")); allTeams.Add(new Team(5, 360, "Altch", "Austria", 154, "ATLC"));
        allTeams.Add(new Team(6, 361, "WSG Wttens", "Austria", 154, "WSG")); allTeams.Add(new Team(6, 362, "Flyerlarm Admira", "Austria", 154, "FLAD")); allTeams.Add(new Team(6, 363, "Mattrsburg", "Austria", 154, "MATT"));
        allTeams.Add(new Team(3, 364, "Young Boys", "Switzerland", 202, "YGBYS")); allTeams.Add(new Team(3, 365, "Basel", "Switzerland", 202, "BAS")); allTeams.Add(new Team(3, 366, "St Gllen", "Switzerland", 202, "GLLN"));
        allTeams.Add(new Team(4, 367, "Zurich", "Switzerland", 202, "ZUR")); allTeams.Add(new Team(4, 368, "Servtte", "Switzerland", 202, "SERV")); allTeams.Add(new Team(4, 369, "Sion", "Switzerland", 202, "SION"));
        allTeams.Add(new Team(5, 370, "Lugano", "Switzerland", 202, "LUGA")); allTeams.Add(new Team(5, 371, "Luzrn", "Switzerland", 202, "LUZN")); allTeams.Add(new Team(5, 372, "Nechatel Xamx", "Switzerland", 202, "XAMX"));
        allTeams.Add(new Team(5, 373, "Thun", "Switzerland", 202, "THUN")); allTeams.Add(new Team(3, 374, "Slavi Prah", "Czech Republic", 162, "PRAH")); allTeams.Add(new Team(3, 375, "Plzen", "Czech Republic", 162, "PLZ"));
        allTeams.Add(new Team(3, 376, "Mlada Bolslav", "Czech Republic", 162, "BSLV")); allTeams.Add(new Team(3, 377, "Sprta Prague", "Czech Republic", 162, "SPRT PR")); allTeams.Add(new Team(3, 378, "Jablnec", "Czech Republic", 162, "JBLC"));
        allTeams.Add(new Team(3, 379, "Bank", "Czech Republic", 162, "BANK")); allTeams.Add(new Team(4, 380, "SK Dynmo", "Czech Republic", 162, "SK DY")); allTeams.Add(new Team(4, 381, "Slovack", "Czech Republic", 162, "SVCK"));
        allTeams.Add(new Team(4, 382, "Liberec", "Czech Republic", 162, "LIBC")); allTeams.Add(new Team(4, 383, "Sigma", "Czech Republic", 162, "SGMA")); allTeams.Add(new Team(5, 384, "Bohemians", "Czech Republic", 162, "BOHE"));
        allTeams.Add(new Team(5, 385, "Teplice", "Czech Republic", 162, "TPLC")); allTeams.Add(new Team(5, 386, "Zlin", "Czech Republic", 162, "ZLIN")); allTeams.Add(new Team(5, 387, "Opava", "Czech Republic", 162, "OPVA"));
        allTeams.Add(new Team(5, 388, "Pribam", "Czech Republic", 162, "PRBM")); allTeams.Add(new Team(5, 389, "Karvna", "Czech Republic", 162, "KVNA")); allTeams.Add(new Team(2, 390, "Ajax", "Netherlands", 188, "AJAX"));
        allTeams.Add(new Team(3, 391, "Eindhoven", "Netherlands", 188, "EIND")); allTeams.Add(new Team(3, 392, "Willem", "Netherlands", 188, "WILL")); allTeams.Add(new Team(3, 392, "Heracles", "Netherlands", 188, "HEFC"));
        allTeams.Add(new Team(3, 394, "Heernveen", "Netherlands", 188, "HEEN")); allTeams.Add(new Team(3, 395, "Feynoord", "Netherlands", 188, "FEYEN")); allTeams.Add(new Team(3, 396, "Urcht", "Netherlands", 188, "UCHT"));
        allTeams.Add(new Team(4, 397, "Vitesse", "Netherlands", 188, "VITE")); allTeams.Add(new Team(4, 398, "Gronngen", "Netherlands", 188, "GRON")); allTeams.Add(new Team(4, 399, "Sparta", "Netherlands", 188, "SPRT"));
        allTeams.Add(new Team(4, 400, "Twente", "Netherlands", 188, "TWE")); allTeams.Add(new Team(4, 401, "Emmen", "Netherlands", 188, "EMM")); allTeams.Add(new Team(5, 402, "Fortna Sittrd", "Netherlands", 188, "SITT"));
        allTeams.Add(new Team(5, 403, "Zwolle", "Netherlands", 188, "ZWO")); allTeams.Add(new Team(5, 404, "VVV", "Netherlands", 188, "VVV")); allTeams.Add(new Team(5, 405, "Den Hag", "Netherlands", 188, "HAG"));
        allTeams.Add(new Team(5, 406, "Waalwijk", "Netherlands", 188, "WAAL")); allTeams.Add(new Team(3, 407, "Olympiacos", "Greece", 172, "OLYM")); allTeams.Add(new Team(3, 408, "PAOK", "Greece", 172, "PAOK"));
        allTeams.Add(new Team(4, 409, "OFI", "Greece", 172, "OFI")); allTeams.Add(new Team(4, 410, "Xanthi", "Greece", 172, "XANT")); allTeams.Add(new Team(4, 411, "AEK", "Greece", 172, "AEK"));
        allTeams.Add(new Team(4, 412, "Larissa", "Greece", 172, "LAR")); allTeams.Add(new Team(4, 413, "Aris", "Greece", 172, "ARIS")); allTeams.Add(new Team(4, 414, "Panthinakos", "Greece", 172, "PANK"));
        allTeams.Add(new Team(4, 415, "Atromtos", "Greece", 172, "ATOS")); allTeams.Add(new Team(4, 416, "Lama", "Greece", 172, "LAMA")); allTeams.Add(new Team(4, 417, "Volos", "Greece", 172, "VOLS"));
        allTeams.Add(new Team(5, 418, "Asteras Triplis", "Greece", 172, "TRPS")); allTeams.Add(new Team(5, 419, "Panonios", "Greece", 172, "PANS")); allTeams.Add(new Team(5, 420, "Pantolikos", "Greece", 172, "PNKS"));
        allTeams.Add(new Team(2, 421, "Dinmo Zagrb", "Croatia", 160, "DI ZA")); allTeams.Add(new Team(3, 422, "Hajduk Spit", "Croatia", 160, "HAJK")); allTeams.Add(new Team(4, 423, "Rijeka", "Croatia", 160, "RIJK"));
        allTeams.Add(new Team(4, 424, "Lokomtiva", "Croatia", 160, "LOKO")); allTeams.Add(new Team(4, 425, "Osjek", "Croatia", 160, "OJK")); allTeams.Add(new Team(4, 426, "Gorca", "Croatia", 160, "GRCA"));
        allTeams.Add(new Team(4, 427, "Slaven Belpo", "Croatia", 160, "BELP")); allTeams.Add(new Team(5, 428, "Istra", "Croatia", 160, "ISTR")); allTeams.Add(new Team(5, 429, "Varazdin", "Croatia", 160, "VARA"));
        allTeams.Add(new Team(5, 430, "Inter Zaprsic", "Croatia", 160, "I ZAP")); allTeams.Add(new Team(3, 431, "Midtjylland", "Denmark", 163, "MIDT")); allTeams.Add(new Team(3, 432, "Kobenhavn", "Denmark", 163, "KBNH"));
        allTeams.Add(new Team(4, 433, "AGF", "Denmark", 163, "AGF")); allTeams.Add(new Team(4, 434, "Brondby", "Denmark", 163, "BRND")); allTeams.Add(new Team(4, 435, "Aalborg", "Denmark", 163, "ALBG"));
        allTeams.Add(new Team(4, 436, "Randers", "Denmark", 163, "RAND")); allTeams.Add(new Team(4, 437, "OB", "Denmark", 163, "OB")); allTeams.Add(new Team(4, 438, "Nordsjaelland", "Denmark", 163, "NORD"));
        allTeams.Add(new Team(5, 439, "Lynby", "Denmark", 163, "LYNB")); allTeams.Add(new Team(5, 440, "Horsens", "Denmark", 163, "HORS")); allTeams.Add(new Team(5, 441, "Sonderjysk", "Denmark", 163, "SOND"));
        allTeams.Add(new Team(5, 442, "Hobru", "Denmark", 163, "HOBU")); allTeams.Add(new Team(5, 442, "Esnjrg", "Denmark", 163, "ENJG")); allTeams.Add(new Team(5, 444, "Silkborg", "Denmark", 163, "SILK"));
        allTeams.Add(new Team(3, 445, "Tel-Aviv", "Israel", 175, "TAVV")); allTeams.Add(new Team(3, 446, "Haifa", "Israel", 175, "HAFA")); allTeams.Add(new Team(4, 447, "Beer-Sheva", "Israel", 175, "BRSV"));
        allTeams.Add(new Team(4, 448, "Beit Jerusalem", "Israel", 175, "B JER")); allTeams.Add(new Team(4, 449, "Bne Yehuda", "Israel", 175, "YEHU")); allTeams.Add(new Team(4, 450, "H Haifa", "Israel", 175, "H HAF"));
        allTeams.Add(new Team(4, 451, "Hap Hadera", "Israel", 175, "HP HDA")); allTeams.Add(new Team(5, 452, "Netanya", "Israel", 175, "NTYA")); allTeams.Add(new Team(5, 453, "Ashdd", "Israel", 175, "ASDD"));
        allTeams.Add(new Team(5, 454, "Kfar-Sba", "Israel", 175, "KRSB")); allTeams.Add(new Team(5, 455, "Hap Tel-Aviv", "Israel", 175, "H TAVV")); allTeams.Add(new Team(5, 456, "Ra'anan", "Israel", 175, "RAAN"));
        allTeams.Add(new Team(6, 457, "Sektzia Ns Tzona", "Israel", 175, "SKTZ")); allTeams.Add(new Team(6, 458, "Kiryt Shmna", "Israel", 175, "KT SM")); allTeams.Add(new Team(4, 459, "Anorthsis", "Cyprus", 161, "ANTH"));
        allTeams.Add(new Team(4, 460, "Omnia", "Cyprus", 161, "OMNA")); allTeams.Add(new Team(4, 461, "Apoel Nicsia", "Cyprus", 161, "NCSA")); allTeams.Add(new Team(4, 462, "AEL", "Cyprus", 161, "AEL"));
        allTeams.Add(new Team(5, 463, "Apolln Limssol", "Cyprus", 161, "LIMSS")); allTeams.Add(new Team(5, 464, "AEK Larnca", "Cyprus", 161, "LARN")); allTeams.Add(new Team(5, 465, "Nea Salmis", "Cyprus", 161, "SALM"));
        allTeams.Add(new Team(5, 466, "Ethnks Achna", "Cyprus", 161, "ACHN")); allTeams.Add(new Team(6, 467, "Olympiaks", "Cyprus", 161, "OLMK")); allTeams.Add(new Team(6, 468, "Pafs", "Cyprus", 161, "PAFS"));
        allTeams.Add(new Team(6, 469, "Paralmni", "Cyprus", 161, "PALN")); allTeams.Add(new Team(6, 470, "Dxa", "Cyprus", 161, "DXA")); allTeams.Add(new Team(4, 471, "Cluj", "Romania", 193, "CLU"));
        allTeams.Add(new Team(4, 472, "Astra Girgiu", "Romania", 193, "A GIRG")); allTeams.Add(new Team(4, 473, "U Crova", "Romania", 193, "U CRV")); allTeams.Add(new Team(4, 474, "Viitrul", "Romania", 193, "VITL"));
        allTeams.Add(new Team(5, 475, "Gaz Mtan", "Romania", 193, "MTAN")); allTeams.Add(new Team(5, 476, "FCSB", "Romania", 193, "FCSB")); allTeams.Add(new Team(5, 477, "Dinmo Bucresti", "Romania", 193, "DI BUC"));
        allTeams.Add(new Team(5, 478, "Botsani", "Romania", 193, "BOTS")); allTeams.Add(new Team(5, 479, "Lasi", "Romania", 193, "LASI")); allTeams.Add(new Team(6, 480, "Sepsi", "Romania", 193, "SEPS"));
        allTeams.Add(new Team(6, 481, "A Clincni", "Romania", 193, "CLIN")); allTeams.Add(new Team(6, 482, "C Targviste", "Romania", 193, "TRGV")); allTeams.Add(new Team(6, 483, "Hermannstdt", "Romania", 193, "HMST"));
        allTeams.Add(new Team(6, 484, "Volntari", "Romania", 193, "VOL")); allTeams.Add(new Team(4, 485, "Slsk", "Poland", 190, "SLI")); allTeams.Add(new Team(4, 486, "P Szczin", "Poland", 190, "SZCZ"));
        allTeams.Add(new Team(4, 487, "L Warsaw", "Poland", 190, "WRSW")); allTeams.Add(new Team(4, 488, "Cracvia", "Poland", 190, "CRCV")); allTeams.Add(new Team(5, 489, "Piast Glice", "Poland", 190, "GLCE"));
        allTeams.Add(new Team(5, 490, "L Gdansk", "Poland", 190, "GDSK")); allTeams.Add(new Team(5, 491, "W Plck", "Poland", 190, "PLCK")); allTeams.Add(new Team(5, 492, "Lch Poznn", "Poland", 190, "POZN"));
        allTeams.Add(new Team(5, 493, "Jagllonia", "Poland", 190, "JGLA")); allTeams.Add(new Team(5, 494, "Zaglbie", "Poland", 190, "ZAGB")); allTeams.Add(new Team(5, 495, "Rakw", "Poland", 190, "RAKW"));
        allTeams.Add(new Team(5, 496, "Gornk Zabrz", "Poland", 190, "GK ZZ")); allTeams.Add(new Team(6, 497, "Korona", "Poland", 190, "KORO")); allTeams.Add(new Team(6, 498, "LKS Ldz", "Poland", 190, "LDZ"));
        allTeams.Add(new Team(6, 499, "A Gdynia", "Poland", 190, "GDYN")); allTeams.Add(new Team(6, 500, "W Krakow", "Poland", 190, "KRAK")); allTeams.Add(new Team(4, 501, "Djrgardens", "Sweden", 201, "DJRG"));
        allTeams.Add(new Team(4, 502, "Malmo", "Sweden", 201, "MALM")); allTeams.Add(new Team(4, 503, "Hammrby", "Sweden", 201, "HAMM")); allTeams.Add(new Team(4, 504, "AIK", "Sweden", 201, "AIK"));
        allTeams.Add(new Team(5, 505, "Norrkping", "Sweden", 201, "NORR")); allTeams.Add(new Team(5, 506, "Hcken", "Sweden", 201, "HKCN")); allTeams.Add(new Team(5, 507, "Gteborg", "Sweden", 201, "GTEB"));
        allTeams.Add(new Team(5, 508, "Elfsborg", "Sweden", 201, "ELFS")); allTeams.Add(new Team(5, 509, "Orbro", "Sweden", 201, "ORBO")); allTeams.Add(new Team(5, 510, "Helsngborgs", "Sweden", 201, "HELSN"));
        allTeams.Add(new Team(5, 511, "Sirius", "Sweden", 201, "SIRI")); allTeams.Add(new Team(5, 512, "Ostrsunds", "Sweden", 201, "OSTR")); allTeams.Add(new Team(6, 513, "Falknbergs", "Sweden", 201, "FALK"));
        allTeams.Add(new Team(6, 514, "Klmar", "Sweden", 201, "KLMR")); allTeams.Add(new Team(6, 515, "Sundsvll", "Sweden", 201, "SNDV")); allTeams.Add(new Team(6, 516, "Esklstuna", "Sweden", 201, "ESKL"));
        allTeams.Add(new Team(2, 517, "Coltic", "Scotland", 196, "CEL")); allTeams.Add(new Team(2, 518, "Rngers", "Scotland", 196, "RAN")); allTeams.Add(new Team(3, 519, "Abrdeen", "Scotland", 196, "ABER"));
        allTeams.Add(new Team(3, 520, "Mothrwell", "Scotland", 196, "MTH")); allTeams.Add(new Team(3, 521, "Kilmrnock", "Scotland", 196, "KILM")); allTeams.Add(new Team(3, 522, "Hibernan", "Scotland", 196, "HIBE"));
        allTeams.Add(new Team(3, 523, "Rs County", "Scotland", 196, "ROSS")); allTeams.Add(new Team(3, 524, "Livngston", "Scotland", 196, "LVNG")); allTeams.Add(new Team(4, 525, "Hearts", "Scotland", 196, "HRTS"));
        allTeams.Add(new Team(4, 526, "Hamilton", "Scotland", 196, "HMLTN")); allTeams.Add(new Team(4, 527, "St Jonston", "Scotland", 196, "ST JON")); allTeams.Add(new Team(4, 528, "St Mirren", "Scotland", 196, "ST MIRR"));
        allTeams.Add(new Team(2, 529, "Crvna Zvzda", "Serbia", 197, "CRV ZV")); allTeams.Add(new Team(3, 530, "Vjvodina", "Serbia", 197, "VJV")); allTeams.Add(new Team(3, 531, "Cukricki", "Serbia", 197, "CUKR"));
        allTeams.Add(new Team(3, 532, "Partzan", "Serbia", 197, "PRTZ")); allTeams.Add(new Team(3, 533, "Bcka Topola", "Serbia", 197, "BCK TP")); allTeams.Add(new Team(3, 534, "Vozd'vac", "Serbia", 197, "VZVC"));
        allTeams.Add(new Team(3, 535, "Radnicki N", "Serbia", 197, "RDNK")); allTeams.Add(new Team(3, 536, "Spartk Subtica", "Serbia", 197, "SPTK SUB")); allTeams.Add(new Team(3, 537, "Mladst Lucni", "Serbia", 197, "MLAD"));
        allTeams.Add(new Team(3, 538, "Naprdak", "Serbia", 197, "NAPR")); allTeams.Add(new Team(3, 539, "Javr", "Serbia", 197, "JAVR")); allTeams.Add(new Team(3, 540, "Radnik Surdlica", "Serbia", 197, "RDK SURD"));
        allTeams.Add(new Team(3, 541, "Proltr Novi", "Serbia", 197, "PTR NVI")); allTeams.Add(new Team(4, 529, "Indija", "Serbia", 197, "INDJA")); allTeams.Add(new Team(4, 529, "Rad", "Serbia", 197, "RAD"));
        allTeams.Add(new Team(4, 544, "Macva S'bac", "Serbia", 197, "MCVA BAC")); allTeams.Add(new Team(3, 545, "Molde", "Norway", 189, "MOLD")); allTeams.Add(new Team(3, 546, "Glmt", "Norway", 189, "GLMT"));
        allTeams.Add(new Team(3, 547, "Roseborg", "Norway", 189, "ROSE")); allTeams.Add(new Team(3, 548, "Odd", "Norway", 189, "ODD")); allTeams.Add(new Team(3, 549, "Viking", "Norway", 189, "VIK"));
        allTeams.Add(new Team(3, 550, "Krstiansnd", "Norway", 189, "KRSND")); allTeams.Add(new Team(3, 551, "Haugesnd", "Norway", 189, "HAUG")); allTeams.Add(new Team(3, 552, "Stabek", "Norway", 189, "STBK"));
        allTeams.Add(new Team(3, 553, "Brann", "Norway", 189, "BRANN")); allTeams.Add(new Team(3, 554, "Valernga", "Norway", 189, "VLRGA")); allTeams.Add(new Team(3, 555, "Stromsgdset", "Norway", 189, "STRMS"));
        allTeams.Add(new Team(3, 556, "Srpsborg", "Norway", 189, "SRPS")); allTeams.Add(new Team(4, 557, "Mjndalen", "Norway", 189, "MJND")); allTeams.Add(new Team(4, 558, "Lillstrom", "Norway", 189, "LILL"));
        allTeams.Add(new Team(4, 559, "Tromzo", "Norway", 189, "TROM")); allTeams.Add(new Team(4, 560, "Ranhim", "Norway", 189, "RANH")); allTeams.Add(new Team(3, 561, "Astana", "Kazakhstan", 177, "ASTA"));
        allTeams.Add(new Team(3, 561, "Karat", "Kazakhstan", 177, "KART")); allTeams.Add(new Team(3, 562, "Ordbasy", "Kazakhstan", 177, "ORDBSY")); allTeams.Add(new Team(4, 563, "Tobl", "Kazakhstan", 177, "TOBL"));
        allTeams.Add(new Team(4, 564, "Zhtysu", "Kazakhstan", 177, "ZHTY")); allTeams.Add(new Team(4, 565, "Kaisr", "Kazakhstan", 177, "KAIS")); allTeams.Add(new Team(4, 566, "Okzhtpes", "Kazakhstan", 177, "OKZPS"));
        allTeams.Add(new Team(4, 567, "Irtysh", "Kazakhstan", 177, "IRTY")); allTeams.Add(new Team(4, 568, "Shak Kargandy", "Kazakhstan", 177, "KARGY")); allTeams.Add(new Team(4, 569, "Tarz", "Kazakhstan", 177, "TARZ"));
        allTeams.Add(new Team(5, 570, "Atyau", "Kazakhstan", 177, "ATYU")); allTeams.Add(new Team(5, 571, "Aktbe", "Kazakhstan", 177, "AKBE")); allTeams.Add(new Team(3, 572, "Dinmo Brest", "Belarus", 156, "DI BRST"));
        allTeams.Add(new Team(4, 573, "BATE", "Belarus", 156, "BATE")); allTeams.Add(new Team(4, 574, "Shakhtyr", "Belarus", 156, "SHKTR")); allTeams.Add(new Team(4, 575, "Dinmmo Minsk", "Belarus", 156, "DI MISK"));
        allTeams.Add(new Team(4, 574, "Islch", "Belarus", 156, "ISCH")); allTeams.Add(new Team(4, 575, "Torpedo-Belz Zhodno", "Belarus", 156, "ZHOD")); allTeams.Add(new Team(4, 576, "Gorodya", "Belarus", 156, "GRDYA"));
        allTeams.Add(new Team(4, 577, "Slavia-Mzyr", "Belarus", 156, "SLVM")); allTeams.Add(new Team(4, 578, "Minsk", "Belarus", 156, "MINSK")); allTeams.Add(new Team(4, 579, "Neman", "Belarus", 156, "NEMN"));
        allTeams.Add(new Team(4, 580, "Slutsk", "Belarus", 156, "SLUT")); allTeams.Add(new Team(4, 581, "Energtik", "Belarus", 156, "EGTK")); allTeams.Add(new Team(5, 582, "Vitebsk", "Belarus", 156, "VTBSK"));
        allTeams.Add(new Team(5, 583, "Dynapro", "Belarus", 156, "DYPRO")); allTeams.Add(new Team(5, 584, "Gom'l", "Belarus", 156, "GOM")); allTeams.Add(new Team(5, 585, "T Minsk", "Belarus", 156, "T MNSK"));
        allTeams.Add(new Team(3, 586, "Qarabag", "Azerbaijan", 155, "QRBG")); allTeams.Add(new Team(4, 587, "Inter Bak", "Azerbaijan", 155, "I BAK")); allTeams.Add(new Team(4, 588, "Neftchi", "Azerbaijan", 155, "NFTCH"));
        allTeams.Add(new Team(4, 589, "Sumqyit", "Azerbaijan", 155, "SMQT")); allTeams.Add(new Team(5, 590, "Sabh", "Azerbaijan", 155, "SABH")); allTeams.Add(new Team(5, 591, "Zira", "Azerbaijan", 155, "ZIRA"));
        allTeams.Add(new Team(5, 592, "Gabala", "Azerbaijan", 155, "GBLA")); allTeams.Add(new Team(5, 593, "Sebal", "Azerbaijan", 155, "SBAL")); allTeams.Add(new Team(3, 594, "Ludogrets", "Bulgaria", 159, "LUDO"));
        allTeams.Add(new Team(3, 595, "Levki Sfia", "Bulgaria", 159, "LK SF")); allTeams.Add(new Team(4, 596, "Lokomotv Plovdiv", "Bulgaria", 159, "LTV PLV")); allTeams.Add(new Team(4, 597, "CSKA Sfia", "Bulgaria", 159, "CSK SF"));
        allTeams.Add(new Team(4, 598, "Cherno More", "Bulgaria", 159, "CHN MRE")); allTeams.Add(new Team(4, 599, "Kardzhli", "Bulgaria", 159, "KRDZ")); allTeams.Add(new Team(4, 600, "Slava Sfia", "Bulgaria", 159, "SLV SF"));
        allTeams.Add(new Team(4, 601, "Bero", "Bulgaria", 159, "BERO")); allTeams.Add(new Team(4, 602, "Botv Plovdi", "Bulgaria", 159, "B PLV")); allTeams.Add(new Team(4, 603, "Etar", "Bulgaria", 159, "ETAR"));
        allTeams.Add(new Team(5, 604, "Dunav Rse", "Bulgaria", 159, "DNV RSE")); allTeams.Add(new Team(5, 605, "Tsar Selo", "Bulgaria", 159, "TSR SLO")); allTeams.Add(new Team(5, 606, "Botv Vrtsa", "Bulgaria", 159, "BV VRT"));
        allTeams.Add(new Team(5, 607, "Vitosha Bstrtsa", "Bulgaria", 159, "VT BST")); allTeams.Add(new Team(3, 608, "Sl'van Bratislava", "Slovakia", 198, "BRAT")); allTeams.Add(new Team(3, 609, "MSK Z'lina", "Slovakia", 198, "MSK ZL"));
        allTeams.Add(new Team(4, 610, "Dunjska Strda", "Slovakia", 198, "DUN ST")); allTeams.Add(new Team(4, 611, "Ruzmbrk", "Slovakia", 198, "RZBK")); allTeams.Add(new Team(4, 612, "Michlvce", "Slovakia", 198, "MICH"));
        allTeams.Add(new Team(4, 613, "Sprttk Trnva", "Slovakia", 198, "SPTK TRN")); allTeams.Add(new Team(5, 614, "Zlte Morvce", "Slovakia", 198, "ZLT MVCE")); allTeams.Add(new Team(5, 615, "Trencin", "Slovakia", 198, "TRNC"));
        allTeams.Add(new Team(5, 616, "Senica", "Slovakia", 198, "SNCA")); allTeams.Add(new Team(5, 617, "Sered", "Slovakia", 198, "SERE")); allTeams.Add(new Team(5, 618, "Nitra", "Slovakia", 198, "NTRA"));
        allTeams.Add(new Team(5, 619, "Pohrnia", "Slovakia", 198, "PHNA")); allTeams.Add(new Team(4, 620, "Olimpja", "Slovenia", 199, "OLMJ")); allTeams.Add(new Team(4, 621, "Aluminj", "Slovenia", 199, "ALMJ"));
        allTeams.Add(new Team(4, 622, "Maribor", "Slovenia", 199, "MRBR")); allTeams.Add(new Team(4, 623, "Celje", "Slovenia", 199, "CELJ")); allTeams.Add(new Team(4, 624, "Mura", "Slovenia", 199, "MURA"));
        allTeams.Add(new Team(4, 625, "Domzale", "Slovenia", 199, "DMZL")); allTeams.Add(new Team(5, 626, "Triglav", "Slovenia", 199, "TRGLV")); allTeams.Add(new Team(5, 627, "Tabor Sezana", "Slovenia", 199, "TBR SZNA"));
        allTeams.Add(new Team(5, 628, "Bravo", "Slovenia", 199, "BRVO")); allTeams.Add(new Team(5, 629, "Rudar", "Slovenia", 199, "RUDR")); allTeams.Add(new Team(4, 620, "Ferencvaros", "Hungary", 173, "FCVS"));
        allTeams.Add(new Team(4, 631, "Vidi", "Hungary", 173, "VIDI")); allTeams.Add(new Team(4, 632, "Mezokoves-Zsory", "Hungary", 173, "MZK-ZRY")); allTeams.Add(new Team(4, 633, "Puskas Akademia", "Hungary", 173, "PSK AKA"));
        allTeams.Add(new Team(4, 634, "Ujpest", "Hungary", 173, "UPST")); allTeams.Add(new Team(5, 635, "Budapest Honved", "Hungary", 173, "BDPT")); allTeams.Add(new Team(5, 636, "Varda SE", "Hungary", 173, "VARD"));
        allTeams.Add(new Team(5, 637, "Debrecen", "Hungary", 173, "DBRCN")); allTeams.Add(new Team(5, 638, "Diosgyor", "Hungary", 173, "DSGYR")); allTeams.Add(new Team(5, 639, "Paksi", "Hungary", 173, "PKSI"));
        allTeams.Add(new Team(5, 640, "Zalaegerszeg", "Hungary", 173, "ZGZG")); allTeams.Add(new Team(5, 641, "K. Rakoczi", "Hungary", 173, "RKZI")); allTeams.Add(new Team(4, 642, "Suduva", "Lithuania", 181, "SDVA"));
        allTeams.Add(new Team(4, 643, "Zalgiris", "Lithuania", 181, "ZALG")); allTeams.Add(new Team(4, 644, "Riteriai", "Lithuania", 181, "RITI")); allTeams.Add(new Team(5, 645, "Kauno Zalgiris", "Lithuania", 181, "KN ZALG"));
        allTeams.Add(new Team(5, 646, "Panevezys", "Lithuania", 181, "PZYS")); allTeams.Add(new Team(5, 647, "Atlantas", "Lithuania", 181, "ATLA")); allTeams.Add(new Team(4, 648, "UT Petange", "Luxembourg", 182, "UT PET"));
        allTeams.Add(new Team(4, 649, "Progres Niederkorn", "Luxembourg", 182, "PGS NDRK")); allTeams.Add(new Team(5, 650, "Folla Esch", "Luxembourg", 182, "FLA ESC")); allTeams.Add(new Team(5, 651, "Differdange 03", "Luxembourg", 182, "DIFF"));
        allTeams.Add(new Team(5, 652, "F91 Dudelange", "Luxembourg", 182, "DUDLG")); allTeams.Add(new Team(5, 653, "UNA Strassen", "Luxembourg", 182, "UNA STRS")); allTeams.Add(new Team(5, 654, "Hostert", "Luxembourg", 182, "HSTRT"));
        allTeams.Add(new Team(5, 655, "Jeunesse d'Esch", "Luxembourg", 182, "JNSE ECH")); allTeams.Add(new Team(5, 656, "Racing", "Luxembourg", 182, "RACG")); allTeams.Add(new Team(5, 657, "Mondorf-les-Bains", "Luxembourg", 182, "MLB"));
        allTeams.Add(new Team(6, 658, "Etzella Ettelbruck", "Luxembourg", 182, "ETEL")); allTeams.Add(new Team(6, 659, "Victoria Rosport", "Luxembourg", 182, "VCT ROS")); allTeams.Add(new Team(6, 660, "Blue Boys Muhlenbach", "Luxembourg", 182, "BB MHBCH"));
        allTeams.Add(new Team(6, 661, "Rodange", "Luxembourg", 182, "RDGE")); allTeams.Add(new Team(5, 662, "Lori", "Armenia", 153, "LORI")); allTeams.Add(new Team(5, 663, "Ararat-Armenia", "Armenia", 153, "ARAT"));
        allTeams.Add(new Team(5, 664, "Alashkert", "Armenia", 153, "ASHKT")); allTeams.Add(new Team(5, 665, "Ararat", "Armenia", 153, "ARRT")); allTeams.Add(new Team(5, 666, "Shirak", "Armenia", 153, "SHIRK"));
        allTeams.Add(new Team(5, 667, "Artsakh", "Armenia", 153, "ATSKH")); allTeams.Add(new Team(6, 668, "Pyunik", "Armenia", 153, "PYNK")); allTeams.Add(new Team(6, 669, "Banants", "Armenia", 153, "BNTS"));
        allTeams.Add(new Team(7, 670, "Gandzasar", "Armenia", 153, "GNDZ")); allTeams.Add(new Team(7, 671, "Yerevan", "Armenia", 153, "YRVN")); allTeams.Add(new Team(5, 672, "Riga", "Latvia", 179, "RIGA"));
        allTeams.Add(new Team(5, 673, "Rigas", "Latvia", 179, "RIGS")); allTeams.Add(new Team(5, 674, "Ventspils", "Latvia", 179, "VNTSP")); allTeams.Add(new Team(5, 675, "Valmeira", "Latvia", 179, "VALM"));
        allTeams.Add(new Team(6, 676, "Spartks Jurmala", "Latvia", 179, "SPTK JU")); allTeams.Add(new Team(6, 677, "Liepaja", "Latvia", 179, "LPJA")); allTeams.Add(new Team(6, 678, "Jelgava", "Latvia", 179, "JLGV"));
        allTeams.Add(new Team(6, 679, "Daugavpils", "Latvia", 179, "DGVP")); allTeams.Add(new Team(6, 680, "Metta", "Latvia", 179, "META")); allTeams.Add(new Team(5, 681, "Partizani", "Albania", 151, "PRTZ"));
        allTeams.Add(new Team(5, 682, "Kukesi", "Albania", 151, "KUKS")); allTeams.Add(new Team(5, 683, "Bylis", "Albania", 151, "BYLS")); allTeams.Add(new Team(5, 684, "Lac", "Albania", 151, "LAC"));
        allTeams.Add(new Team(5, 685, "Teuta", "Albania", 151, "TUTA")); allTeams.Add(new Team(5, 686, "Vllaznia", "Albania", 151, "VLZA")); allTeams.Add(new Team(5, 687, "Skenderbeu", "Albania", 151, "SKRBU"));
        allTeams.Add(new Team(6, 688, "Tirana", "Albania", 151, "TIRA")); allTeams.Add(new Team(6, 689, "Luftetari", "Albania", 151, "LUFT")); allTeams.Add(new Team(6, 690, "Flamurtari", "Albania", 151, "FLMT"));
        allTeams.Add(new Team(5, 691, "Vardar", "North Macedonia", 183, "VRDR")); allTeams.Add(new Team(5, 692, "Shkendija", "North Macedonia", 183, "SHDJA")); allTeams.Add(new Team(5, 693, "Akademija Pandev", "North Macedonia", 183, "AK PDV"));
        allTeams.Add(new Team(5, 694, "Sileks", "North Macedonia", 183, "SLKS")); allTeams.Add(new Team(5, 695, "Makedonija", "North Macedonia", 183, "MAK")); allTeams.Add(new Team(6, 696, "Struga", "North Macedonia", 183, "STGA"));
        allTeams.Add(new Team(6, 697, "Shkupi", "North Macedonia", 183, "SKPI")); allTeams.Add(new Team(6, 698, "Borec", "North Macedonia", 183, "BORC")); allTeams.Add(new Team(6, 699, "Renova", "North Macedonia", 183, "RNVA"));
        allTeams.Add(new Team(6, 700, "Rabotnicki", "North Macedonia", 183, "RBNKI")); allTeams.Add(new Team(5, 701, "Sarajevo", "Bosnia", 158, "SRJVO")); allTeams.Add(new Team(5, 702, "Zeljeznicar", "Bosnia", 158, "ZLJZ"));
        allTeams.Add(new Team(5, 703, "Borac", "Bosnia", 158, "BRAC")); allTeams.Add(new Team(5, 704, "Sloga Simin Han", "Bosnia", 158, "SSHN")); allTeams.Add(new Team(6, 705, "Zrinjski Mostar", "Bosnia", 158, "ZJK MOS"));
        allTeams.Add(new Team(6, 706, "Radnik", "Bosnia", 158, "RADNK")); allTeams.Add(new Team(6, 707, "Siroki Brijeg", "Bosnia", 158, "SIRK BJG")); allTeams.Add(new Team(6, 708, "Velez", "Bosnia", 158, "VLZ"));
        allTeams.Add(new Team(6, 709, "Celik", "Bosnia", 158, "CELI")); allTeams.Add(new Team(6, 710, "Mladost Doboj Kakanj", "Bosnia", 158, "M D KJ")); allTeams.Add(new Team(6, 711, "Sloboda", "Bosnia", 158, "SLBDA"));
        allTeams.Add(new Team(6, 712, "Zvijezda", "Bosnia", 158, "ZVJZ")); allTeams.Add(new Team(5, 713, "Sheriff", "Moldova", 185, "RIFF")); allTeams.Add(new Team(5, 714, "Sfintul Gheorghe", "Moldova", 185, "STL GHGE"));
        allTeams.Add(new Team(5, 715, "Petrocub", "Moldova", 185, "PTRCB")); allTeams.Add(new Team(5, 716, "Dinamo-Auto", "Moldova", 185, "DI-AU")); allTeams.Add(new Team(5, 717, "Milsami", "Moldova", 185, "MILS"));
        allTeams.Add(new Team(6, 718, "Speranta Nisporeni", "Moldova", 185, "SP NSP")); allTeams.Add(new Team(6, 719, "Zimbru", "Moldova", 185, "ZIMB")); allTeams.Add(new Team(5, 720, "Codru Lozova", "Moldova", 185, "CD LZA"));
        allTeams.Add(new Team(5, 721, "Dundalk", "Ireland", 192, "DUND")); allTeams.Add(new Team(5, 722, "Shamrock Rovers", "Ireland", 192, "SHAM")); allTeams.Add(new Team(6, 723, "Bohemians", "Ireland", 192, "BOHE"));
        allTeams.Add(new Team(6, 724, "Derry City", "Ireland", 192, "DER")); allTeams.Add(new Team(6, 725, "St Patrick's Athletic", "Ireland", 192, "PTATL")); allTeams.Add(new Team(6, 726, "Waterford", "Ireland", 192, "WATE"));
        allTeams.Add(new Team(6, 727, "Sligo Rovers", "Ireland", 192, "SLIG")); allTeams.Add(new Team(6, 728, "Cork City", "Ireland", 192, "CORK")); allTeams.Add(new Team(6, 729, "Finn Harps", "Ireland", 192, "HARP"));
        allTeams.Add(new Team(6, 730, "UCD", "Ireland", 192, "UCD")); allTeams.Add(new Team(5, 731, "KuPS Kuopio", "Finland", 167, "KUOP")); allTeams.Add(new Team(5, 731, "Inter Turku", "Finland", 167, "INTRK"));
        allTeams.Add(new Team(6, 733, "Honka", "Finland", 167, "HKA")); allTeams.Add(new Team(6, 734, "Ilves", "Finland", 167, "ILV")); allTeams.Add(new Team(6, 735, "Helsinki", "Finland", 167, "HELS"));
        allTeams.Add(new Team(6, 736, "Mariehamn", "Finland", 167, "MHM")); allTeams.Add(new Team(5, 737, "Dinamo Tbilisi", "Georgia", 170, "DTSI")); allTeams.Add(new Team(5, 738, "Dinamo Batumi", "Georgia", 170, "DBTM"));
        allTeams.Add(new Team(6, 739, "Saburtalo", "Georgia", 170, "SABT")); allTeams.Add(new Team(6, 740, "Locomotive Tbilisi", "Georgia", 170, "LTBI")); allTeams.Add(new Team(6, 741, "Chikhura Sachkhere", "Georgia", 170, "CHSK"));
        allTeams.Add(new Team(6, 742, "Torpedo Kutaisi", "Georgia", 170, "TKUTI")); allTeams.Add(new Team(6, 743, "Dila", "Georgia", 170, "DLA")); allTeams.Add(new Team(6, 744, "Rustavi", "Georgia", 170, "RUST"));
        allTeams.Add(new Team(6, 745, "Sioni", "Georgia", 170, "SION")); allTeams.Add(new Team(6, 746, "WIT Georgia", "Georgia", 170, "WGEO")); allTeams.Add(new Team(6, 739, "Floriana", "Malta", 184, "FLOR"));
        allTeams.Add(new Team(6, 748, "Gzira Utd", "Malta", 184, "GZR U")); allTeams.Add(new Team(6, 749, "Sirens", "Malta", 184, "SRNS")); allTeams.Add(new Team(6, 750, "Valletta", "Malta", 184, "VALL"));
        allTeams.Add(new Team(6, 751, "Hibernians", "Malta", 184, "HIBN")); allTeams.Add(new Team(6, 752, "Hamrun", "Malta", 184, "HAMR")); allTeams.Add(new Team(6, 753, "Balzan", "Malta", 184, "BALZ"));
        allTeams.Add(new Team(6, 754, "Silema", "Malta", 184, "SLMA")); allTeams.Add(new Team(6, 755, "Gudja Utd", "Malta", 184, "GUD U")); allTeams.Add(new Team(6, 756, "Birkirkara", "Malta", 184, "BIRK"));
        allTeams.Add(new Team(6, 757, "Mosta", "Malta", 184, "MOST")); allTeams.Add(new Team(6, 758, "Senglea", "Malta", 184, "SENG")); allTeams.Add(new Team(6, 759, "Santa Lucia", "Malta", 184, "ST LUC"));
        allTeams.Add(new Team(6, 760, "Tarxien", "Malta", 184, "TRXN")); allTeams.Add(new Team(6, 761, "Breidablik", "Iceland", 174, "BRDK")); allTeams.Add(new Team(6, 762, "FH", "Iceland", 174, "FH"));
        allTeams.Add(new Team(6, 763, "Stjarnan", "Iceland", 174, "STJN")); allTeams.Add(new Team(6, 761, "Valur", "Iceland", 174, "VALR")); allTeams.Add(new Team(6, 761, "KA", "Iceland", 174, "KA"));
        allTeams.Add(new Team(6, 764, "ÍA", "Iceland", 174, "ÍA")); allTeams.Add(new Team(6, 765, "Víkingur Reykjavík", "Iceland", 174, "VKRK")); allTeams.Add(new Team(6, 765, "Fylkir", "Iceland", 174, "FYLK"));
        allTeams.Add(new Team(6, 765, "HK", "Iceland", 174, "HK")); allTeams.Add(new Team(6, 765, "Grindavík", "Iceland", 174, "GRIN")); allTeams.Add(new Team(6, 765, "ÍBV", "Iceland", 174, "ÍBV"));
        allTeams.Add(new Team(6, 768, "The New Saints", "Wales", 205, "NWST")); allTeams.Add(new Team(6, 769, "Connah's Quay Nomads", "Wales", 205, "CQW")); allTeams.Add(new Team(6, 770, "Bala Town", "Wales", 205, "BLTWN"));
        allTeams.Add(new Team(6, 771, "Barry Town", "Wales", 205, "BYWLS")); allTeams.Add(new Team(6, 772, "Caernarfon Town", "Wales", 205, "CTWN")); allTeams.Add(new Team(6, 773, "Cefn Druids", "Wales", 205, "CFN"));
        allTeams.Add(new Team(6, 774, "Cardiff", "Wales", 205, "CARD")); allTeams.Add(new Team(6, 775, "Newtown", "Wales", 205, "NEWT")); allTeams.Add(new Team(6, 776, "Aberystwyth", "Wales", 205, "ABWH"));
        allTeams.Add(new Team(6, 777, "Pennybont", "Wales", 205, "PENN")); allTeams.Add(new Team(6, 778, "Broughton", "Wales", 205, "BROTN")); allTeams.Add(new Team(6, 779, "Carmarthen Twon", "Wales", 205, "CARMA"));
        allTeams.Add(new Team(6, 780, "Linfield", "Northern Ireland", 187, "LINF")); allTeams.Add(new Team(6, 781, "Coleraine", "Northern Ireland", 187, "COLE")); allTeams.Add(new Team(6, 782, "Crusaders", "Northern Ireland", 187, "CRUS"));
        allTeams.Add(new Team(6, 783, "Cliftonville", "Northern Ireland", 187, "CLFT")); allTeams.Add(new Team(6, 784, "Glentoran", "Northern Ireland", 187, "GLTN")); allTeams.Add(new Team(6, 785, "Larne", "Northern Ireland", 187, "LRNE"));
        allTeams.Add(new Team(6, 786, "Carrick", "Northern Ireland", 187, "CRRK")); allTeams.Add(new Team(6, 787, "Nallymena Utd", "Northern Ireland", 187, "NYMN")); allTeams.Add(new Team(6, 788, "Glenavon", "Northern Ireland", 187, "GLEN"));
        allTeams.Add(new Team(6, 789, "Dungannon", "Northern Ireland", 187, "DUNG")); allTeams.Add(new Team(6, 790, "Institute", "Northern Ireland", 187, "INST")); allTeams.Add(new Team(6, 791, "Warrenpoint", "Northern Ireland", 187, "WARR"));
        allTeams.Add(new Team(6, 792, "St Joseph's", "Gibraltor", 169, "ST JO")); allTeams.Add(new Team(6, 793, "Europa", "Gibraltor", 169, "EURO")); allTeams.Add(new Team(6, 793, "Lincoln Red Imps", "Gibraltor", 169, "LINC"));
        allTeams.Add(new Team(6, 795, "Lynx", "Gibraltor", 169, "LYNX")); allTeams.Add(new Team(6, 796, "Magpies", "Gibraltor", 169, "MAGS")); allTeams.Add(new Team(6, 797, "Mons Calpe", "Gibraltor", 169, "CALP"));
        allTeams.Add(new Team(6, 798, "Manchester 62", "Gibraltor", 169, "MAN 62")); allTeams.Add(new Team(6, 799, "Lions Gibraltor", "Gibraltor", 169, "LIONS")); allTeams.Add(new Team(6, 800, "Boca Juniors", "Gibraltor", 169, "BOCA J"));
        allTeams.Add(new Team(6, 801, "Glacis Utd", "Gibraltor", 169, "GLA U")); allTeams.Add(new Team(6, 802, "Europa Point", "Gibraltor", 169, "EPA PNT")); allTeams.Add(new Team(6, 803, "College 1975", "Gibraltor", 169, "CGE 75"));
        allTeams.Add(new Team(6, 804, "Buducnost", "Montenegro", 186, "BUDU")); allTeams.Add(new Team(6, 805, "Sutjeska", "Montenegro", 186, "SJSK")); allTeams.Add(new Team(6, 806, "Iskra", "Montenegro", 186, "ISK"));
        allTeams.Add(new Team(6, 807, "Zeta", "Montenegro", 186, "ZETA")); allTeams.Add(new Team(6, 808, "Mladost", "Montenegro", 186, "MLAD")); allTeams.Add(new Team(6, 809, "Rudar Pljevlja", "Montenegro", 186, "RDPJ"));
        allTeams.Add(new Team(6, 810, "Mladost Podgorica", "Montenegro", 186, "M PGC")); allTeams.Add(new Team(6, 811, "Petrovac", "Montenegro", 186, "PTRO")); allTeams.Add(new Team(6, 812, "Kom", "Montenegro", 186, "KOM"));
        allTeams.Add(new Team(6, 813, "Grbalj", "Montenegro", 186, "GRBJ")); allTeams.Add(new Team(6, 814, "Flora", "Estonia", 165, "FLRA")); allTeams.Add(new Team(6, 815, "Levadia", "Estonia", 165, "LVDA"));
        allTeams.Add(new Team(6, 816, "Nomme Kalju", "Estonia", 165, "KALJ")); allTeams.Add(new Team(6, 817, "Paide", "Estonia", 165, "PDE")); allTeams.Add(new Team(6, 818, "Tammeka", "Estonia", 165, "TAMM"));
        allTeams.Add(new Team(6, 819, "Trans", "Estonia", 165, "TRAN")); allTeams.Add(new Team(6, 820, "Tulevik", "Estonia", 165, "TLVK")); allTeams.Add(new Team(6, 821, "Tallinna Kalev", "Estonia", 165, "TLKV"));
        allTeams.Add(new Team(6, 822, "Kuressaare", "Estonia", 165, "KRSE")); allTeams.Add(new Team(6, 823, "Maardu", "Estonia", 165, "MRDU")); allTeams.Add(new Team(6, 824, "Ballkani", "Kosovo", 178, "BLKI"));
        allTeams.Add(new Team(6, 825, "Gjilani", "Kosovo", 178, "GJLI")); allTeams.Add(new Team(6, 826, "Drita", "Kosovo", 178, "DRTA")); allTeams.Add(new Team(6, 827, "Prishtina", "Kosovo", 178, "PSTA"));
        allTeams.Add(new Team(6, 828, "Feronikeli", "Kosovo", 178, "FRKL")); allTeams.Add(new Team(6, 829, "Drenica Skenderaj", "Kosovo", 178, "SKEN")); allTeams.Add(new Team(6, 830, "Llapi", "Kosovo", 178, "LLPI"));
        allTeams.Add(new Team(6, 831, "Trepca'89", "Kosovo", 178, "TRPC")); allTeams.Add(new Team(6, 832, "Flamurtari", "Kosovo", 178, "FLAM")); allTeams.Add(new Team(6, 833, "Ferizaj", "Kosovo", 178, "FRZJ"));
        allTeams.Add(new Team(6, 834, "Vushtrria", "Kosovo", 178, "VUSH")); allTeams.Add(new Team(6, 835, "Dukagjini", "Kosovo", 178, "DUKA")); allTeams.Add(new Team(6, 836, "HB", "Faroe Islands", 166, "HB"));
        allTeams.Add(new Team(6, 837, "NSI", "Faroe Islands", 166, "NSI")); allTeams.Add(new Team(6, 838, "Torshavn", "Faroe Islands", 166, "TORS")); allTeams.Add(new Team(6, 839, "KI", "Faroe Islands", 166, "KI"));
        allTeams.Add(new Team(6, 840, "Vikingur", "Faroe Islands", 166, "VIKI")); allTeams.Add(new Team(6, 841, "Skala", "Faroe Islands", 166, "SKA")); allTeams.Add(new Team(6, 842, "Royn", "Faroe Islands", 166, "ROY"));
        allTeams.Add(new Team(6, 843, "Streymur", "Faroe Islands", 166, "STRE")); allTeams.Add(new Team(6, 844, "Argir", "Faroe Islands", 166, "ARGI")); allTeams.Add(new Team(6, 845, "Vestur", "Faroe Islands", 166, "VEST"));
        allTeams.Add(new Team(6, 846, "FC Santa Coloma", "Andorra", 152, "COLO")); allTeams.Add(new Team(6, 847, "Inter d'Escaldes", "Andorra", 152, "INT ESC")); allTeams.Add(new Team(6, 848, "Engordany", "Andorra", 152, "ENGOR"));
        allTeams.Add(new Team(6, 849, "Sant Julia", "Andorra", 152, "SAN JUL")); allTeams.Add(new Team(6, 850, "UE Santa Coloma", "Andorra", 152, "SAN COL")); allTeams.Add(new Team(6, 851, "Atletic Escaldes", "Andorra", 152, "ATL ESC"));
        allTeams.Add(new Team(6, 852, "Ordino", "Andorra", 152, "ORD")); allTeams.Add(new Team(6, 853, "Carroi", "Andorra", 152, "CARR")); allTeams.Add(new Team(6, 854, "Cailungo", "San Marino", 195, "CAIL"));
        allTeams.Add(new Team(6, 855, "La Fiorita", "San Marino", 195, "L' FIO")); allTeams.Add(new Team(6, 856, "Tre Fiori", "San Marino", 195, "TRE F")); allTeams.Add(new Team(6, 857, "Tre Penne", "San Marino", 195, "TRE P"));
        allTeams.Add(new Team(6, 858, "Folgore", "San Marino", 195, "FOLG")); allTeams.Add(new Team(6, 859, "Libertas", "San Marino", 195, "LIBE")); allTeams.Add(new Team(6, 860, "Murata", "San Marino", 195, "MUR"));
        allTeams.Add(new Team(6, 861, "Virtus", "San Marino", 195, "VIT")); allTeams.Add(new Team(5, 862, "Vaduz", "Liechtenstein", 180, "VADZ")); allTeams.Add(new Team(6, 863, "USV Mauren", "Liechtenstein", 180, "MAUR"));
        allTeams.Add(new Team(6, 864, "Balzers", "Liechtenstein", 180, "BALZ")); allTeams.Add(new Team(7, 865, "Ruggell", "Liechtenstein", 180, "RUG")); allTeams.Add(new Team(7, 866, "Triesenberg", "Liechtenstein", 180, "TRI"));
        allTeams.Add(new Team(5, 867, "Afghanistan", "Afghanistan", 0, "AFGH")); allTeams.Add(new Team(3, 868, "Australia", "Australia", 1, "AUS")); allTeams.Add(new Team(4, 869, "Bahrain", "Bahrain", 2, "BAH"));
        allTeams.Add(new Team(5, 870, "Bangladesh", "Bangladesh", 3, "BANG")); allTeams.Add(new Team(5, 871, "Bhutan", "Bhutan", 4, "BHU")); allTeams.Add(new Team(5, 872, "Brunei", "Brunei", 5, "BRU"));
        allTeams.Add(new Team(5, 873, "Cambodia", "Cambodia", 6, "CAMB")); allTeams.Add(new Team(3, 874, "China", "China", 7, "CHI")); allTeams.Add(new Team(5, 875, "Guam", "Guam", 8, "GUAM"));
        allTeams.Add(new Team(4, 876, "Hong Kong", "Hong Kong", 9, "HO KO")); allTeams.Add(new Team(4, 877, "India", "India", 10, "IND")); allTeams.Add(new Team(5, 878, "Indonesia", "Indonesia", 11, "INDO"));
        allTeams.Add(new Team(2, 879, "Iran", "Iran", 12, "IRAN")); allTeams.Add(new Team(3, 880, "Iraq", "Iraq", 13, "IRAQ")); allTeams.Add(new Team(2, 881, "Japan", "Japan", 14, "JAP"));
        allTeams.Add(new Team(4, 882, "Jordan", "Jordan", 15, "JOR")); allTeams.Add(new Team(5, 883, "Kuwait", "Kuwait", 16, "KUW")); allTeams.Add(new Team(4, 884, "Kyrgyzstan", "Kyrgyzstan", 17, "KYR"));
        allTeams.Add(new Team(5, 885, "Laos", "Laos", 18, "LAO")); allTeams.Add(new Team(4, 886, "Lebananon", "Lebananon", 19, "LEB")); allTeams.Add(new Team(5, 887, "Macau", "Macau", 20, "MACA"));
        allTeams.Add(new Team(5, 888, "Malaysia", "Malaysia", 21, "MAL")); allTeams.Add(new Team(5, 889, "Maldives", "Maldives", 22, "MALD")); allTeams.Add(new Team(5, 890, "Mongolia", "Mongolia", 23, "MON"));
        allTeams.Add(new Team(4, 891, "Myanmar", "Myanmar", 24, "MYA")); allTeams.Add(new Team(4, 892, "North Korea", "North Korea", 25, "N KOR")); allTeams.Add(new Team(5, 893, "Nepal", "Nepal", 26, "NEP"));
        allTeams.Add(new Team(4, 894, "Oman", "Oman", 27, "OMAN")); allTeams.Add(new Team(5, 895, "Pakistan", "Pakistan", 28, "PAK")); allTeams.Add(new Team(4, 896, "Phillipines", "Phillipines", 29, "PHIL"));
        allTeams.Add(new Team(4, 897, "Palestine", "Palestine", 30, "PALE")); allTeams.Add(new Team(3, 898, "Qatar", "Qatar", 31, "QAT")); allTeams.Add(new Team(2, 899, "South Korea", "South Korea", 32, "S KOR"));
        allTeams.Add(new Team(5, 900, "Sri Lanka", "Sri Lanka", 33, "SRI")); allTeams.Add(new Team(3, 901, "Saudi Arabia", "Saudi Arabia", 34, "SAUD")); allTeams.Add(new Team(5, 902, "Singapore", "Singapore", 35, "SING"));
        allTeams.Add(new Team(3, 903, "Syria", "Syria", 36, "SYR")); allTeams.Add(new Team(4, 904, "Chinese Taipei", "Chinese Taipei", 37, "CHI T")); allTeams.Add(new Team(4, 905, "Tajikistan", "Tajikistan", 38, "TAJI"));
        allTeams.Add(new Team(4, 906, "Thailand", "Thailand", 39, "THAI")); allTeams.Add(new Team(5, 907, "Timor-Leste", "Timor-Leste", 40, "TIM-LES")); allTeams.Add(new Team(4, 908, "Turkmenistan", "Turkmenistan", 41, "TURKM"));
        allTeams.Add(new Team(3, 909, "UAE", "UAE", 42, "UAE")); allTeams.Add(new Team(4, 910, "Uzbekistan", "Uzbekistan", 43, "UZB")); allTeams.Add(new Team(4, 911, "Vietnam", "Vietnam", 44, "VIET"));
        allTeams.Add(new Team(5, 912, "Yemen", "Yemen", 45, "YEM")); allTeams.Add(new Team(2, 913, "Algeria", "Algeria", 46, "ALGA")); allTeams.Add(new Team(4, 914, "Angola", "Angola", 47, "ANG"));
        allTeams.Add(new Team(4, 915, "Benin", "Benin", 48, "BENI")); allTeams.Add(new Team(5, 916, "Botswana", "Botswana", 49, "BOTS")); allTeams.Add(new Team(3, 917, "Burkino Faso", "Burkino Faso", 50, "BURK"));
        allTeams.Add(new Team(5, 918, "Burundi", "Burundi", 51, "BUR")); allTeams.Add(new Team(3, 919, "Cape Verde", "Cape Verde", 52, "CP VDE")); allTeams.Add(new Team(3, 920, "Central African Republic", "Central African Republic", 53, "AFR REP"));
        allTeams.Add(new Team(5, 921, "Chad", "Chad", 54, "CHAD")); allTeams.Add(new Team(3, 922, "Cameroon", "Cameroon", 55, "CAM")); allTeams.Add(new Team(4, 923, "Comoros", "Comoros", 56, "COM"));
        allTeams.Add(new Team(4, 924, "Congo", "Congo", 57, "CON")); allTeams.Add(new Team(5, 925, "Djibouti", "Djibouti", 58, "DJI")); allTeams.Add(new Team(3, 926, "Dr Congo", "Dr Congo", 59, "DR C"));
        allTeams.Add(new Team(3, 927, "Egypt", "Egypt", 60, "EGY")); allTeams.Add(new Team(5, 928, "Equatorial Guinea", "Equatorial Guinea", 61, "EQ GUIN")); allTeams.Add(new Team(5, 929, "Eritrea", "Eritrea", 62, "ERIT"));
        allTeams.Add(new Team(5, 930, "Ethiopia", "Ethiopia", 63, "ETH")); allTeams.Add(new Team(4, 931, "Gabon", "Gabon", 64, "GAB")); allTeams.Add(new Team(5, 932, "Gambia", "Gambia", 65, "GAMB"));
        allTeams.Add(new Team(4, 933, "Guinea-Bissau", "Guinea-Bissau", 66, "GNE-BIS")); allTeams.Add(new Team(3, 934, "Ghana", "Ghana", 67, "GHA")); allTeams.Add(new Team(3, 935, "Guinea", "Guinea", 68, "GUIN"));
        allTeams.Add(new Team(3, 936, "Cote D'Ivoire", "Cote D'Ivoire", 69, "IVO")); allTeams.Add(new Team(4, 937, "Kenya", "Kenya", 70, "KEN")); allTeams.Add(new Team(4, 938, "Lesotho", "Lesotho", 71, "LES"));
        allTeams.Add(new Team(5, 939, "Liberia", "Liberia", 72, "LIB")); allTeams.Add(new Team(4, 940, "Libya", "Libya", 73, "LIBY")); allTeams.Add(new Team(4, 941, "Mauritania", "Mauritania", 74, "MATA"));
        allTeams.Add(new Team(4, 942, "Madagascar", "Madagascar", 75, "MADA")); allTeams.Add(new Team(4, 943, "Malawi", "Malawi", 76, "MALA")); allTeams.Add(new Team(3, 944, "Mali", "Mali", 77, "MAL"));
        allTeams.Add(new Team(3, 945, "Morroco", "Morroco", 78, "MORR")); allTeams.Add(new Team(4, 946, "Mozambique", "Mozambique", 79, "MOZ")); allTeams.Add(new Team(5, 947, "Mauritius", "Mauritius", 80, "MAUR"));
        allTeams.Add(new Team(4, 948, "Namibia", "Namibia", 81, "NAM")); allTeams.Add(new Team(4, 949, "Niger", "Niger", 82, "NIG")); allTeams.Add(new Team(2, 950, "Nigeria", "Nigeria", 83, "NIGE"));
        allTeams.Add(new Team(4, 951, "Rwanda", "Rwanda", 84, "RWAN")); allTeams.Add(new Team(3, 952, "South Africa", "South Africa", 85, "SOU AF")); allTeams.Add(new Team(5, 953, "Sao Tome and Principe", "Sao Tome and Principe", 86, "SAO"));
        allTeams.Add(new Team(2, 954, "Senegal", "Senegal", 87, "SENE")); allTeams.Add(new Team(5, 955, "Seychelles", "Seychelles", 88, "SEY")); allTeams.Add(new Team(4, 956, "Sierra Leone", "Sierra Leone", 89, "SIE"));
        allTeams.Add(new Team(5, 957, "Somalia", "Somalia", 90, "SOMA")); allTeams.Add(new Team(4, 958, "Sudan", "Sudan", 91, "SUDA")); allTeams.Add(new Team(5, 959, "Swaziland", "Swaziland", 92, "SWAZ"));
        allTeams.Add(new Team(4, 960, "Tanzania", "Tanzania", 93, "TANZ")); allTeams.Add(new Team(4, 961, "Togo", "Togo", 94, "TOGO")); allTeams.Add(new Team(2, 962, "Tunisia", "Tunisia", 95, "TUNI"));
        allTeams.Add(new Team(3, 963, "Uganda", "Uganda", 96, "UGAN")); allTeams.Add(new Team(4, 964, "Zambia", "Zambia", 97, "ZAMB")); allTeams.Add(new Team(4, 965, "Zimbabwe", "Zimbabwe", 98, "ZIMB"));
        allTeams.Add(new Team(5, 966, "Anguilla", "Anguilla", 99, "ANGU")); allTeams.Add(new Team(4, 967, "Antigua and Barbuda", "Antigua and Barbuda", 100, "A&B")); allTeams.Add(new Team(5, 968, "Aruba", "Aruba", 101, "ARU"));
        allTeams.Add(new Team(5, 969, "Bahamas", "Bahamas", 102, "BAH")); allTeams.Add(new Team(5, 970, "Belize", "Belize", 103, "BELZ")); allTeams.Add(new Team(5, 971, "Bermuda", "Bermuda", 104, "BERM"));
        allTeams.Add(new Team(5, 972, "Barbados", "Barbados", 105, "BARB")); allTeams.Add(new Team(5, 973, "British Virgin Islands", "British Virgin Islands", 106, "BR VIR")); allTeams.Add(new Team(3, 974, "Costa Rica", "Costa Rica", 107, "COS RCA"));
        allTeams.Add(new Team(3, 975, "Canada", "Canada", 108, "CAN")); allTeams.Add(new Team(5, 976, "Cayman Islands", "Cayman Islands", 109, "CYMN")); allTeams.Add(new Team(5, 977, "Cuba", "Cuba", 110, "CUB"));
        allTeams.Add(new Team(3, 978, "Curacao", "Curacao", 111, "CURA")); allTeams.Add(new Team(5, 979, "Dominica", "Dominica", 112, "DOMI")); allTeams.Add(new Team(5, 980, "Dominican Republic", "Dominican Republic", 113, "DOM REP"));
        allTeams.Add(new Team(3, 981, "El Salvador", "El Salvador", 114, "EL SAL")); allTeams.Add(new Team(5, 982, "Guadeloupe", "Guadeloupe", 115, "GUAD")); allTeams.Add(new Team(5, 983, "Grenada", "Grenada", 116, "GREN"));
        allTeams.Add(new Team(4, 984, "Guatemala", "Guatemala", 117, "GUAT")); allTeams.Add(new Team(5, 985, "Guyana", "Guyana", 118, "GUY")); allTeams.Add(new Team(4, 986, "Haiti", "Haiti", 119, "HAI"));
        allTeams.Add(new Team(3, 987, "Honduras", "Honduras", 120, "HOND")); allTeams.Add(new Team(3, 988, "Jamaica", "Jamaica", 121, "JAM")); allTeams.Add(new Team(1, 989, "Mexico", "Mexico", 122, "MEX"));
        allTeams.Add(new Team(5, 990, "Montserrat", "Montserrat", 123, "MONT")); allTeams.Add(new Team(5, 991, "Nicaragua", "Nicaragua", 124, "NIC")); allTeams.Add(new Team(5, 992, "Puerto Rico", "Puerto Rico", 125, "PUR"));
        allTeams.Add(new Team(4, 993, "Panama", "Panama", 126, "PAN")); allTeams.Add(new Team(5, 994, "St Vincents and Grenadines", "St Vincents and Grenadines", 127, "ST V&G")); allTeams.Add(new Team(4, 995, "St Kitts and Nevis", "St Kitts and Nevis", 128, "ST K&N"));
        allTeams.Add(new Team(5, 996, "St Lucia", "St Lucia", 129, "ST LUC")); allTeams.Add(new Team(5, 997, "Suriname", "Suriname", 130, "SURI")); allTeams.Add(new Team(4, 998, "Trinidad and Tobago", "Trinidad and Tobago", 131, "T&T"));
        allTeams.Add(new Team(5, 999, "Turks and Caicos Islands", "Turks and Caicos Islands", 132, "TCI")); allTeams.Add(new Team(5, 1000, "US Virgin Islands", "US Virgin Islands", 133, "VIR")); allTeams.Add(new Team(2, 1001, "USA", "USA", 134, "USA"));
        allTeams.Add(new Team(1, 1002, "Argentina", "Argentina", 135, "ARG")); allTeams.Add(new Team(3, 1003, "Bolivia", "Bolivia", 136, "BOL")); allTeams.Add(new Team(1, 1004, "Brazil", "Brazil", 137, "BRA"));
        allTeams.Add(new Team(2, 1005, "Chile", "Chile", 138, "CHLE")); allTeams.Add(new Team(1, 1006, "Columbia", "Columbia", 139, "COL")); allTeams.Add(new Team(3, 1007, "Ecuador", "Ecuador", 140, "ECU"));
        allTeams.Add(new Team(2, 1008, "Peru", "Peru", 141, "PERU")); allTeams.Add(new Team(2, 1009, "Paraguay", "Paraguay", 142, "PARA")); allTeams.Add(new Team(1, 1010, "Uraguay", "Uraguay", 143, "URA"));
        allTeams.Add(new Team(4, 1011, "Venezuela", "Venezuela", 144, "VENE")); allTeams.Add(new Team(5, 1012, "American Samoa", "American Samoa", 145, "SAM")); allTeams.Add(new Team(5, 1013, "Cook Islands", "Cook Islands", 146, "CK IS"));
        allTeams.Add(new Team(5, 1014, "Fiji", "Fiji", 147, "FJI")); allTeams.Add(new Team(5, 1015, "New Caledonia", "New Caledonia", 148, "NWC")); allTeams.Add(new Team(4, 1016, "New Zealand", "New Zealand", 149, "NZ"));
        allTeams.Add(new Team(5, 1017, "Papua New Guinea", "Papua New Guinea", 150, "PNG")); allTeams.Add(new Team(3, 1018, "Albania", "Albania", 151, "ALB")); allTeams.Add(new Team(4, 1019, "Andorra", "Andorra", 152, "AND"));
        allTeams.Add(new Team(4, 1020, "Armenia", "Armenia", 153, "ARM")); allTeams.Add(new Team(2, 1021, "Austria", "Austria", 154, "AUST")); allTeams.Add(new Team(4, 1022, "Azerbaijan", "Azerbaijan", 155, "AZJN"));
        allTeams.Add(new Team(4, 1023, "Belarus", "Belarus", 156, "BELA")); allTeams.Add(new Team(1, 1024, "Belgium", "Belgium", 157, "BEL")); allTeams.Add(new Team(3, 1025, "Bosnia", "Bosnia", 158, "BOS"));
        allTeams.Add(new Team(3, 1026, "Bulgaria", "Bulgaria", 159, "BULG")); allTeams.Add(new Team(1, 1027, "Croatia", "Croatia", 160, "CRO")); allTeams.Add(new Team(4, 1028, "Cyprus", "Cyprus", 161, "CYP"));
        allTeams.Add(new Team(3, 1029, "Czech Republic", "Czech Republic", 162, "CZE")); allTeams.Add(new Team(2, 1030, "Denmark", "Denmark", 163, "DEN")); allTeams.Add(new Team(1, 1031, "England", "England", 164, "ENG"));
        allTeams.Add(new Team(4, 1032, "Estonia", "Estonia", 165, "EST")); allTeams.Add(new Team(4, 1033, "Faroe Islands", "Faroe Islands", 166, "FAR")); allTeams.Add(new Team(3, 1034, "Finland", "Finland", 167, "FIN"));
        allTeams.Add(new Team(1, 1035, "France", "France", 168, "FRA")); allTeams.Add(new Team(5, 1036, "Gibraltor", "Gibraltor", 169, "GIB")); allTeams.Add(new Team(4, 1037, "Georgia", "Georgia", 170, "GEOR"));
        allTeams.Add(new Team(1, 1038, "Germany", "Germany", 171, "GER")); allTeams.Add(new Team(3, 1039, "Greece", "Greece", 172, "GRE")); allTeams.Add(new Team(3, 1040, "Hungary", "Hungary", 173, "HUN"));
        allTeams.Add(new Team(2, 1041, "Iceland", "Iceland", 174, "ICE")); allTeams.Add(new Team(4, 1042, "Israel", "Israel", 175, "ISR")); allTeams.Add(new Team(1, 1043, "Italy", "Italy", 176, "ITA"));
        allTeams.Add(new Team(4, 1044, "Kazakhstan", "Kazakhstan", 177, "KAZ")); allTeams.Add(new Team(4, 1045, "Kosovo", "Kosovo", 178, "KOS")); allTeams.Add(new Team(4, 1046, "Latvia", "Latvia", 179, "LAT"));
        allTeams.Add(new Team(5, 1047, "Liechtenstein", "Liectenstein", 180, "LICT")); allTeams.Add(new Team(4, 1048, "Lithuania", "Lithuania", 181, "LITH")); allTeams.Add(new Team(4, 1049, "Luxembourg", "Luxembourg", 182, "LUXE"));
        allTeams.Add(new Team(3, 1050, "Macedonia", "Macedonia", 183, "MACE")); allTeams.Add(new Team(5, 1051, "Malta", "Malta", 184, "MLTA")); allTeams.Add(new Team(5, 1052, "Moldova", "Moldova", 185, "MOLD"));
        allTeams.Add(new Team(3, 1053, "Montengro", "Montengro", 186, "MONT")); allTeams.Add(new Team(2, 1054, "Northern Ireland", "Northern Ireland", 187, "N IRE")); allTeams.Add(new Team(1, 1055, "Netherlands", "Netherlands", 188, "NED"));
        allTeams.Add(new Team(3, 1056, "Norway", "Norway", 189, "NOR")); allTeams.Add(new Team(2, 1057, "Poland", "Poland", 190, "POL")); allTeams.Add(new Team(1, 1058, "Portugal", "Portugal", 191, "POR"));
        allTeams.Add(new Team(2, 1059, "Ireland", "Ireland", 192, "IRE")); allTeams.Add(new Team(2, 1060, "Romania", "Romania", 193, "ROM")); allTeams.Add(new Team(2, 1061, "Russia", "Russia", 194, "RUS"));
        allTeams.Add(new Team(5, 1062, "San Marino", "San Marino", 195, "SAN")); allTeams.Add(new Team(3, 1063, "Scotland", "Scotland", 196, "SCO")); allTeams.Add(new Team(2, 1064, "Serbia", "Serbia", 197, "SERB"));
        allTeams.Add(new Team(2, 1065, "Slovakia", "Slovakia", 198, "SLVK")); allTeams.Add(new Team(3, 1066, "Slovenia", "Slovenia", 199, "SLOV")); allTeams.Add(new Team(1, 1067, "Spain", "Spain", 200, "SPA"));
        allTeams.Add(new Team(2, 1068, "Sweden", "Sweden", 201, "SWE")); allTeams.Add(new Team(1, 1069, "Switzerland", "Switzerland", 202, "SWIT")); allTeams.Add(new Team(2, 1070, "Turkey", "Turkey", 203, "TURK"));
        allTeams.Add(new Team(2, 1071, "Ukraine", "Ukraine", 204, "UKR"));
    }

    public void SetUpPlayerGenders()
    {
        for (int i = 0; i < schoolTeams.Count; i++)
            schoolTeams[i].AssignPlayerGender(player.GetMale());
    }
    public void GetTeam()
    {
        
    }

    public void AddPlayerToTeam()
    {
        for (int i = 0; i < schoolTeams.Count; i++)
            if (schoolTeams[i].GetTeamName() == player.GetTeamName())
                schoolTeams[i].ReplaceFirstWithPlayer(player);
    }
}
