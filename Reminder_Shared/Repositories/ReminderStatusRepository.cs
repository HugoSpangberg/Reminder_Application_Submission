
using Microsoft.EntityFrameworkCore;
using Reminder_Shared.Context;
using Reminder_Shared.Entities;
using System.Diagnostics;

namespace Reminder_Shared.Repositories;

public class ReminderStatusRepository : BaseRepository<ReminderStatusEntity>
{
    private readonly DataContext _context;
    public ReminderStatusRepository(DataContext context) : base(context)
    {
        _context = context;
    }


}
