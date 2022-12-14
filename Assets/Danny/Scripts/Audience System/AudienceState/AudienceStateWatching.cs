using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceStateWatching : AudienceStateBase
{
    public override void EnterState(Audience audience)
    {
        audience.animator.SetTrigger("Watch");
        audience.isWatched = true;
    }
    public override void UpdateState(Audience audience)
    {
        if (Services.audienceManager.attraction < audience.data.leaveThres) 
        {
            audience.ToWalkState();
        }
    }

    public override void ExitState(Audience audience)
    {

    }
}
