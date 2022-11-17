using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeAnim : MonoBehaviour
{
    public void DropObject()
    {
        transform.parent.gameObject.GetComponent<AppleTree>().Fall();
    }
}
