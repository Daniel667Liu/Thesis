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
   
    Vector3 desPos;
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
        CalDesPos();
       
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

    void CalDesPos() 
    {
        desPos = box.transform.position + new Vector3(data.offset.x, 0, data.offset.y);
    }

    public void MovingToBox()
    {
        Vector3 translation = transform.position - desPos;
        transform.Translate(translation * Time.deltaTime*data.movingSpeed *-1f, Space.World);
        Debug.Log("moving to box");
    }

    public void NormalWalking()
    {
        
        Vector3 pos = transform.position;

        if (data.isFacingLeft)
        {
            pos.x -= data.walkingSpeed * Time.deltaTime;
        }
        else 
        {
            pos.x -= data.walkingSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }

    public void Leaving() 
    {
        Vector3 translation = transform.position - desPos;
        transform.Translate(translation * Time.deltaTime * data.movingSpeed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AudienceKiller")) 
        {
            Destroy(this.gameObject);
        }
    }

}
