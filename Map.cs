using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PacMan
{
    class Map
    {
        public char[,] map = new char[44, 51];
        public bool[,] foodIsAvailable = new bool[44,51];
        Graphics g;
        Bitmap block;

        public Map()
        {
            string[] lines;
            lines = System.IO.File.ReadAllLines(@"C:\Users\User\source\repos\PacMan\PacMan\level_1.txt");

            int  x = 0, y = 0;
            foreach(string line in lines)
            {
                x = 0;
                foreach (char c in line)
                {
                    foodIsAvailable[x, y] = true;
                    map[x, y] = line[x];
                    x++;
                }
                y++;
            }

            block = new Bitmap(10, 10);
            g = Graphics.FromImage(block);
            g.FillRectangle(Brushes.Blue, 0, 0, 10, 10);
        }

        /*public string[] GetMap()
        {
            return map;
        }*/

        public Bitmap BlockMap()
        {
            return block;
        }
    }
}
