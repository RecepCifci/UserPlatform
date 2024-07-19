using UserPlatform.Domain.Entities;
using UserPlatform.Infrastructure;
using UserPlatform.Infrastructure.Repository;

namespace UserPlatform.Application.Services;

public class UserService(ApplicationDbContext applicationDbContext) : BaseRepository<User, ApplicationDbContext>(applicationDbContext), IUserService
{
    public void CreateUser(User user) 
    {
        Add(user);
    }
    public List<User> GetUserList() 
    {
        return GetList().ToList();
    }
    public bool CheckUserIfExists(int userId)
    {
        return Get(x=> x.Id == userId) != null;
    }
}
