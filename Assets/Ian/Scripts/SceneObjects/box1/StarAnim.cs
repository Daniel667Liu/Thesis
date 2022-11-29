using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnim : MonoBehaviour
{
    public KidAnim kidAnim;

    public bool isCaught;

    private float caughtTimer;

    private void Start()
    {
        //kidAnim = GameObject.Find("Boy2D").GetComponent<KidAnim>();
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
}
