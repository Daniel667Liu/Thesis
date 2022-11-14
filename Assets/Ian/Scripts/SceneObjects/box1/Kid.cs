using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : SceneObject
{
    public SceneObjectState state = SceneObjectState.DDD;

    public Material highlightMat;
    private Material defaultMat;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        defaultMat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaiseHand()
    {
        Debug.Log("raised hand");

        if (anim != null) anim.SetTrigger("PLACEHOLDER");

        state = SceneObjectState.DD;
    }

    public void DropHand()
    {
        Debug.Log("dropped hand");

        if (anim != null) anim.SetTrigger("PLACEHOLDER");
    }

    public override void Highlight()
    {
        //TODO
        Debug.Log("highlighted");
        GetComponent<MeshRenderer>().material = highlightMat;
    }

    public override void StopHighlight()
    {
        //TODO
        Debug.Log("stopped highlight");
        GetComponent<MeshRenderer>().material = defaultMat;
    }

    public override void FinishedLoop()
    {
        // REMARK: this should be called at the end of raise hand, and there should be a certain amount of empty frame, which will be the delay before which it turns into 3D

        // back to 3d model
        state = SceneObjectState.DDD;
        //TODO
    }
}
