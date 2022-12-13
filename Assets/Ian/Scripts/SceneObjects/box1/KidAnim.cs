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

    public Transform waitPosition;
    public Transform leavePosition;

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
        if (!attracted && star2_2d != null && Vector2.Distance(sitAnchor.transform.position, star2_2d.transform.position) < 1f)
        {
            //attract star2
            star2_2d.GetComponent<StarAnim>().FollowBoyHitBox(sitAnchor, 2);

            attracted = true;
        }
        if (!attracted && star3_2d != null && Vector2.Distance(sitAnchor.transform.position, star3_2d.transform.position) < 1f)
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
        GameObject.Find("Tree").GetComponent<AppleTree>().childLeft = true;
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

            StartCoroutine(flyAway());
        }
        if (starNum == 3)
        {
            anim.Play("boy_ride");
            // fly to wait for girl
            
            StartCoroutine(flyToWait());
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

    IEnumerator flyToWait()
    {
        float timer = 0f;
        Vector3 startPos = transform.position;

        //yield return new WaitForSeconds(0.1f);

        while (timer <= 1)
        {
            if (timer > 0f && anim.enabled) anim.enabled = false;

            float t = quadrupleEaseIn(timer);
            float tY = customCubic(quadEaseIn(timer), -1.7f, 1.4f);

            Vector3 newPos = Vector3.zero;
            newPos.x = Mathf.LerpUnclamped(startPos.x, waitPosition.position.x, t);
            newPos.y = Mathf.LerpUnclamped(startPos.y, waitPosition.position.y, tY);
            newPos.z = Mathf.LerpUnclamped(startPos.z, waitPosition.position.z, t);

            transform.position = newPos;
            timer += Time.deltaTime / 1.7f;
            yield return new WaitForEndOfFrame();
        }

        // reached wait position
    }

    IEnumerator flyAway()
    {
        float timer = 0f;
        Vector3 startPos = transform.position;

        //yield return new WaitForSeconds(0.1f);

        while (timer <= 1)
        {
            if (timer > 0f && anim.enabled) anim.enabled = false;

            float t = customEaseIn(timer, 6f);
            float tY = customEaseOut(timer, 6f);

            Vector3 newPos = Vector3.zero;
            newPos.x = Mathf.LerpUnclamped(startPos.x, leavePosition.position.x, t);
            newPos.y = Mathf.LerpUnclamped(startPos.y, leavePosition.position.y, tY);
            newPos.z = Mathf.LerpUnclamped(startPos.z, leavePosition.position.z, t);

            transform.position = newPos;
            timer += Time.deltaTime / 1.4f;
            yield return new WaitForEndOfFrame();
        }

        // reached wait position
    }

    private float quadEaseIn(float t) => t * t;
    private float quadEaseOut(float t) => 1 - quadEaseIn(1 - t);
    private float cubicEaseIn(float t) => t * t * t;
    private float customCubic(float t, float a, float b) => (a + b - 2) * t * t * t + (3 - 2 * a - b) * t * t + a * t;
    private float quadrupleEaseIn(float t) => t * t * t * t;
    private float customEaseIn(float t, float deg) => Mathf.Pow(t, deg);
    private float customEaseOut(float t, float deg) => 1 - Mathf.Pow((1 - t), deg);
}
