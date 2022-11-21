using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<GameObject> allBoxes;

    private PerformanceManager pm;
    private PerformBox performingBox;

    private void Start()
    {
        pm = GameObject.Find("PerformanceStuff").GetComponent<PerformanceManager>();

        // create the box at position
        placeBox();
    }

    private void placeBox()
    {
        // activate the selected box in the scene, deactivate the rest
        foreach (GameObject box in allBoxes)
        {
            int id = box.GetComponent<PerformBox>().id;
            if (id == pm.selectedBoxId)
            {
                box.SetActive(true);
                performingBox = box.GetComponent<PerformBox>();
            }
            else box.SetActive(false);
        }

        // set the selected box's inputs
        performingBox.AssignAllKeys(pm.selectedBoxKeyGroups);
    }
}
