using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Audience : MonoBehaviour
{
    public AudienceData data;
    [HideInInspector]
    public Animator animator;
    public TextMeshPro tmPro;
    [HideInInspector]
    public AudienceManager manager;
    public GameObject box;
    [HideInInspector]
    public float distance;
    AudienceStateBase currentState;
    AudienceStateWalking walkState = new AudienceStateWalking();
    AudienceStateWatching watchState = new AudienceStateWatching();
    AudienceStateGathering gatherState = new AudienceStateGathering();
    AudienceStateLeaving leaveState = new AudienceStateLeaving();
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudienceManager>();
        animator = GetComponent<Animator>();
        currentState = walkState;
        currentState.EnterState(this);
        tmPro.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        CalDistance();
        
    }

    public void TransitState(AudienceStateBase next) 
    {
        currentState.ExitState(this);
        next.EnterState(this);
        currentState = next;
    }


    public void ToWalkState() 
    {
        TransitState(walkState);
    }

    public void ToGatherState() 
    {
        TransitState(gatherState);
    }

    public void ToWatchState() 
    {
        TransitState(watchState);
    }

    public void ToLeaveState() 
    {
        TransitState(leaveState);
    }

    void CalDistance() 
    {
        distance = Mathf.Abs(transform.position.z - box.transform.position.z);
    }

    
}
