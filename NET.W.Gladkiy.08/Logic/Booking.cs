namespace BookingSystem
{
    using System;
    using System.Collections.Generic;
    using Logic.BookingSystem;
    using NLog;
    using NLog.Config;
    using NLog.Targets;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Setup logger
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget("filetarget")
            {
                FileName = "${basedir}/BookingSystem.log",
                Layout = "[${level}] [${longdate}] --- ${message}"
            };
            config.AddTarget(fileTarget);
            config.AddRuleForAllLevels("filetarget");
            LogManager.Configuration = config;
            
            // Try to load library
            var library = new BookListStorage();
            if (library.LoadFromDisk("library.dat"))
            {
                Console.WriteLine("Library loaded from disk!");
            }
            else
            {
                // Fill library
                try
                {
                    library.AddBook(new Book("123-4-56789-123-1", "Mikk", "M.NET", "MPub", 2010, 75, 15));
                    library.AddBook(new Book("123-4-56789-123-2", "Mikk", "M.NET", "MPub", 2013, 85, 25));
                    library.AddBook(new Book("123-4-56789-123-3", "Mikk", "M.NET", "MPub", 2015, 95, 35));
                    library.AddBook(new Book("123-4-55555-111-0", "Gravitonas", "LStar", "UPub", 2015, 75, 25));
                    library.AddBook(new Book("123-4-55555-333-0", "J. Richter", "CLR via C#", "UPub", 2010, 950, 50));
                    Console.WriteLine("Created book library:");
                }
                catch
                {
                    Console.WriteLine("Can't add book!");
                }
            }

            if (library.IsEmpty)
            {
                Console.WriteLine("Library is empty!");
            }
            else
            {
                library.PrintLibrary(Console.Out);
            }

            Console.WriteLine();

            // Remove book
            try
            {
                library.RemoveBook("123-4-55555-111-0");
                Console.WriteLine("After removing book:");
                if (library.IsEmpty)
                {
                    Console.WriteLine("Library is empty!");
                }
                else
                {
                    library.PrintLibrary(Console.Out);
                }
            }
            catch
            {
                Console.WriteLine("Cant' remove book!");
            }

            Console.WriteLine();

            // Find books by tag
            List<Book> books = library.FindBooksByTag(BookListService.TAG.AUTHOR, "Mikk");
            Console.WriteLine("Searching books:");
            if (books.Count == 0)
            {
                Console.WriteLine("No results found!");
            }
            else
            {
                Console.WriteLine(string.Join<Book>("\n", books));
            }

            Console.WriteLine();
            
            // Sort books by tag
            library.SortBooksByTag(BookListService.TAG.ISBN);
            Console.WriteLine("After sorting library:");
            if (library.IsEmpty)
            {
                Console.WriteLine("Library is empty!");
            }
            else
            {
                library.PrintLibrary(Console.Out);
            }

            Console.WriteLine();

            // Try to save library
            if (library.SaveToDisk("library.dat"))
            {
                Console.WriteLine("Library saved to disk!");
            }
            else
            {
                Console.WriteLine("Can't save library!");
            }

            Console.WriteLine();
        }
    }
}
