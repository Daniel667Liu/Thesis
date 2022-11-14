using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : SceneObject
{
    public SceneObjectState state = SceneObjectState.DDD;

    public GameObject[] FallObjects;
    public int currentObjectIndex;


    public float speed;

    public Material highlightMat;
    private Material defaultMat;

    private Animator anim;

    private float cd = 2f;
    private float cdTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (anim == null) anim = GetComponent<Animator>();
        defaultMat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        speed -= Time.deltaTime * 2f;
        if (speed <= 0f) speed = 0f;

        if (anim == null) anim = GetComponent<Animator>();
        if (anim != null)
        {
            if (cdTimer <= 0f)
            {
                anim.speed = (speed > 1f) ? 1f : speed;

                if (anim.speed > 0f && state == SceneObjectState.DDD) state = SceneObjectState.DD;
            }
            else
            {
                cdTimer -= Time.deltaTime;
                if (cdTimer <= 0f)
                {
                    //TODO: play the animation from the beginning
                    //anim.Play("xxx", 0, 0f);
                    cdTimer = 0f;
                }
            }
        }

        
    }

    public void Shake()
    {
        //TODO
        Debug.Log("SHAKE");
        speed += 0.35f;
        if (speed >= 1f) speed = 1f;
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
        // set cd
        cdTimer = cd;

        // back to 3d model
        state = SceneObjectState.DDD;
        //TODO

    }

    public void Fall()
    {
        Instantiate(FallObjects[currentObjectIndex]);
        currentObjectIndex = (currentObjectIndex + 1) % FallObjects.Length;
    }
}
