using UserPlatform.Domain.Enums;

namespace UserPlatform.Application.Dtos;

public class ActivityDto
{
    public string Description { get; set; } = default!;
    public ActivityTypes Type { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
}
