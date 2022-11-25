using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConstructerAndDipose
{
    public class SimpleReverseService : IDisposable
    {
        const string INPUT = "input";
        private static readonly Regex RESTRICTSPECIALCHARACTERS = new Regex(@"[^a-zA-Z0-9\s]");

        public string SimpleReverse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(INPUT, "Input Cannot be Empty");

            }

            if (RESTRICTSPECIALCHARACTERS.IsMatch(input))
            {

                throw new ArgumentException("Special Characters are not allowed", INPUT);
            }

            string reverseString = string.Join(" ", input.Split(' ').Reverse());
            return reverseString;

        }
        public void Dispose()
        {
            //Clean up Dispose
        }
    }

}