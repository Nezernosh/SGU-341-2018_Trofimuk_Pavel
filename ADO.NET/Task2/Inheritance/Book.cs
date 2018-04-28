using System;
using System.IO;

namespace ADO.NET.Inheritance
{
    public class Book
    {
        private string _name;
        private int _pageAmount;
        private string _publisher;
        private DateTime _publishingDate;
        private DateTime _writingDate;
        private Author _author;

        public Book() { }

        public Book(string name, int pageAmount, string publisher, DateTime publishingDate, 
            DateTime writingDate, Author author)
        {
            Name = name;
            PageAmount = pageAmount;
            Publisher = publisher;
            Author = author;
            WritingDate = writingDate;
            PublishingDate = publishingDate;      
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

        public int PageAmount
        {
            get => _pageAmount;
            set
            {
                if (value <= 0)
                {
                    throw new InvalidDataException("Found not positive amount of pages");
                }

                _pageAmount = value;
            }
        }

        public string Publisher
        {
            get => _publisher;
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidDataException("Found empty or null publisher value");
                }

                _publisher = value;
            }
        }

        public DateTime PublishingDate
        {
            get => _publishingDate;
            set
            {
                if (value.Date.Year < Author.BirthYear || value.Date < WritingDate.Date)
                {
                    throw new InvalidDataException("Publishing date can't be " +
                        "early than author's birth year or writing date");
                }

                _publishingDate = value;
            }
        }

        public DateTime WritingDate
        {
            get => _writingDate;
            set
            {
                if (value.Date.Year < Author.BirthYear)
                {
                    throw new InvalidDataException("Writing date can't be " +
                        "early than author's birth year");
                }

                _writingDate = value;
            }
        }

        public Author Author
        {
            get => _author;
            set
            {
                _author = value ?? throw new InvalidDataException("Found null author value");
            }
        }
    }
}
