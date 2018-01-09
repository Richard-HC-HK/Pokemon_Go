using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pokemon__Test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// public class PokemonType

    public class GAMEdata
    {
        public static List<Skill> skilllist = new List<Skill>();
        public static void Defineskills()
        {
            skilllist.Add(new Skill("Thunderbolt", ElementType.Electric, 1, "A strong electric blast crashes down on the target.", 100, 50, 120, 0));
            skilllist.Add(new Skill("Thunder Shock", ElementType.Electric, 1, "A jolt of electricity crashes down on the target to inflict damage.", 120, 80, 100, 0));
            skilllist.Add(new Skill("Quick Attack", ElementType.Normal, 1, "The user lunges at the target at a speed that makes it almost invisible.", 100, 30, 70, 8));
            skilllist.Add(new Skill("Flame Burst", ElementType.Fire, 1, "The user attacks the target with a bursting flame.", 100, 50, 120, 0));
            skilllist.Add(new Skill("Flamethrower", ElementType.Fire, 1, "The target is scorched with an intense blast of fire.", 90, 70, 90, 4));
            skilllist.Add(new Skill("Scratch", ElementType.Normal, 1, "Hard, pointed, sharp claws rake the target to inflict damage.", 100, 40, 60, 8));
            skilllist.Add(new Skill("Fire Blast", ElementType.Fire, 1, "The target is attacked with an intense blast of all-consuming fire.", 50, 70, 120, 0));
            skilllist.Add(new Skill("Thunder Wave", ElementType.Electric, 1, "The user launches a weak jolt of electricity that paralyzes the target.", 80, 80, 100, 0));
            skilllist.Add(new Skill("Ice Shard", ElementType.Ice, 1, "The user flash-freezes chunks of ice and hurls them at the target.", 100, 80, 110, 0));
            skilllist.Add(new Skill("Frost Breath", ElementType.Ice, 1, "The user blows its cold breath on the target.", 100, 100, 80, 4));
            skilllist.Add(new Skill("Blizzard", ElementType.Ice, 1, "A howling blizzard is summoned to strike opposing Pokémon.", 110, 70, 120, 0));
            skilllist.Add(new Skill("Water Gun", ElementType.Water, 1, "The target is blasted with a forceful shot of water.", 100, 50, 90, 4));
            skilllist.Add(new Skill("Water Pulse", ElementType.Water, 1, "The user attacks the target with a pulsing blast of water.", 100, 80, 100, 0));
            skilllist.Add(new Skill("Hydro Pump", ElementType.Water, 1, "The target is blasted by a huge volume of water launched under great pressure.", 50, 80, 120, 0));
            skilllist.Add(new Skill("Earthquake", ElementType.Ground, 1, "The user sets off an earthquake that strikes every Pokémon around it.", 100, 50, 120, 0));
            skilllist.Add(new Skill("Mud Bomb", ElementType.Ground, 1, "The user launches a hard-packed mud ball to attack.", 80, 80, 90, 4));
            skilllist.Add(new Skill("Slash", ElementType.Normal, 1, "The target is attacked with a slash of claws or blades.", 100, 30, 70, 8));
        }
    }

    public enum ElementType { Fire, Ice, Ground, Electric, Water,Normal };
   
    public class GameController                                   // defining the GameController--static class
    {
        
           static PokemonType Pikachu = new PokemonType("Pikachu", ElementType.Electric);
           static PokemonType Raichu = new PokemonType("Raichu", ElementType.Electric);
           static PokemonType Charmander = new PokemonType("Charmander", ElementType.Fire);
           static PokemonType Charmeleon = new PokemonType("Charmeleon", ElementType.Fire);
           static PokemonType Squirtle = new PokemonType("Squirtle", ElementType.Water);
           static PokemonType Wartortle = new PokemonType("Wartortle", ElementType.Water);
           static PokemonType Lapras = new PokemonType("Lapras", ElementType.Ice);
           static PokemonType Diglett = new PokemonType("Diglett", ElementType.Ground);
           static PokemonType Dugtrio = new PokemonType("Dugtrio", ElementType.Ground);

        public void DefineType()
        {
            Pikachu.nextevolvedtype = Raichu;
            Charmander.nextevolvedtype = Charmeleon;
            Squirtle.nextevolvedtype = Wartortle;
            Diglett.nextevolvedtype = Dugtrio;
            Lapras.nextevolvedtype = null;
            Raichu.nextevolvedtype = null;
            Charmeleon.nextevolvedtype = null;
            Wartortle.nextevolvedtype = null;
            Dugtrio.nextevolvedtype = null;
        }

        public Ball[] myballs = new Ball[3];
        public List<PokemonType> pokemonlist = new List<PokemonType>() { Pikachu, Charmander, Squirtle, Lapras, Diglett };

        public void Initialize()
        {
            for (int i = 0; i < 3; i++)
            {
                myballs[i] = new Ball();
            }

            DefineType();          
            GAMEdata.Defineskills();

        }               

    }

    public class PokemonType
    {
        public string typename;
        public ElementType PokemonElementType;              // defining the characteristic of the type, e.g fire, water
        public PokemonType nextevolvedtype;                 // defining the next evolving type
        public PokemonType(string pname, ElementType ptype) //custom constructor of pokemon type
        {
            typename = pname;
            PokemonElementType = ptype;
        }
    }

    public class Ball
    {

        public bool ifbusy;
        public Ball()
        {
            ifbusy = false;
        }
        public Pokemon pokemoninball;
        public void ballEvolve()                                  // defining the evolving method
        {
            if (pokemoninball.mytype.nextevolvedtype == null)
            {
                MessageBox.Show("Can't evolve: This is the final type");
            }
            else if (pokemoninball.level >= 5)
            {
                pokemoninball.mytype = pokemoninball.mytype.nextevolvedtype;
                pokemoninball.s1.skillevolve();
                pokemoninball.s2.skillevolve();
                pokemoninball.hp = pokemoninball.hp * 13 / 10;
                pokemoninball.cp = pokemoninball.cp * 13 / 10;
                pokemoninball.ScalingCP = pokemoninball.ScalingCP * 13 / 10;
                pokemoninball.ScalingHP = pokemoninball.ScalingHP * 13 / 10;
                MessageBox.Show("You are now " + pokemoninball.mytype.typename+"!");
                //get new skill
            }
            else
            {
                MessageBox.Show("Can't evolve: You need level 5.");
            }
        }
        public void ballLvlup()                                   // defining the Lvlup method
        {
            if (pokemoninball.level == 10)
            {
                MessageBox.Show("You have max level 10.");
            }
            else if (pokemoninball.exp >= pokemoninball.expLimit)
            {
                pokemoninball.level++;
                pokemoninball.s1.SkillLevel++;
                pokemoninball.s2.SkillLevel++;
                pokemoninball.expLimit = pokemoninball.expLimit + 1000;
                pokemoninball.hp += pokemoninball.ScalingHP;
                pokemoninball.cp += pokemoninball.ScalingCP;
                MessageBox.Show("You are now level " + pokemoninball.level.ToString()+"!");
              
            }
            else
            {
                MessageBox.Show("You don't have enough exp!");
            }
        }
    }

    public class Skill
    {
        public string SkillName;
        public string Skilldes;    // skill description
        public int SkillLevel;
        public ElementType SkillElementType;
        public bool ifevolved;
        public int Scaleskilldamage;
        public int baseskilldamage;
        public int damageCPpercent;
        public int damageHPpercent;

        public void skillevolve()
        {

            ifevolved = true;
            baseskilldamage = baseskilldamage * 15 / 10;
            Scaleskilldamage = Scaleskilldamage * 15 / 10;
            damageCPpercent = damageCPpercent + 25;
            damageHPpercent = damageHPpercent + 2;

        }

       
        public Skill(string pName, ElementType pType, int pSkillLevel, string pDescription, int pdamage, 
            int pscaledamage, int pdamageCPpercent, int pdamageHPpercent)
        {
            SkillName = pName;
            Skilldes = pDescription;
            SkillElementType = pType;
            SkillLevel = pSkillLevel;
            ifevolved = false;
            Scaleskilldamage = pscaledamage;
            baseskilldamage = pscaledamage;
            damageCPpercent = pdamageCPpercent;
            damageHPpercent = pdamageHPpercent;

        }
        public string describeskill(int pcp, int php)
        {
            int actualdamage = baseskilldamage + (SkillLevel - 1) * Scaleskilldamage + pcp * damageCPpercent / 100 + php * damageHPpercent / 100;
            string s = SkillName + ": Level " + SkillLevel.ToString();
            if (ifevolved == true)  s = s + "(EVOLVED: this skill can deal more damage)"; 
            s = s + "\n";
            s = s + "Type: " + SkillElementType.ToString() + "\n";
            s = s + Skilldes;
            s = s + "\nDeals " + baseskilldamage.ToString() + " (+" + Scaleskilldamage.ToString() + " per-level) (+" + damageCPpercent.ToString() + "% CP) (+" + damageHPpercent.ToString() + "% HP) = " + actualdamage.ToString() + " damage on the target.";
            return s;
        }

    }


    public class Pokemon
    {
        public string name;       // defining the name of pokemon
        public PokemonType mytype; // defining the type
        public int cp;            // defining the combat point
        public int hp;            // defining the health point
        public int exp;           // defining the experience
        public int level;         // defining the level
        public int expLimit; // defining the upper limit
        public Skill s1;          // defining skill_1
        public Skill s2;          // defining skill_2
        public int ScalingHP;     // defining the scaling rate
        public int ScalingCP;
        static Random myrnd = new Random();
        static Random myrnd2 = new Random();

        public Pokemon(int plevel, PokemonType type) //Wild Pokemon Constructor: lvl=1
        {
            name = "wild_" + type.typename;
            mytype = type;
            exp = 1000 * (plevel - 1);
            level = plevel;
            expLimit = 1000 + (plevel - 1) * 1000;
            hp = 1950 + myrnd.Next(1, 200) + (plevel - 1) * ScalingHP;
            cp = 80 + myrnd.Next(1, 10) + (plevel - 1) * ScalingCP;
            ScalingHP = 350 + myrnd.Next(1, 30);
            ScalingCP = 15 + myrnd.Next(1, 5);

            List<Skill> mypossibleskills = new List<Skill>(); // defining all possible skills for first skill
            for (int i = 0; i < GAMEdata.skilllist.Count; i++)
            {
                if ((GAMEdata.skilllist[i].SkillElementType == this.mytype.PokemonElementType) || (GAMEdata.skilllist[i].SkillElementType == ElementType.Normal))
                {
                    mypossibleskills.Add(GAMEdata.skilllist[i]);
                }
            }

            int firstindex = Pokemon.myrnd.Next(0, mypossibleskills.Count);
            s1 = mypossibleskills[firstindex];


            List<Skill> secondmypossibleskills = new List<Skill>(); // defining all possible skills for second skill
            if (s1.SkillElementType.ToString() == "Normal")
            {
                for (int j = 0; j < GAMEdata.skilllist.Count; j++)
                {
                    if (GAMEdata.skilllist[j].SkillElementType == this.mytype.PokemonElementType)
                    {
                        secondmypossibleskills.Add(GAMEdata.skilllist[j]);
                    }
                    else { }
                }
                int secondindex = Pokemon.myrnd2.Next(0, secondmypossibleskills.Count);
                s2 = mypossibleskills[secondindex];
            }
            else if (s1.SkillElementType == this.mytype.PokemonElementType)
            {
                for (int k = 0; k < GAMEdata.skilllist.Count; k++)
                {
                    if ((GAMEdata.skilllist[k] != s1 && GAMEdata.skilllist[k].SkillElementType == mytype.PokemonElementType) || GAMEdata.skilllist[k].SkillElementType == ElementType.Normal)
                    {
                        secondmypossibleskills.Add(GAMEdata.skilllist[k]);
                    }
                    else { }
                }
                int secondindex = myrnd.Next(0, secondmypossibleskills.Count);
                s2 = mypossibleskills[secondindex];
            }
            else { MessageBox.Show("there are bugs here!"); }


        }
            

        

        public Pokemon(string Iname, int l, PokemonType type) //NPC Constructor: no need for others because cp and hp are determined by subclasses
        {
            name = type.typename;
            mytype = type;
            this.exp = 0;
            this.level = l;
            //random hp and others

        }


    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            referencebox.Visibility = Visibility.Hidden;
            typingbox.Visibility = Visibility.Hidden;

            Typeblock1.Visibility=Visibility.Hidden;
            NameBlock1.Visibility=Visibility.Hidden;
            HPBlock1.Visibility=Visibility.Hidden;
            CPBlock1.Visibility=Visibility.Hidden;
            ExpBlock1.Visibility=Visibility.Hidden;
            EvolveBnt1.Visibility=Visibility.Hidden;
            LvlupBnt1.Visibility=Visibility.Hidden;
            CheckSkillBnt1.Visibility=Visibility.Hidden;

            Typeblock2.Visibility=Visibility.Hidden;
            NameBlock2.Visibility=Visibility.Hidden;
            HPBlock2.Visibility=Visibility.Hidden;
            CPBlock2.Visibility=Visibility.Hidden;
            ExpBlock2.Visibility=Visibility.Hidden;
            EvolveBnt2.Visibility=Visibility.Hidden;
            LvlupBnt2.Visibility=Visibility.Hidden;
            CheckSkillBnt2.Visibility=Visibility.Hidden;

            Typeblock3.Visibility=Visibility.Hidden;
            NameBlock3.Visibility=Visibility.Hidden;
            HPBlock3.Visibility=Visibility.Hidden;
            CPBlock3.Visibility=Visibility.Hidden;
            ExpBlock3.Visibility=Visibility.Hidden;
            EvolveBnt3.Visibility=Visibility.Hidden;
            LvlupBnt3.Visibility=Visibility.Hidden;
            CheckSkillBnt3.Visibility=Visibility.Hidden;

            ball1img.Visibility=Visibility.Hidden;
            ball2img.Visibility=Visibility.Hidden;
            ball3img.Visibility=Visibility.Hidden;

            bnt1.Visibility = Visibility.Hidden;
            bnt2.Visibility = Visibility.Hidden;
            bnt3.Visibility = Visibility.Hidden;
            bnt4.Visibility = Visibility.Hidden;
            StopCatchingBnt.Visibility = Visibility.Hidden;
            TipsBnt.Visibility = Visibility.Hidden;

            Initstr();
        }

        
        Random rndpokemontype = new Random();                     // defining the random map generator
        Random rndmap = new Random();                             // defining the random map generator
        Random rndpokemon = new Random();                         // defining the random pokemon generator
        int pokemon_generatetime;                                 // defining the pokemon generating time
        GameController currentGame;                              // defining the current GameController
        public Pokemon wildpokemon;                              // defining the wildpokemon

        System.Windows.Threading.DispatcherTimer PokemonTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer PokemonExpTimer = new System.Windows.Threading.DispatcherTimer();

        private void StartGameButton_Click(object sender, RoutedEventArgs e)  // Create the current game and start the game
        {
            if (currentGame == null)                             // Singleton
            {
                currentGame = new GameController();
                currentGame.Initialize();

            }

            StartGameButton.Visibility = Visibility.Hidden;
            bnt1.Visibility = Visibility.Visible;
            bnt2.Visibility = Visibility.Visible;
            bnt3.Visibility = Visibility.Visible;
            bnt4.Visibility = Visibility.Visible;
            StopCatchingBnt.Visibility = Visibility.Visible;
            TipsBnt.Visibility = Visibility.Visible;

            pokemon_generatetime = rndpokemon.Next(5, 10);
            PokemonTimer.Tick += PokemonTimer_Tick;
            PokemonTimer.Interval = TimeSpan.FromSeconds(1);
            PokemonTimer.Start();

            PokemonExpTimer.Tick += PokemonExpTimer_Tick;
            PokemonExpTimer.Interval = TimeSpan.FromSeconds(1);
            PokemonExpTimer.Start();

        }

        void PokemonTimer_Tick(object sender, EventArgs e)
        {
            if (pokemon_generatetime > 0)
            {
                pokemon_generatetime--;
            }
            else
            {
                PokemonTimer.Stop();
                pokemon_generatetime = rndpokemon.Next(5, 10);
                if (MessageBox.Show("You find a new pokemon, do you want to catch?", "Find new Pokemon",
               MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    //nothing happens
                    PokemonTimer.Start();
                }
                else
                {
                    //begin catching 
                    //implement catching here
                    wildpokemon = new Pokemon(1,currentGame.pokemonlist[rndpokemontype.Next(0, 5)]);
                    referencebox.Text = wildpokemon.mytype.typename + ": is a kind of monster with " + wildpokemon.mytype.PokemonElementType.ToString() + " power";
                    bnt1.Visibility = Visibility.Hidden;
                    bnt2.Visibility = Visibility.Hidden;
                    bnt3.Visibility = Visibility.Hidden;
                    bnt4.Visibility = Visibility.Hidden;
                    TipsBnt.Visibility = Visibility.Hidden;
                    StopCatchingBnt.Visibility = Visibility.Hidden;
                    referencebox.Visibility = Visibility.Visible;
                    typingbox.Visibility = Visibility.Visible;
                }
            }
        }

        void PokemonExpTimer_Tick(object sender, EventArgs e)
        {           
            Pokemon p1 = currentGame.myballs[0].pokemoninball;
            Pokemon p2 = currentGame.myballs[1].pokemoninball;
            Pokemon p3 = currentGame.myballs[2].pokemoninball;
            if (p1==null)
            {
                // do nothing
            }
            else if (p1.exp < p1.expLimit && p1 != null)
            {
                p1.exp += 100;
                int exp1 = int.Parse(ExpBox1.Text);
                exp1 += 100;
                ExpBox1.Text = exp1.ToString();
            }
            else { }

            if (p2==null)
            {
                //do nothing
            }
            else if (p2.exp < p2.expLimit && p2 != null)
            {
                p2.exp += 100;
                int exp2 = int.Parse(ExpBox2.Text);
                exp2 += 100;
                ExpBox2.Text = exp2.ToString();
            }
            else { }

            if (p3==null)
            {
                //do nothing
            }
            else if (p3.exp < p3.expLimit && p3 != null)
            {
                p3.exp += 100;
                int exp3 = int.Parse(ExpBox3.Text);
                exp3 += 100;
                ExpBox3.Text = exp3.ToString();
            }
            else { }
            
          
        }

        private void CheckSkillBntBall1_Click(object sender, RoutedEventArgs e)  // Check skills of the first pokemon
        {
            PokemonTimer.Stop();
            Pokemon p1=currentGame.myballs[0].pokemoninball;
            string str1 = p1.s1.describeskill(p1.cp, p1.hp);
            string str2 = p1.s2.describeskill(p1.cp, p1.hp);
            MessageBoxResult result= MessageBox.Show(str1+"\n\n"+str2,"Skills description",MessageBoxButton.OK);
            if (result==MessageBoxResult.OK)
            {
                PokemonTimer.Start();
            }
           
        }


        private void LevelupButtonBall1_Click(object sender, RoutedEventArgs e)     // Level up of first pokemon
        {
            currentGame.myballs[0].ballLvlup();
            int hp = int.Parse(HPBox1.Text);
            hp = currentGame.myballs[0].pokemoninball.hp;
            HPBox1.Text = hp.ToString();
            int cp = int.Parse(CPBox1.Text);
            cp = currentGame.myballs[0].pokemoninball.cp;
            CPBox1.Text = cp.ToString();
        } 

        private void EvolveButtonBall1_Click(object sender, RoutedEventArgs e)      // Evolve of first pokemon
        {
            currentGame.myballs[0].ballEvolve();
            Pokemon p1 = currentGame.myballs[0].pokemoninball;
            if (p1.mytype.typename=="Raichu")
            {
                ball1img.Source = new BitmapImage(new Uri("Image/Raichu.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (p1.mytype.typename=="Wartortle")
            {
                ball1img.Source = new BitmapImage(new Uri("Image/Wartortle.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (p1.mytype.typename == "Charmeleon")
            {
                ball1img.Source = new BitmapImage(new Uri("Image/Charmeleon.jpg", UriKind.RelativeOrAbsolute));
            }
            else { ball1img.Source = new BitmapImage(new Uri("Image/Dugtrio.jpg", UriKind.RelativeOrAbsolute)); }

        }

        private void CheckSkillBntBall2_Click(object sender, RoutedEventArgs e)  // Check skills of the second pokemon
        {

            PokemonTimer.Stop();
            Pokemon p2 = currentGame.myballs[1].pokemoninball;
            string str1 = p2.s1.describeskill(p2.cp, p2.hp);
            string str2 = p2.s2.describeskill(p2.cp, p2.hp);
            MessageBoxResult result = MessageBox.Show(str1 + "\n\n" + str2, "Skills description", MessageBoxButton.OK);
            if (result == MessageBoxResult.OK)
            {
                PokemonTimer.Start();
            }
        }

        private void LevelupButtonBall2_Click(object sender, RoutedEventArgs e)     // Level up of second pokemon
        {
            currentGame.myballs[1].ballLvlup();
            int hp = int.Parse(HPBox2.Text);
            hp = currentGame.myballs[1].pokemoninball.hp;
            HPBox2.Text = hp.ToString();
            int cp = int.Parse(CPBox2.Text);
            cp = currentGame.myballs[1].pokemoninball.cp;
            CPBox2.Text = cp.ToString();
        }

        private void EvolveButtonBall2_Click(object sender, RoutedEventArgs e)      // Evolve of  second pokemon
        {
            currentGame.myballs[1].ballEvolve();
            Pokemon p1 = currentGame.myballs[1].pokemoninball;
            if (p1.mytype.typename == "Raichu")
            {
                ball1img.Source = new BitmapImage(new Uri("Image/Raichu.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (p1.mytype.typename == "Wartortle")
            {
                ball1img.Source = new BitmapImage(new Uri("Image/Wartortle.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (p1.mytype.typename == "Charmeleon")
            {
                ball1img.Source = new BitmapImage(new Uri("Image/Charmeleon.jpg", UriKind.RelativeOrAbsolute));
            }
            else { ball1img.Source = new BitmapImage(new Uri("Image/Dugtrio.jpg", UriKind.RelativeOrAbsolute)); }
        }

        private void CheckSkillBntBall3_Click(object sender, RoutedEventArgs e)  // Check skills of the third pokemon
        {
            PokemonTimer.Stop();
            Pokemon p3 = currentGame.myballs[2].pokemoninball;
            string str1 = p3.s1.describeskill(p3.cp, p3.hp);
            string str2 = p3.s2.describeskill(p3.cp, p3.hp);
            MessageBoxResult result = MessageBox.Show(str1 + "\n\n" + str2, "Skills description", MessageBoxButton.OK);
            if (result == MessageBoxResult.OK)
            {
                PokemonTimer.Start();
            }

        }

        private void LevelupButtonBall3_Click(object sender, RoutedEventArgs e)     // Level up of third pokemon
        {
            currentGame.myballs[2].ballLvlup();
            int hp = int.Parse(HPBox3.Text);
            hp = currentGame.myballs[2].pokemoninball.hp;
            HPBox3.Text = hp.ToString();
            int cp = int.Parse(CPBox3.Text);
            cp = currentGame.myballs[2].pokemoninball.cp;
            CPBox3.Text = cp.ToString();
        }

        private void EvolveButtonBall3_Click(object sender, RoutedEventArgs e)      // Evolve of third pokemon
        {
            currentGame.myballs[2].ballEvolve();
            Pokemon p1 = currentGame.myballs[2].pokemoninball;
            if (p1.mytype.typename == "Raichu")
            {
                ball1img.Source = new BitmapImage(new Uri("Image/Raichu.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (p1.mytype.typename == "Wartortle")
            {
                ball1img.Source = new BitmapImage(new Uri("Image/Wartortle.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (p1.mytype.typename == "Charmeleon")
            {
                ball1img.Source = new BitmapImage(new Uri("Image/Charmeleon.jpg", UriKind.RelativeOrAbsolute));
            }
            else { ball1img.Source = new BitmapImage(new Uri("Image/Dugtrio.jpg", UriKind.RelativeOrAbsolute)); }
        }

        Random tiprnd = new Random();
        List<string> tipstring = new List<string>();
        public void Initstr()
        {
            tipstring.Add("Do you know? There are two types of skills:\nNormal attack (damage mostly depends on your max HP, not on element types);\nElemental Attack (damage mostly depends on your CP and element types).");
            tipstring.Add("The actual attack damage depends on the element types of the skills of the attacker and the target pokemon.\nWater cons Fire\nFire cons Ice\nIce cons Ground\nGround cons Electric\nElectric cons Water");
            tipstring.Add("Today is a sunny day! Go ahead and find your pokemon!");
            tipstring.Add("Different Pikachus can have different HP,CP and skill set.");
            tipstring.Add("You only have three pokemon balls, be careful to choose the pokemon you really want! If you don't want any one of them, you can drop it by adding new pokemon.");
            tipstring.Add("If you don't want to catch anymore pokemon, please click \"Stop Catching\" button");
        }

        private void CheckTips_Click(object sender, RoutedEventArgs e)
        {
            PokemonTimer.Stop();
            int i = tiprnd.Next(0, 6);
            MessageBoxResult result= MessageBox.Show(tipstring[i],"Tips",MessageBoxButton.OK);
            if (result==MessageBoxResult.OK)
            {
                PokemonTimer.Start();
            }
        }

        public Coordinate Currentplace = new Coordinate(6, 6, Cotype.Road);        //defining the current place cordination

        Image imgroad = new Image() { Source = new BitmapImage(new Uri("Image/" + "1.jpg", UriKind.Relative)) }; //defining the different image sources
        Image imgbush = new Image() { Source = new BitmapImage(new Uri("Image/" + "2.jpg", UriKind.Relative)) };
        Image imgbattle = new Image() { Source = new BitmapImage(new Uri("Image/" + "3.jpg", UriKind.Relative)) };
        Image imgplayer = new Image() { Source = new BitmapImage(new Uri("Image/" + "4.jpg", UriKind.Relative)) };

        public Coordinate[,] Mymap = new Coordinate[12, 12];
        private void gridMap_Loaded(object sender, RoutedEventArgs e)
        {

            Random rnd = new Random();

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    int imageNumber = rndmap.Next(1, 100);
                    Image img = new Image();
                    if (i == 6 && j == 6)
                    {
                        img.Source = new BitmapImage(new Uri("Image/" + "1.jpg", UriKind.Relative));
                        Mymap[i, j] = new Coordinate(i, j, Cotype.Road);
                    }
                    else if (imageNumber == 1)                              // for battle place
                    {
                        img.Source = new BitmapImage(new Uri("Image/" + "3.jpg", UriKind.Relative));
                        Mymap[i, j] = new Coordinate(i, j, Cotype.Gym);
                    }

                    else if (imageNumber > 20)                         // for road place
                    {
                        img.Source = new BitmapImage(new Uri("Image/" + "1.jpg", UriKind.Relative));
                        Mymap[i, j] = new Coordinate(i, j, Cotype.Road);
                    }
                    else
                    {
                        img.Source = new BitmapImage(new Uri("Image/" + "2.jpg", UriKind.Relative));  // for bush place
                        Mymap[i, j] = new Coordinate(i, j, Cotype.Bush);
                    }

                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, j);
                    gridMap.Children.Add(img);

                }
            }

            Grid.SetRow(imgplayer, 6);   // initializing the starting point of the player
            Grid.SetColumn(imgplayer, 6);
            gridMap.Children.Add(imgplayer);

        }

        private void bnt1_Click(object sender, RoutedEventArgs e)  // Upward operation
        {

            if (Currentplace.x == 0 || Mymap[Currentplace.x - 1, Currentplace.y].mytype == Cotype.Bush)
            {
                return;
            }

            else if (Mymap[Currentplace.x - 1, Currentplace.y].mytype == Cotype.Gym)
            {
                PokemonTimer.Stop();
                if (MessageBox.Show("You arrive at a gym, go fighting?", "Gym",
               MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    PokemonTimer.Start();
                }
                else
                {

                    //begin fight
                    //implement fight here
                    //remenber to let timer start after fight
                    PokemonTimer.Start();
                }
                return;
            }

            else
            {
                Grid.SetRow(imgplayer, Currentplace.x - 1);
                Grid.SetColumn(imgplayer, Currentplace.y);
                Currentplace = Mymap[Currentplace.x - 1, Currentplace.y];


            }

        }

        private void bnt2_Click(object sender, RoutedEventArgs e)  // Leftward operation
        {
            if (Currentplace.y == 0 || Mymap[Currentplace.x, Currentplace.y - 1].mytype == Cotype.Bush)
            {
                return;
            }

            else if (Mymap[Currentplace.x, Currentplace.y - 1].mytype == Cotype.Gym)
            {
                PokemonTimer.Stop();
                if (MessageBox.Show("You arrive at a gym, go fighting?", "Gym",
               MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    PokemonTimer.Start();
                }
                else
                {

                    //begin fight
                    //implement fight here
                    //remenber to let timer start after fight
                }
                return;
            }

            else
            {
                Grid.SetRow(imgplayer, Currentplace.x);
                Grid.SetColumn(imgplayer, Currentplace.y - 1);
                Currentplace = Mymap[Currentplace.x, Currentplace.y - 1];


            }
        }

        private void bnt3_Click(object sender, RoutedEventArgs e)        // Downward operation
        {
            if (Currentplace.x == 11 || Mymap[Currentplace.x + 1, Currentplace.y].mytype == Cotype.Bush)
            {
                return;
            }

            else if (Mymap[Currentplace.x + 1, Currentplace.y].mytype == Cotype.Gym)
            {
                PokemonTimer.Stop();
                if (MessageBox.Show("You arrive at a gym, go fighting?", "Gym",
               MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    PokemonTimer.Start();
                }
                else
                {

                    //begin fight
                    //implement fight here
                    //remenber to let timer start after fight
                }
            }

            else
            {
                Grid.SetRow(imgplayer, Currentplace.x + 1);
                Grid.SetColumn(imgplayer, Currentplace.y);
                Currentplace = Mymap[Currentplace.x + 1, Currentplace.y];


            }
        }

        private void bnt4_Click(object sender, RoutedEventArgs e)        // Rightward operation
        {
            if (Currentplace.y == 11 || Mymap[Currentplace.x, Currentplace.y + 1].mytype == Cotype.Bush)
            {
                return;
            }

            else if (Mymap[Currentplace.x, Currentplace.y + 1].mytype == Cotype.Gym)
            {
                PokemonTimer.Stop();
                if (MessageBox.Show("You arrive at a gym, go fighting?", "Gym",
               MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    PokemonTimer.Start();
                }
                else
                {

                    //begin fight
                    //implement fight here
                    //remenber to let timer start after fight
                }
                return;
            }

            else
            {
                Grid.SetRow(imgplayer, Currentplace.x);
                Grid.SetColumn(imgplayer, Currentplace.y + 1);
                Currentplace = Mymap[Currentplace.x, Currentplace.y + 1];


            }
        }

        private void typingbox_TextChanged(object sender, TextChangedEventArgs e) // Check if the typing text is right
        {
            if (typingbox.Text == wildpokemon.mytype.typename + ": is a kind of monster with " + wildpokemon.mytype.PokemonElementType.ToString() + " power")
            {
                typingbox.Text = "";
                if (MessageBox.Show("You get a Pokemon, go to check now?", "New Pokemon!",
              MessageBoxButton.YesNo) == MessageBoxResult.No)
                {

                    bnt1.Visibility = Visibility.Visible;
                    bnt2.Visibility = Visibility.Visible;
                    bnt3.Visibility = Visibility.Visible;
                    bnt4.Visibility = Visibility.Visible;
                    TipsBnt.Visibility = Visibility.Visible;
                    StopCatchingBnt.Visibility = Visibility.Visible;
                    typingbox.Visibility = Visibility.Hidden;
                    referencebox.Visibility = Visibility.Hidden;
                    pokemon_generatetime = rndpokemon.Next(5, 10);
                    PokemonTimer.Start();

                }
                else
                {
                    bnt1.Visibility = Visibility.Visible;
                    bnt2.Visibility = Visibility.Visible;
                    bnt3.Visibility = Visibility.Visible;
                    bnt4.Visibility = Visibility.Visible;
                    TipsBnt.Visibility = Visibility.Visible;
                    StopCatchingBnt.Visibility = Visibility.Visible;
                    typingbox.Visibility = Visibility.Hidden;
                    referencebox.Visibility = Visibility.Hidden;
                    pokemon_generatetime = rndpokemon.Next(5, 10);
                    

                  
                        if (currentGame.myballs[0].ifbusy == false)
                        {
                               currentGame.myballs[0].ifbusy = true;                       // put the caught pokemon into the vacant ball
                               currentGame.myballs[0].pokemoninball = wildpokemon;

                               Typeblock1.Visibility=Visibility.Visible;
                               NameBlock1.Visibility=Visibility.Visible;
                               HPBlock1.Visibility=Visibility.Visible;
                               CPBlock1.Visibility=Visibility.Visible;
                               ExpBlock1.Visibility=Visibility.Visible;
                               EvolveBnt1.Visibility=Visibility.Visible;
                               LvlupBnt1.Visibility=Visibility.Visible;
                               CheckSkillBnt1.Visibility=Visibility.Visible;

                               typebox1.Text=wildpokemon.mytype.PokemonElementType.ToString();
                               NameBox1.Text=wildpokemon.name;
                               HPBox1.Text=wildpokemon.hp.ToString();
                               CPBox1.Text=wildpokemon.cp.ToString();
                               ExpBox1.Text=wildpokemon.exp.ToString();

                               if (wildpokemon.mytype.typename=="Pikachu")                     // Stick the image of pokemon
                               {
                                   ball1img.Source = new BitmapImage(new Uri("Image/pikachu.jpg", UriKind.RelativeOrAbsolute));
                               }
                               else if (wildpokemon.mytype.typename=="Charmander")
                               { 
                                   ball1img.Source = new BitmapImage(new Uri("Image/charmander.png", UriKind.RelativeOrAbsolute));
                               }
                               else if (wildpokemon.mytype.typename == "Diglett")
                               {
                                   ball1img.Source = new BitmapImage(new Uri("Image/diglette.jpg", UriKind.RelativeOrAbsolute));
                               }
                               else if (wildpokemon.mytype.typename == "Lapras")
                               {
                                   ball1img.Source = new BitmapImage(new Uri("Image/lapras.jpg", UriKind.RelativeOrAbsolute));
                               }
                               else ball1img.Source = new BitmapImage(new Uri("Image/squirtle.jpg", UriKind.RelativeOrAbsolute));

                               ball1img.Visibility = Visibility.Visible;
                               wildpokemon = null;
                               PokemonTimer.Start();  // restart the timer
                            
                        }

                        else if (currentGame.myballs[1].ifbusy == false)
                        {
                            currentGame.myballs[1].ifbusy = true;                       // put the caught pokemon into the vacant ball
                            currentGame.myballs[1].pokemoninball = wildpokemon;

                               Typeblock2.Visibility=Visibility.Visible;
                               NameBlock2.Visibility=Visibility.Visible;
                               HPBlock2.Visibility=Visibility.Visible;
                               CPBlock2.Visibility=Visibility.Visible;
                               ExpBlock2.Visibility=Visibility.Visible;
                               EvolveBnt2.Visibility=Visibility.Visible;
                               LvlupBnt2.Visibility=Visibility.Visible;
                               CheckSkillBnt2.Visibility=Visibility.Visible;

                               typebox2.Text=wildpokemon.mytype.PokemonElementType.ToString();
                               NameBox2.Text=wildpokemon.name;
                               HPBox2.Text=wildpokemon.hp.ToString();
                               CPBox2.Text=wildpokemon.cp.ToString();
                               ExpBox2.Text=wildpokemon.exp.ToString();

                               if (wildpokemon.mytype.typename=="Pikachu")                     // Stick the image of pokemon
                               {
                                   ball2img.Source = new BitmapImage(new Uri("Image/pikachu.jpg", UriKind.RelativeOrAbsolute));
                               }
                               else if (wildpokemon.mytype.typename=="Charmander")
                               { 
                                   ball2img.Source = new BitmapImage(new Uri("Image/charmander.png", UriKind.RelativeOrAbsolute));
                               }
                               else if (wildpokemon.mytype.typename == "Diglett")
                               {
                                   ball2img.Source = new BitmapImage(new Uri("Image/diglette.jpg", UriKind.RelativeOrAbsolute));
                               }
                               else if (wildpokemon.mytype.typename == "Lapras")
                               {
                                   ball2img.Source = new BitmapImage(new Uri("Image/lapras.jpg", UriKind.RelativeOrAbsolute));
                               }
                               else ball2img.Source = new BitmapImage(new Uri("Image/squirtle.jpg", UriKind.RelativeOrAbsolute));

                               ball2img.Visibility = Visibility.Visible;
                               wildpokemon = null;
                               PokemonTimer.Start();  // restart the timer
                        }

                        else if (currentGame.myballs[2].ifbusy == false)
                        {
                            currentGame.myballs[2].ifbusy = true;                       // put the caught pokemon into the vacant ball
                            currentGame.myballs[2].pokemoninball = wildpokemon;

                            Typeblock3.Visibility = Visibility.Visible;
                            NameBlock3.Visibility = Visibility.Visible;
                            HPBlock3.Visibility = Visibility.Visible;
                            CPBlock3.Visibility = Visibility.Visible;
                            ExpBlock3.Visibility = Visibility.Visible;
                            EvolveBnt3.Visibility = Visibility.Visible;
                            LvlupBnt3.Visibility = Visibility.Visible;
                            CheckSkillBnt3.Visibility = Visibility.Visible;

                            typebox3.Text = wildpokemon.mytype.PokemonElementType.ToString();
                            NameBox3.Text = wildpokemon.name;
                            HPBox3.Text = wildpokemon.hp.ToString();
                            CPBox3.Text = wildpokemon.cp.ToString();
                            ExpBox3.Text = wildpokemon.exp.ToString();

                            if (wildpokemon.mytype.typename == "Pikachu")                     // Stick the image of pokemon
                            {
                                ball3img.Source = new BitmapImage(new Uri("Image/pikachu.jpg", UriKind.RelativeOrAbsolute));
                            }
                            else if (wildpokemon.mytype.typename == "Charmander")
                            {
                                ball3img.Source = new BitmapImage(new Uri("Image/charmander.png", UriKind.RelativeOrAbsolute));
                            }
                            else if (wildpokemon.mytype.typename == "Diglett")
                            {
                                ball3img.Source = new BitmapImage(new Uri("Image/diglette.jpg", UriKind.RelativeOrAbsolute));
                            }
                            else if (wildpokemon.mytype.typename == "Lapras")
                            {
                                ball3img.Source = new BitmapImage(new Uri("Image/lapras.jpg", UriKind.RelativeOrAbsolute));
                            }
                            else ball3img.Source = new BitmapImage(new Uri("Image/squirtle.jpg", UriKind.RelativeOrAbsolute));

                            ball3img.Visibility = Visibility.Visible;
                            wildpokemon = null;
                            PokemonTimer.Start();  // restart the timer
                        }
                        else
                        {
                            MessageBoxResult result = MessageBox.Show("All your three balls have pokemons inside, would you like to release a ball?", "Warning", MessageBoxButton.YesNo);
                            if (result==MessageBoxResult.Yes)
                            {
                                MessageBoxResult dropresult1= MessageBox.Show("Do you want to drop the first pokemon?", "Pokemon choice", MessageBoxButton.YesNo);
                                if (dropresult1==MessageBoxResult.Yes)
                                {
                                    currentGame.myballs[0].pokemoninball = wildpokemon;

                                    typebox1.Text = wildpokemon.mytype.PokemonElementType.ToString();
                                    NameBox1.Text = wildpokemon.name;
                                    HPBox1.Text = wildpokemon.hp.ToString();
                                    CPBox1.Text = wildpokemon.cp.ToString();
                                    ExpBox1.Text = wildpokemon.exp.ToString();

                                    if (wildpokemon.mytype.typename == "Pikachu")                     // Stick the image of pokemon
                                    {
                                        ball1img.Source = new BitmapImage(new Uri("Image/pikachu.jpg", UriKind.RelativeOrAbsolute));
                                    }
                                    else if (wildpokemon.mytype.typename == "Charmander")
                                    {
                                        ball1img.Source = new BitmapImage(new Uri("Image/charmander.png", UriKind.RelativeOrAbsolute));
                                    }
                                    else if (wildpokemon.mytype.typename == "Diglett")
                                    {
                                        ball1img.Source = new BitmapImage(new Uri("Image/diglette.jpg", UriKind.RelativeOrAbsolute));
                                    }
                                    else if (wildpokemon.mytype.typename == "Lapras")
                                    {
                                        ball1img.Source = new BitmapImage(new Uri("Image/lapras.jpg", UriKind.RelativeOrAbsolute));
                                    }
                                    else ball1img.Source = new BitmapImage(new Uri("Image/squirtle.jpg", UriKind.RelativeOrAbsolute));

                                    ball1img.Visibility = Visibility.Visible;
                                    wildpokemon = null;
                                    PokemonTimer.Start();  // restart the timer

                                }
                                else if (dropresult1 == MessageBoxResult.No)
                                {
                                    MessageBoxResult dropresult2 = MessageBox.Show("Do you want to drop the second pokemon?", "Pokemon choice", MessageBoxButton.YesNo);
                                    if (dropresult2==MessageBoxResult.Yes)
                                    {
                                         Typeblock2.Visibility=Visibility.Visible;
                                         NameBlock2.Visibility=Visibility.Visible;
                                         HPBlock2.Visibility=Visibility.Visible;
                                         CPBlock2.Visibility=Visibility.Visible;
                                         ExpBlock2.Visibility=Visibility.Visible;
                                         EvolveBnt2.Visibility=Visibility.Visible;
                                        LvlupBnt2.Visibility=Visibility.Visible;
                                         CheckSkillBnt2.Visibility=Visibility.Visible;

                                        typebox2.Text=wildpokemon.mytype.PokemonElementType.ToString();
                                        NameBox2.Text=wildpokemon.name;
                                        HPBox2.Text=wildpokemon.hp.ToString();
                                        CPBox2.Text=wildpokemon.cp.ToString();
                                        ExpBox2.Text=wildpokemon.exp.ToString();

                                        if (wildpokemon.mytype.typename=="Pikachu")                     // Stick the image of pokemon
                                         {
                                             ball2img.Source = new BitmapImage(new Uri("Image/pikachu.jpg", UriKind.RelativeOrAbsolute));
                                         }
                                        else if (wildpokemon.mytype.typename=="Charmander")
                                         { 
                                             ball2img.Source = new BitmapImage(new Uri("Image/charmander.png", UriKind.RelativeOrAbsolute));
                                         }
                                        else if (wildpokemon.mytype.typename == "Diglett")
                                         {
                                             ball2img.Source = new BitmapImage(new Uri("Image/diglette.jpg", UriKind.RelativeOrAbsolute));
                                         }
                                        else if (wildpokemon.mytype.typename == "Lapras")
                                         {
                                             ball2img.Source = new BitmapImage(new Uri("Image/lapras.jpg", UriKind.RelativeOrAbsolute));
                                         }
                                         else ball2img.Source = new BitmapImage(new Uri("Image/squirtle.jpg", UriKind.RelativeOrAbsolute));

                                        ball2img.Visibility = Visibility.Visible;
                                        wildpokemon = null;
                                        PokemonTimer.Start();  // restart the timer
                                      }
                                    else
                                    {
                                         MessageBoxResult dropresult3 = MessageBox.Show("Do you want to drop the third pokemon?", "Pokemon choice", MessageBoxButton.YesNo);
                                    if (dropresult3==MessageBoxResult.Yes)
                                    {
                                        currentGame.myballs[2].ifbusy = true;                       // put the caught pokemon into the vacant ball
                                        currentGame.myballs[2].pokemoninball = wildpokemon;

                                        Typeblock3.Visibility = Visibility.Visible;
                                        NameBlock3.Visibility = Visibility.Visible;
                                        HPBlock3.Visibility = Visibility.Visible;
                                        CPBlock3.Visibility = Visibility.Visible;
                                        ExpBlock3.Visibility = Visibility.Visible;
                                        EvolveBnt3.Visibility = Visibility.Visible;
                                        LvlupBnt3.Visibility = Visibility.Visible;
                                        CheckSkillBnt3.Visibility = Visibility.Visible;

                                        typebox3.Text = wildpokemon.mytype.PokemonElementType.ToString();
                                        NameBox3.Text = wildpokemon.name;
                                        HPBox3.Text = wildpokemon.hp.ToString();
                                        CPBox3.Text = wildpokemon.cp.ToString();
                                       ExpBox3.Text = wildpokemon.exp.ToString();

                                       if (wildpokemon.mytype.typename == "Pikachu")                     // Stick the image of pokemon
                                       {
                                          ball3img.Source = new BitmapImage(new Uri("Image/pikachu.jpg", UriKind.RelativeOrAbsolute));
                                       }
                                         else if (wildpokemon.mytype.typename == "Charmander")
                                       {
                                         ball3img.Source = new BitmapImage(new Uri("Image/charmander.png", UriKind.RelativeOrAbsolute));
                                       }
                                      else if (wildpokemon.mytype.typename == "Diglett")
                                      {
                                         ball3img.Source = new BitmapImage(new Uri("Image/diglette.jpg", UriKind.RelativeOrAbsolute));
                                      }
                                         else if (wildpokemon.mytype.typename == "Lapras")
                                      {
                                         ball3img.Source = new BitmapImage(new Uri("Image/lapras.jpg", UriKind.RelativeOrAbsolute));
                                      }
                                         else ball3img.Source = new BitmapImage(new Uri("Image/squirtle.jpg", UriKind.RelativeOrAbsolute));

                                         ball3img.Visibility = Visibility.Visible;
                                         wildpokemon = null;
                                         PokemonTimer.Start();  // restart the timer
                                      }
                                }
                               
                                }
	
	
                            }
                            else
                            {
                                MessageBox.Show("What a pity! You just missed a precious pokemon!");
                                wildpokemon = null;
                                PokemonTimer.Start();
                            }
                        }   

                    }

                   
                    // implement pokemon check here
                    // remember to let timer start after check
                }
            }

        private void StopCatchingBnt_Click(object sender, RoutedEventArgs e)
        {
            if (StopCatchingBnt.Content.ToString()=="Stop Catching")
            {
                StopCatchingBnt.Content = "Start Catching";
                PokemonTimer.Stop();
            }
            else
            {
                StopCatchingBnt.Content = "Stop Catching";
                PokemonTimer.Start();
            }
        }

       
             
       
    }

    public enum Cotype { Bush, Road, Gym };
    public class Coordinate
    {
        public int x;
        public int y;
        public Cotype mytype;
        public Coordinate(int x, int y, Cotype ptype)
        {

            mytype = ptype;
            this.x = x;
            this.y = y;
        }
    }
   


}

