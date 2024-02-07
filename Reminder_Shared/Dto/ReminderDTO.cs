
namespace Reminder_Shared.Dto;

public class ReminderDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DueDate { get; set; }
    public string CategoryName { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public string Email { get; set; } = null!;

}
