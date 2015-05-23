using System;

namespace NumberGuesser
{
	class MainClass
	{
        public const string PlayerChoice = "P", ComputerChoice = "C";

		public static void Main (string[] args)
		{
			Console.WriteLine ("Welcome to the 'Number Guesser!'");
			Console.WriteLine ("What mode would you like to have?");
			Console.WriteLine ("Computer Guess ({0}) or Player Guess ({1})", ComputerChoice, PlayerChoice);
			string modeChoice = Console.ReadLine ().ToUpper();
            
            //Input validation
            while (!(modeChoice == ComputerChoice || modeChoice == PlayerChoice))
            {
                Console.WriteLine("Please enter a valid answer");
                Console.WriteLine("Computer Guess (C) or Player Guess (P)");
                modeChoice = Console.ReadLine().ToUpper();
            }

			Console.WriteLine (string.Format ("You chose: {0} ", modeChoice));

            //Player choice
            if (modeChoice == PlayerChoice)
            {
                SolvedEvent se = delegate () {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The number was correct!");
                    Console.ResetColor();
                };

                Random rand = new Random();

                NumberGuesser guesser = new NumberGuesser(rand.Next(0, 101), se);

                while (!guesser.Solved)
                {
                    Console.Write("Please enter your desired number: ");
                    string input = Console.ReadLine();
                    int numberInput;
                    if (int.TryParse(input, out numberInput))
                    {
                        if (NumberGuesser.IsValid(numberInput))
                        {
                            GuessValue guess = guesser.MakeGuess(numberInput);

                            if (guess != GuessValue.Correct)
                            {
                                Console.Write("The number is ");
                                Console.ForegroundColor = (guess == GuessValue.Higher ? ConsoleColor.Cyan : ConsoleColor.Blue);
                                Console.Write(guess.ToString().ToLower() + "\n");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Your number is not between 0 and 100");
                            Console.ResetColor();
                            continue;
                        }
                    }
                    else if (input.ToLower() == "q")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Exiting... ");
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a whole number in interger form e.g. 1");
                        Console.ResetColor();
                    }
                }
            }
            else if (modeChoice == ComputerChoice)
            {
                Console.WriteLine("Computer choice is currently being implemented");
                Console.WriteLine(Console.ReadKey().Key);
                Console.ReadKey();
            }
			
		}
	}
}
