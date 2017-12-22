using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{
    class Ship : Point
    {
        //Integrity of the ship saying it can only be hit once before being destroyed (pretty flimsy ships...).
        public int ShipIntegrity { get; protected set; } = 1;

        public Ship(int x, int y, Map map) : base(x, y)
        {
            if (!map.IsOnMap(this))
            {
                throw new OutOfBoundsException(this + " is not on the map.");
            }
        }

        public bool IsDestroyed => ShipIntegrity <= 0 ? true : false;

        public void ShootShip(Point point)
        {
            if(!IsDestroyed && point.X == X && point.Y == Y)
            {
                Console.WriteLine("HIT!");
                ShipIntegrity--;
            }
        }

        public virtual bool CheckForOverlap(Ship othership)
        {
            return othership.X == X && othership.Y == Y;
        }
    }
}
