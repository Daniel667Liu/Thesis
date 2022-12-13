using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidAnim : MonoBehaviour
{
    public bool isHandUp;
    public bool isHandOccupied;
    public bool isCharging;

    public GameObject star2_2d;
    public GameObject star3_2d;
    private GameObject sitAnchor;

    private Animator anim;

    private bool attracted;

    private void Start()
    {
        sitAnchor = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // if at any point, the boyhitbox is near a star, attract the star to follow the boyhitbox and when it catches boyhitBox, play boy ride
        if (!attracted && Vector2.Distance(sitAnchor.transform.position, star2_2d.transform.position) < 1f)
        {
            //attract star2
            star2_2d.GetComponent<StarAnim>().FollowBoyHitBox(sitAnchor, 2);

            attracted = true;
        }
        if (!attracted && Vector2.Distance(sitAnchor.transform.position, star3_2d.transform.position) < 1f)
        {
            //attract star3
            star3_2d.GetComponent<StarAnim>().FollowBoyHitBox(sitAnchor, 3);

            attracted = true;
        }
    }

    public void HandUp()
    {
        isHandUp = true;
    }

    public void HandDown()
    {
        isHandUp = false;
    }

    public void EatLollipop()
    {
        transform.parent.GetComponent<Kid>().EatLollipop();
        HandDown();
    }

    public void EatStar()
    {
        transform.parent.GetComponent<Kid>().EatStar();
        HandDown();
        isHandOccupied = false;
    }

    public void Charging()
    {
        isCharging = true;
    }

    public void StartMoving()
    {
        transform.parent.GetComponent<Kid>().GetComponent<Animator>().SetTrigger("float");
    }

    public void Reset()
    {
        transform.parent.GetComponent<Kid>().FinishedLoop();
    }

    public void RideStar(int starNum)
    {
        transform.parent.GetComponent<Animator>().enabled = false;

        if (starNum == 2)
        {
            anim.Play("boy_ride");
            // fly away and another star comes in
            
        }
        if (starNum == 3)
        {
            anim.Play("boy_ride");
            // fly to wait for girl

        }
    }

    public void Wa()
    {
        anim.Play("boy_wa");
    }

    public void StopParentMoving()
    {
        transform.parent.GetComponent<Animator>().speed = 0f;
    }

    public void ResumeParentMoving()
    {
        transform.parent.GetComponent<Animator>().speed = 1f;
    }
}
