using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyControl : MonoBehaviour
{
    public List<GameObject> flies;
    List<Vector3> DePosition;
    List<Vector3> desPoses;
    public float noiseScalarX = 0f;
    public float noiseScalarY = 0f;
    public float noiseScalarZ = 0f;
    public float speed = 1f;
    float noiseSampleCoord = 0f;
    Vector3 center;
    public bool moveable = true;
    public float posUpdateGap = 0f;
    public float timeGap = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        DePosition = new List<Vector3>();
        desPoses = new List<Vector3>();
        foreach (GameObject fly in flies) 
        {
            DePosition.Add(fly.transform.localPosition);
        }
        GetCenterPos();
        Debug.Log(center);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveable) 
        {
            NoiseFly();
            posUpdateGap += Time.deltaTime;
        }
        
    }

    void NoiseFly() 
    {
        
        for (int i = 0; i < flies.Count; i++) 
        {
            Vector3 tarPos;
            tarPos.x= center.x  + (2f * Mathf.PerlinNoise(i + noiseSampleCoord, i + noiseSampleCoord) - 1f) * noiseScalarX;
            tarPos.y = center.y + (2f * Mathf.PerlinNoise(i+0.5f + noiseSampleCoord, i + noiseSampleCoord) - 1f) * noiseScalarY;
            tarPos.z = center.z + (2f * Mathf.PerlinNoise(i +1f+ noiseSampleCoord, i + noiseSampleCoord) - 1f) * noiseScalarZ;

            Vector3 desPos = Vector3.MoveTowards(DePosition[i], tarPos,1f);
            //Debug.Log(tarPos);
            desPoses.Add(tarPos);
            //flies[i].transform.localPosition = desPos;
        }
        noiseSampleCoord += Time.deltaTime*speed;
        if (posUpdateGap >= timeGap) 
        {
            for (int i = 0; i < flies.Count; i++) 
            {
                flies[i].transform.localPosition = desPoses[i];
            }
            posUpdateGap = 0f;
        }
    }

    void GetCenterPos() 
    {
        center = DePosition[0];
        for (int i = 1; i < DePosition.Count; i++)
        {
            center = (center + DePosition[i]) * 0.5f;
            Debug.Log(center);
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
