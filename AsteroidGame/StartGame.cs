using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    internal class StartGame
    {

        public void Launch()
        {
            Form __formStartGame = new Form();
            __formStartGame.StartPosition = FormStartPosition.CenterScreen;
            __formStartGame.MaximumSize = new System.Drawing.Size(1200, 1000);
            __formStartGame.MinimumSize = new System.Drawing.Size(800, 600);
            __formStartGame.Width = 800;
            __formStartGame.Height = 600;

            SplachScreen.StartMenu(__formStartGame);

            Application.Run(__formStartGame);
        }

        //public void Restart(Form form, int Width, int Height)
        //{
        //    form.Width = Width;
        //    form.Height = Height;

        //    form.StartPosition = FormStartPosition.CenterScreen;

        //    SplachScreen.StartMenu(form);

        //    form.Show();

        //}
    }
}
