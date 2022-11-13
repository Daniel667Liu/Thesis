using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavgationUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject insideUI;
    public GameObject hamburgerUI;
    void Start()
    {
        insideUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUpUI()
    {
        insideUI.SetActive(true);
        hamburgerUI.SetActive(false);
    }

    public void CloseUI() 
    {
        insideUI.SetActive(false);
        hamburgerUI.SetActive(true);
    }
}
