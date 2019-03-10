using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PacMan
{
    class Pac
    {
        public Bitmap bmp;//, bmpRight, bmpLeft, bmpUp, bmpDown;
        public int x, y;

        public Pac()
        {
            x = 10;
            y = 10;

            bmp = new Bitmap(@"C:\Users\User\source\repos\PacMan\PacMan\pacman.png");
            bmp = new Bitmap(bmp, new Size(26, 28));
            
        }

        public Pac LoadPac()
        {
            return this;
        }

        public void Move(int dir)
        {
            switch (dir)
            {
                case 1:
                    this.y--;
                    break;
                case 2:
                    this.y++;
                    break;
                case 3:
                    this.x++;
                    break;
                case 4:
                    this.x--;
                    break;
            }
        }

    }
}
