using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : SceneObject
{
    public SceneObjectState state = SceneObjectState.DDD;
    public float delay;
    public string raiseHandClip;
    public string dropHandClip;
    public GameObject TwoDParent;
    public GameObject ThreeDParent;

    public Material highlightMat;
    private Material defaultMat;

    private Animator anim;


    private float cdTimer;
    private bool cd;

    // Start is called before the first frame update
    void Start()
    {
        anim = TwoDParent.GetComponent<Animator>();
        defaultMat = ThreeDParent.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (cd)
        {
            cdTimer += Time.deltaTime;
            if (cdTimer > delay)
            {
                FinishedLoop();
                cd = false;
            }
        }
    }

    public void RaiseHand()
    {
        Debug.Log("raised hand");

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(dropHandClip))
        {
            float n = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            anim.Play(raiseHandClip, 0, 1 - n);
            resetCD();

            if (state == SceneObjectState.DDD)
            {
                StartedLoop();
            }
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName(dropHandClip))
        {
            // seems need nothing here? not sure
            anim.Play(raiseHandClip, 0, 0f);
            resetCD();

            if (state == SceneObjectState.DDD)
            {
                StartedLoop();
            }
        }

    }

    public void DropHand()
    {
        Debug.Log("dropped hand");

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(raiseHandClip))
        {
            float n = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            anim.Play(dropHandClip, 0, 1 - n);
            
            startCD();
        }
        else
        {
            // seems need nothing here? not sure, or kind of sure?
        }
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
        // REMARK: this should be called at the end of raise hand, and there should be a certain amount of empty frame, which will be the delay before which it turns into 3D

        // back to 3d model
        state = SceneObjectState.DDD;
        ThreeDParent.SetActive(true);
        TwoDParent.SetActive(false);
    }

    private void resetCD()
    {
        cdTimer = 0f;
        cd = false;
    }

    private void startCD()
    {
        cdTimer = 0f;
        cd = true;
    }
}
