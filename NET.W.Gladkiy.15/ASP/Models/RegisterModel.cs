using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class RegisterModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password1 { get; set; }

        public string Password2 { get; set; }
    }
}