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
       
        if (audience.distance > audience.iniDistance*0.69f+Random.Range(-1f,5f))
        {
            //leave the box pos
            
            audience.ToWalkState();
        }
        else
        {
            //stop movement
            audience.Leaving();
        }
    }

    public override void ExitState(Audience audience)
    {

    }
}
