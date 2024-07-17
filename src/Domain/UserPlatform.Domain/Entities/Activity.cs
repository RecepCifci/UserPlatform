using UserPlatform.Domain.Entities.Base;
using UserPlatform.Domain.Enums;

namespace UserPlatform.Domain.Entities;

public class Activity : BaseEntity
{
    public string Description { get; set; } = default!;
    public ActivityTypes Type { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
}

