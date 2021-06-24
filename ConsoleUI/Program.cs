using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random _rdm = new Random();

        static void Main(string[] args)
        {

            string str = "BoB bojack";
            // method chaining
            Console.WriteLine(str.ToLower().ToUpper());





























            /*
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestsName();
            PrintWinner();
            */
        }

        //Start writing your code here
        /// <summary>
        /// Print out a user message, and then return user input
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string GetUserInput(string message)
        {
            // pass the message as an argument to print something
            Console.WriteLine(message);
            // get user input 
            string userInput = Console.ReadLine();
            //  return userInput
            return userInput;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void GetUserInfo()
        {
            // enter a name
            string guestName = "";
            // while the guestName is NOT "no" 
            while (!guestName.ToLower().Equals("no"))
            {
                guestName = GetUserInput("Please enter a name: ");
                // keep asking for name if they enter a blank string
                if (guestName.Equals(""))
                {
                    Console.WriteLine("Name empty!, please enter a valid name");
                    continue;
                }

                // generate random number
                raffleNumber = GenerateRandomNumber(min, max);
                // generate a new raffle number if it exists until it doesn't
                if (guests.ContainsKey(raffleNumber))
                {
                    // keep looping until raffleNumber is not in the dict
                    while (guests.ContainsKey(raffleNumber))
                    {
                        raffleNumber = GenerateRandomNumber(min, max);
                    }
                }

                // add the raffle number and guest name to the dict
                AddGuestsInRaffle(raffleNumber, guestName);
            }

            /*
                    string otherGuest = "";

                do
                {
                    string name = GetUserInput("Please enter your name ");
                    raffleNumber = GenerateRandomNumber(_min, _max);

                    while (String.IsNullOrEmpty(name))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        name = GetUserInput("Please enter your name ");
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    //Keep generating random number when already exists

                    while (guests.ContainsKey(raffleNumber))
                    {
                        raffleNumber = GenerateRandomNumber(_min, _max);

                    }

                    //add name and number in the guests dict buy calling the AddGuestsInRaffle method raffleNumber is the key and name the value
                    AddGuestsInRaffle(raffleNumber, name);

                    // You need to know when to exit the loop, loop end when user enter "no"

                    otherGuest = GetUserInput("Do you want to add another name? ").ToLower();

                    while (String.IsNullOrEmpty(otherGuest))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        otherGuest = GetUserInput("Do you want to add another name? ").ToLower();
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    Console.WriteLine();



                } while (otherGuest == "yes" || string.IsNullOrEmpty(otherGuest)); 
            */

        }


        // Returns a random int between min and max numbers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private static int GenerateRandomNumber(int min, int max)
        {
            return _rdm.Next(min, max);

        }

        // Add Guests to the raffle dictionary
        /// <summary>
        /// 
        /// </summary>
        /// <param name="raffleNumber"></param>
        /// <param name="guest"></param>
        private static void AddGuestsInRaffle(int raffleNumber, string guest)
        {
            guests.Add(raffleNumber, guest);
        }

        // print guest names
        /// <summary>
        /// 
        /// </summary>
        private static void PrintGuestsName()
        {
            foreach(var guest in guests)
            {
                Console.WriteLine($"Guest name: {guest.Value}");
                Console.WriteLine($"Guest raffle: {guest.Key}");
            }
        }

        // gets the raffle numbers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        private static int GetRaffleNumber(Dictionary<int, string> people)
        {
            // get a count of all the instances that exist
            int dictCount = people.Count;
            // get a list to store all the keys
            List<int> keys = new List<int>(); 
            // iterate over each raffle key and add it to the list
            foreach (var raffle in people.Keys)
            {
                keys.Add(raffle);
            }
            // select a random instance from the list
            int keyWinner = keys[_rdm.Next(dictCount - 1)];
            return keyWinner;
        }

        /// <summary>
        /// print out the winner
        /// </summary>
        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            //print out the winner
            Console.WriteLine($"Winner Raffle Number: {winnerNumber}\nName:{guests[winnerNumber]}");
        }

        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
