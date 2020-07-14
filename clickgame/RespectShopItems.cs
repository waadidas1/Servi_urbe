using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servi_urbe
{
    class RespectShopItems
    {
       
        
        public string Name { get;}
        public int Price { get;}
        public int RespectBonus { get;}
        public int MoneyBonus { get;}
        public int SellValue { get;}
        public RespectShopItemType Type { get; }

        
        public RespectShopItems(string name, RespectShopItemType type, int price, int respectsbonus,int moneybonus)
        {
            Name = name;
            Type = type;
            Price = price;
            RespectBonus = respectsbonus;
            MoneyBonus = moneybonus;
            SellValue = price / 100 * 20; 
        }

        public static void  BuyRespectShopitem(RespectShopItems item)
        {
            if (IsRespectShopitemBought(item) == false)
            { 
                if (IsRespectShopItemSameType(item) == false)
                {
                    if (Player.Money >= item.Price)
                    {
                        Player.Money -= item.Price;
                        Player.Respect += item.RespectBonus;
                        Player.BoughtRespectShopitems.Add(item);
                    }
                    else
                    {
                        MessageBox.Show($"Du kannst dir diesen Gegenstand {item.Name} nicht leisten.");
                    }
                }
                else
                {
                     MessageBox.Show("Du kannst nur ein Item eines Typs besitzen.");
                }
            }
            else
            {
                MessageBox.Show($"Du besitzt bereits dieses Item: {item.Name}.");
            }
           
        }

        public static void SellRespectShopitem(RespectShopItems item)
        {
            if(IsRespectShopitemBought(item) == true)
            {
                Player.Money += item.SellValue;
                Player.Respect -= item.RespectBonus;
                Player.BoughtRespectShopitems.Remove(item);
            }
            else
            {
                MessageBox.Show($"Du besitzt {item.Name} nicht.");
            }
        }
        public static bool IsRespectShopitemBought(RespectShopItems item)
        {
            foreach(RespectShopItems items in Player.BoughtRespectShopitems)
            {
                if(items == item)
                {
                    return true;
                }
                
            }
            return false;

            
        }
        public static bool IsRespectShopItemSameType(RespectShopItems item)
        {
            foreach(RespectShopItems items in Player.BoughtRespectShopitems)
            {
                if (items.Type == item.Type)
                {
                    return true;
                }
                
            }
            return false;
        }

        public class RespectShopItemType
        {
         
        }

    }

}
