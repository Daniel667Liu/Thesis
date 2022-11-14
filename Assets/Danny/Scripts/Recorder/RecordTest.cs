using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordTest : MonoBehaviour
{
    RecordManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<RecordManager>();
        manager.SetTimeLimit(10f);
    }

    // Update is called once per frame
    void Update()
    {
        Test();
    }

    void Test() 
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            manager.StartRecording();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            manager.StopRecording();
        }
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            manager.StartReplaying();
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            Up();
            manager.AddRecord(this, "Up");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Down();
            manager.AddRecord(this, "Down");
        }

    }

    public void Up()
    {
        Debug.Log("up");
    }
    public void Down()
    {
        Debug.Log("down");
    }
}
