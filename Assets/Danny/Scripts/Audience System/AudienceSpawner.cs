using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceSpawner : MonoBehaviour
{
    public Audience audiencePrefab;
    public List<AudienceData> audienceDatas;
    public GameObject box;
    int audienceIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            SpawnAudience();
        }
    }

    public void SpawnAudience() 
    {
        
        Audience clone = Instantiate(audiencePrefab, transform.position, Quaternion.identity);
        clone.data = audienceDatas[audienceIndex];
        clone.box = box;
        if (audienceIndex < audienceDatas.Count - 1) 
        {
            audienceIndex += 1;
        }
        if (audienceIndex == audienceDatas.Count - 1) 
        {
            audienceIndex = 0;
        }
    }
}
