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
    //[HideInInspector]
    //public AudienceManager manager;
    public GameObject box;
    [HideInInspector]
    public float distance = 30;
    [HideInInspector] public float iniDistance;
    Vector3 desPos;
    float walkSpeed;
    bool isGivenFeedback = false;
    AudienceStateBase currentState;
    AudienceStateWalking walkState = new AudienceStateWalking();
    AudienceStateWatching watchState = new AudienceStateWatching();
    AudienceStateGathering gatherState = new AudienceStateGathering();
    AudienceStateLeaving leaveState = new AudienceStateLeaving();
    AudienceStateClapping clapState = new AudienceStateClapping();

    
    void Start()
    {
        //manager = FindObjectOfType<AudienceManager>();
        animator = GetComponent<Animator>();
        currentState = walkState;
        currentState.EnterState(this);
        tmPro.text = " ";
        CalDesPos();
        CalDistance();
        iniDistance = (transform.position - box.transform.position).magnitude;
        walkSpeed = Random.Range(10f, 25f);

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
        distance = (transform.position - box.transform.position).magnitude;
        
    }

    void CalDesPos() 
    {
        desPos = box.transform.position + new Vector3(Random.Range(-1f,1f), 0,Random.Range(-1f,1f));
    }

    public void MovingToBox()
    {
        Vector3 translation = transform.position - desPos;
        transform.Translate(translation * Time.deltaTime*data.movingSpeed *-1f, Space.World);
        //Debug.Log("moving to box");
    }

    public void NormalWalking()
    {
        
        Vector3 pos = transform.position;

        if (data.isFacingLeft)
        {
            pos.x -= walkSpeed * Time.deltaTime;
        }
        else 
        {
            pos.x = walkSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }

    public void Leaving() 
    {
      
        Vector3 translation = transform.position - desPos;
        translation.x = 0;
        translation.y = 0;
        transform.Translate(translation * Time.deltaTime * data.movingSpeed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AudienceKiller")) 
        {
            Services.audienceManager.audiences[data.interactionPrefer] = null;
            Destroy(this.gameObject);
        }
    }

    public void GiveFeedback() 
    {
        if (currentState == watchState)
        {
            TransitState(clapState);
        }
        if (!isGivenFeedback) 
        {
            tmPro.text = data.textFeedback;
            Invoke("ClearFeedback", 5f);
            isGivenFeedback = true;
        }
        
        
        
    }

    void ClearFeedback() 
    {
        tmPro.text = "";
    }
}
