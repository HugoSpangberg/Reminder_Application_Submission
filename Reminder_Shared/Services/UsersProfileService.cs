using Reminder_Shared.Dto;
using Reminder_Shared.Entities;
using Reminder_Shared.Repositories;

namespace Reminder_Shared.Services;

public class UsersProfileService(UsersProfileRepository userProfileRepository)
{
    private readonly UsersProfileRepository _userProfileRepository = userProfileRepository;




    public UsersProfileEntity CreateUsersProfile(UsersProfileDTO usersProfile)
    {

        try
        {

            var usersProfileEntity = _userProfileRepository.Create(new UsersProfileEntity
            {

                FirstName = usersProfile.FirstName,
                LastName = usersProfile.LastName,


            });
            _userProfileRepository.Create(usersProfileEntity);
            return usersProfileEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Creating User Profile: {ex.Message}");
            return null!;
        }
    }

    public UsersProfileEntity GetUsersProfile(UsersProfileDTO usersProfile)
    {
        try
        {
            var usersProfileEntity = _userProfileRepository.Get(x => x.FirstName == usersProfile.FirstName && x.LastName == usersProfile.LastName);
            return usersProfileEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Getting User Profile: {ex.Message}");
            return null!;
        }
    }

    public IEnumerable<UsersProfileEntity> GetAllUsersProfile()
    {
        try
        {
            var allUsersProfile = _userProfileRepository.GetAll();
            return allUsersProfile;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Getting All User Profiles: {ex.Message}");
            return null!;
        }
    }

    public UsersProfileEntity UpdateUsersProfile(UsersProfileEntity usersProfileEntity)
    {
        try
        {
            var updatedUsersProfileEntity = _userProfileRepository.Update(x => x.Id == usersProfileEntity.Id, usersProfileEntity);
            return updatedUsersProfileEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Update User Profile: {ex.Message}");
            return null!;
        }
    }

    public bool DeleteUsersProfile(int id)
    {
        try
        {
            _userProfileRepository.Delete(x => x.Id == id);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Delete User Profile: {ex.Message}");
            return false;
        }
    }
}
