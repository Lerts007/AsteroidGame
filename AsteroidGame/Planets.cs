using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    internal class Planets : BaseObject
    {
        private static Image[] __ImagePlanet = { Image.FromFile("image/1_planet.png"),
                                              Image.FromFile("image/2_planet.png"),
                                              Image.FromFile("image/3_planet.png")};
        Image _Planet = __ImagePlanet[0];
        Random r = new Random();
        public Planets(Point pos, Point dir, Size size) : base(pos, dir, size) {     }

        public override void Draw()
        {
            Game.__buffer.Graphics.DrawImage(_Planet, _Pos.X, _Pos.Y, _Size.Width, _Size.Height);
        }

        public override void Update()
        {
            _Pos.X = _Pos.X - _Dir.X;
            if ((_Pos.X + _Size.Width) < 0)
            {
                _Pos.X = Game.__Width + _Size.Width;
                _Planet = __ImagePlanet[r.Next(0, 3)];
            }
        }
    }
}
