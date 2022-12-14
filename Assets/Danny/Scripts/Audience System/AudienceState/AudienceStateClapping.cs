using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceStateClapping : AudienceStateBase
{
    public override void EnterState(Audience audience)
    {
        audience.animator.SetTrigger("Clap");
        //audience.tmPro.text = audience.data.textFeedback;
    }
    public override void UpdateState(Audience audience)
    {
        if (Services.audienceManager.attraction < audience.data.leaveThres)
        {
            audience.ToLeaveState();
        }
    }

    public override void ExitState(Audience audience)
    {
        audience.tmPro.text = " ";
    }
}
