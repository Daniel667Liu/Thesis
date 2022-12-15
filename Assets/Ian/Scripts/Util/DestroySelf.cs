using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public void DestroyNow()
    {
        Destroy(this.gameObject);
    }

    public void DestroyParent()
    {
        Destroy(transform.parent.gameObject);
    }
}
