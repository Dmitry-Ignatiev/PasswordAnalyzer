namespace PasswordAnalyzer.Models
{
    public class PasswordResult
    {
        public int Score { get; set; } // 0 - 100
        public string Strength { get; set; }
    }
}