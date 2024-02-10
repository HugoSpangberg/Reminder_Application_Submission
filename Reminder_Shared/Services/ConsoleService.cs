
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Reminder_Shared.Dto;
using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services
{
    
    public class ConsoleService(UsersService usersService, ReminderService reminderService, CategoryService categoryService, UsersRepository usersRepository, ReminderStatusService reminderStatusService)
    {
        private readonly UsersService _usersService = usersService;
        private readonly ReminderService _reminderService = reminderService;
        private readonly CategoryService _categoryService = categoryService;
        private readonly UsersRepository _usersRepository = usersRepository;
        private readonly ReminderStatusService _reminderStatusService = reminderStatusService;


        private readonly UsersDTO _userDto = new();
        private readonly ReminderDTO _reminderDto = new();
        private readonly CategoryDTO _categoryDto = new();
        private readonly ReminderStatusDTO _reminderStatusDto = new();


        public void MenuService()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("\n\t------ Login ------");
                Console.WriteLine("\t Enter Email: ");
                _userDto.Email = Console.ReadLine()!.Trim().ToLower(); ;
                var emailExist = _usersService.GetUserByEmail(_userDto);
                bool LoginRun;
                if (emailExist != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Email: {emailExist.Email} is now logged in.");
                    Console.Write("Press any key to continue...");
                    LoginRun = true;
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
                    LoginRun = true;
                    Console.ReadKey();
                }

                while (LoginRun)
                {
                    Console.Clear();
                    Console.WriteLine($"\n\t----- Reminder App | <{_userDto.Email} > -----");
                    Console.WriteLine("\n\t [1] - Create a New Reminder");
                    Console.WriteLine("\t [2] - View a Reminder");
                    Console.WriteLine("\t [3] - View all Reminder");
                    Console.WriteLine("\t [4] - View Active Reminders");
                    Console.WriteLine("\t [5] - Delete a Reminder");
                    Console.WriteLine("\t [6] - Logout");
                    Console.WriteLine("\t [0] - Exit Application");


                    var option = Console.ReadLine()!;


                    switch (option)
                    {
                        case "1":
                            CreateReminder();
                            break;
                        case "2":
                            ViewReminder();
                            break;
                        case "3":
                            ViewAllReminders();
                            break;
                        case "4":
                            ViewActiveReminders();
                            break;
                        case "5":
                            DeleteReminder();
                            break;
                        case "6":
                            LoginRun = false;
                            break;

                        case "0":
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("\tUnvalid Option. Try again..");
                            Console.Write("Press any key to continue...");
                            
                            break;


                    }

                    Console.ReadKey();
                }
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
            Console.Clear();
            Console.Write("Press any key to continue...");
        }

        private void ViewReminder()
        {
            Console.Clear();
            Console.WriteLine("\n\t----- View a Reminder -----");
            Console.Write("Enter the ID of the reminder you want to view: ");
            if (int.TryParse(Console.ReadLine(), out int reminderId))
            {
                var reminder = _reminderService.GetRemindersById(reminderId);
                Console.Clear();
                if (reminder != null)
                {
                    Console.WriteLine($"\n\t----- ID {reminder.Id} -----");
                    Console.WriteLine($"\tTitle: {reminder.Title}");
                    Console.WriteLine($"\tDescription: {reminder.Description}");
                    Console.WriteLine($"\tDue Date: {reminder.DueDate}");
                    Console.WriteLine($"\tCategory: {reminder.Category.CategoryName}");


                    Console.Write("\nDo you want to update this reminder? (y/n): ");
                    var response = Console.ReadLine()?.ToLower();

                    if (response == "y")
                    {
                        UpdateReminder(reminder);

                    }

                }
                else
                {
                    Console.WriteLine("Reminder not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid reminder ID.");
            }

            Console.Write("\nPress any key to continue...");
        }

        private void UpdateReminder(ReminderEntity reminder)
        {
            Console.Clear();
            Console.WriteLine($"\n\t----- ID {reminder.Id} -----");
            Console.WriteLine($"\tTitle: {reminder.Title}");
            Console.WriteLine($"\tDescription: {reminder.Description}");
            Console.WriteLine($"\tDue Date: {reminder.DueDate}");
            Console.WriteLine($"\tCategory: {reminder.Category.CategoryName}");

            Console.WriteLine("Mark this reminder as Done (y/n): ");
            var response = Console.ReadLine()?.ToLower();

            if (response == "y")
            {

                var newReminderStatus = new ReminderStatusEntity
                {
                    IsActive = false 
                };

                reminder.ReminderStatus = newReminderStatus;
            }
            else
            {
                Console.WriteLine("\n\t----- Update Reminder -----");
                Console.Write("New Title: ");
                reminder.Title = Console.ReadLine()!;
                Console.Write("New Description: ");
                reminder.Description = Console.ReadLine()!;
                Console.Write("New Due date (yyyy-mm-dd): ");
                reminder.DueDate = DateTime.Parse(Console.ReadLine()!);
                reminder.Category.CategoryName = Console.ReadLine()!;


                _reminderService.UpdateReminder(reminder);
                Console.Clear();
                Console.WriteLine("Reminder updated successfully.");
                Console.Write("\nPress any key to continue...");
            }

        }

        //private void createuserprofile()
        //{
        //    console.writeline($"\n\t----- user profile settings -----");
        //    console.writeline($"user: {_userdto.email}");
        //    console.write("first name: ");
        //    _userdto.firstname = console.readline()!;
        //    console.write("last name: ");
        //    _userdto.lastname = console.readline()!;

        //}


        private void ViewActiveReminders()
        {
            var activeReminders = _reminderStatusService.GetActiveReminders();

            Console.Clear();
            Console.WriteLine($"\n\t----- View Active Reminders -----");

            foreach (var reminderStatus in activeReminders)
            {
                foreach (var reminder in reminderStatus.Reminders)
                {
                    Console.WriteLine($"\n\t----- ID {reminder.Id} -----");
                    Console.WriteLine($"\t{reminder.Title}");
                    Console.WriteLine($"\t{reminder.Description}");
                    Console.WriteLine($"\t{reminder.DueDate}");
                    Console.WriteLine($"\t{reminder.Category.CategoryName}");
                    Console.WriteLine($"\t{(reminder.ReminderStatus.IsActive ? "Not done" : "Done")}");
                }
            }

            Console.Write("\nPress any key to continue...");
        }



        private void ViewAllReminders()
        {
            var userEntity = _usersRepository.Get(x => x.Email == _userDto.Email);

            if (userEntity != null)
            {
                var userReminders = _reminderService.GetRemindersByUserId(userEntity.Id);

                Console.Clear();
                Console.WriteLine($"\n\t----- View All Reminders -----");

                foreach (var reminder in userReminders)
                {
                    Console.WriteLine($"\n\t----- ID {reminder.Id} -----");
                    Console.WriteLine($"\t{reminder.Title}");
                    Console.WriteLine($"\t{reminder.Description}");
                    Console.WriteLine($"\t{reminder.DueDate}");
                    Console.WriteLine($"\t{reminder.Category.CategoryName}");
                    Console.WriteLine($"\t{(reminder.ReminderStatus.IsActive ? "Not done" : "Done")}");


                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }

            Console.Write("\nPress any key to continue...");

        }


        private void DeleteReminder()
        {
            Console.Clear();
            Console.WriteLine("\n\t----- Delete a Reminder -----");
            Console.Write("Enter the ID of the reminder you want to delete: ");

            if (int.TryParse(Console.ReadLine(), out int reminderId))
            {
                var isDeleted = _reminderService.DeleteReminder(reminderId);
                Console.Clear();
                if (isDeleted)
                {
                    Console.WriteLine("Reminder deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Reminder not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid reminder ID.");
            }

            Console.Write("\nPress any key to continue...");
        }



    }
}
