
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reminder_Shared.Entities;

public class UsersProfileEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public int UserId { get; set; }
    public UsersEntity User { get; set; } = null!;

}
