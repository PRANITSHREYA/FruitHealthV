using System.ComponentModel.DataAnnotations;

namespace FruitHealth.Areas.Identity.Data
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Key]
        public string Email { get; set; }

        public string Password { get; set; }
        
    }
}
