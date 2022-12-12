using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : SceneObject
{
    public SceneObjectState state = SceneObjectState.DDD;
    public GameObject TwoDParent;
    public GameObject ThreeDParent;

    public Material highlightMat;
    private Material defaultMat;

    private Animator anim;

    public bool caught;

    // Start is called before the first frame update
    void Start()
    {
        defaultMat = ThreeDParent.GetComponent<MeshRenderer>().material;
        anim = TwoDParent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ShootStar()
    {
        //TODO
        Debug.Log("shoot star");
        if (anim != null)
        {
            if (state == SceneObjectState.DDD)
            {
                StartedLoop();
                //anim.SetTrigger("fly");
                return true;
            }
        }

        return false;
    }

    public override void Highlight()
    {
        //TODO
        Debug.Log("highlighted");
        ThreeDParent.GetComponent<MeshRenderer>().material = highlightMat;
    }

    public override void StopHighlight()
    {
        //TODO
        Debug.Log("stopped highlight");
        ThreeDParent.GetComponent<MeshRenderer>().material = defaultMat;
    }

    public override void StartedLoop()
    {
        state = SceneObjectState.DD;
        TwoDParent.SetActive(true);
        ThreeDParent.SetActive(false);
    }

    public override void FinishedLoop()
    {
        // back to 3d model
        state = SceneObjectState.DDD;
        ThreeDParent.SetActive(true);
        TwoDParent.SetActive(false);
    }

    public void CaughtByHand()
    {
        anim.speed = 0f;
    }

    public void ReleasedByHand()
    {
        anim.speed = 1f;
    }
}
