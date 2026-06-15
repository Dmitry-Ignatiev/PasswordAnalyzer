namespace PasswordAnalyzer.Models
{
    public class PasswordResult
    {
        // Score from 0 to 100
        public int Score { get; set; }

        // Human-readable strength
        public string Strength { get; set; } = "";

        // Whether the password appears in the common-password list
        public bool IsCommonPassword { get; set; } = false;
    }
}