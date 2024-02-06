
using Reminder_Shared.Context;
using Reminder_Shared.Entities;

namespace Reminder_Shared.Repositories;

public class UsersRepository : BaseRepository<UsersEntity>
{
    public UsersRepository(DataContext context) : base(context)
    {
    }
}
