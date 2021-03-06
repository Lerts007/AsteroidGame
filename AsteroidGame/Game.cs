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

            
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            timer.Stop();
            
            if (e.KeyCode == Keys.Escape)
            {
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
                item.Draw();
            }
            __bullet.Draw();
            __buffer.Render();
        }

        public static void Update()
        {
            __planet.Update();
            foreach (Star item in __star)
                item.Update();

            foreach (Asteroid item in __asteroid)
            {
                item.Update();
                if(item.Collision(__bullet))
                {
                    __bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(15, 5));
                    System.Media.SystemSounds.Hand.Play();
                }
                    
            }
            __bullet.Update();

        }

        public static void Load()
        {
            Random r = new Random();
            __star = new Star[31];
            __asteroid = new Asteroid[10];


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

            //Создается пуля /creat bullet/
            __bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(15, 5));

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
