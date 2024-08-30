using System.Windows;
using LeadGenApp.viewmodels;

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