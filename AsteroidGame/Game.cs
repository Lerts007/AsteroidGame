using System;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame
{
    internal static class Game
    {
        private static BufferedGraphicsContext __context;
        public static BufferedGraphics __buffer;

        public static int __Width { get; set; }
        public static int __Height { get; set; }

        public static BaseObject[] __objs;

        

        static Game() { }

        public static void Init(Form form)
        {
            Graphics g;

            __context = BufferedGraphicsManager.Current;

            g = form.CreateGraphics();

            __Width = form.ClientSize.Width;
            __Height = form.ClientSize.Height;

            __buffer = __context.Allocate(g, new Rectangle(0, 0, __Width, __Height));
           
            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        public static void Draw()
        {           
            __buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject item in __objs)
            {
                item.Draw();
            }
            __buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject item in __objs)
                item.Update();
        }

        public static void Load()
        {
            Random r = new Random();
            __objs = new BaseObject[30];
            for (int i = 0; i < __objs.Length; i++)
            {
                __objs[i] = new BaseObject(new Point(r.Next(0, __Height), r.Next(0, __Width - 300)), 
                                            new Point(RAN(), RAN()), 
                                            new Size(20, 20));
            }

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

    }
}
