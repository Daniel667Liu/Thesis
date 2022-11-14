using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour
{
    public Material highlightMat;
    private Material defaultMat;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        defaultMat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaiseHand()
    {
        Debug.Log("raised hand");

        if (anim != null) anim.SetTrigger("PLACEHOLDER");
    }

    public void DropHand()
    {
        Debug.Log("dropped hand");

        if (anim != null) anim.SetTrigger("PLACEHOLDER");
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
