using System;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using System.Collections.Generic;

namespace AsteroidGame
{
    internal static class SplachScreen
    {
        private static Bitmap __bitmap = null;
        private static Form __form = null;
        

        private static Button btn_1 = new Button();
        private static Button btn_2 = new Button();
        private static Button btn_3 = new Button();
        private static Button btn_4 = new Button();

        private static List<Button> btn = new List<Button> { btn_1, btn_2, btn_3, btn_4 };

        public static void StartMenu(Form form)
        {
            __form = form;
            __bitmap =new Bitmap(Properties.Resources.background, form.Width, form.Height);
            form.BackgroundImage = __bitmap;

            ButtonListGame();
            ButtonNewGame();
            ButtonRecords();
            ButtonSettings();
            ButtonExit();

        }

        private static void ButtonListGame()
        {
            for(int i = 0; i < btn.Count; i++)
            {
                btn[i].Size = new Size(120, 40);
                btn[i].Location = new Point((__form.Width / 2 - btn_1.Size.Width / 2 - 10), (__form.Height / 2 - btn_1.Size.Height / 2 - 10+50*i));
                __form.Controls.Add(btn[i]);
            }
        }

        public static void ButtonNewGame()
        {
            btn_1.Text = "New game";
            btn_1.Click += btn_1_Clicked;
        }

        private static void ButtonRecords()
        {
            btn_2.Text = "Records";
        }

        private static void ButtonSettings()
        {
            btn_3.Text = "Settings";
        }

        private static void ButtonExit()
        {
            btn_4.Text = "Exit";
            btn_4.Click += btn_4_Clicked;
        }


        private static void btn_1_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < btn.Count; i++)
            {
               btn[i].Visible = false;
            }
            
            Game.Init(__form);
            __form.Show();
            Game.Draw();
        }

        private static void btn_4_Clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}