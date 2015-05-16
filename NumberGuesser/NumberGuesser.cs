using System;

namespace NumberGuesser
{
	public enum GuessValue 
	{
		Lower,
		Higher,
		Correct
	}

	public delegate void SolvedEvent();

	public class NumberGuesser
	{
		public const int MAX_VAL = 100;
		public const int MIN_VAL = 0;

        public static bool IsValid (int numberToTest) 
        {
            return (numberToTest <= MAX_VAL && numberToTest >= MIN_VAL);
        }

		public int GuessesUsed { get; private set;}
	 	public bool Solved { get; private set;}

		int number;

		public NumberGuesser (int _Number)
		{
			if (_Number <= MAX_VAL && _Number >= MIN_VAL) 
			{
				this.number = _Number;
			}
		}

		public NumberGuesser (int _Number, SolvedEvent _OnSolved) : this(_Number)
		{
			this.OnSolved = _OnSolved;
		}

		public GuessValue MakeGuess (int guess) 
		{
			GuessesUsed++;

			if (guess == number) 
			{
				Solved = true;
				OnSolved ();

				return GuessValue.Correct;
			}
			else
			{
				return (guess > number ? GuessValue.Lower : GuessValue.Higher);
			}
		}

		SolvedEvent OnSolved = delegate() {
			//Do Stuff
		};
	}
}

