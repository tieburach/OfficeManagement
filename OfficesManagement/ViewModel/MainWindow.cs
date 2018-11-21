using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System;

namespace OfficesManagement.ViewModel
{
    class MainWindow
    {
        public RelayCommand AddNewPersonButton { get; set; }
        public RelayCommand ShowPersonListButton { get; set; }
        public RelayCommand LoadDataButton { get; set; }
        public RelayCommand SaveDataButton { get; set; }
        public static AddNewForm AddNewForm { get => addNewForm; set => addNewForm = value; }
        public static ListOfPersonsForm ListOfPersonsForm { get => listOfPersons; set => listOfPersons = value; }

        public static AddNewForm addNewForm;
        public static ListOfPersonsForm listOfPersons;

        public MainWindow()
        {
            AddNewPersonButton = new RelayCommand(pars => AddNewPerson());
            ShowPersonListButton = new RelayCommand(pars => ShowPersonList());
            LoadDataButton = new RelayCommand(pars => LoadData());
            SaveDataButton = new RelayCommand(pars => SaveData());

        }

        private void SaveData()
        {
            try
            {
                string path = "";
                System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.Filter = "XML file (*.xml)|*.xml";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                }
                XDocument doc = new XDocument();
                ObjectXMLSerializer.SerializeParams<Person>(doc, PersonsList.PersonList);
                doc.Save(path);
            } catch (Exception)
             {
                MessageBoxResult result = System.Windows.MessageBox.Show("Nie została wybrana nazwa pliku. Anuluje operację.",
                                          "Błąd",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                XDocument doc = null;
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "XML file (*.xml)|*.xml";
                openFileDialog.Title = "Select a XML File";
                if (openFileDialog.ShowDialog() == true)
                {
                    doc = XDocument.Load(openFileDialog.FileName);
                }
                List<Person> personList = ObjectXMLSerializer.DeserializeParams<Person>(doc);
                foreach (Person person in personList)
                {
                    PersonsList.PersonList.Add(person);
                }
                MessageBoxResult result = System.Windows.MessageBox.Show("Zostały załadowane dane. Czy chcesz przejść do widoku listy?",
                                          "Szybkie przejście",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    listOfPersons = new ListOfPersonsForm();
                    listOfPersons.Show();
                }

            }
            catch (Exception)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Nie wybrany został żaden plik. Anuluje operację.",
                                          "Błąd",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Error);
            }

        }

        private void ShowPersonList()
        {
            listOfPersons = new ListOfPersonsForm();
            listOfPersons.Show();
        }

        private void AddNewPerson()
        {
            addNewForm = new AddNewForm();
            addNewForm.Show();
        }
    }
}
