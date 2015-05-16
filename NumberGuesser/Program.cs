using System;

namespace NumberGuesser
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Welcome to the 'Number Guesser!'");
			/*
			Console.WriteLine ("What mode would you like to have?");
			Console.WriteLine ("Computer Guess (C) or Player Guess (P)");
			string modeChoice = Console.ReadLine ();
			Console.WriteLine (string.Format ("You chose: {0} ", modeChoice));
            */
			SolvedEvent se = delegate() {
                Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("The number was correct!");
                Console.ResetColor ();
			};

			NumberGuesser guesser = new NumberGuesser (10, se);

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
                            Console.Write(guess.ToString ().ToLower () + "\n");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your number is not between 0 and 100");
                        continue;
                    }
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Please enter a whole number in interger form e.g. 1");
                    Console.ResetColor();
                }
            }
		}
	}
}
