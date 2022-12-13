using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceStateLeaving : AudienceStateBase
{
    public override void EnterState(Audience audience)
    {
        audience.animator.SetTrigger("Leave");
    }
    public override void UpdateState(Audience audience)
    {
       
        if (audience.distance < audience.manager.gatherDistance + Random.Range(-1f, 1f))
        {
            //leave the box pos
            audience.Leaving();
        }
        else
        {
            //stop movement
            audience.ToWalkState();
        }
    }

    public override void ExitState(Audience audience)
    {

    }
}
