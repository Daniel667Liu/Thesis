using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : SceneObject
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

    public override void Highlight()
    {
        //TODO
        Debug.Log("highlighted");
        GetComponent<MeshRenderer>().material = highlightMat;
    }

    public override void StopHighlight()
    {
        //TODO
        Debug.Log("stopped highlight");
        GetComponent<MeshRenderer>().material = defaultMat;
    }

    public override void FinishedLoop()
    {
        //TODO
        // set cd

        // back to 3d model

    }
}
