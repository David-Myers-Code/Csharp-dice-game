using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pig
{
    class Program
    {
        static void Main(string[] args)
        {

            player player1 = new player();
            player player2 = new player();

            player1.score = 0;
            player2.score = 0;

            Console.WriteLine("Welcome to PIG");
            Console.WriteLine("What is your name?");
            player1.name = Console.ReadLine();
            Console.WriteLine("What is the computer's name?");
            player2.name = Console.ReadLine();

            int targetScore = 0;

            Console.WriteLine("What are you playing to?");
            targetScore = int.Parse(Console.ReadLine());
            

            //game loop
            while (player1.score < targetScore && player2.score < targetScore)
            {
                //add scoreboard here
                Console.WriteLine("**************************************");
                Console.WriteLine("{0}'s score: {1}", player1.name, player1.score);
                Console.WriteLine("{0}'s score: {1}", player2.name, player2.score);
                Console.WriteLine("**************************************");

                int turnScore = 0;
                //player turn loop
                while (true)
                {
                    int diceRoll = Roll();

                    Console.WriteLine("It's your turn, you roll a {0}", diceRoll);
                    if(diceRoll == 1)
                    {
                        Console.WriteLine("You rolled a 1, you lose all your points for this turn.");
                        break;
                    }
                    else
                    {
                        turnScore += diceRoll;
                        Console.WriteLine("You total for this turn is {0}", turnScore);
                        Console.WriteLine("Do you want to hold or roll?");
                        string play2Name = Console.ReadLine();
                        play play2 = (play)Enum.Parse(typeof(play), play2Name);

                        if(play2 == play.hold)
                        {
                            player1.score += turnScore;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You decide to roll again");
                            
                        }
                    }
                }


                Console.WriteLine("**************************************");
                turnScore = 0;
                Thread.Sleep(1000);

                //Breaks the loop if the player wins
                if (player1.score >= targetScore || player2.score >= targetScore)
                {
                    break;
                }


                //computer turn loop
                while (true)
                {

                    int diceRoll = Roll();
                    Console.WriteLine("{0} rolls a {1}", player2.name, diceRoll);

                    if(diceRoll == 1)
                    {
                        Console.WriteLine("{0} rolled a 1, and loses all their points for this turn.", player2.name);
                        break;
                    }

                    else
                    {
                        turnScore += diceRoll;
                        Console.WriteLine("{0}'s total for this turn is {1}",player2.name, turnScore);
                        //sleep to rethread random number, found idea on stackoverflow.com
                        Thread.Sleep(750);
                        //insert computer ai here
                        Random rnd = new Random();
                        int computerRand = rnd.Next(1, 10);
                        

                        if (computerRand%2 == 0)
                        {
                            Console.WriteLine("{0} chooses to hold", player2.name);
                            player2.score += turnScore;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("{0} chooses to roll again", player2.name);
                            
                        }
                    }

                }

            }


            Console.WriteLine("**************************************");
            Console.WriteLine("Final Score:");
            Console.WriteLine("{0}'s score: {1}", player1.name, player1.score);
            Console.WriteLine("{0}'s score: {1}", player2.name, player2.score);
            Console.WriteLine("**************************************");

            if (player1.score < player2.score)
            {
                Console.WriteLine("{0} wins!  Better luck next time.", player2.name);
            }

            else
            {
                Console.WriteLine("You win!");
            }

            Console.ReadLine();


        }
        static IList<int> diceValues = new List<int>() { 1, 2, 3, 4, 5, 6 };

        public static int Roll()
        {
            diceValues.Shuffle();
            return diceValues.Take(1).Single();
        }
    }
}
