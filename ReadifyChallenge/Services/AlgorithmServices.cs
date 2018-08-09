using System;

namespace ReadifyChallenge.Services
{
    public interface IAlgorithmServices
    {
        long CalculateFibonacci(long n);
        string GetReversedSentence(string sentence);
    }

    public class AlgorithmServices: IAlgorithmServices
    {
        /// <summary>
        /// Calculates the nth fibonacci number.
        /// </summary>
        /// <returns>The fibonacci.</returns>
        /// <param name="n">N.</param>
        public long CalculateFibonacci(long n)
        {
            if (!Helpers.IsWithinInputRange(n))
                throw new ArgumentException();
            
            if (n < 0)
                return ((long)Math.Pow(-1, n+1)) * CalculateFibonacci(-1 * n);
            
            long result = 0;
            long previous = 1;

            for (long i = 0; i < n; i++)
            {
                long temp = result;
                result = previous;
                previous = temp + previous;

            }
            return result;
        }

        /// <summary>
        /// Gets the reversed words in a sentence.
        /// </summary>
        /// <returns>The sentence with reversed words.</returns>
        /// <param name="sentence">Sentence.</param>
        public string GetReversedSentence(string sentence)
        {
            string reversedString = "";

            if (string.IsNullOrEmpty(sentence))
                return reversedString;

            string[] sentenceArray = sentence.Split(' ');

            foreach(var item in sentenceArray)
            {
                reversedString += (" " + GetSingleWordReversed(item));
            }

            return reversedString.Trim();
        }

        private string GetSingleWordReversed(string word)
        {
            string reversedWord = "";
            char[] wordsArray = word.ToCharArray();
            for (int i = word.Length - 1; i >= 0; i--)
            {
                reversedWord += wordsArray[i];
            }

            // Or just simply use: reversedWord = new string(Array.Reverse(wordsArray));
            return reversedWord;
        }

        /// Recursive approach Not Recommended
        /// The response time for larger numbers is too long 
        /*
        private long CalculateFibonacciRecursive(long n)
        {
            if (n < 0)
                return ((long)Math.Pow(-1, n)) * CalculateFibonacci(n);
            if (n == 0 || n == 1)
                return n;
            else
                return CalculateFibonacciRecursive(n - 1) + CalculateFibonacciRecursive(n - 2);
        }
        */
    }
}
