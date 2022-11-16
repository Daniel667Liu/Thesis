using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual : MonoBehaviour
{
    public bool shown;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if (anim == null) anim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            ManualUp();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ManualDown();
        }
    }

    public void ManualDown()
    {
        anim.SetFloat("speed", 1f);
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.01f)
        {
            anim.Play("down", 0, 0f);
        }

        shown = false;
    }

    public void ManualUp()
    {
        anim.SetFloat("speed", -1f);
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
        {
            anim.Play("down", 0, 1f);
        }

        shown = true;
    }

    public void StartAnim()
    {
        if (anim == null) anim = GetComponent<Animator>();
        anim.SetTrigger("start");
        anim.SetFloat("speed", 0f);
    }

    public void ResetAnim()
    {
        if (anim == null) anim = GetComponent<Animator>();
        anim.SetTrigger("reset");
        anim.SetFloat("speed", 0f);
    }
}
