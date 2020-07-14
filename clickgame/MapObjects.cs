namespace Servi_urbe
{
    class MapObjects
    {
       
        public static void GetMapObject(int xPos, int yPos)
        {
            
            // reihenfolge ist : startx endx starty endy
            if (xPos > 30 && xPos < 215 && yPos > 23 && yPos < 120)
            {

                Hospital.OnHospitalClick();
               
            }
            else if (xPos > 338 && xPos < 504 && yPos > 115 && yPos < 171)
            {
                Job.OnJobClick();
            }
            else if (xPos > 342 && xPos < 469 && yPos > 294 && yPos < 342)
            {
                Restaurant.OnRestaurantClick();
            }
            else if (xPos > 73 && xPos < 226 && yPos > 301 && yPos < 379)
            {
              
                Sport.OnSportClick();
            }
        }
        
    }
        



    

}
