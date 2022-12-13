using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceStateGathering : AudienceStateBase
{
    public override void EnterState(Audience audience)
    {
        audience.animator.SetTrigger("Gather");
    }
    public override void UpdateState(Audience audience)
    {
        //check if arrived the spot, if so then stop the animation and movement
        if (audience.distance > Services.audienceManager.gatherDistance+Random.Range(-1f,1f))
        {
            //move to the box
            audience.MovingToBox();
        }
        else 
        {
            //stop movement
            audience.ToWatchState();
        }
    }

    public override void ExitState(Audience audience)
    {

    }
}
