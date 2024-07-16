using UserPlatform.Domain.Entities.Base;

namespace UserPlatform.Domain.Entities;

public class Activity : BaseEntity
{
    public string Description { get; set; } = default!;
    public ActivityTypes Type { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = default!;
}
public enum ActivityTypes
{
    Login,
    Paging,
    ViewReport,
    DownloadReport
}
