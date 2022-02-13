using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    internal class Star : BaseObject
    {
        private static Image __ImageStar = Properties.Resources.Star;
        public Star(Point poz, Point dir, Size size) : base(poz, dir, size) {        }

        public override void Draw()
        {
            Game.__buffer.Graphics.DrawImage(__ImageStar, _Pos.X, _Pos.Y, _Size.Width, _Size.Height);
        }

        public override void Update()
        {
            _Pos.X = _Pos.X - _Dir.X;
            if ((_Pos.X+_Size.Width) < 0) _Pos.X = Game.__Width + _Size.Width;
        }
    }
}
