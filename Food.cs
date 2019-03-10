using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PacMan
{
    class Food
    {
        public bool isAvaliable;
        Graphics gfood, gspecialfood;
        Bitmap food, specialfood;
        
        public Food()
        {
            isAvaliable = true;
            food = new Bitmap(5, 5);
            specialfood = new Bitmap(9, 9);
            gfood = Graphics.FromImage(food);
            gspecialfood = Graphics.FromImage(specialfood);
        }

        public Bitmap BlockFood()
        {
            gfood.FillRectangle(Brushes.LightYellow, 0, 0, 5, 5);
            return food;
        }

        public Bitmap BlockSpecialFood()
        {
            gspecialfood.FillEllipse(Brushes.Salmon, 0, 0, 9, 9);
            return specialfood;
        }
    }
}
