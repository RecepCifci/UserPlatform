namespace UserPlatform.Application.Dtos;

public class UserDto
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public DateTime JoinDate { get; set; }
}
