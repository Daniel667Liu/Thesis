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

    public List<string> currentAmmos;
    public GameObject fireworkPrefab;
    public GameObject pineappleCloudPrefab;
    public GameObject sparkPrefab;

    public FireflyControl ffControl;


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
        if (currentAmmos.Count == 0)
        {
            // shoot firework
            currentFirework = Instantiate(fireworkPrefab, transform.parent.parent, true);
        }
        else
        {
            string currentAmmo = currentAmmos[0];
            if (currentAmmo.Equals("pineapple"))
            {
                Instantiate(pineappleCloudPrefab, transform.parent.parent, true);
            }
            else if (currentAmmo.Equals("star"))
            {
                // star thing
                Instantiate(sparkPrefab, transform.parent.parent, true);
                ffControl.PlaySpray();
            }

            currentAmmos.RemoveAt(0);
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
