using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class FireflyControl : MonoBehaviour
{
    public VisualEffect spray;
    public List<VisualEffect> flyEnds;
    int endIndex = 0;
    public bool ifTest = true;
    public float dropWait = 4.3f;
    public float finalWait = 8f;
    // Start is called before the first frame update
    void Start()
    {
        spray.Stop();
        
        foreach (VisualEffect ve in flyEnds) 
        {
            ve.Stop();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ifTest) 
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                PlaySpray();
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                spray.Stop();
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                FlyAway();
            }
        }
        
    }

    public void PlaySpray() 
    {
        spray.Play();
        Invoke("PlayEnds", dropWait);
    }

    public void PlayEnds() 
    {
        if (endIndex < flyEnds.Count-1) 
        {
            flyEnds[endIndex].Play();
            endIndex += 1;
        }
        else if (endIndex == flyEnds.Count - 1) 
        {
            flyEnds[endIndex].Play();
            endIndex += 1;
            Invoke("FlyAway", finalWait);
        }
    }

    public void FlyAway() 
    {
        foreach (VisualEffect ve in flyEnds) 
        {
            ve.SetBool("IfMove", true);
        }
    }

    
}
