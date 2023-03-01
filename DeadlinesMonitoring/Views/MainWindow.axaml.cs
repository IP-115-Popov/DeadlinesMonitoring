using Avalonia.Controls;
using DeadlinesMonitoring.ViewModels;

namespace DeadlinesMonitoring.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
