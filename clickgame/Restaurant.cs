using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Servi_urbe
{
    class Restaurant : MapObjects
    {
        public static int RestaurantPrice { get; set; }

        public Restaurant()
        {
            RestaurantPrice = 10;
        }
        public static SoundPlayer SoundPlayer = new SoundPlayer(Properties.Resources.eat);
        public static void OnRestaurantClick()
        {
           Restaurant restaurant = new Restaurant();
            restaurant.RestaurantLogic();
        }
        private void RestaurantLogic()
        {
            if (Player.Money >= RestaurantPrice && Player.Hungryness < 100)
            {
                Player.Money -= RestaurantPrice;
                Player.Hungryness = 100;
                SoundPlayer.Play();
            }

        }
    }
}
