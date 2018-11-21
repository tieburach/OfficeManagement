using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace OfficesManagement.ViewModel
{
    internal class ListOfPersons
    {
        public ObservableCollection<Person> Items { get; set; }
        public Person SelectedItem { get; set; }
        public RelayCommand RemovePersonsButton { get; set; }

        public ListOfPersons()
        {
            RemovePersonsButton = new RelayCommand(pars => RemovePersons());
        }

        private void RemovePersons()
        {
            MessageBoxResult result = MessageBox.Show("Zaraz usuniesz element. Czy jesteś tego pewien?",
                          "Usuwanie elementu.",
                          MessageBoxButton.YesNo,
                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                PersonsList.PersonList.Remove(SelectedItem);
                var dataGrid = (DataGrid)MainWindow.ListOfPersonsForm.FindName("Sampledatagrid");
                dataGrid.ItemsSource = PersonsList.PersonList;
            }


        }
    }
}