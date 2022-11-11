using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //if dont use cenimachine, use position lerp
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //move camera to start menu frame position
    public void TransitToStart() 
    {
        Debug.Log("camera move to start pos");
    }

    public void TransitToPrepare() 
    {
        Debug.Log("camera move to prepare pos");

    }

    public void TransitToIngame() 
    {
        Debug.Log("camera move to ingame pos");

    }

    public void TransitToInventory() 
    {
        Debug.Log("camera move to inventory pos");

    }


}
