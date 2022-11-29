using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LollipopAnim : MonoBehaviour
{
    private KidAnim kidAnim;

    private void Start()
    {
        kidAnim = GameObject.Find("Boy2D").GetComponent<KidAnim>();
    }

    public void CheckHand()
    {
        if (kidAnim.isHandUp && !kidAnim.isHandOccupied)
        {
            kidAnim.EatLollipop();
            Destroy(this.gameObject);
        }
    }
}
