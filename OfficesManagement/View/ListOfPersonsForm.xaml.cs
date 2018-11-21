using System.Windows;

namespace OfficesManagement
{
    public partial class ListOfPersonsForm : Window
    {
        public ListOfPersonsForm()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.ListOfPersons();
        }
    }
}
