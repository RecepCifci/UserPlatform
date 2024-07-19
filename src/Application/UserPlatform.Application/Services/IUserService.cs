using UserPlatform.Domain.Entities;

namespace UserPlatform.Application.Services;

public interface IUserService
{
    public void CreateUser(User user);
    public List<User> GetUserList();
    public bool CheckUserIfExists(int userId);
}
