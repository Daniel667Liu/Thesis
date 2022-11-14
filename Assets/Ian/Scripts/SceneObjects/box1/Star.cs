using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Material highlightMat;
    private Material defaultMat;

    // Start is called before the first frame update
    void Start()
    {
        defaultMat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootStar()
    {
        //TODO
        Debug.Log("shoot star");
    }

    public void Highlight()
    {
        //TODO
        Debug.Log("highlighted");
        GetComponent<MeshRenderer>().material = highlightMat;
    }

    public void StopHighlight()
    {
        //TODO
        Debug.Log("stopped highlight");
        GetComponent<MeshRenderer>().material = defaultMat;
    }
}
