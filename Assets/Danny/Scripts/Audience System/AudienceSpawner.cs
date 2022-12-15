using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceSpawner : MonoBehaviour
{
    public Audience audiencePrefab;
    public List<AudienceData> audienceDatas;
    public GameObject box;
    //AudienceManager manager;
    int audienceIndex = 0;
    [Tooltip("vector2 to store min wait time and max wait time for spawn a new audience.")]
    public Vector2 gapTimeRange;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnCoroutine());
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
        
        Audience clone = Instantiate(audiencePrefab, transform.position+new Vector3(Random.Range(-10f,10f),0,Random.Range(-10f,10f)), Quaternion.identity,transform);
        clone.data = audienceDatas[audienceIndex];
        clone.box = box;
        Services.audienceManager.audiences[clone.data.interactionPrefer] = clone;
        if (audienceIndex < audienceDatas.Count - 1) 
        {
            audienceIndex += 1;
        }
        else if (audienceIndex == audienceDatas.Count - 1) 
        {
            audienceIndex = 0;
        }
    }

    IEnumerator SpawnCoroutine() 
    {
        while (true) 
        {
            if (transform.childCount <= 31) 
            {
                yield return new WaitForEndOfFrame();
                SpawnAudience();
            }
            yield return new WaitForSeconds(Random.Range(gapTimeRange.x,gapTimeRange.y));
        }
        
            
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void UpdateBox(GameObject _box)
    {
        box = _box;
        foreach (Audience a in Services.audienceManager.audiences)
        {
            if (a != null)
                a.box = _box;
        }
    }
}
