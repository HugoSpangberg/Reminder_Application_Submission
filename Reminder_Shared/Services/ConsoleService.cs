
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Reminder_Shared.Dto;
using Reminder_Shared.Entities;

namespace Reminder_Shared.Services
{
    
    public class ConsoleService(UsersService usersService, ReminderService reminderService, CategoryService categoryService)
    {
        private readonly UsersService _usersService = usersService;
        private readonly ReminderService _reminderService = reminderService;
        private readonly CategoryService _categoryService = categoryService;


        private readonly UsersDTO _userDto = new();
        private readonly ReminderDTO _reminderDto = new();
        private readonly CategoryDTO _categoryDto = new();
        private readonly ReminderStatusDTO _reminderStatusDto = new();
        public void MenuService()
        {
            Console.Clear();
            Console.WriteLine("\n\t------ Login ------");
            Console.WriteLine("\t Enter Email: ");
            _userDto.Email = Console.ReadLine()!.Trim().ToLower(); ;
            var emailExist = _usersService.GetUserByEmail(_userDto);
            bool isRunning;
            if (emailExist != null)
            {
                Console.Clear();
                Console.WriteLine($"Email: {emailExist.Email} is now logged in.");
                Console.Write("Press any key to continue...");
                isRunning = true;
                Console.ReadKey();

            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Email dose not exist, Create a new one:");
                _userDto.Email = Console.ReadLine()!.Trim().ToLower();
                var newEmail = _usersService.CreateUser(_userDto);
                Console.WriteLine($"Email: {newEmail.Email} was created");
                Console.Write("Press any key to continue...");
                isRunning = true;
                Console.ReadKey();
            }

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine($"\n\t----- Reminder App | <{_userDto.Email}> -----");
                Console.WriteLine("\n\t [1] - Create a New Reminder");
                Console.WriteLine("\t [2] - View a Reminder");
                Console.WriteLine("\t [3] - View all Reminder");
                Console.WriteLine("\t [4] - View Active Reminders");
                Console.WriteLine("\t [5] - Delete a Reminder");
                Console.WriteLine("\t [0] - Logout");

                var option = int.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 1:
                        CreateReminder();
                        break;
                    case 2:
                        ViewReminder();
                        break;
                    case 3:
                        ViewAllReminders();
                        break;
                    case 4:
                        ViewActiveReminders();
                        break;
                    case 5:
                        DeleteReminder();
                        break;
                    case 0:
                        isRunning = false;
                        break;


                }

                Console.ReadKey();

                
            }

            

        }
        private void CreateReminder()
        {
            Console.Clear();
            Console.WriteLine($"\n\t----- Create a New Reminder -----");
            Console.Write("Title: ");
            _reminderDto.Title = Console.ReadLine()!;
            Console.Write("Description: ");
            _reminderDto.Description = Console.ReadLine()!;
            Console.Write("Due date (yyyy-mm-dd): ");
            _reminderDto.DueDate = DateTime.Parse(Console.ReadLine()!);
            Console.Write("Category: ");
            _reminderDto.CategoryName = Console.ReadLine()!;
            _reminderDto.Email = _userDto.Email;
            _reminderDto.IsActive = _reminderStatusDto.IsActive;
            

            _reminderService.CreateReminder( _reminderDto );
            
            
            
            
        }

        private void ViewReminder()
        {

        }

        private void ViewActiveReminders()
        {
            
        }

        private void ViewAllReminders()
        {
            
        }


        private void DeleteReminder()
        {

        }


    }
}
