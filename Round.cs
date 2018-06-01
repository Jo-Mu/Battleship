using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{
    class Round
    {
        public List<Ship> P1Ships;
        public List<Ship> P2Ships;
        public readonly Map GameMap;

        public Round(List<Ship> p1Ships, List<Ship> p2Ships, Map gameMap)
        {
            P1Ships = p1Ships;
            P2Ships = p2Ships;
            GameMap = gameMap;
        }

        /*Each player takes a turn until one loses all of their ships.
         * Returns true if Player 1 wins and false if Player 2 wins*/
        public bool Battle
        {
            get
            {
                List<Point> p1ShotsFired = new List<Point>();
                List<Point> p2ShotsFired = new List<Point>();
                int p1ShipsRemaining = P1Ships.Count;
                int p2ShipsRemaining = P2Ships.Count;
                int turn = 1;
                while (p1ShipsRemaining > 0)
                {
                    while (true)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("TURN " + turn);
                        Console.WriteLine("");
                        Console.WriteLine("Player 1's Turn");
                        Console.WriteLine("-------------------------------------------------------------------------");
                        Console.Write("Choose x-coordinate to fire at: ");

                        string xInput = Console.ReadLine();
                        int p1ShotX;

                        if (int.TryParse(xInput, out p1ShotX))
                        { }

                        else
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }

                        Console.Write("Choose y-coordinate to fire at: ");

                        string yInput = Console.ReadLine();
                        int p1ShotY;

                        if (int.TryParse(yInput, out p1ShotY))
                        { }

                        else
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }

                        Point shot = new Point(p1ShotX, p1ShotY);

                        //Check if shot is on the map or if spot hasn't been fired on already.
                        if (!GameMap.IsOnMap(shot))
                        {
                            Console.WriteLine("You are firing outside the map! Try again.");
                            continue;
                        }

                        else if (p1ShotsFired.Contains(shot)) 
                        {
                            Console.WriteLine("You already fired there! Try again.");
                            continue;
                        }

                        //Determines if the shot "HIT!" any ships otherwise the console will print "MISS!"
                        else
                        {
                            p1ShotsFired.Add(item: shot);
                            int p1MissCheck = p2ShipsRemaining;
                            p2ShipsRemaining = 0;
                            for (int i = 0; i < P2Ships.Count; i++)
                            {
                                P2Ships[i].ShootShip(shot);

                                if (!P2Ships[i].IsDestroyed)
                                {
                                    p2ShipsRemaining++;
                                }
                            }

                            if (p1MissCheck == p2ShipsRemaining)
                            {
                                Console.WriteLine("MISS!");
                            }
                        }

                        if (p2ShipsRemaining <= 0)
                        {
                            return true;
                        }
                        else
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Player 2's Turn");
                        Console.WriteLine("-------------------------------------------------------------------------");
                        Console.Write("Choose x-coordinate to fire at: ");

                        string xInput = Console.ReadLine();
                        int p2ShotX;

                        if (int.TryParse(xInput, out p2ShotX))
                        { }

                        else
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }

                        Console.Write("Choose y-coordinate to fire at: ");

                        string yInput = Console.ReadLine();
                        int p2ShotY;

                        if (int.TryParse(yInput, out p2ShotY))
                        { }

                        else
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }

                        Point shot = new Point(p2ShotX, p2ShotY);

                        //Check if shot is on the map or if spot hasn't been fired on already.
                        if (!GameMap.IsOnMap(shot))
                        {
                            Console.WriteLine("You are firing outside the map! Try again.");
                            continue;
                        }

                        else if (p2ShotsFired.Contains(shot))
                        {
                            Console.WriteLine("You already fired there! Try again.");
                            continue;
                        }

                        else
                        {
                            p2ShotsFired.Add(item: shot);
                            int p2MissCheck = p1ShipsRemaining;
                            p1ShipsRemaining = 0;
                            for (int i = 0; i < P1Ships.Count; i++)
                            {
                                P1Ships[i].ShootShip(shot);

                                if (!P1Ships[i].IsDestroyed)
                                {
                                    p1ShipsRemaining++;
                                }
                            }
                            if (p2MissCheck == p1ShipsRemaining)
                            {
                                Console.WriteLine("MISS!");
                            }
                        }
                        turn++;
                        break;
                    }
                }
                return false;
            }
        }
    }
}
