using System;

namespace tp_plusmoins
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Welcome in the +/- game! ***");
            bool again = true;
            while(again) {
                Console.WriteLine("--- Try to find the secret number between 0 and 100 : ---");
                again = Search();
            }
        }

        static bool Search() {
            int rand = Random();
            bool found = false;
            int count = 0;
            while(!found) {
                string read = Console.ReadLine();
                count++;
                if(int.TryParse(read, out int input)) {
                    if(input < 0 || input > 100)
                        Console.WriteLine("...\nWe said BETWEEN 0 and 100 !");
                    else if(input == rand) {
                        Found(rand, count);
                        found = true;
                    } else if(input > rand)
                        Console.WriteLine("Nope, it's less.");
                    else
                        Console.WriteLine("Argh no, it's more.");
                } else {
                    Console.WriteLine("Really ?? That's not even a number !");
                }
            }
            return Again();
        }

        static int Random() {
            return new Random().Next(0, 101);
        }

        static void Found(int rand, int count) {
            if(count == 1)
                Console.WriteLine("WHAAAAAT ????" 
                                    + "\nYou found the number \'" + rand
                                    + "\' in a single step."
                                    + "\nBro, you're genius (or a lucky bastard ! ;) )");
            else if(count < 5)
                Console.WriteLine("Congratulations, quickie!" 
                                    + "\nYou found the number \'" + rand
                                    + "\' in only " + count + " steps.");
            else if(count >= 5 && count < 10)
                Console.WriteLine("Congratulations !" 
                                    + "\nYou found the number \'" + rand
                                    + "\' in " + count + " steps.");
            else
                Console.WriteLine("At last, slowhead !" 
                                    + "\nYou found the number \'" + rand
                                    + "\' in " + count + " steps.");
        }

        static bool Again() {
            while(true) {
                Console.WriteLine("Do you want to continue ? (Y/N)");
                var get = Console.ReadKey(true);
                if(get.Key == ConsoleKey.Y) {
                    Console.WriteLine("Nice, here we go again !\n");
                    return true;
                }
                else if(get.Key == ConsoleKey.N) {
                    Console.WriteLine("Oh...\nOkay...\nBye...");
                    return false;
                }
                else
                    Console.WriteLine("Are you kidding, what is that shit ??");
            }
            
        }
    }
}
