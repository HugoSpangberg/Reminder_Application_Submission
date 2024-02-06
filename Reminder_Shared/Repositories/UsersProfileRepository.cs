
using Reminder_Shared.Context;
using Reminder_Shared.Entities;

namespace Reminder_Shared.Repositories;

public class UsersProfileRepository : BaseRepository<UsersProfileEntity>
{
    public UsersProfileRepository(DataContext context) : base(context)
    {
    }
}
