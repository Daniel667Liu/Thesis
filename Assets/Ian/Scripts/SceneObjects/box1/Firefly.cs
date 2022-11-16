using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : SceneObject
{
    public SceneObjectState state = SceneObjectState.DDD;
    public float delay = 1f;
    public GameObject TwoDParent;
    public GameObject ThreeDParent;

    public float speed;
    public Material highlightMat;
    private Material defaultMat;

    private Animator anim;

    private float cdTimer = 0f;
    private bool cd;

    // Start is called before the first frame update
    void Start()
    {
        if (anim == null) anim = TwoDParent.GetComponent<Animator>();
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
        if (speed == 0 && !cd)
        {
            startCD();
        }


        speed -= Time.deltaTime * 1.5f;
        if (speed <= 0f) speed = 0f;
        

        if (anim == null) anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.speed = (speed > 1f) ? 1f : speed;
            if (anim.speed > 0f && state == SceneObjectState.DDD)
            {
                StartedLoop();
            }
        }
    }

    public void Fly()
    {
        speed += 0.5f;
        if (speed >= 1.5f) speed = 1.5f;

        resetCD();
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
}
