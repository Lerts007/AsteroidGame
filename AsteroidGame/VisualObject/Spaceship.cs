using System;
using System.Drawing;

namespace AsteroidGame.VisualObject
{
    internal class Spaceship : BaseObject
    {
        private int _energy;

        private int _point = 0;

        public static event Message MessageDie;

        public int Energy => _energy;

        public int Point => _point;

        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        
        public void EnergyHeigh()
        {
            _energy += 10;
        }

        public void PointUp()
        {
            _point += 1;
        }

        public Spaceship(int energy, Point poz, Point dir, int size) : base(poz, dir, new Size(size, size))
        {
            _energy = energy;
        }
        public override void Draw()
        {
            Game.__buffer.Graphics.FillEllipse(Brushes.Wheat, _Pos.X, _Pos.Y, _Size.Width, _Size.Height);
        }

        public override void Update()
        {
        }

        public void Up()
        {
            if(_Pos.Y > 0) _Pos.Y = _Pos.Y - _Dir.Y;
        }

        public void Down()
        {
            if(_Pos.Y < Game.__Height) _Pos.Y = _Pos.Y + _Dir.Y;
        }

        public void Right()
        {
            if(_Pos.X < Game.__Width)  _Pos.X = _Pos.X + _Dir.X;
        }

        public void Left()
        {
            if(_Pos.X > 0) _Pos.X = _Pos.X - _Dir.X;
        }

        public Rectangle Rect => new Rectangle(_Pos, _Size);

        public bool Collision(ICollision o)
        {
            return o.Rect.IntersectsWith(this.Rect);
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
