using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkAnim : MonoBehaviour
{
    public void Boom()
    {
        transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("boom");
        Destroy(this.gameObject, 1f);
    }
}
