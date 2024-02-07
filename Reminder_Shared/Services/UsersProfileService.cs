using Reminder_Shared.Dto;
using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services;

public class UsersProfileService(UsersProfileRepository userProfileRepository)
{
    private readonly UsersProfileRepository _userProfileRepository = userProfileRepository;



    public UsersProfileEntity CreateUsersProfile(UsersProfileDTO usersProfile)
    {

        var usersProfileEntity = _userProfileRepository.Create(new UsersProfileEntity { 
            
            FirstName = usersProfile.FirstName, 
            LastName = usersProfile.LastName,

            
        });
        _userProfileRepository.Create(usersProfileEntity);
        return usersProfileEntity;
    }

    public UsersProfileEntity GetUsersProfile(UsersProfileDTO usersProfile)
    {
        var usersProfileEntity = _userProfileRepository.Get(x => x.FirstName == usersProfile.FirstName && x.LastName == usersProfile.LastName);
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
