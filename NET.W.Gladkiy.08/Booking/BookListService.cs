namespace Logic.BookingSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class BookListService
    {
        /// <summary>Finding and sorting tag enum</summary>
        public enum TAG
        {
            ISBN, AUTHOR, TITLE, PUBLISHER, YEAR, PAGES, PRICE
        }

        /// <summary>Add book to storage</summary>
        /// <param name="bls">this book storage</param>
        /// <param name="book">book to add</param>
        public static void AddBook(this BookListStorage bls, Book book)
        {
            if (book == null || bls.Library.Contains(book))
            {
                throw new ArgumentException();
            }

            bls.Library.Add(book);
        }

        /// <summary>Remove book from storage</summary>
        /// <param name="bls">this book storage</param>
        /// <param name="isbn">book's isbn identifier</param>
        public static void RemoveBook(this BookListStorage bls, string isbn)
        {
            if (isbn == null)
            {
                throw new ArgumentException();
            }

            bool wasRemoved = false;
            foreach (Book book in bls.Library)
            {
                if (book.ISBN == isbn)
                {
                    wasRemoved = true;
                    bls.Library.Remove(book);
                    break;
                }
            }

            if (!wasRemoved)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>Find books by tag</summary>
        /// <param name="bls">this book storage</param>
        /// <param name="tag">tag to find</param>
        /// <param name="tagData">tag data to find</param>
        /// <returns></returns>
        public static List<Book> FindBooksByTag(this BookListStorage bls, TAG tag, object tagData)
        {
            if (tagData == null)
            {
                throw new ArgumentException();
            }

            var result = new List<Book>();
            foreach (Book book in bls.Library)
            {
                switch (tag)
                {
                    case TAG.ISBN:
                        if (book.ISBN == tagData as string)
                        {
                            result.Add(book);
                        }

                        break;
                    case TAG.AUTHOR:
                        if (book.Author == tagData as string)
                        {
                            result.Add(book);
                        }

                        break;
                    case TAG.TITLE:
                        if (book.Title == tagData as string)
                        {
                            result.Add(book);
                        }

                        break;
                    case TAG.PUBLISHER:
                        if (book.Publisher == tagData as string)
                        {
                            result.Add(book);
                        }

                        break;
                    case TAG.YEAR:
                        if (tagData as int? != null && book.Year == tagData as int?)
                        {
                            result.Add(book);
                        }

                        break;
                    case TAG.PAGES:
                        if (tagData as int? != null && book.Pages == tagData as int?)
                        {
                            result.Add(book);
                        }

                        break;
                    case TAG.PRICE:
                        if (tagData as int? != null && book.Price == tagData as int?)
                        {
                            result.Add(book);
                        }

                        break;
                }
            }

            return result;
        }

        /// <summary>Sort books in storage by tag</summary>
        /// <param name="bls">this book storage</param>
        /// <param name="tag">tag to sort</param>
        public static void SortBooksByTag(this BookListStorage bls, TAG tag)
        {
            // TODO
            bls.Library.Sort(new BookTagComparer(tag));
        }

        /// <summary>Print library to stream</summary>
        /// <param name="bls">this book storage</param>
        /// <param name="tw">output textwritter stream</param>
        public static void PrintLibrary(this BookListStorage bls, TextWriter tw)
        {
            if (tw == null)
            {
                throw new ArgumentException();
            }

            foreach (Book book in bls.Library)
            {
                tw.WriteLine(book);
            }
        }
    }
}
