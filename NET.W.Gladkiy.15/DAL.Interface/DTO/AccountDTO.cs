using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Interface.DTO
{
    public class AccountDTO : IEquatable<AccountDTO>
    {
        [Key]
        public int AccountID { get; set; }

        public decimal Balance { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AccountTypeDTO Type { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as AccountDTO);
        }

        public bool Equals(AccountDTO other)
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
