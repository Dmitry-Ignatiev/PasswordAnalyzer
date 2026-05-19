using System.Windows;

namespace PasswordAnalyzer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new global::PasswordAnalyzer.ViewModels.MainViewModel();
        }
    }
}