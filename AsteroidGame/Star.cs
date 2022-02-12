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
        public Star(Point poz, Point dir, Size size) : base(poz, dir, size) {        }

        public override void Draw()
        {
            Game.__buffer.Graphics.DrawLine(Pens.White, _Pos.X, _Pos.Y, _Pos.X + _Size.Width, _Pos.Y + _Size.Height);
            Game.__buffer.Graphics.DrawLine(Pens.White, _Pos.X + _Size.Width, _Pos.Y, _Pos.X, _Pos.Y + _Size.Height);
        }

        public override void Update()
        {
            _Pos.X = _Pos.X - _Dir.X;
            if (_Pos.X < 0) _Pos.X = Game.__Width + _Size.Width;
        }
    }
}
