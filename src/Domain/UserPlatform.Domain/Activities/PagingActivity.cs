﻿using UserPlatform.Domain.Activities.Base;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Domain.Activities;

public class PagingActivity : IBaseActivity
{
    public string GetDescription()
    {
        return "Paging completed";
    }
    public Activity SetActivityType(Activity activity)
    {
        activity.Type = Enums.ActivityTypes.Paging;
        return activity;
    }
}
