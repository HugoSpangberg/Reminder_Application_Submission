using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services;

public class ReminderService(ReminderRepository reminderRepository, CategoryService categoryService, ReminderStatusService reminderStatusService, UsersService usersService)
{
    private readonly ReminderRepository _reminderRepository = reminderRepository;
    private readonly CategoryService _categoryService = categoryService;
    private readonly ReminderStatusService _reminderStatusService = reminderStatusService;
    private readonly UsersService _usersService = usersService;



    public ReminderEntity CreateReminder(string title, string description, DateTime dueDate)
    {

    }

    public ReminderEntity GetRemindersById(int id)
    {
        var reminderEntity = _reminderRepository.Get(x => x.Id == id);
        return reminderEntity;
    }

    public IEnumerable<ReminderEntity> GetAllReminders()
    {
        var allReminder = _reminderRepository.GetAll();
        return allReminder;
    }

    public ReminderEntity UpdateReminder(ReminderEntity reminderEntity)
    {
        var updatedReminderEntity = _reminderRepository.Update(x => x.Id == reminderEntity.Id, reminderEntity);
        return updatedReminderEntity;
    }

    public bool DeleteReminder(int id)
    {
        _reminderRepository.Delete(x => x.Id == id);
        return true;
    }
}
