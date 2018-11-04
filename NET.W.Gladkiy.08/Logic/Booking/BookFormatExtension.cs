namespace BookFormatExtension
{
    using System.Text;
    using Logic.BookingSystem;

    public static class BookFormatExtension
    {
        /// <summary>Gets book string representation with price</summary>
        /// <param name="book">book to get string representation</param>
        /// <returns>short book string representation with price</returns>
        public static string ToRegionalPricedFormat(this Book book)
        {
            var sb = new StringBuilder();
            sb.Append(book.ToShortString() + ", ");
            sb.AppendFormat("{0:C}", book.Price);
            return sb.ToString();
        }
    }
}
