namespace Logic.BookingSystem
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        #region Fields

        private string _isbn;
        private string _author;
        private string _title;
        private string _publisher;
        private int _year;
        private int _pages;
        private int _price;

        #endregion Fields

        #region Constructors

        /// <summary>Book constructor</summary>
        /// <param name="isbn">book's ISBN number</param>
        /// <param name="author">book's author</param>
        /// <param name="title">book's title</param>
        /// <param name="publisher">book's publishiing house</param>
        /// <param name="year">book's publishing year</param>
        /// <param name="pages">book's pages count</param>
        /// <param name="price">book's price</param>
        public Book(string isbn, string author, string title, string publisher, int year, int pages, int price)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            Pages = pages;
            Price = price;
        }

        #endregion Constructors
        
        #region Properties

        /// <summary>Book's ISBN number</summary>
        public string ISBN
        {
            get => _isbn;
            private set
            {
                var isbnRegex = new Regex(@"\d{3}-\d-\d{5}-\d{3}-\d");
                if (isbnRegex.IsMatch(value))
                {
                    _isbn = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>Book's author</summary>
        public string Author { get => _author; private set => _author = value; }

        /// <summary>Book's title</summary>
        public string Title { get => _title; private set => _title = value; }

        /// <summary>Book's publishing house</summary>
        public string Publisher { get => _publisher; private set => _publisher = value; }

        /// <summary>Book's publishing year</summary>
        public int Year
        {
            get => _year;
            private set
            {
                if (value > 0 && value <= DateTime.Now.Year)
                {
                    _year = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>Book's pages count</summary>
        public int Pages
        {
            get => _pages;
            private set
            {
                if (value > 0)
                {
                    _pages = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>Book's price</summary>
        public int Price
        {
            get => _price;
            private set
            {
                if (value >= 0)
                {
                    _price = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        #endregion Properties

        #region PublicAPI

        /// <summary>GetHashCode</summary>
        /// <returns>int hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = 31;
            hashCode = (hashCode * 31) + ISBN.GetHashCode();
            hashCode = (hashCode * 31) + Author.GetHashCode();
            hashCode = (hashCode * 31) + Title.GetHashCode();
            hashCode = (hashCode * 31) + Publisher.GetHashCode();
            hashCode = (hashCode * 31) + Year.GetHashCode();
            hashCode = (hashCode * 31) + Pages.GetHashCode();
            hashCode = (hashCode * 31) + Price.GetHashCode();
            return hashCode;
        }

        /// <summary>Equals (object)</summary>
        /// <param name="obj">object to compare with</param>
        /// <returns>bool equality result</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Book);
        }

        /// <summary>Equals (Book)</summary>
        /// <param name="other">book to compare with</param>
        /// <returns>bool equality result</returns>
        public bool Equals(Book other)
        {
            return other != null &&
                   ISBN == other.ISBN &&
                   Author == other.Author &&
                   Title == other.Title &&
                   Publisher == other.Publisher &&
                   Year == other.Year &&
                   Pages == other.Pages &&
                   Price == other.Price;
        }

        /// <summary>CompareTo</summary>
        /// <param name="other">book to compare</param>
        /// <returns>int comparsion result</returns>
        public int CompareTo(Book other)
        {
            if (other == null)
            {
                throw new ArgumentException();
            }

            return ISBN.CompareTo(other.ISBN);
        }

        /// <summary>ToString</summary>
        /// <returns>string representation</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("ISBN: " + ISBN);
            sb.Append(", Author: " + Author);
            sb.Append(", Title: " + Title);
            sb.Append(", Publishing: " + Publisher);
            sb.Append(", Year: " + Year);
            sb.Append(", Pages: " + Pages);
            sb.Append(", Price: " + Price);
            return sb.ToString();
        }

        #endregion PublicAPI
    }
}
