using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    internal class Pause : Form
    {
        private static Button __btnContinue = new Button();
        private static Button __btnExit = new Button();
        private static Bitmap __bitmap_2;

        public bool bl=false;
        public Pause()
        {
            PauseForm();
        }
        public void PauseForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Text = "Pause";
            
            __bitmap_2 = new Bitmap(Properties.Resources.background, this.Width, this.Height);
            this.BackgroundImage = __bitmap_2;

            ButtonContinue();
            ButtonExit();
            LabelText();
        }     
        private void ButtonContinue()
        {
            __btnContinue.Size = new Size(120, 40);
            __btnContinue.Text = "Continue";
            __btnContinue.Location = new Point(15, 100);
            this.Controls.Add(__btnContinue);
            __btnContinue.Click += btnContinue_Clicked;
        }

        private void ButtonExit ()
        {
            __btnExit.Size = new Size(120, 40);
            __btnExit.Text = "Exit";
            __btnExit.Location = new Point(155, 100);
            this.Controls.Add(__btnExit);
            __btnExit.Click += btnExit_Clicked;
        }

        private void LabelText()
        {
            Label label = new Label();
            label.Font = new Font("TimeNewRoman", 14);
            label.Text = "Would you like to play again?";
            label.Size = new Size(280, 40);
            label.Location = new Point(15, 40);
            label.BackColor = Color.Transparent;
            this.Controls.Add(label);
        }

        private void btnExit_Clicked(object sender, EventArgs e)
        {
            this.Close();
            bl = true;
        }
        private void btnContinue_Clicked(object sender, EventArgs e)
        {
            this.Close();
            bl = false;
        }
    }
}
