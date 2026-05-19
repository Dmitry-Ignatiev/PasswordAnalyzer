using System.ComponentModel;
using System.Runtime.CompilerServices;
using PasswordAnalyzer.Services;
using PasswordAnalyzer.Models;

namespace PasswordAnalyzer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _password;
        private int _score;
        private string _strength;

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
            set { _score = value; OnPropertyChanged(); }
        }

        public string Strength
        {
            get => _strength;
            set { _strength = value; OnPropertyChanged(); }
        }

        private void AnalyzePassword()
        {
            var result = _service.Analyze(_password);
            Score = result.Score;
            Strength = result.Strength;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}