using System.Windows;

namespace LeadGenApp
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel = new();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _viewModel;
        }
    }
}