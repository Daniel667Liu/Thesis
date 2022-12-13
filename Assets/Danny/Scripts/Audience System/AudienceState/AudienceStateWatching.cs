using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceStateWatching : AudienceStateBase
{
    public override void EnterState(Audience audience)
    {
        audience.animator.SetTrigger("Watch");
    }
    public override void UpdateState(Audience audience)
    {
        if (audience.manager.attraction < audience.data.leaveThres) 
        {
            audience.ToLeaveState();
        }
    }

    public override void ExitState(Audience audience)
    {

    }
}
