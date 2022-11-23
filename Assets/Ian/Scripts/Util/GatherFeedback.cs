using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherFeedback : MonoBehaviour
{
    public void CheckForFeedback(int effectID)
    {
        if (Services.liveFeedbackManager != null)   Services.liveFeedbackManager.CheckForFeedback(effectID);
    }
}
