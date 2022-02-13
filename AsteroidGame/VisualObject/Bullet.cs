using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObject
{
    internal class Bullet : BaseObject, ICollision
    {
        private static Image __ImageBullet = Properties.Resources.bullet;
        public Bullet(Point pos, Point dir, Size size) 
            : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.__buffer.Graphics.DrawImage(__ImageBullet, _Pos.X, _Pos.Y, _Size.Width, _Size.Height);
        }

        public override void Update()
        {
            _Pos.X += 10;
            if ((_Pos.X + _Size.Width) > Game.__Width) _Pos.X = 0- _Size.Width;
        }

        public Rectangle Rect => new Rectangle(_Pos, _Size);

        public bool Collision(ICollision o)
        {
            return o.Rect.IntersectsWith(this.Rect);
        }
    }
}
