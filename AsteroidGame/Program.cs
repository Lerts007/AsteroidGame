using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Form form = new Form();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximumSize = new System.Drawing.Size(800, 600);
            form.MinimumSize = new System.Drawing.Size(800, 600);
            SplachScreen.StartMenu(form);
            Application.Run(form);
        }        
    }    
}
