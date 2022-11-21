using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int id;
    public LayerMask manualLayer;
    public LayerMask boxLayer;

    private GameObject manual;

    private void Start()
    {
        manual = transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        // show/hide manual
        GameObject hitManual = raycast(manualLayer);
        if (hitManual != null)
        {
            if (hitManual == manual.transform.GetChild(0).gameObject)
            {
                if (manual.GetComponent<Manual>().shown == false)
                {
                    // manual up
                    if (Input.GetMouseButtonDown(0))
                    {
                        manual.GetComponent<Manual>().ManualUp();
                    }
                }
            }
        }
        else
        {
            if (manual.GetComponent<Manual>().shown == true)
            {
                // manual down
                if (Input.GetMouseButtonDown(0))
                {
                    manual.GetComponent<Manual>().ManualDown();
                }
            }
        }


        // put box on table
        GameObject hitBox = raycast(boxLayer);
        if (hitBox == this.gameObject)
        {
            if (Services.boxManager.currentBox != this)
            {
                // show this box
                if (Input.GetMouseButtonDown(0))
                {
                    Services.boxManager.ShowMusicBox(id);
                }
            }
            else
            {
                // zoom camera into the box
            }
        }
    }

    public void ShowUI()
    {
        manual.SetActive(true);
        manual.GetComponent<Manual>().StartAnim();
    }

    public void HideUI()
    {
        manual.SetActive(false);
        manual.GetComponent<Manual>().ResetAnim();
    }

    private GameObject raycast(LayerMask layer)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    public List<List<KeyCode>> GetKeyGroups()
    {
        return manual.GetComponent<Manual>().GetAllKeys();
    }
}
