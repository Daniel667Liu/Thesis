using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : SceneObject
{
    public SceneObjectState state = SceneObjectState.DDD;
    public float delay = 1f;
    public string shakeClip;
    public GameObject TwoDParent;
    public GameObject ThreeDParent;

    public GameObject[] FallObjects;
    public int currentObjectIndex;


    public float speed;

    public Material highlightMat;
    private Material defaultMat;

    public bool childLeft;
    public GameObject appleWithoutChild;
    public GameObject lolipopWithoutChild;

    private Animator anim;

    private bool cd;
    private float cdTimer = 0f;

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
            //float n = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            //if ( n - Mathf.Floor(n) >= 0.7f)
                startCD();
        }

        speed -= Time.deltaTime * 2f;
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

    public void Shake()
    {
        //TODO
        Debug.Log("SHAKE");
        speed += 0.35f;
        if (speed >= 1f) speed = 1f;

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

    public void Fall()
    {
        if (childLeft)
        {
            if (currentObjectIndex == 0)
            {
                Instantiate(appleWithoutChild);
            }
            else if (currentObjectIndex == 2)
            {
                Instantiate(lolipopWithoutChild);
            }
            else
            {
                Instantiate(FallObjects[currentObjectIndex]);
            }
        }
        else
        {
            Instantiate(FallObjects[currentObjectIndex]);
        }
        currentObjectIndex = (currentObjectIndex + 1) % FallObjects.Length;
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
