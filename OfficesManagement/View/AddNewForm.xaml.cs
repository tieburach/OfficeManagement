using System.Windows;

namespace OfficesManagement
{
    public partial class AddNewForm : Window
    {
        public AddNewForm()
        {
            InitializeComponent();
            this.DataContext = new AddNewPersonViewModel();
        }
    }
}
