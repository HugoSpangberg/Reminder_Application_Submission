
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reminder_Shared.Context;
using Reminder_Shared.Repositories;
using Reminder_Shared.Services;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\ProjectsCode\Reminder_Application_Submission\Reminder_Shared\Data\Local_database2.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<ReminderRepository>();
    services.AddScoped<UsersRepository>();
    services.AddScoped<UsersProfileRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<ReminderStatusRepository>();

    services.AddScoped<ReminderService>();
    services.AddScoped<UsersService>();
    services.AddScoped<UsersProfileService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<ReminderStatusService>();

    services.AddScoped<ConsoleService>();


}).Build();

builder.Start();

var menuService = builder.Services.GetRequiredService<ConsoleService>();
menuService.MenuService();

