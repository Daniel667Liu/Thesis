using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LollipopAnim : MonoBehaviour
{
    private KidAnim kidAnim;

    private void Start()
    {
        //kidAnim = GameObject.Find("Boy2D").GetComponent<KidAnim>();
    }

    public void CheckHand()
    {
        GameObject kd = GameObject.Find("Boy2D");
        if (kd == null) return;
        kidAnim = kd.GetComponent<KidAnim>();

        if (kidAnim.isHandUp && !kidAnim.isHandOccupied)
        {
            kidAnim.EatLollipop();
            Destroy(this.gameObject);
        }
    }
}
