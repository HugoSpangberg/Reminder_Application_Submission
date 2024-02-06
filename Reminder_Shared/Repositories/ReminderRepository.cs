
using Reminder_Shared.Context;
using Reminder_Shared.Entities;

namespace Reminder_Shared.Repositories;

public class ReminderRepository : BaseRepository<ReminderEntity>
{
    public ReminderRepository(DataContext context) : base(context)
    {
    }
}
