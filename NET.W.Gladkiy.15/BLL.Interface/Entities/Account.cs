namespace BLL.Interface.Entities
{
    using System;
    using System.Text;

    public class Account : IEquatable<Account>
    {
        public int AccountID { get; set; }

        public decimal Balance { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AccountType Type { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Account);
        }

        public bool Equals(Account other)
        {
            return other != null &&
                   AccountID == other.AccountID &&
                   Balance == other.Balance &&
                   FirstName == other.FirstName &&
                   LastName == other.LastName &&
                   Type == other.Type;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"ID={AccountID}; ");
            sb.Append($"Balance={Balance}; ");
            sb.Append($"FirstName={FirstName}; ");
            sb.Append($"LastName={LastName}; ");
            sb.Append($"Type={Type}");
            return sb.ToString();
        }
    }
}
