
using Reminder_Shared.Context;
using Reminder_Shared.Entities;

namespace Reminder_Shared.Repositories;

public class ReminderStatusRepository : BaseRepository<ReminderStatusEntity>
{
    public ReminderStatusRepository(DataContext context) : base(context)
    {
    }
}
