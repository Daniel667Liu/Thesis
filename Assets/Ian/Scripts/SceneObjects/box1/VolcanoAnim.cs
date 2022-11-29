using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishedLoop()
    {
        // back to 3d model
        Volcano v = transform.parent.GetComponent<Volcano>();
        v.FinishedLoop();
    }

    public void Shoot()
    {
        Volcano v = transform.parent.GetComponent<Volcano>();
        v.ShootObj();
    }
}
