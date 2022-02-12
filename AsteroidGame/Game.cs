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

        static Game() { }

        public static void Init(Form form)
        {
            Graphics g;

            __context = BufferedGraphicsManager.Current;

            g = form.CreateGraphics();

            __Width = form.ClientSize.Width;
            __Height = form.ClientSize.Height;

            __buffer = __context.Allocate(g, new Rectangle(0, 0, __Width, __Height));

        }

        public static void Draw()
        {
            __buffer.Graphics.Clear(Color.Black);
            __buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            __buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            __buffer.Render();
        }
    }
}
