using System;
using System.Drawing;


namespace AsteroidGame
{
    internal class BaseObject
    {
        protected Point _Pos;
        protected Point _Dir;
        protected Size _Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            _Pos = pos;
            _Dir = dir;
            _Size = size;
        }

        public void Draw()
        {
            Game.__buffer.Graphics.DrawEllipse(Pens.White, _Pos.X, _Pos.Y, _Size.Width, _Size.Height);
        }

        public void Update()
        {
            _Pos.X += _Dir.X;
            _Pos.Y += _Dir.Y;
            if(_Pos.X < 0) _Dir.X = -_Dir.X;
            if ((_Pos.X) > Game.__Width-20) _Dir.X = -_Dir.X;

            if (_Pos.Y < 0) _Dir.Y = -_Dir.Y;
            if (_Pos.Y > Game.__Height-20) _Dir.Y = -_Dir.Y;
        }

    }
}
