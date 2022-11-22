using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherFeedback : MonoBehaviour
{
    public void CheckForFeedback(int effectID)
    {
        Services.liveFeedbackManager.CheckForFeedback(effectID);
    }
}
