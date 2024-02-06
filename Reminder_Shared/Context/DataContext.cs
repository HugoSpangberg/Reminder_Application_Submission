
using Microsoft.EntityFrameworkCore;
using Reminder_Shared.Entities;

namespace Reminder_Shared.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ReminderEntity> Reminders { get; set; }
    public DbSet<ReminderStatusEntity> RemindersStatus { get; set;}
    public DbSet<UsersEntity> Users { get; set; }
    public DbSet<UsersProfileEntity> UsersProfile { get; set; }

}
