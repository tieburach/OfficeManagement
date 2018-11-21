using System.ComponentModel;
using System.Windows;

namespace OfficesManagement
{
    class AddNewPersonViewModel : INotifyPropertyChanged
    {

        public RelayCommand SavePerson { get; set; }

        public AddNewPersonViewModel()
        {
            SavePerson = new RelayCommand(pars => Save());
        }

        private void Save()
        {
            Person person;

            
                try
                {
                    person = new Person(Name, Surname, Location, gender, double.Parse(Salary));
                    PersonsList.PersonList.Add(person);
                }
                catch (System.Exception)

                {
                    MessageBoxResult result3 = MessageBox.Show("Nie wypełniłeś wszystkich pól prawidłowo. Pamiętaj że zarobki muszą być liczbą.",
                                              "Błąd podczas tworzenia.",
                                              MessageBoxButton.OK,
                                              MessageBoxImage.Warning);
                return;
                }

            if (double.Parse(Salary) > 0)
            {
                MessageBoxResult result = MessageBox.Show("Osoba została dodana prawidłowo.",
                                          "Potwierdzenie.",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);
                ViewModel.MainWindow.AddNewForm.Close();
            }
            else
            {
                        MessageBoxResult result2 = MessageBox.Show("Zarobki nie mogą być liczbą ujemną.",
                      "Błąd.",
                      MessageBoxButton.OK,
                      MessageBoxImage.Warning);


            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private string _Name = null;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _Surname = null;
        public string Surname
        {
            get
            {
                return _Surname;
            }
            set
            {
                _Surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string _Salary = null;
        public string Salary
        {
            get
            {
                return _Salary;
            }
            set
            {
                _Salary = value;
                OnPropertyChanged("Salary");
            }
        }

        private string _Location = null;
        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
                OnPropertyChanged("Location");
            }
        }

        string gender = "";
        private bool _optionMale;
        public bool OptionMale
        {
            get { return _optionMale; }
            set
            {
                _optionMale = value;
                if (_optionMale)
                {
                    this.OptionFemale = false;
                    gender = "Mezczyzna";
                }
            }
        }

        private bool _optionFemale;
        public bool OptionFemale
        {
            get { return _optionFemale; }
            set
            {
                _optionFemale = value;
                if (_optionFemale)
                {
                    this.OptionMale = false;
                    gender = "Kobieta";
                }
            }
        }

        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
