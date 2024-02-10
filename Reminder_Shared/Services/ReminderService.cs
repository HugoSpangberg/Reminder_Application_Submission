using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Reminder_Shared.Dto;
using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;
using System.Diagnostics;

namespace Reminder_Shared.Services;

public class ReminderService(ReminderRepository reminderRepository, ReminderStatusRepository reminderStatusRepository, UsersRepository usersRepository, CategoryRepository categoryRepository)
{
    private readonly ReminderRepository _reminderRepository = reminderRepository;
    private readonly ReminderStatusRepository _reminderStatusRepository = reminderStatusRepository;
    private readonly UsersRepository _usersRepository = usersRepository;
    private readonly CategoryRepository _categoryRepository = categoryRepository;



    public ReminderEntity CreateReminder(ReminderDTO reminder)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == reminder.CategoryName);
            categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = reminder.CategoryName });

            var reminderStatus = _reminderStatusRepository.Get(x => x.IsActive == reminder.IsActive);

            if (reminderStatus == null)
            {

                reminderStatus = _reminderStatusRepository.Create(new ReminderStatusEntity { IsActive = reminder.IsActive });
            }

            var userEntity = _usersRepository.Get(x => x.Email == reminder.Email);

            if (userEntity == null)
            {

                userEntity = _usersRepository.Create(new UsersEntity { Email = reminder.Email });
            }

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
        catch (Exception ex) 
        {
            Console.WriteLine($"Error creating reminder: {ex.Message}");
            return null!;
        
        }


    }

    public ReminderEntity GetRemindersById(int id)
    {
        try
        {
            var reminderEntity = _reminderRepository.Get(x => x.Id == id);
            return reminderEntity;
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"Error getting reminder by ID: {ex.Message}");
            return null!;
        }

    }

    public IEnumerable<ReminderEntity> GetAllReminders()
    {
        try
        {
            var allReminder = _reminderRepository.GetAll();
            return allReminder;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting all reminders: {ex.Message}");
            return null!;
        }

    }
    public IEnumerable<ReminderEntity> GetRemindersByUserId(int userId)
    {
        try
        {
            var userReminders = _reminderRepository.GetAllById(x => x.UserId == userId);
            return userReminders;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting reminders by User ID: {ex.Message}");
            return null!;
        }
    }

    public ReminderEntity UpdateReminder(ReminderEntity reminderEntity)
    {
        try
        {
            var updatedReminderEntity = _reminderRepository.Update(x => x.Id == reminderEntity.Id, reminderEntity);
            return updatedReminderEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Update reminder: {ex.Message}");
            return null!;
        }
    }

    public bool DeleteReminder(int id)
    {
        try
        {
            var existingReminder = _reminderRepository.Get(x => x.Id == id);

            if (existingReminder != null)
            {
                _reminderRepository.Delete(x => x.Id == id);
                return true;
            }

            return false;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Delete reminder: {ex.Message}");
            return false;
        }
    }

}
