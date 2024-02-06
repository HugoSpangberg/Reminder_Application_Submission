
using System.ComponentModel.DataAnnotations;

namespace Reminder_Shared.Entities
{
    public class UsersEntity
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; } = null!;

        public UsersProfileEntity UserProfile { get; set; } = null!;
    }
}
