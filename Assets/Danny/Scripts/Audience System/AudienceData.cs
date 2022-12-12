using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Audience Date",menuName ="Custom/Audience Date")]
public class AudienceData : ScriptableObject
{
    //for how fast the audience is patrolling in the scene in walking state
    public float movingSpeed =1;

    //when to gather
    public float gatherThres = 5;

    //when to leave
    public float leaveThres = 3;

    //when trigger feedback , say the word
    public string textFeedback;

}
