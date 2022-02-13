using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    internal class Asteroid : BaseObject
    {
        private static Image __ImageAsteroid = Properties.Resources.Asteroid;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.__buffer.Graphics.DrawImage(__ImageAsteroid, _Pos.X, _Pos.Y, _Size.Width, _Size.Height);
        }

        public override void Update()
        {
            _Pos.X += _Dir.X;
            _Pos.Y += _Dir.Y;
            if (_Pos.X < 0) _Dir.X = -_Dir.X;
            if ((_Pos.X) > Game.__Width - 20) _Dir.X = -_Dir.X;

            if (_Pos.Y < 0) _Dir.Y = -_Dir.Y;
            if (_Pos.Y > Game.__Height - 20) _Dir.Y = -_Dir.Y;
        }
    }
}
