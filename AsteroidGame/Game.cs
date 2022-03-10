using System;
using System.Windows.Forms;
using System.Drawing;
using AsteroidGame.VisualObject;

namespace AsteroidGame
{
    internal class Game : Form
    {
        private static BufferedGraphicsContext __context;
        public static BufferedGraphics __buffer;
        private static Form form = null;

        public static int __Width { get; set; }
        public static int __Height { get; set; }

        private static Star[] __star;
        private static Asteroid[] __asteroid;
        private static Bullet __bullet;
        private static Planets __planet;
        private static Medicine_Cabinet __Medicine;
        private static Spaceship __spaceship;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private static Timer timer = new Timer { Interval = 100 };

        public Game(Form _form) 
        {
            form = _form;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = __Width = form.Width;
            this.Height = __Height = form.Height;
            this.MaximumSize = new System.Drawing.Size(__Width, __Height);
            this.MinimumSize = new System.Drawing.Size(__Width, __Height);

            Init();
        }

        public void Init()
        {
            
            Graphics g;

            __context = BufferedGraphicsManager.Current;

            g = this.CreateGraphics();

            

            __buffer = __context.Allocate(g, new Rectangle(0, 0, __Width, __Height));
           
            Load();

            this.KeyDown += form_KeyDown;
            this.KeyPreview = true;

            Spaceship.MessageDie += Finish;

            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) __bullet = new Bullet(new Point(__spaceship.Rect.X + 10, __spaceship.Rect.Y + 4), new Point(5, 0), new Size(15, 5));
            if (e.KeyCode == Keys.Up) __spaceship.Up();
            if (e.KeyCode == Keys.Down) __spaceship.Down();
            if (e.KeyCode == Keys.Left) __spaceship.Left();
            if (e.KeyCode == Keys.Right) __spaceship.Right();
            
            if (e.KeyCode == Keys.Escape)
            {
                timer.Stop();
                Pause ps = new Pause();
                ps.ShowDialog();
                if (ps.bl)
                {
                    this.Close();
                    __buffer.Dispose();
                    __context.Dispose();
                }
                else
                    timer.Start();
            }
        }


        public static void Draw()
        {           
            __buffer.Graphics.Clear(Color.Black);
            __planet.Draw();
            foreach (Star item in __star)
            {
                item.Draw();
            }
            foreach (Asteroid item in __asteroid)
            {
                item?.Draw();
            }

            __bullet?.Draw();

            __Medicine?.Draw();

            __spaceship?.Draw();

            if(__spaceship != null)
            {
                __buffer.Graphics.DrawString("Health: " + __spaceship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
                __buffer.Graphics.DrawString("Point: " + __spaceship.Point, SystemFonts.DefaultFont, Brushes.White, 0, 15);
            }

            __buffer.Render();
        }

        public static void Update()
        {
            var rnd = new Random();
            __planet.Update();
            foreach (Star item in __star)
                item.Update();

            for(int i = 0; i < __asteroid.Length; i++)
            {
                if (__asteroid[i] == null) continue;

                __asteroid[i].Update();

                if(__bullet != null && __bullet.Collision(__asteroid[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    __asteroid[i] = null;
                    __bullet = null;
                    __spaceship.PointUp();
                    continue;
                }

                if(!__spaceship.Collision(__asteroid[i])) continue;

                
                __spaceship?.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if(__spaceship.Energy <= 0) __spaceship?.Die();

                
            }

            if (__bullet != null && __bullet.EndBullet())
            {
                __bullet = null;
            }

            if(__spaceship.Collision(__Medicine))
            {
                __spaceship?.EnergyHeigh();
                __Medicine = null;

                __Medicine = new Medicine_Cabinet(new Point(rnd.Next(0, __Height), rnd.Next(0, __Width - 300)),
                                            new Point(RAN(), RAN()),
                                            20);

                int RAN()
                {
                    int ran = rnd.Next(-15, 15);
                    if (ran == 0)
                        return 1;
                    return ran;
                }
            }

            __Medicine.Update();
            
            __bullet?.Update();

        }

        public static void Load()
        {
            Random r = new Random();
            __star = new Star[31];
            __asteroid = new Asteroid[10];
            __spaceship = new Spaceship(100, new Point(100, 100), new Point(5, 5), 10);

            //Создается планета /create planet/
                __planet = new Planets(new Point(r.Next(0, __Height), r.Next(0, __Width - 500)),
                                            new Point(5, 0),
                                            150);

            //Создается астероид /creat asteroid/
            for (int i = 0; i < __asteroid.Length; i++)
            {
                __asteroid[i] = new Asteroid(new Point(r.Next(0, __Height), r.Next(0, __Width - 300)), 
                                            new Point(RAN(), RAN()), 
                                            20);
            }

            //Создается звезда /creat star/
            for (int i = 0; i < __star.Length; i++)
            {
                __star[i] = new Star(new Point(r.Next(0, __Height), r.Next(0, __Width - 300)),
                                            new Point(r.Next(15, 25), 0),
                                            r.Next(30, 50));
            }

            __Medicine = new Medicine_Cabinet(new Point(r.Next(0, __Height), r.Next(0, __Width - 300)),
                                            new Point(RAN(), RAN()),
                                            20);

            int RAN()
            {
                int ran = r.Next(-15, 15);
                if ( ran == 0)
                    return 1;
                return ran;
            }
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Finish()
        {
            timer.Stop();
            __buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            __buffer.Render();
        }

        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Game
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Game";
            this.ResumeLayout(false);

        }
    }
}
