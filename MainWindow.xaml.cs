using System.Windows;
using PasswordAnalyzer.ViewModels;

namespace PasswordAnalyzer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}