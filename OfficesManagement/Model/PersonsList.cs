using System.Collections.Generic;

namespace OfficesManagement
{
    class PersonsList : List <Person>
    {
        static List<Person> personList = new List<Person>();

        public PersonsList()
        {
            foreach (Person person in personList){
                this.Add(person);
            }
        }

        internal static List<Person> PersonList { get => personList; set => personList = value; }

        public void AddNewPerson(Person person) {
            this.Add(person);
        }

        public void RemovePerson(Person person){
            this.Remove(person);
        }
    }
}
