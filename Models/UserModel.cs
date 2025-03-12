using System.ComponentModel.DataAnnotations;

namespace ADD_DABOMPA.Models
{
    public class UserModel
    {
        [Key] // Marks this property as the primary key
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}
