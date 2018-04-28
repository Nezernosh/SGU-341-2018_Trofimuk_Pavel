using System.IO;

namespace ADO.NET.Inheritance
{
    public class Man
    {
        private string _name;
        private int _age;
        private double _weight;
        private double _height;
        
        public Man() { }

        public Man(string name, int age, double weight, double height)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidDataException("Found empty or null name value");
                }

                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value <= 0)
                {
                    throw new InvalidDataException("Found not positive age");
                }

                _age = value;
            }
        }
        
        public double Weight
        {
            get => _weight;
            set
            {
                if (value <= 0)
                {
                    throw new InvalidDataException("Found not positive weight");
                }

                _weight = value;
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (value <= 0)
                {
                    throw new InvalidDataException("Found not positive height");
                }

                _height = value;
            }
        }
    }
}
