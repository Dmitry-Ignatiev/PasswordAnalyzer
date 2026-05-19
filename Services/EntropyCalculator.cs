using System;
using System.Linq;

namespace PasswordAnalyzer.Services
{
    public static class EntropyCalculator
    {
        public static double Calculate(string password)
        {
            if (string.IsNullOrEmpty(password))
                return 0;

            bool hasLower = password.Any(char.IsLower);
            bool hasUpper = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSymbol = password.Any(c => !char.IsLetterOrDigit(c));

            int charsetSize = 0;

            if (hasLower) charsetSize += 26;
            if (hasUpper) charsetSize += 26;
            if (hasDigit) charsetSize += 10;
            if (hasSymbol) charsetSize += 32;

            if (charsetSize == 0)
                return 0;

            return password.Length * Math.Log(charsetSize, 2);
        }
    }
}