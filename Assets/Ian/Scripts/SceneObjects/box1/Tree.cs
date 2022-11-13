using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float speed;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if (anim == null) anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        speed -= Time.deltaTime * 2f;
        if (speed <= 0f) speed = 0f;

        if (anim == null) anim = GetComponent<Animator>();
        if (anim != null) anim.speed = (speed > 1f) ? 1f : speed;
    }

    public void Shake()
    {
        //TODO
        Debug.Log("SHAKE");
        speed += 0.35f;
        if (speed >= 1f) speed = 1f;
    }

    public void Highlight()
    {
        //TODO
        Debug.Log("highlighted");
    }

    public void StopHighlight()
    {
        //TODO
        Debug.Log("stopped highlight");
    }
}
