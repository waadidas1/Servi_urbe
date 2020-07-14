using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Servi_urbe
{
    class Sport : MapObjects
    {
        SoundPlayer sound = new SoundPlayer(Properties.Resources.SportsSound);
       public static int SportPrice { get; set; }
       public static int SportHungerPrice { get; set; }
       public static int SportLifePrice { get; set; }

        public Sport()
        {

            SportPrice = 10;
            SportHungerPrice = 10;
            SportLifePrice = 10;

        }

        public static void OnSportClick()
        {
            Sport sport = new Sport();
            sport.SportplatzLogic();
        }
        private void SportplatzLogic()
        {
            if (Player.Money >= SportPrice && Player.Lifepoints >= SportLifePrice && Player.Hungryness >= SportHungerPrice && Player.Fun < 100)
            {
                Player.Money -= SportPrice;
                Player.Hungryness -= SportHungerPrice;
                Player.Lifepoints -= SportLifePrice;
                Player.Fun = 100;
                sound.Play();
            }

        }
    }
}
