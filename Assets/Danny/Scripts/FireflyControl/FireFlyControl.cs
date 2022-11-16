using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyControl : MonoBehaviour
{
    public List<GameObject> flies;
    List<Vector3> DePosition;
    public float noiseScalarX = 0f;
    public float noiseScalarY = 0f;
    public float noiseScalarZ = 0f;
    public float speed = 1f;
    float noiseSampleCoord = 0f;
    Vector3 center;
    bool moveable;


    // Start is called before the first frame update
    void Start()
    {
        DePosition = new List<Vector3>();
        foreach (GameObject fly in flies) 
        {
            DePosition.Add(fly.transform.position);
        }
        GetCenterPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveable) 
        {
            NoiseFly();
        }
    }

    void NoiseFly() 
    {
        
        for (int i = 0; i < flies.Count; i++) 
        {
            Vector3 tarPos;
            tarPos.x= center.x * (1f + (2f * Mathf.PerlinNoise(i + noiseSampleCoord, i + noiseSampleCoord) - 1f) * noiseScalarX);
            tarPos.y = center.y * (1f + (2f * Mathf.PerlinNoise(i+0.5f + noiseSampleCoord, i + noiseSampleCoord) - 1f) * noiseScalarY);
            tarPos.z = center.z * (1f + (2f * Mathf.PerlinNoise(i +1f+ noiseSampleCoord, i + noiseSampleCoord) - 1f) * noiseScalarZ);

            Vector3 desPos = Vector3.MoveTowards(DePosition[i], tarPos,1f);
            flies[i].transform.position = desPos;
        }
        noiseSampleCoord += Time.deltaTime*speed;
    }

    void GetCenterPos() 
    {
        center = DePosition[0];
        for (int i = 1; i < DePosition.Count; i++)
        {
            center = (center + DePosition[i]) * 0.5f;
        }
    }

    public void StartMoving() 
    {
        moveable = true;
    }

    public void StopMoving() 
    {
        moveable = false;
    }
}
