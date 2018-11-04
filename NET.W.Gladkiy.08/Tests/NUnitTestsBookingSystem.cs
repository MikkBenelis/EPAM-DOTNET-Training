namespace NUnitTests
{
    using System;
    using BookFormatExtension;
    using Logic.BookingSystem;
    using NUnit.Framework;

    [TestFixture]
    public class NUnitTestsBookingSystem
    {
        [Test]
        public void TestShortBookFormat()
        {
            Book book = new Book("978-0-73566-745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 60);
            string expected = "Jeffrey Richter, CLR via C#, 2012";
            Assert.AreEqual(book.ToShortString(), expected);
            Assert.AreEqual(string.Format("{0:S}", book.ToShortString()), expected);
        }

        [Test]
        public void TestFullBookFormat()
        {
            Book book = new Book("978-0-73566-745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 60);
            string expected = "978-0-73566-745-7, Jeffrey Richter, CLR via C#, Microsoft Press, 2012, 826, 60";
            Assert.AreEqual(book.ToFullString(), expected);
            Assert.AreEqual(string.Format("{0:F}", book.ToFullString()), expected);
        }

        [Test]
        public void TestExtendedBookFormat()
        {
            Book book = new Book("978-0-73566-745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 60);
            string expected = "Jeffrey Richter, CLR via C#, 2012, 60,00 ₽";
            Assert.AreEqual(book.ToRegionalPricedFormat(), expected);
        }

        [Test]
        public void TestBookFormatException()
        {
            void CheckFunction()
            {
                Book book = new Book("978-0-73566-745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 60);
                string.Format(string.Format("{0:A}", book));
            }

            Assert.That(CheckFunction, Throws.TypeOf<FormatException>());
        }
    }
}
