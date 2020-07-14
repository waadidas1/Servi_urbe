using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Servi_urbe
{
    class Player
    {
        public static int Lifepoints { get; set; }
        public static int MaximumLifepoints { get; set; }
        public static int Experience { get; set; }
        public static int Hungryness { get; set; }
        public static int Money { get; set; }
        public static int Level { get; set; }
        public static int Fun { get; set; }
        public static int Respect { get; set; }
        public static List<RespectShopItems> BoughtRespectShopitems = new List<RespectShopItems>();
        public static List<Factions> Factions = new List<Factions>();
        
        

        public Player(int lifepoints, int experience, int hungryness, int money, int level, int fun, int respect)
        {
            Lifepoints = lifepoints;
            Experience = experience;
            Hungryness = hungryness;
            Money = money;
            Level = level;
            Fun = fun;
            Respect = respect;
           MaximumLifepoints = 100;
        }
        public static void IsLevelUp()
        {
            if(Experience > 99)
            {
                Level++;
                Experience -= Experience;
            }
        }

    }
}
