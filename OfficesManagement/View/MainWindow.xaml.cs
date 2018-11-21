using System.Windows;
using XamlCSS.WPF;

namespace OfficesManagement
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Css.Initialize();
            InitializeComponent();
            this.DataContext = new ViewModel.MainWindow();
        }
    }
}
