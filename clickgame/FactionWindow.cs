using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servi_urbe
{
    public partial class FactionWindow : Form
    {
        public FactionWindow()
        {
            InitializeComponent();
        }
        private void LoadDatashit()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Player.Factions;
            DebugLabel.Text = Player.Factions.Count.ToString();
        }
        Factions factionA = new FactionA();
        Factions factionB = new FactionB();
        Factions factionC = new FactionC();
        private void FactionABox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DialogResult  result = MessageBox.Show($"Name: {factionA.Name} \n Bonus: {factionA.Bonus} \n willst du dieser Gruppe beitreten?", "Beitreten?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    FactionSystem.JoinFaction(factionA);
                    LoadDatashit();
                }
            }else if(e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Name: {factionA.Name} \n Bonus: {factionA.Bonus} \n willst du diese Gruppe verlassen?", "Verlassen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    FactionSystem.LeaveFaction(factionA);
                    LoadDatashit();
                }
            }
        }

        private void FactionBBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"Name: {factionB.Name} \n Bonus: {factionB.Bonus} \n willst du dieser Gruppe beitreten?", "Beitreten?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    FactionSystem.JoinFaction(factionB);
                    LoadDatashit();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Name: {factionB.Name} \n Bonus: {factionB.Bonus} \n willst du diese Gruppe verlassen?", "Verlassen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    FactionSystem.LeaveFaction(factionB);
                    LoadDatashit();
                }
            }
        }

        private void FactionCBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DialogResult result = MessageBox.Show($"Name: {factionC.Name} \n Bonus: {factionC.Bonus} \n willst du dieser Gruppe beitreten?", "Beitreten?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    FactionSystem.JoinFaction(factionC);
                    LoadDatashit();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show($"Name: {factionC.Name} \n Bonus: {factionC.Bonus} \n willst du diese Gruppe verlassen?", "Verlassen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    FactionSystem.LeaveFaction(factionC);
                    LoadDatashit();
                }
            }
        }

        private void FactionWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Game.IsFactionWindowOpen = false;
            Game.IsShopOpen = false;
        }
    }
}
