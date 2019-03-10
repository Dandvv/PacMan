using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    static class Program
    {
        static void Main()
        {
            Game game = new Game();
            

            //game.screen.DrawToBuffer(game.map.GetMap(), game.pac.LoadPac(),);
            //game.screen.DrawToScreen();

            Application.Run(game.screen.GameScreen());
        }
        

    }
}
