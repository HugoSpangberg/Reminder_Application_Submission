
using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services;

public class ReminderStatusService(ReminderStatusRepository reminderStatusRepository)
{
    private readonly ReminderStatusRepository _reminderStatusRepository = reminderStatusRepository;


    public ReminderStatusEntity CreateReminderStatus(bool isActive)
    {
        var reminderStatusEntity = _reminderStatusRepository.Get(x => x.IsActive == false); ;
        reminderStatusEntity ??= _reminderStatusRepository.Create(new ReminderStatusEntity { IsActive = isActive });
        return reminderStatusEntity;
    }

    public IEnumerable<ReminderStatusEntity> GetAllReminderStatus()
    {
        var allReminderStatus = _reminderStatusRepository.GetAll();
        return allReminderStatus;
    }
    public IEnumerable<ReminderStatusEntity> GetCompletedReminders()
    {
        var completedReminders = _reminderStatusRepository.GetAll().Where(x => x.IsActive == false);
        return completedReminders;
    }

    public IEnumerable<ReminderStatusEntity> GetActiveReminders()
    {
        var activeReminders = _reminderStatusRepository.GetAll().Where(x => x.IsActive == true);
        return activeReminders;
    }

    public ReminderStatusEntity UpdateReminderStatus(ReminderStatusEntity categoryEntity)
    {
        var updatedReminderStatusEntity = _reminderStatusRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return updatedReminderStatusEntity;
    }

    public bool DeleteReminderStatus(bool isActive)
    {
        _reminderStatusRepository.Delete(x => x.IsActive == false);
        return isActive;
    }
}
