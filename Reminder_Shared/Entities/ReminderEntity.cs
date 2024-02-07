
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reminder_Shared.Entities;

public class ReminderEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }


    public int UserId { get; set; }
    public UsersEntity User { get; set; } = null!;

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;

    public int ReminderStatusId { get; set; }
    public ReminderStatusEntity ReminderStatus { get; set; } = null!;

}
