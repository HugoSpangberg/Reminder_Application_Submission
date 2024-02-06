using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services;

public class UsersProfileService(UsersProfileRepository userProfileRepository, UsersService usersService)
{
    private readonly UsersProfileRepository _userProfileRepository = userProfileRepository;
    private readonly UsersService _usersService = usersService;


    public UsersProfileEntity CreateUsersProfile(string firstName, string lastName, string email)
    {
        var userEntity = _usersService.CreateUser(email);
        var usersProfileEntity = _userProfileRepository.Create(new UsersProfileEntity { 
            
            FirstName = firstName, 
            LastName = lastName,
            UserId = userEntity.Id    
            
        });
        _userProfileRepository.Create(usersProfileEntity);
        return usersProfileEntity;
    }

    public UsersProfileEntity GetUsersProfile(string firstName, string lastName)
    {
        var usersProfileEntity = _userProfileRepository.Get(x => x.FirstName == firstName && x.LastName == lastName);
        return usersProfileEntity;
    }

    public IEnumerable<UsersProfileEntity> GetAllUsersProfile()
    {
        var allUsersProfile = _userProfileRepository.GetAll();
        return allUsersProfile;
    }

    public UsersProfileEntity UpdateUsersProfile(UsersProfileEntity usersProfileEntity)
    {
        var updatedUsersProfileEntity = _userProfileRepository.Update(x => x.Id == usersProfileEntity.Id, usersProfileEntity);
        return updatedUsersProfileEntity;
    }

    public bool DeleteUsersProfile(int id)
    {
        _userProfileRepository.Delete(x => x.Id == id);
        return true;
    }
}
