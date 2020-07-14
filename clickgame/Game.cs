using Servi_urbe.Properties;
using System.Drawing;
using System.Media;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Servi_urbe
{
    
    // TODO: 3D Map und verschiedene Maps mit if(map.picture == bla bla)( ich brauch dann ne neue Statische methode getMapObject pro map eine)
    // außerdem brauch ich dann auf jeder Map Pfeile zum Laufen :) 
    /*
         
        



      

       

         Level
        pro level gibts ein Multiplikatorwert der dann Geldbonus bestimmt somit hat Geldbonus A n Sinn und B wird es nicht zu viel geld auf einmal geben (sollte aber auch so schnell voran gehen, dass man irgendwann ganz sicher die Letzten Gegenstände erreichen kann.
        Sport muss mehr leben als der Job kosten

        Levelup system hinzufügen :D ( Klasse für Level erstellen wobei jedes level ne Unterklasse bekommt und über Eigenschaften wie min exp, max exp und geldbonus besitzt)
        Preise von restaurant, Sportplatz und Krankenhaus werden pro level n bisschen teurer (nicht viel)

        neue Methode buy useable item (keine neue shopklasse das is Schwachsinn)

        

        
    */
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            LoadPlayerDataOnScreen();
        }
        Player _ = new Player(100, 0, 100, 100, 1, 100, 0); // Faulheit siegt
        
        public static bool IsShopOpen { get; set; }
        public static bool IsFactionWindowOpen { get; set; }

        public void LoadPlayerDataOnScreen()
        {
           
           LebensLabel.Text = Player.Lifepoints.ToString();
           LebensBar.Value = Player.Lifepoints;
            LebensBar.Maximum = Player.MaximumLifepoints;
            MoneyLabel.Text = Player.Money.ToString() + "$";
           HungerLabel.Text = Player.Hungryness.ToString();
           HungerBar.Value = Player.Hungryness;
           SpaßLabel.Text = Player.Fun.ToString();
           SpaßBar.Value = Player.Fun;
           ErfahrungspunkteLabel.Text = Player.Experience.ToString();
           ErfahrungspunkteBar.Value = Player.Experience;
           LevelLabel.Text = Player.Level.ToString();
           RespectLabel.Text = Player.Respect.ToString();
           
        }
        //

        private void Map_Click(object sender, MouseEventArgs e)
        {
            // label2.Text = e.X.ToString();  um neue MapObjekte erstellen zu können
            //label4.Text = e.Y.ToString();           ''
            if (Player.Lifepoints < 1)
            {
                MessageBox.Show($"Du bist tot. Um neu zu beginnen, musst du das Programm neustarten. du hattest {Player.Money}$");
                Player.Money = 0;
                LoadPlayerDataOnScreen();
            }
            
                MapObjects.GetMapObject(e.X, e.Y);
                LoadPlayerDataOnScreen();
            
        }

        private void OpenShopButton_Click(object sender, System.EventArgs e)
        {
            Shop shop = new Shop();
            
            shop.Show();
            OpenShopButton.Enabled = false;
            IsShopOpen = true;
            IsFactionWindowOpen  = true;
            FactionButton.Enabled = false;
            
        }

        private void Map_MouseEnter(object sender, System.EventArgs e)
        {
            LoadPlayerDataOnScreen();
            if(IsShopOpen == false && IsFactionWindowOpen == false)
            {
                OpenShopButton.Enabled = true;
                FactionButton.Enabled = true;
            }
          

        }

        private void FactionButton_Click(object sender, System.EventArgs e)
        {
            FactionWindow faction = new FactionWindow();
            faction.Show();
            FactionButton.Enabled = false;
            IsFactionWindowOpen = true;
            IsShopOpen = true;
            OpenShopButton.Enabled = false;
           
        }
    }
}
