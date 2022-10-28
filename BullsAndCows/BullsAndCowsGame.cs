using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private string secret;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var guessDigits = guess.Split(" ");
            var secretDigits = secret.Split(" ");

            var countCows = CountCows(guessDigits, secretDigits);
            var countBulls = CountBulls(guessDigits, secretDigits);

            return $"{countBulls}A{countCows - countBulls}B";
        }

        private int CountCows(string[] guessDigits, string[] secretDigits)
        {
            var countCows = guessDigits.Count(t => secretDigits.ToList().Contains(t));
            return countCows;
        }

        private int CountBulls(string[] guessDigits, string[] secretDigits)
        {
            int countBulls = secretDigits.Where((digit, index) => digit == guessDigits[index]).Count();
            return countBulls;
        }
    }
}