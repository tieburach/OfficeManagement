using System.Collections.Generic;

namespace OfficesManagement
{
    public class Person
    {
        string name;
        string surname;
        string location;
        string gender;
        double salary;

        public Person() {
        }

        public Person(string name, string surname, string location, string gender, double salary)
        {
            this.name = name;
            this.surname = surname;
            this.location = location;
            this.gender = gender;
            this.salary = salary;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public double Salary { get => salary; set => salary = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Location { get => location; set => location = value; }
    }
}

