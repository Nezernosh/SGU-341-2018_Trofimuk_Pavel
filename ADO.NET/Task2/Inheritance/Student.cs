using System;
using System.IO;

namespace ADO.NET.Inheritance
{
    public class Student : Man
    {
        private int _educationStartYear;
        private int _courseNumber;
        private string _groupNumber;

        public Student() { }
        
        public Student(string name, int age, double weight, double height, 
            int educationStartYear, int courseNumber, string groupNumber) 
            : base(name, age, weight, height)
        {
            EducationStartYear = educationStartYear;
            CourseNumber = courseNumber;
            GroupNumber = groupNumber;
        }

        public int EducationStartYear
        {
            get => _educationStartYear;
            set
            {
                if (value > DateTime.Now.Year)
                {
                    throw new InvalidDataException("Education start year can't be early than birth date");
                }

                _educationStartYear = value;
            }
        }

        public int CourseNumber
        {
            get => _courseNumber;
            set
            {
                if (value <= 0)
                {
                    throw new InvalidDataException("Found not positive course number");
                }

                _courseNumber = value;
            }
        }

        public string GroupNumber
        {
            get => _groupNumber;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidDataException("Found empty or null group number value");
                }

                _groupNumber = value;
            }
        }

    }
}
