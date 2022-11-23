using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<GameObject> allBoxes;
    public Countdown countDown;
    public ProgressBar progressBar;
    public GameObject returnButton;

    private PerformanceManager pm;
    private PerformBox performingBox;
    private Performance currentPerformance;
    

    private void Start()
    {
        pm = GameObject.Find("PerformanceStuff").GetComponent<PerformanceManager>();

        // create the box at position
        placeBox();

        // this should probably be in a separate script dedicated to real-time feedback
        /*// read and setup based on the performance
        currentPerformance = pm.nextPerformance;*/
        Services.liveFeedbackManager.LoadLiveFeedback(pm.nextPerformance.LiveFB);


        StartCoroutine(Perform());
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

    IEnumerator Perform()
    {
        performingBox.DisableInput();
        countDown.StartCountdown();
        yield return new WaitForSeconds(4f);
        performingBox.EnableInput();
        progressBar.StartProgressBar();
        yield return new WaitForSeconds(20f);
        performingBox.DisableInput();
        returnButton.SetActive(true);
    }

    public PerformBox GetPerformingBox()
    {
        return performingBox;
    }
}
