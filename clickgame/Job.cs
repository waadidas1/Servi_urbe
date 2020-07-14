using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace Servi_urbe
{
    class Job : MapObjects
    {
        SoundPlayer sound = new SoundPlayer(Properties.Resources.JobSound);
        public static int JobLebensPrice { get; set; }
        public static int JobHungerPrice { get; set; }
        public static int JobSpaßPrice { get; set; }
        public static int Verdienst { get; set; }
        
        public Job()
        {
            JobLebensPrice = 10;
            JobHungerPrice = 20;
            JobSpaßPrice = 15;
            Verdienst = 1 * Player.Fun / 10 * Player.Level + Player.Respect;

        }

        public static void OnJobClick()
        {
            Job job = new Job();
            job.JobLogic();
        }
        
        private void JobLogic()
        {
            if (Player.Lifepoints >= JobLebensPrice && Player.Hungryness >= JobHungerPrice)
            {
                sound.Play();
                Player.Money += Verdienst;
                Player.Lifepoints -= JobLebensPrice;
                Player.Hungryness -= JobHungerPrice;

                Player.Experience += 1;
                Player.IsLevelUp();
                if (Player.Fun >= JobSpaßPrice)
                {
                    Player.Fun -= JobSpaßPrice;

                }
                else
                {
                    Player.Fun = 0;
                }

            }

        }
    }
}
