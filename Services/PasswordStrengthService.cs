using System.Linq;
using System.Text.RegularExpressions;
using PasswordAnalyzer.Models;

namespace PasswordAnalyzer.Services
{
    public class PasswordStrengthService
    {
        public PasswordResult Analyze(string password)
        {
            int score = 0;

            if (string.IsNullOrEmpty(password))
                return new PasswordResult { Score = 0, Strength = "Empty" };

            if (password.Length >= 8) score += 20;
            if (password.Length >= 12) score += 10;

            if (Regex.IsMatch(password, "[a-z]")) score += 10;
            if (Regex.IsMatch(password, "[A-Z]")) score += 15;
            if (Regex.IsMatch(password, "[0-9]")) score += 15;
            if (Regex.IsMatch(password, "[^a-zA-Z0-9]")) score += 20;

            if (password.Distinct().Count() > 6) score += 10;

            string strength =
                score < 40 ? "Weak" :
                score < 70 ? "Medium" :
                "Strong";

            return new PasswordResult
            {
                Score = score,
                Strength = strength
            };
        }
    }
}