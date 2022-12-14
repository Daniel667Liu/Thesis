using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlAnim : MonoBehaviour
{
    public float threshold;
    public GameObject star1CP;
    public GameObject star2CP;
    public GameObject girlBoom;

    private Animator anim;

    private bool waiting;

    private KidAnim ka;

    private void Start()
    {
        anim = GetComponent<Animator>();
        ka = GameObject.Find("Boy2D").GetComponent<KidAnim>();
    }

    private void Update()
    {
        if (waiting)
        {
            // check if boy came
            if (ka.waiting)
            {
                // go together
                ka.Leave();
                anim.SetTrigger("leave");
            }
        }
    }

    public void CheckStar1()
    {
        GameObject star1 = GameObject.Find("star1");
        if (star1 != null)
        {
            star1 = star1.transform.GetChild(1).gameObject;
        }
        else
        {
            return;
        }

        if (Vector2.Distance(star1.transform.position, star1CP.transform.position) < threshold)
        {
            star1.GetComponent<StarAnim>().Star1FlyIn();
            anim.Play("girl_ridingstar2");
        }
    }

    public void CheckStar2()
    {
        GameObject star2 = GameObject.Find("star2");
        if (star2 != null)
        {
            star2 = star2.transform.GetChild(1).gameObject;
        }
        else
        {
            return;
        }

        if (Vector2.Distance(star2.transform.position, star2CP.transform.position) < threshold)
        {
            star2.GetComponent<StarAnim>().Star2Destroy();
            anim.Play("girl_ridingstar1");
        }
    }

    public void Boom()
    {
        anim.enabled = false;
        Vector3 pos = transform.GetChild(2).position;
        Instantiate(girlBoom, pos, Quaternion.identity);
        DestroySelf();
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public void Arrived()
    {
        waiting = true;
    }
}
