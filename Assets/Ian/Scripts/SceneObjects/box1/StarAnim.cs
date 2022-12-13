using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnim : MonoBehaviour
{
    public KidAnim kidAnim;

    public bool isCaught;

    private float caughtTimer;

    private Animator anim;

    private bool hitGround;
    private bool hitVolcano;

    private void Start()
    {
        //kidAnim = GameObject.Find("Boy2D").GetComponent<KidAnim>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (kidAnim.isHandUp == false && isCaught)
        {
            Released();
        }

        if (isCaught)
        {
            caughtTimer += Time.deltaTime;

            if (caughtTimer > 3f)
            {
                Eaten();
            }
        }




    }

    public void FinishedLoop()
    {
        // back to 3d model
        Star s = transform.parent.GetComponent<Star>();
        s.FinishedLoop();
    }

    public void CheckHand()
    {
        if (kidAnim.isHandUp)
        {
            isCaught = true;
            caughtTimer = 0f;
            transform.parent.GetComponent<Star>().CaughtByHand();
            kidAnim.isHandOccupied = true;
        }
    }

    public void Released()
    {
        isCaught = false;
        caughtTimer = 0f;
        transform.parent.GetComponent<Star>().ReleasedByHand();
        kidAnim.isHandOccupied = false;
    }

    public void Eaten()
    {
        kidAnim.EatStar();
        Destroy(transform.parent.gameObject);
        kidAnim.isHandOccupied = false;
    }

    public void Star1FlyIn()
    {
        anim.Play("star1_come");
    }

    public void Star2Destroy()
    {
        Destroy(transform.parent.gameObject);
    }

    public void FollowBoyHitBox(GameObject boyHitBox, int starNum)
    {
        anim.enabled = false;
        StartCoroutine(followObject(boyHitBox, starNum));
    }

    IEnumerator followObject(GameObject target, int starNum)
    {
        while (Vector2.Distance(transform.position, target.transform.position) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 5f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        // reached object
        if (starNum == 2)
        {
            target.transform.parent.GetComponent<KidAnim>().RideStar(2);
            anim.enabled = true;
            anim.Play("star2_come");
        }
        else
        {
            target.transform.parent.GetComponent<KidAnim>().RideStar(3);
            //Destroy(transform.parent.gameObject);
            transform.parent.gameObject.SetActive(false);
        }
    }

    public void HitByFirework()
    {
        if (anim.enabled == false) return;

        anim.enabled = false;
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("fall");

        StartCoroutine(DropDown());
    }

    IEnumerator DropDown()
    {

        while (!hitGround && !hitVolcano)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.up, 8f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        if (hitGround)
        {
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("disappear");
        }
        if (hitVolcano)
        {
            GameObject.Find("Volcano").GetComponent<Volcano>().currentAmmos.Add("star");
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "moon" || other.tag == "desk") && !hitVolcano)
        {
            hitGround = true;
        }
        if (other.tag == "volcano" && !hitGround)
        {
            hitVolcano = true;
        }
    }
}
