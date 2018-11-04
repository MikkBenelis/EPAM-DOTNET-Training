namespace Logic.BookingSystem
{
    using System;
    using System.Collections.Generic;

    public class BookTagComparer : IComparer<Book>
    {
        /// <summary>Comparsion tag</summary>
        private BookListService.TAG _tag;

        /// <summary>Comparer constructor</summary>
        /// <param name="tag">compargion tag</param>
        public BookTagComparer(BookListService.TAG tag)
        {
            _tag = tag;
        }

        /// <summary>Tag comparer</summary>
        /// <param name="x">first object to compare</param>
        /// <param name="y">second object to compare</param>
        /// <returns></returns>
        public int Compare(Book x, Book y)
        {
            switch (_tag)
            {
                case BookListService.TAG.ISBN:
                    return x.ISBN.CompareTo(y.ISBN);
                case BookListService.TAG.AUTHOR:
                    return x.Author.CompareTo(y.Author);
                case BookListService.TAG.TITLE:
                    return x.Title.CompareTo(y.Title);
                case BookListService.TAG.PUBLISHER:
                    return x.Publisher.CompareTo(y.Publisher);
                case BookListService.TAG.YEAR:
                    return x.Year.CompareTo(y.Year);
                case BookListService.TAG.PAGES:
                    return x.Pages.CompareTo(y.Pages);
                case BookListService.TAG.PRICE:
                    return x.Price.CompareTo(y.Price);
            }

            throw new ArgumentException();
        }
    }
}
