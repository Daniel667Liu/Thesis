using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RecorderUIControl : MonoBehaviour
{
    public Button recordButton;
    public Button replayButton;
    //--set replayButton to interactable when the replay is over, so that players can replay it again;
    bool isRecording;
    RecordManager recordManager;
    Text recordButtonText;
    // Start is called before the first frame update
    void Start()
    {
        recordManager = FindObjectOfType<RecordManager>();
        replayButton.interactable = false;
        recordButtonText = recordButton.gameObject.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecordButtonClick()
    {
        if (isRecording)//click to stop recording
        {
            StopRecordUI();
        }
        else //click to start recording
        {
            recordManager.StartRecording();
            isRecording = true;
            recordButtonText.text = "Stop Recording";
            replayButton.interactable = false;
        }
    }


    //call in Recordmanager when the recording is at the time limit
    public void StopRecordUI()
    {
        recordManager.StopRecording();
        isRecording = false;
        recordButtonText.text = "Start Recording";
        replayButton.interactable = true;
    }


     
    public void ReplayButtonClick() 
    {
        recordManager.StartReplaying();
        replayButton.interactable = false;
    }
}
