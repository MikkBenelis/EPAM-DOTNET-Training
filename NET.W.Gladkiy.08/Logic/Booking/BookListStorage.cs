namespace Logic.BookingSystem
{
    using System.Collections.Generic;
    using System.IO;

    public class BookListStorage
    {
        /// <summary>List of books in library</summary>
        public List<Book> Library { get; } = new List<Book>();

        /// <summary>bool empty library state</summary>
        public bool IsEmpty { get => Library.Count == 0; }

        /// <summary>Load library from disk</summary>
        /// <param name="pathToLoad">path to load file</param>
        public bool LoadFromDisk(string pathToLoad)
        {
            // TODO
            FileStream fs;
            try
            {
                using (fs = new FileStream(pathToLoad, FileMode.Open))
                {
                    if (fs.CanRead)
                    {
                        var br = new BinaryReader(fs);
                        string isbn, author, title, publisher;
                        int year, pages, price;
                        while (fs.Position != fs.Length)
                        {
                            isbn = br.ReadString();
                            author = br.ReadString();
                            title = br.ReadString();
                            publisher = br.ReadString();
                            year = br.ReadInt32();
                            pages = br.ReadInt32();
                            price = br.ReadInt32();
                            Library.Add(new Book(isbn, author, title, publisher, year, pages, price));
                        }

                        return true;
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }

            return false;
        }

        /// <summary>Save library to disk</summary>
        /// <param name="pathToSave">path to save file</param>
        public bool SaveToDisk(string pathToSave)
        {
            // TODO
            FileStream fs;
            try
            {
                using (fs = new FileStream(pathToSave, FileMode.Create))
                {
                    if (fs.CanWrite)
                    {
                        var bw = new BinaryWriter(fs);
                        foreach (Book book in Library)
                        {
                            bw.Write(book.ISBN);
                            bw.Write(book.Author);
                            bw.Write(book.Title);
                            bw.Write(book.Publisher);
                            bw.Write(book.Year);
                            bw.Write(book.Pages);
                            bw.Write(book.Price);
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}
