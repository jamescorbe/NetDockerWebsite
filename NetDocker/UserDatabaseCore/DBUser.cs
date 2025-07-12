using System.ComponentModel.DataAnnotations;

namespace UserDatabaseCore
{
    public class DBUser
    {
        [Key]
        public string UserID { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
