﻿
using System.ComponentModel.DataAnnotations;

namespace Reminder_Shared.Entities;

public class ReminderStatusEntity
{
    [Key]
    public int Id { get; set; }
    public bool IsActive { get; set; } = false;

    public ICollection<ReminderEntity> Reminders { get; set; } = new List<ReminderEntity>();

}
