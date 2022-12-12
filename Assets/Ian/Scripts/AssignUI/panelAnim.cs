using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelAnim : MonoBehaviour
{
    private Animator anim;
    public bool isUp;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isUp)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
                {
                    anim.Play("panelDown", 0, 1 - anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                }
                else
                {
                    anim.Play("panelDown", 0, 0f);
                }
                isUp = false;
            }
            else
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("panelUp"))
                {
                    anim.Play("panelDown", 0, 1 - anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                }
                else
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
                    {
                        anim.Play("panelUp", 0, 1 - anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                    }
                    else
                    {
                        anim.Play("panelUp", 0, 0f);
                    }
                }
                //isUp = true;
            }
        }
    }

    public void FullyUp()
    {
        isUp = true;
    }
}
