using System;
using System.IO;

namespace ADO.NET.Inheritance
{
    public class Author
    {
        private string _firstName;
        private string _lastName;
        private int _birthYear;

        public Author() { }

        public Author(string firstName, string lastName, int birthYear)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidDataException("Found empty or null first name value");
                }

                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidDataException("Found empty or null last name value");
                }

                _lastName = value;
            }
        }

        public int BirthYear
        {
            get => _birthYear;
            set
            {
                if (value >= DateTime.Now.Date.Year)
                {
                    throw new InvalidDataException("Birth Year can't be in a future");
                }

                _birthYear = value;
            }
        }  
    }  
}
