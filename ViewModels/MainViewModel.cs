using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using PasswordAnalyzer.Services;

namespace PasswordAnalyzer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _password = "";
        private int _score;
        private string _strength = "";

        private readonly PasswordStrengthService _service = new();

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
                AnalyzePassword();
            }
        }

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(BarColor));
            }
        }

        public string Strength
        {
            get => _strength;
            set
            {
                _strength = value;
                OnPropertyChanged();
            }
        }

        public Brush BarColor
        {
            get
            {
                if (Score < 40)
                    return Brushes.Red;

                if (Score < 70)
                    return Brushes.Orange;

                return Brushes.Green;
            }
        }

        private void AnalyzePassword()
        {
            var result = _service.Analyze(_password);

            double entropy = EntropyCalculator.Calculate(_password);

            // 🔥 convert entropy → score
            int score = (int)(entropy * 2);

            if (score > 100)
                score = 100;

            Score = score; // ✅ THIS WAS MISSING

            Strength = result.Strength;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}