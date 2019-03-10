using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PacMan
{
    class Game 
    {
        // remove public status for those OBJs
        public Screen screen;
        Map map;
        Pac pac;
        Food food;
        bool up, down, left, right;
        

        public Game()
        {
            screen = new Screen();
            map = new Map();
            pac = new Pac();
            food = new Food();

            Timer t = new Timer();
            t.Interval = 5;
            t.Start();

            //Events 
            t.Tick += new EventHandler(CheckDirection);
            screen.FrmScreen.KeyDown += new KeyEventHandler(EventKeyDown);
            screen.FrmScreen.KeyUp += new KeyEventHandler(EventKeyUp);

        }

        private void EventKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { up = true; }
            if (e.KeyCode == Keys.Down) { down = true; }
            if (e.KeyCode == Keys.Right) { right = true; }
            if (e.KeyCode == Keys.Left) { left = true; }
        }

        private void EventKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { up = false; }
            if (e.KeyCode == Keys.Down) { down = false; }
            if (e.KeyCode == Keys.Right) { right = false; }
            if (e.KeyCode == Keys.Left) { left = false; }
        }

        private void CheckDirection(object sender, EventArgs e)
        {
            Point pt1 = new Point();
            Point pt2 = new Point();
            Point pt3 = new Point();

            if (up)
            {
                pt1.X = pac.x;
                pt1.Y = pac.y - 1;
                pt2.X = pac.x + 26;
                pt2.Y = pac.y - 1;
                pt3.X = pac.x + 13;
                pt3.Y = pac.y - 1;

                if (screen.GetColorOfPixel(pt3) != Color.FromArgb(255, 255, 255, 224))
                    map.foodIsAvailable[pt3.X / 10, pt3.Y / 10] = false;

                if ((screen.GetColorOfPixel(pt1)) != (Color.FromArgb(255, 0, 0, 255)) && 
                    (screen.GetColorOfPixel(pt2)) != (Color.FromArgb(255, 0, 0, 255)) &&
                    (screen.GetColorOfPixel(pt3)) != (Color.FromArgb(255, 0, 0, 255)))
                {
                    pac.Move(1);
                }
            }
            if (down)
            {
                pt1.X = pac.x;
                pt1.Y = pac.y + 29;
                pt2.X = pac.x + 26;
                pt2.Y = pac.y + 29;
                pt3.X = pac.x + 13;
                pt3.Y = pac.y + 29;

                if (screen.GetColorOfPixel(pt3) != Color.FromArgb(255, 255, 255, 224))
                    map.foodIsAvailable[pt3.X / 10, pt3.Y / 10] = false;

                if ((screen.GetColorOfPixel(pt1)) != (Color.FromArgb(255, 0, 0, 255)) &&
                    (screen.GetColorOfPixel(pt2)) != (Color.FromArgb(255, 0, 0, 255)) &&
                    (screen.GetColorOfPixel(pt3)) != (Color.FromArgb(255, 0, 0, 255)))
                {
                    pac.Move(2);
                }
            }
            if (right)
            {
                pt1.X = pac.x + 27;
                pt1.Y = pac.y;
                pt2.X = pac.x + 27;
                pt2.Y = pac.y + 28;
                pt3.X = pac.x + 27;
                pt3.Y = pac.y + 14;

                if (screen.GetColorOfPixel(pt3) != Color.FromArgb(255, 255, 255, 224))
                    map.foodIsAvailable[pt3.X / 10, pt3.Y / 10] = false;

                if ((screen.GetColorOfPixel(pt1)) != (Color.FromArgb(255, 0, 0, 255)) &&
                    (screen.GetColorOfPixel(pt2)) != (Color.FromArgb(255, 0, 0, 255)) &&
                    (screen.GetColorOfPixel(pt3)) != (Color.FromArgb(255, 0, 0, 255)))
                {
                    pac.Move(3);
                }
            }
            if (left)
            {
                pt1.X = pac.x - 1;
                pt1.Y = pac.y;
                pt2.X = pac.x - 1;
                pt2.Y = pac.y + 28;
                pt3.X = pac.x - 1;
                pt3.Y = pac.y + 14;

                if (screen.GetColorOfPixel(pt3) != Color.FromArgb(255, 255, 255, 224))
                    map.foodIsAvailable[pt3.X / 10, pt3.Y / 10] = false;

                if ((screen.GetColorOfPixel(pt1)) != (Color.FromArgb(255, 0, 0, 255)) &&
                    (screen.GetColorOfPixel(pt2)) != (Color.FromArgb(255, 0, 0, 255)) &&
                    (screen.GetColorOfPixel(pt3)) != (Color.FromArgb(255, 0, 0, 255)))
                {
                    pac.Move(4);
                }
            }

            //screen.DrawToBuffer(map.GetMap(), map.BlockMap(), pac.LoadPac(), food.BlockFood(),
            //    food.BlockSpecialFood());
            screen.DrawToBuffer(map, map.BlockMap(), pac.LoadPac(), food.BlockFood(),
                food.BlockSpecialFood());
            screen.DrawToScreen();
        }
    }
}
