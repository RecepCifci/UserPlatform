using AutoMapper;
using UserPlatform.Application.Dtos;
using UserPlatform.Domain.Entities;
using UserPlatform.Infrastructure;
using UserPlatform.Infrastructure.Repository;

namespace UserPlatform.Application.Services;

public class UserService(ApplicationDbContext applicationDbContext, IMapper mapper) : BaseRepository<User, ApplicationDbContext>(applicationDbContext), IUserService
{
    public void CreateUser(UserDto user)
    {
        Add(mapper.Map<User>(user));
    }
    public List<UserDto> GetUserList()
    {
        return mapper.Map<List<UserDto>>(GetList().ToList()) ?? throw new Exception($"Sistemde kullanıcı bulunamadı");
    }
    public bool CheckUserWithIdIfExists(int userId)
    {
        return Get(x => x.Id == userId) != null;
    }
    public bool CheckUserWithEmailAndPasswordIfExists(string email)
    {
        return Get(x => x.Email == email) != null;
    }
}
