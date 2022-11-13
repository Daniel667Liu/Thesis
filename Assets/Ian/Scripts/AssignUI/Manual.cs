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
        anim = GetComponent<Animator>();
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
        anim.SetFloat("speed", -1f);
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
        {
            anim.Play("down", 0, 1f);
        }

        shown = true;
    }

    public void ManualUp()
    {
        anim.SetFloat("speed", 1f);
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.01f)
        {
            anim.Play("down", 0, 0f);
        }

        shown = false;
    }

    public void StartAnim()
    {
        anim.SetTrigger("start");
        anim.SetFloat("speed", 0f);
    }

    public void ResetAnim()
    {
        anim.SetTrigger("reset");
        anim.SetFloat("speed", 0f);
    }
}
