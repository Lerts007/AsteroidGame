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

        public virtual void Draw() {    }

        public virtual void Update() {  }

    }
}
