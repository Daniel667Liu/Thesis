using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : SceneObject
{
    public SceneObjectState state = SceneObjectState.DDD;
    public float delay;
    public string raiseHandClip;
    public string dropHandClip;
    public string eatLollipopClip;
    public string eatStarClip;
    public string startFloatClip;
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
        defaultMat = ThreeDParent.transform.GetChild(0).GetComponent<MeshRenderer>().material;
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
        // if kid is charging, start floating instead of raisehand
        if (transform.GetChild(1).GetComponent<KidAnim>().isCharging)
        {
            anim.Play(startFloatClip);
            transform.GetChild(1).GetComponent<KidAnim>().isCharging = false;
        }


        Debug.Log("raised hand");

        if (state == SceneObjectState.DDD)
        {
            StartedLoop();
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(dropHandClip))
        {
            float n = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            float s = 0f;
            if (n < 1)
            {
                s = 1 - n;
            }
            anim.Play(raiseHandClip, 0, s);

            resetCD();

        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("New State"))
        {
            Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            // seems need nothing here? not sure
            anim.Play(raiseHandClip, 0, 0f);
            resetCD();

        }

    }

    public void DropHand()
    {
        Debug.Log("dropped hand");

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(raiseHandClip))
        {
            float n = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            Debug.Log(n);
            float s = 0f;
            if (n < 1)
            {
                s = 1 - n;
            }
            anim.Play(dropHandClip, 0, s);
            //anim.speed = 1f;
            
            startCD();
        }
        else
        {
            // seems need nothing here? not sure, or kind of sure?
        }
    }

    public void EatLollipop()
    {
        anim.Play(eatLollipopClip);
    }

    public void EatStar()
    {
        anim.Play(eatStarClip);
    }
    
    public override void Highlight()
    {
        //TODO
        Debug.Log("highlighted");
        for (int i=0; i<ThreeDParent.transform.childCount; i++)
        {
            ThreeDParent.transform.GetChild(i).GetComponent<MeshRenderer>().material = highlightMat;
        }
    }

    public override void StopHighlight()
    {
        //TODO
        Debug.Log("stopped highlight");
        for (int i = 0; i < ThreeDParent.transform.childCount; i++)
        {
            ThreeDParent.transform.GetChild(i).GetComponent<MeshRenderer>().material = defaultMat;
        }
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

    public void FallToGround()
    {
        TwoDParent.GetComponent<KidAnim>().SitBackDown();
    }
}
