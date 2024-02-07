using Reminder_Shared.Dto;
using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services;

public class ReminderService(ReminderRepository reminderRepository, ReminderStatusRepository reminderStatusRepository, UsersRepository usersRepository, CategoryRepository categoryRepository)
{
    private readonly ReminderRepository _reminderRepository = reminderRepository;
    private readonly ReminderStatusRepository _reminderStatusRepository = reminderStatusRepository;
    private readonly UsersRepository _usersRepository = usersRepository;
    private readonly CategoryRepository _categoryRepository = categoryRepository;



    public ReminderEntity CreateReminder(ReminderDTO reminder)
    {

        var categoryEntity = _categoryRepository.Get(x => x.CategoryName ==  reminder.CategoryName);
        categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = reminder.CategoryName });

        var reminderStatus = _reminderStatusRepository.Get(x => x.IsActive == reminder.IsActive);
        reminderStatus = _reminderStatusRepository.Create(new ReminderStatusEntity { IsActive = reminder.IsActive });

        var userEntity = _usersRepository.Get(x => x.Email == reminder.Email);
        userEntity = _usersRepository.Create(new UsersEntity { Email = reminder.Email });



        var reminderEntity = new ReminderEntity
        {
            Title = reminder.Title,
            Description = reminder.Description,
            DueDate = reminder.DueDate,
            UserId = userEntity.Id,
            CategoryId = categoryEntity.Id,
            ReminderStatusId = reminderStatus.Id


        };
        reminderEntity = _reminderRepository.Create(reminderEntity);
        return reminderEntity;
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
