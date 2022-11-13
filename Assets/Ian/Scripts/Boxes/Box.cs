using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int id;

    private GameObject ui;

    private void Start()
    {
        ui = transform.GetChild(1).gameObject;
    }

    public void ShowUI()
    {
        ui.SetActive(true);
        ui.GetComponent<Manual>().StartAnim();
    }

    public void HideUI()
    {
        ui.SetActive(false);
        ui.GetComponent<Manual>().ResetAnim();
    }
}
