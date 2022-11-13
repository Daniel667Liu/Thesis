using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraSwitcher 
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static void RegisterCamera(CinemachineVirtualCamera camera) 
    {
        cameras.Add(camera);
    }

    public static void UnregisterCamera(CinemachineVirtualCamera camera) 
    {
        cameras.Remove(camera);
    }

    public static void SwitchToCamera(CinemachineVirtualCamera camera) 
    {
        camera.Priority = 10;
        foreach (CinemachineVirtualCamera c in cameras) 
        {
            if (c != camera && c.Priority != 0) 
            {
                c.Priority = 0;
            }
        }
    }
}
