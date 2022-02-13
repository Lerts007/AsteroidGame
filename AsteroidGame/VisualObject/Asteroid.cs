using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObject
{
    internal class Asteroid : BaseObject, ICollision
    {
        private static Image __ImageAsteroid = Properties.Resources.Asteroid;

        public int Power { get; set; }

        public Asteroid(Point pos, Point dir, int size) 
            : base(pos, dir, new Size(size, size)) 
        {
            Power = 1;
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

        public Rectangle Rect => new Rectangle(_Pos, _Size);

        public bool Collision(ICollision o)
        {
            return o.Rect.IntersectsWith(this.Rect);
        }
    }
}
