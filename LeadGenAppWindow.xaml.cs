using System.Windows;

namespace LeadGenApp
{
    public partial class LeadGenAppWindow : Window
    {
        private LeadGenAppViewModel _viewModel = new();

        public LeadGenAppWindow()
        {
            InitializeComponent();

            DataContext = _viewModel;
        }
    }
}