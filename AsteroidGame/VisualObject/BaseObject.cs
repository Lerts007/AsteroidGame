using System;
using System.Drawing;


namespace AsteroidGame.VisualObject
{
    public delegate void Message();
    internal abstract class BaseObject
    {
        protected Point _Pos;
        protected Point _Dir;
        protected Size _Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            _Pos = pos;
            _Dir = dir;
            _Size = size;
        }

        public abstract void Draw();

        public abstract void Update();

    }
}
