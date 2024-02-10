
using Microsoft.EntityFrameworkCore;
using Reminder_Shared.Context;
using Reminder_Shared.Entities;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Reminder_Shared.Repositories;

public class ReminderRepository : BaseRepository<ReminderEntity>
{
    private readonly DataContext _context;
    public ReminderRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override ReminderEntity Get(Expression<Func<ReminderEntity, bool>> predicate)
    {
        try
        {
            var entity = _context.Reminders.Include(i => i.Category).Include(i => i.ReminderStatus).FirstOrDefault(predicate);
            return entity!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public override IEnumerable<ReminderEntity> GetAll()
    {
        try
        {
            return _context.Reminders.Include(i => i.Category).Include(i => i.ReminderStatus).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<ReminderEntity>();
        }
    }

    public override IEnumerable<ReminderEntity> GetAllById(Expression<Func<ReminderEntity, bool>> predicate)
    {
        try
        {
            return _context.Reminders.Include(i => i.Category).Include(i => i.ReminderStatus).Where(predicate).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<ReminderEntity>();
        }
    }
}
