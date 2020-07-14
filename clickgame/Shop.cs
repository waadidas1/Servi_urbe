using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servi_urbe
{
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
            LoadPlayerDataOnScreen();

        }
        #region ShopItemTypes
        static RespectShopItems.RespectShopItemType house = new House();
        static RespectShopItems.RespectShopItemType car = new Car();
        static RespectShopItems.RespectShopItemType bike = new Bike();
        static RespectShopItems.RespectShopItemType prestige = new PrestigeObject();
        #endregion
        #region ShopItems
        static RespectShopItems House1 = new RespectShopItems("Müllcontainer", house, 500, 5, 0);
        static RespectShopItems House2 = new RespectShopItems("Ghetto Wohnung", house, 100, 10, 0);
        static RespectShopItems House3 = new RespectShopItems("Bruchbude", house, 100, 20, 0);
        static RespectShopItems House4 = new RespectShopItems("Altbau Haus", house, 100, 40, 0);
        static RespectShopItems House5 = new RespectShopItems("Südländischer Traum", house, 100, 80, 0);
        static RespectShopItems House6 = new RespectShopItems("Einfamilienhaus", house, 100, 160, 0);
        static RespectShopItems House7 = new RespectShopItems("Großes Einfamilienhaus", house, 100, 320, 0);
        static RespectShopItems House8 = new RespectShopItems("Einfamilien Villa", house, 100, 640, 0);
        static RespectShopItems House9 = new RespectShopItems("Große Villa", house, 100, 1280, 0);
        static RespectShopItems House10 = new RespectShopItems("Riesen VIlla", house, 100, 2560, 0);
        static RespectShopItems Bike1 = new RespectShopItems("BMX", bike, 500, 5, 0);
        static RespectShopItems Bike2 = new RespectShopItems("Mountainbike", bike, 100, 10, 0);
        static RespectShopItems Bike3 = new RespectShopItems("Roller", bike, 100, 20, 0);
        static RespectShopItems Bike4 = new RespectShopItems("125er Offroad Motorrad", bike, 100, 40, 0);
        static RespectShopItems Bike5 = new RespectShopItems("125er Sport Motorrad", bike, 100, 80, 0);
        static RespectShopItems Bike6 = new RespectShopItems("Sport Motorrad", bike, 100, 160, 0);
        static RespectShopItems Bike7 = new RespectShopItems("chopper", bike, 100, 320, 0);
        static RespectShopItems Bike8 = new RespectShopItems("Reise Motorrad", bike, 100, 640, 0);
        static RespectShopItems Bike9 = new RespectShopItems("Renn Motorrad", bike, 100, 1280, 0);
        static RespectShopItems Bike10 = new RespectShopItems("Ultrarace Motorrad", bike, 100, 2560, 0);
        static RespectShopItems Car1 = new RespectShopItems("Schrottmühle", car, 1000, 5, 0);
        static RespectShopItems Car2 = new RespectShopItems("Ersatzteillager", car, 100, 10, 0);
        static RespectShopItems Car3 = new RespectShopItems("Anfänger Auto", car, 100, 20, 0);
        static RespectShopItems Car4 = new RespectShopItems("Oldtimer", car, 100, 40, 0);
        static RespectShopItems Car5 = new RespectShopItems("Familienkutsche", car, 100, 80, 0);
        static RespectShopItems Car6 = new RespectShopItems("Sportwagen", car, 100, 160, 0);
        static RespectShopItems Car7 = new RespectShopItems("V8 Sportwagen", car, 100, 320, 0);
        static RespectShopItems Car8 = new RespectShopItems("Supersportwagen", car, 100, 640, 0);
        static RespectShopItems Car9 = new RespectShopItems("V10 Supersportwagen", car, 100, 1280, 0);
        static RespectShopItems Car10 = new RespectShopItems("Ultrasportwagen", car, 100, 2560, 0);
        static RespectShopItems Prestige1 = new RespectShopItems("Zeitungsstand", prestige, 3000, 5, 0);
        static RespectShopItems Prestige2 = new RespectShopItems("Biogasanlage", prestige, 100, 10, 0);
        static RespectShopItems Prestige3 = new RespectShopItems("Mexicanischer Imbis", prestige, 100, 20, 0);
        static RespectShopItems Prestige4 = new RespectShopItems("Taco Imbis", prestige, 100, 40, 0);
        static RespectShopItems Prestige5 = new RespectShopItems("Italienisches Restaurant", prestige, 100, 80, 0);
        static RespectShopItems Prestige6 = new RespectShopItems("Musikladen", prestige, 100, 160, 0);
        static RespectShopItems Prestige7 = new RespectShopItems("Einkaufszentrum", prestige, 100, 320, 0);
        static RespectShopItems Prestige8 = new RespectShopItems("Fernsehsender", prestige, 100, 640, 0);
        static RespectShopItems Prestige9 = new RespectShopItems("Bank", prestige, 100, 1280, 0);
        static RespectShopItems Prestige10 = new RespectShopItems("Waffenladen", prestige, 100, 2560, 0);
        #endregion
        private void Shop_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.IsShopOpen = false;
            Game.IsFactionWindowOpen = false;
        }

        private void LoadPlayerDataOnScreen()
        {
            BoughtItemsGrid.DataSource = null;
            BoughtItemsGrid.DataSource = Player.BoughtRespectShopitems;
            MoneyLabel.Text = Player.Money.ToString() + "$";
            RespectLabel.Text = Player.Respect.ToString();
        }

        #region HouseEvents
        private void HouseSlot1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {House1.Name} wirklich verkaufen? Du bekommst dafür {House1.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                
                if(result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(House1);
                    LoadPlayerDataOnScreen();
                }
                
            }else if(e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{House1.Name} \n Preis: {House1.Price}$ \n Respektbonus: {House1.RespectBonus} \n","Kaufen?", MessageBoxButtons.YesNo , MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                
                if(result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(House1);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void HouseSlot2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {House2.Name} wirklich verkaufen? Du bekommst dafür {House2.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(House2);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{House2.Name} \n Preis: {House2.Price}$ \n Respektbonus: {House2.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(House2);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void HouseSlot3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {House3.Name} wirklich verkaufen? Du bekommst dafür {House3.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(House3);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{House3.Name} \n Preis: {House3.Price}$ \n Respektbonus: {House3.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(House3);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void HouseSlot4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {House4.Name} wirklich verkaufen? Du bekommst dafür {House4.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(House4);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{House4.Name} \n Preis: {House4.Price}$ \n Respektbonus: {House4.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(House4);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void HouseSlot5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {House5.Name} wirklich verkaufen? Du bekommst dafür {House5.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(House5);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{House5.Name} \n Preis: {House5.Price}$ \n Respektbonus: {House5.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(House5);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void HouseSlot6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {House6.Name} wirklich verkaufen? Du bekommst dafür {House6.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(House6);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{House6.Name} \n Preis: {House6.Price}$ \n Respektbonus: {House6.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(House6);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void HouseSlot7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {House7.Name} wirklich verkaufen? Du bekommst dafür {House7.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(House7);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{House7.Name} \n Preis: {House7.Price}$ \n Respektbonus: {House7.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(House7);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void HouseSlot8_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {House8.Name} wirklich verkaufen? Du bekommst dafür {House8.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(House8);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{House8.Name} \n Preis: {House8.Price}$ \n Respektbonus: {House8.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(House8);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void HouseSlot9_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {House9.Name} wirklich verkaufen? Du bekommst dafür {House9.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(House9);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{House9.Name} \n Preis: {House9.Price}$ \n Respektbonus: {House9.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(House9);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void HouseSlot10_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {House10.Name} wirklich verkaufen? Du bekommst dafür {House10.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(House10);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{House10.Name} \n Preis: {House10.Price}$ \n Respektbonus: {House10.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(House10);
                    LoadPlayerDataOnScreen();
                }
            }
        }
        #endregion
        #region BikeEvents
        private void BikeSlot1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Bike1.Name} wirklich verkaufen? Du bekommst dafür {Bike1.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Bike1);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Bike1.Name} \n Preis: {Bike1.Price}$ \n Respektbonus: {Bike1.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Bike1);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void BikeSlot2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Bike2.Name} wirklich verkaufen? Du bekommst dafür {Bike2.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Bike2);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Bike2.Name} \n Preis: {Bike2.Price}$ \n Respektbonus: {Bike2.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Bike2);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void BikeSlot3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Bike3.Name} wirklich verkaufen? Du bekommst dafür {Bike3.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Bike3);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Bike3.Name} \n Preis: {Bike3.Price}$ \n Respektbonus: {Bike3.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Bike3);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void BikeSlot4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Bike4.Name} wirklich verkaufen? Du bekommst dafür {Bike4.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Bike4);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Bike4.Name} \n Preis: {Bike4.Price}$ \n Respektbonus: {Bike4.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Bike4);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void BikeSlot5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Bike5.Name} wirklich verkaufen? Du bekommst dafür {Bike5.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Bike5);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Bike5.Name} \n Preis: {Bike5.Price}$ \n Respektbonus: {Bike5.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Bike5);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void BikeSlot6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Bike6.Name} wirklich verkaufen? Du bekommst dafür {Bike6.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Bike6);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Bike6.Name} \n Preis: {Bike6.Price}$ \n Respektbonus: {Bike6.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Bike6);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void BikeSlot7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Bike7.Name} wirklich verkaufen? Du bekommst dafür {Bike7.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Bike7);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Bike7.Name} \n Preis: {Bike7.Price}$ \n Respektbonus: {Bike7.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Bike7);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void BikeSlot8_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Bike8.Name} wirklich verkaufen? Du bekommst dafür {Bike8.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Bike8);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Bike8.Name} \n Preis: {Bike8.Price}$ \n Respektbonus: {Bike8.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Bike8);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void BikeSlot9_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Bike9.Name} wirklich verkaufen? Du bekommst dafür {Bike9.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Bike9);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Bike9.Name} \n Preis: {Bike9.Price}$ \n Respektbonus: {Bike9.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Bike9);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void BikeSlot10_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Bike10.Name} wirklich verkaufen? Du bekommst dafür {Bike10.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Bike10);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Bike10.Name} \n Preis: {Bike10.Price}$ \n Respektbonus: {Bike10.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Bike10);
                    LoadPlayerDataOnScreen();
                }
            }
        }
        #endregion
        #region CarEvents
        private void CarSlot1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Car1.Name} wirklich verkaufen? Du bekommst dafür {Car1.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Car1);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Car1.Name} \n Preis: {Car1.Price}$ \n Respektbonus: {Car1.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Car1);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void CarSlot2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Car2.Name} wirklich verkaufen? Du bekommst dafür {Car2.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Car2);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Car2.Name} \n Preis: {Car2.Price}$ \n Respektbonus: {Car2.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Car2);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void CarSlot3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Car3.Name} wirklich verkaufen? Du bekommst dafür {Car3.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Car3);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Car3.Name} \n Preis: {Car3.Price}$ \n Respektbonus: {Car3.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Car3);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void CarSlot4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Car4.Name} wirklich verkaufen? Du bekommst dafür {Car4.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Car4);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Car4.Name} \n Preis: {Car4.Price}$ \n Respektbonus: {Car4.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Car4);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void CarSlot5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Car5.Name} wirklich verkaufen? Du bekommst dafür {Car5.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Car5);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Car5.Name} \n Preis: {Car5.Price}$ \n Respektbonus: {Car5.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Car5);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void CarSlot6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Car6.Name} wirklich verkaufen? Du bekommst dafür {Car6.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Car6);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Car6.Name} \n Preis: {Car6.Price}$ \n Respektbonus: {Car6.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Car6);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void CarSlot7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Car7.Name} wirklich verkaufen? Du bekommst dafür {Car7.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Car7);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Car7.Name} \n Preis: {Car7.Price}$ \n Respektbonus: {Car7.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Car7);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void CarSlot8_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Car8.Name} wirklich verkaufen? Du bekommst dafür {Car8.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Car8);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Car8.Name} \n Preis: {Car8.Price}$ \n Respektbonus: {Car8.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Car8);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void CarSlot9_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Car9.Name} wirklich verkaufen? Du bekommst dafür {Car9.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Car9);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Car9.Name} \n Preis: {Car9.Price}$ \n Respektbonus: {Car9.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Car9);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void CarSlot10_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Car10.Name} wirklich verkaufen? Du bekommst dafür {Car10.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Car10);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Car10.Name} \n Preis: {Car10.Price}$ \n Respektbonus: {Car10.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Car10);
                    LoadPlayerDataOnScreen();
                }
            }
        }
        #endregion
        #region PrestigeEvents
        private void PrestigeSlot1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Prestige1.Name} wirklich verkaufen? Du bekommst dafür {Prestige1.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Prestige1);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Prestige1.Name} \n Preis: {Prestige1.Price}$ \n Respektbonus: {Prestige1.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Prestige1);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void PrestigeSlot2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Prestige2.Name} wirklich verkaufen? Du bekommst dafür {Prestige2.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Prestige2);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Prestige2.Name} \n Preis: {Prestige2.Price}$ \n Respektbonus: {Prestige2.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Prestige2);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void PrestigeSlot3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Prestige3.Name} wirklich verkaufen? Du bekommst dafür {Prestige3.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Prestige3);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Prestige3.Name} \n Preis: {Prestige3.Price}$ \n Respektbonus: {Prestige3.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Prestige3);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void PrestigeSlot4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Prestige4.Name} wirklich verkaufen? Du bekommst dafür {Prestige4.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Prestige4);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Prestige4.Name} \n Preis: {Prestige4.Price}$ \n Respektbonus: {Prestige4.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Prestige4);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void PrestigeSlot5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Prestige5.Name} wirklich verkaufen? Du bekommst dafür {Prestige5.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Prestige5);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Prestige5.Name} \n Preis: {Prestige5.Price}$ \n Respektbonus: {Prestige5.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Prestige5);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void PrestigeSlot6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Prestige6.Name} wirklich verkaufen? Du bekommst dafür {Prestige6.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Prestige6);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Prestige6.Name} \n Preis: {Prestige6.Price}$ \n Respektbonus: {Prestige6.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Prestige6);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void PrestigeSlot7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Prestige7.Name} wirklich verkaufen? Du bekommst dafür {Prestige7.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Prestige7);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Prestige7.Name} \n Preis: {Prestige7.Price}$ \n Respektbonus: {Prestige7.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Prestige7);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void PrestigeSlot8_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Prestige8.Name} wirklich verkaufen? Du bekommst dafür {Prestige8.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Prestige8);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Prestige8.Name} \n Preis: {Prestige8.Price}$ \n Respektbonus: {Prestige8.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Prestige8);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void PrestigeSlot9_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Prestige9.Name} wirklich verkaufen? Du bekommst dafür {Prestige9.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Prestige9);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Prestige9.Name} \n Preis: {Prestige9.Price}$ \n Respektbonus: {Prestige9.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Prestige9);
                    LoadPlayerDataOnScreen();
                }
            }
        }

        private void PrestigeSlot10_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Möchtest du {Prestige10.Name} wirklich verkaufen? Du bekommst dafür {Prestige10.SellValue}$ zurück.", "Verkaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.SellRespectShopitem(Prestige10);
                    LoadPlayerDataOnScreen();
                }

            }
            else if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"{Prestige10.Name} \n Preis: {Prestige10.Price}$ \n Respektbonus: {Prestige10.RespectBonus} \n", "Kaufen?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    RespectShopItems.BuyRespectShopitem(Prestige10);
                    LoadPlayerDataOnScreen();
                }
            }
        }
        #endregion
    }
}
