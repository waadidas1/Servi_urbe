using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Servi_urbe
{
    class Hospital : MapObjects
    {
        public static int HospitalPrice { get; set; }

        public Hospital()
        {

            HospitalPrice = 10;



        }
        SoundPlayer sound = new SoundPlayer(Properties.Resources.HospitalSound);
        public static void OnHospitalClick()
        {
            Hospital hospital = new Hospital();
            hospital.HospitalLogic();
        }
        private  void HospitalLogic()
        {
            if (Player.Lifepoints < 100)
            {
                if (Player.Money > HospitalPrice || Player.Money == HospitalPrice)
                {
                    Player.Lifepoints = Player.MaximumLifepoints;
                    Player.Money -= 10;
                    sound.Play();
                }
                else
                {
                   MessageBox.Show("Du hast nicht genug Geld");
                }
            }
            else
            {
                MessageBox.Show("Du hast bereits volles Leben");
            }
        }
        
    }
}

