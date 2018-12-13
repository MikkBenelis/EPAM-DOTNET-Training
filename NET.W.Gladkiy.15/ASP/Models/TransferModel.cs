namespace ASP.Models
{
    public class TransferModel
    {
        public int FromAccountID { get; set; }

        public int ToAccountID { get; set; }
        
        public decimal Amount { get; set; }
    }
}