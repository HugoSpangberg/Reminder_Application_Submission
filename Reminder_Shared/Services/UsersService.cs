
using Reminder_Shared.Dto;
using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services;

public class UsersService(UsersRepository usersRepository)
{
    private readonly UsersRepository _usersRepository = usersRepository;



    public UsersEntity CreateUser(UsersDTO user)
    {
        var userEntity = _usersRepository.Get(x => x.Email == user.Email);
        userEntity ??= _usersRepository.Create(new UsersEntity { Email = user.Email });
        return userEntity;
    }

    public UsersEntity GetUserByEmail(UsersDTO userEmail)
    {
        var usersEntity = _usersRepository.Get(x => x.Email == userEmail.Email);
        return usersEntity;
    }

    public UsersEntity GetUserById(UsersDTO userEmail)
    {
        var usersEntity = _usersRepository.Get(x => x.Id == userEmail.Id);
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
