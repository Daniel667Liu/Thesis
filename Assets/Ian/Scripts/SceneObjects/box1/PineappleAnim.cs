using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineappleAnim : MonoBehaviour
{
    
    public void LoadVolcanoAndDestroySelf()
    {
        GameObject.Find("Volcano").GetComponent<Volcano>().currentAmmo = "pineapple";
        Destroy(this.gameObject, 1f);
    }


}
