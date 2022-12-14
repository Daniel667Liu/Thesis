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
        if (audience.startCheck)
        {
            if (Services.audienceManager.attraction > audience.data.gatherThres)
            {

                if (!audience.isWatched)
                {
                    if (audience.distance > Services.audienceManager.gatherDistance)
                    {
                        audience.ToGatherState();
                    }
                    if (audience.distance <= Services.audienceManager.gatherDistance)
                    {
                        audience.ToWatchState();
                    }
                }
                else 
                {
                    audience.NormalWalking();
                }



            }
            else
            {
                //do normal walking
                audience.NormalWalking();
            }
        }
        else 
        {
            audience.NormalWalking();

        }
        //check if should gather then change the state
        
    }

    public override void ExitState(Audience audience)
    {
       
    }
}
