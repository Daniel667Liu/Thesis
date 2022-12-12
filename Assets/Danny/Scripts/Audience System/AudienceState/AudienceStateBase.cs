using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class AudienceStateBase 
{
    public abstract void EnterState(Audience audience);
    public abstract void UpdateState(Audience audience);
    public abstract void ExitState(Audience audience);
}
