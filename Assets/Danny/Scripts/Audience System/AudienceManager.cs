using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceManager : MonoBehaviour
{
    public float attraction = 0f;
    public float gatherDistance = 10f;
    public int interactionCount = 32;
    public List<Audience> audiences;
    // Start is called before the first frame update
    void Start()
    {
        Services.audienceManager = this;
        audiences = new List<Audience>();
        for (int i = 0; i < interactionCount; i++)
        {
            audiences.Add(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            attraction += 1;
        }
        if (attraction > 0f) 
        {
            attraction -= Time.deltaTime ;
        }
    }
}
