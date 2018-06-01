using System;
using System.Collections.Generic;

namespace Battleship
{
    class Game
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Board is 10x10 so place your ships in coordinates from 0 to 9.");
            Console.WriteLine("");

            Map map = new Map(10, 10);
            int p1Score = 0;
            int p2Score = 0;
            int round = 1;

            while (true)
            {
                List<Ship> p1Ships = new List<Ship>();
                List<Ship> p2Ships = new List<Ship>();
                //Asks for how many ships each player has in this round and checks if input is valid (a whole number > 0).
                Console.WriteLine("How many ships do you want each player to have?");
                string input = Console.ReadLine();
                int ships;

                if (int.TryParse(input, out ships) && ships > 0)
                {
                    int p1ShipNumber = 1;
                    int p2ShipNumber = 1;
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("Player 1");
                    Console.WriteLine("-------------------------------------------------------------------------");

                    //Asks player 1 for coordinates for ships and checks if input is valid and ships don't overlap.
                    while (p1ShipNumber <= ships)
                    {
                        Console.Write("Enter the x-coordinate for ship " + p1ShipNumber + ": ");

                        string xInput = Console.ReadLine();
                        int p1ShipX;

                        if (int.TryParse(xInput, out p1ShipX))
                        { }

                        else
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }

                        Console.Write("Enter the y-coordinate for ship " + p1ShipNumber + ": ");

                        string yInput = Console.ReadLine();
                        int p1ShipY;

                        if (int.TryParse(yInput, out p1ShipY))
                        { }

                        else
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }

                        try
                        {
                            /* If coordinates are valid (on the map) and the ship doesn't overlap
                             then it gets added to the list of ships for player 1.
                             However, if either of these 2 things happen then the player will be asked
                             to input the coordinates again.*/
                            Ship test = new Ship(p1ShipX, p1ShipY, map);
                            bool noOverlap = true;

                            if (p1Ships.Count > 0)
                            {
                                for (int i = 0; i < p1Ships.Count; i++)
                                {
                                    if (p1Ships[i].CheckForOverlap(test))
                                    {
                                        noOverlap = false;
                                        break;
                                    }
                                }
                            }

                            if (noOverlap)
                            {
                                p1Ships.Add(item: test);
                            }

                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Ship overlaps with an already placed ship.");
                                Console.WriteLine("");
                                continue;
                            }
                        }

                        catch (OutOfBoundsException)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Coordinates are outside of the map.");
                            Console.WriteLine("");
                            continue;
                        }

                        Console.WriteLine("");
                        p1ShipNumber++;
                    }

                    Console.WriteLine(".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.");
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("Player 2");
                    Console.WriteLine("-------------------------------------------------------------------------");

                    //Same process for player 1 but for player 2.
                    while (p2ShipNumber <= ships)
                    {
                        Console.Write("Enter the x-coordinate for ship " + p2ShipNumber + ": ");

                        string xInput = Console.ReadLine();
                        int p2ShipX;

                        if (int.TryParse(xInput, out p2ShipX))
                        { }

                        else
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }

                        Console.Write("Enter the y-coordinate for ship " + p2ShipNumber + ": ");

                        string yInput = Console.ReadLine();
                        int p2ShipY;

                        if (int.TryParse(yInput, out p2ShipY))
                        { }

                        else
                        {
                            Console.WriteLine("Invalid input.");
                            continue;
                        }

                        try
                        {
                            Ship test = new Ship(p2ShipX, p2ShipY, map);
                            bool noOverlap = true;

                            if (p2Ships.Count > 0)
                            {
                                for (int i = 0; i < p2Ships.Count; i++)
                                {
                                    if (p2Ships[i].CheckForOverlap(test))
                                    {
                                        noOverlap = false;
                                        break;
                                    }
                                }
                            }

                            if (noOverlap)
                            {
                                p2Ships.Add(item: test);
                            }

                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Ship overlaps with an already placed ship.");
                                Console.WriteLine("");
                                continue;
                            }
                        }

                        catch (OutOfBoundsException)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Coordinates are outside of the map.");
                            Console.WriteLine("");
                            continue;
                        }

                        Console.WriteLine("");
                        p2ShipNumber++;
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input, please enter a whole number greater than 0.");
                    continue;
                }

                Console.WriteLine(".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.");
                Console.WriteLine("Ship setup complete! Time to play!");
                Console.WriteLine("BEST OUT OF 3 WINS!");

                /*The game begins and each round  will ask for a new set of ships starting from the
                 beginning of the loop after the round is over. Every time a player wins they will get
                 a point to their score which will be kept track ofand the first to win 2 out of 3 rounds is 
                 the overall winner of the game triggering the a break for the loop and the program will end.*/
                Round gameRound = new Round(p1Ships, p2Ships, map);

                if (gameRound.Battle)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Player 1 wins round " + round + "!");
                    p1Score++;
                    Console.WriteLine("");
                    Console.WriteLine("Score");
                    Console.WriteLine("-------------");
                    Console.WriteLine("Player 1: " + p1Score);
                    Console.WriteLine("Player 2: " + p2Score);
                    Console.WriteLine("");
                    round++;
                }

                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Player 2 wins round " + round + "!");
                    p2Score++;
                    Console.WriteLine("");
                    Console.WriteLine("Score");
                    Console.WriteLine("-------------");
                    Console.WriteLine("Player 1: " + p1Score);
                    Console.WriteLine("Player 2: " + p2Score);
                    Console.WriteLine("");
                    round++;
                }

                if (p1Score >= 2 || p2Score >= 2)
                {
                    Console.WriteLine("PLAYER " + (p1Score > p2Score ? "1" : "2") + " WINS!!!! \\(**)/");
                    break;
                }

                else
                {
                    continue;
                }
            }

        }
    }
}
