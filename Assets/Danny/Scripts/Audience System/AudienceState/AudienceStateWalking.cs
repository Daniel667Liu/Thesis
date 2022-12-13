using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceStateWalking : AudienceStateBase
{
    public override void EnterState(Audience audience)
    {
        audience.animator.SetTrigger("Walk");
    }
    public override void UpdateState(Audience audience)
    {
        //check if should gather then change the state
        if (audience.manager.attraction >= audience.data.gatherThres)
        {
            if (audience.distance > audience.manager.gatherDistance)
            {
                audience.ToGatherState();
            }
            else
            {
                audience.ToWatchState();
            }
        }
        else 
        {
            //do normal walking
            audience.NormalWalking();
        }
    }

    public override void ExitState(Audience audience)
    {
       
    }
}
