using UserPlatform.Domain.Entities.Base;

namespace UserPlatform.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public DateTime JoinDate { get; set; }

}
