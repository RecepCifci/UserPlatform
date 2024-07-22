using UserPlatform.Application.Dtos;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Application.Services;

public interface IUserService
{
    public void CreateUser(UserDto user);
    public List<UserDto> GetUserList();
    public bool CheckUserWithIdIfExists(int userId);
    public bool CheckUserWithEmailAndPasswordIfExists(string email);
}
