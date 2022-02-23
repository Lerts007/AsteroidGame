using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    internal static class Program
    {
        //[STAThread]
        static void Main()
        {
            StartGame SG = new StartGame();
            SG.Launch();
        }        
    }    
}
