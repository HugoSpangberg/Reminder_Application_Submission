
using Reminder_Shared.Dto;
using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services;

public class ReminderStatusService(ReminderStatusRepository reminderStatusRepository)
{
    private readonly ReminderStatusRepository _reminderStatusRepository = reminderStatusRepository;


    public ReminderStatusEntity CreateReminderStatus(ReminderStatusDTO reminderStatus)
    {
        try
        {
            var reminderStatusEntity = _reminderStatusRepository.Get(x => x.IsActive == false);
            reminderStatusEntity ??= _reminderStatusRepository.Create(new ReminderStatusEntity { IsActive = reminderStatus.IsActive });
            return reminderStatusEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Creating Reminder status: {ex.Message}");
            return null!;
        }
    }

    public IEnumerable<ReminderStatusEntity> GetAllReminderStatus()
    {
        try
        {
            var allReminderStatus = _reminderStatusRepository.GetAll();
            return allReminderStatus;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error All Reminder status: {ex.Message}");
            return null!;
        }

    }
    public IEnumerable<ReminderStatusEntity> GetCompletedReminders()
    {
        try
        {
            var completedReminders = _reminderStatusRepository.GetAll().Where(x => x.IsActive == false);
            return completedReminders;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Getting Completed Reminder: {ex.Message}");
            return null!;
        }
    }

    public IEnumerable<ReminderStatusEntity> GetActiveReminders()
    {
        try
        {
            var activeReminders = _reminderStatusRepository.GetAll().Where(x => x.IsActive);
            return activeReminders;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Getting Active Reminders: {ex.Message}");
            return null!;
        }
    }

    public ReminderStatusEntity UpdateReminderStatus(ReminderStatusEntity categoryEntity)
    {
        try
        {
            var updatedReminderStatusEntity = _reminderStatusRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
            return updatedReminderStatusEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Update Reminder: {ex.Message}");
            return null!;
        }
    }

    public bool DeleteReminderStatus(bool isActive)
    {
        try
        {
            _reminderStatusRepository.Delete(x => x.IsActive == false);
            return isActive;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Update Reminder: {ex.Message}");
            return isActive;
        }
    }
}
