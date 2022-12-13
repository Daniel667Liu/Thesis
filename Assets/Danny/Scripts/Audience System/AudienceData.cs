using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Audience Date",menuName ="Custom/Audience Date")]
public class AudienceData : ScriptableObject
{
    //for how fast the audience is patrolling in the scene in walking state
    [Tooltip("the speed that tthe audience moving towards the box")]
    public float movingSpeed =0.3f;

    //when to gather
    public float gatherThres = 5;

    //when to leave
    public float leaveThres = 3;

    //when trigger feedback , say the word
    public string textFeedback;

    //for audience to calculate the destination position of gathering
    [Tooltip("input xoffset and z offset for audience moving to the box")]
    public Vector2 offset;

    [Tooltip("if the audience is facing the left")]
    public bool isFacingLeft;

    public float walkingSpeed = 2f;
}
