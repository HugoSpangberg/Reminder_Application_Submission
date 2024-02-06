
using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services;

public class UsersService(UsersRepository usersRepository, UsersProfileService usersProfileService)
{
    private readonly UsersRepository _usersRepository = usersRepository;
    private readonly UsersProfileService _usersProfileService = usersProfileService;


    public UsersEntity CreateUser(string email)
    {
        var userEntity = _usersRepository.Get(x => x.Email == email);
        userEntity ??= _usersRepository.Create(new UsersEntity { Email = email });
        return userEntity;
    }

    public UsersEntity GetUserByEmail(string email)
    {
        var usersEntity = _usersRepository.Get(x => x.Email == email);
        return usersEntity;
    }

    public IEnumerable<UsersEntity> GetAllUsers()
    {
        var allUsers = _usersRepository.GetAll();
        return allUsers;
    }

    public UsersEntity UpdateUser(UsersEntity UsersEntity)
    {
        var updatedUsersEntity = _usersRepository.Update(x => x.Id == UsersEntity.Id, UsersEntity);
        return updatedUsersEntity;
    }

    public bool DeleteUser(int id)
    {
        _usersRepository.Delete(x => x.Id == id);
        return true;
    }
}
