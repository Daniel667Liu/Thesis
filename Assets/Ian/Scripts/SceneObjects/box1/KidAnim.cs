using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidAnim : MonoBehaviour
{
    public bool isHandUp;
    public bool isHandOccupied;
    public bool isCharging;

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
}
