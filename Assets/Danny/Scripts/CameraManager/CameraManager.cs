using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera startCam;
    [SerializeField] CinemachineVirtualCamera prepareCam;
    [SerializeField] CinemachineVirtualCamera gameCam;
    [SerializeField] CinemachineVirtualCamera bookCam;
    [SerializeField] CinemachineVirtualCamera inventoryCam;


    

    // Start is called before the first frame update
    void Start()
    {
        RegisterCameras();
        CameraSwitcher.SwitchToCamera(startCam);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //move camera to start menu frame position
    public void TransitToStart() 
    {
        Debug.Log("camera move to start pos");
        CameraSwitcher.SwitchToCamera(startCam);
    }

    public void TransitToPrepare() 
    {
        Debug.Log("camera move to prepare pos");
        CameraSwitcher.SwitchToCamera(prepareCam);
    }

    public void TransitToBook() 
    {
        Debug.Log("camera move to book pos");
        CameraSwitcher.SwitchToCamera(bookCam);
    }

    public void TransitToIngame() 
    {
        Debug.Log("camera move to ingame pos");
        CameraSwitcher.SwitchToCamera(gameCam);
    }

    public void TransitToInventory() 
    {
        Debug.Log("camera move to inventory pos");
        CameraSwitcher.SwitchToCamera(inventoryCam);
    }

    void RegisterCameras()
    {
        CameraSwitcher.RegisterCamera(startCam);
        CameraSwitcher.RegisterCamera(prepareCam);
        CameraSwitcher.RegisterCamera(gameCam);
        CameraSwitcher.RegisterCamera(bookCam);
        CameraSwitcher.RegisterCamera(inventoryCam);
    }

    void Unregistercameras()
    {
        CameraSwitcher.UnregisterCamera(startCam);
        CameraSwitcher.UnregisterCamera(prepareCam);
        CameraSwitcher.UnregisterCamera(gameCam);
        CameraSwitcher.UnregisterCamera(bookCam);
        CameraSwitcher.UnregisterCamera(inventoryCam);
    }

    private void OnDisable()
    {
        Unregistercameras();
    }

    
}
