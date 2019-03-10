using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


namespace PacMan
{
    class Screen 
    {
        static int WIDTH = 800;
        static int HEIGHT = 600;
        public Form FrmScreen = new Form();
        Bitmap BtmScreenBuffer;
        Graphics GphBuffer, GphScreen;

        public Screen()
        {
            FrmScreen.Width = Convert.ToInt32(WIDTH);
            FrmScreen.Height = Convert.ToInt32(HEIGHT);
            FrmScreen.BackColor = Color.Black;
            FrmScreen.Text = "PacMan";
            FrmScreen.Show();

            BtmScreenBuffer = new Bitmap(WIDTH, HEIGHT);
            GphBuffer = Graphics.FromImage(BtmScreenBuffer);
            GphScreen = FrmScreen.CreateGraphics();
        }
        
        public Form GameScreen()
        {
            return FrmScreen;
        }

        public void DrawToBuffer(Map level, Bitmap block, Pac pac, Bitmap food, Bitmap specialfood)
        {
            // Draws the map on the buffer
            for (int x = 0; x <= level.map.GetLength(0) - 1; x++)
                for (int y = 0; y <= level.map.GetLength(1) - 1; y++)
                {
                    if (level.map[x, y] == 'x')
                    {
                        GphBuffer.DrawImage(block, x * 10, y * 10, 10, 10);
                    }
                    if (level.map[x, y] == 'f')
                    {
                        if (level.foodIsAvailable[x, y] == true)
                        {
                            GphBuffer.DrawImage(food, x * 10 + 2, y * 10 + 2, 5, 5);
                        }
                    }
                    if (level.map[x, y] == 'o')
                    {
                        if (level.foodIsAvailable[x, y] == true)
                        {
                            GphBuffer.DrawImage(specialfood, x * 10, y * 10, 9, 9);
                        }
                    }
                }

            // Draws the pac on the buffer in the x and y position
            GphBuffer.DrawImage(pac.bmp, new Point(pac.x, pac.y));
        }

        public void DrawToScreen()
        {
            GphScreen.DrawImage(BtmScreenBuffer, new Point(0, 0));
        }
        
        public Color GetColorOfPixel(Point point)
        {
            Color pixelColor = Color.LightYellow;

            pixelColor = BtmScreenBuffer.GetPixel(point.X, point.Y);

            return pixelColor;
        }
    }
}
