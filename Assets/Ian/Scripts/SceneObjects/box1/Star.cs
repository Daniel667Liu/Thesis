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
                anim.SetTrigger("PLACEHOLDER");
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
}
