using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnim : MonoBehaviour
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
        Star s = transform.parent.GetComponent<Star>();
        s.state = SceneObjectState.DDD;
        s.ThreeDParent.SetActive(true);
        s.TwoDParent.SetActive(false);
    }
}
