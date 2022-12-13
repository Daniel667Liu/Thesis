using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : SceneObject
{
    public SceneObjectState state = SceneObjectState.DDD;
    public GameObject TwoDParent;
    public GameObject ThreeDParent;

    public Material highlightMat;
    private Material defaultMat;

    public string currentAmmo;
    public GameObject fireworkPrefab;
    public GameObject pineappleCloudPrefab;


    private Animator anim;
    private GameObject currentFirework;

    // Start is called before the first frame update
    void Start()
    {
        defaultMat = ThreeDParent.GetComponent<MeshRenderer>().material;
        anim = TwoDParent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Erupt()
    {
        if (currentFirework != null)
        {
            // boom the currentFirework
            currentFirework.GetComponent<Animator>().speed = 0f;
            currentFirework.GetComponent<FireworkAnim>().Boom();

            currentFirework = null;

            return;
        }

        if (anim != null)
        {
            if (state == SceneObjectState.DDD)
            {
                StartedLoop();
                anim.SetTrigger("erupt");
            }
        }
    }

    public void ShootObj()
    {
        if (currentAmmo.Length == 0)
        {
            // shoot firework
            currentFirework = Instantiate(fireworkPrefab);
        }
        else if (currentAmmo.Equals("pineapple"))
        {
            Instantiate(pineappleCloudPrefab);
            currentAmmo = "";
        }
    }

    public override void Highlight()
    {
        //TODO
        Debug.Log("highlighted");
        ThreeDParent.GetComponent<MeshRenderer>().material = highlightMat;
    }

    public override void StopHighlight()
    {
        //TODO
        Debug.Log("stopped highlight");
        ThreeDParent.GetComponent<MeshRenderer>().material = defaultMat;
    }

    public override void StartedLoop()
    {
        state = SceneObjectState.DD;
        TwoDParent.SetActive(true);
        ThreeDParent.SetActive(false);
    }

    public override void FinishedLoop()
    {
        // back to 3d model
        state = SceneObjectState.DDD;
        ThreeDParent.SetActive(true);
        TwoDParent.SetActive(false);
    }

    
}
