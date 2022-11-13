using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
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
        speed -= Time.deltaTime * 1.5f;
        if (speed <= 0f) speed = 0f;

        if (anim == null) anim = GetComponent<Animator>();
        if (anim != null) anim.speed = speed;
    }

    public void Fly()
    {
        speed += 0.5f;
        if (speed >= 1.5f) speed = 1.5f;
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
