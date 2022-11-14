using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    int recorderState = 0;
    //0 standby,1 recording, 2 replaying.

    float excuteTime = 0f;
    float currentTime = 0f;
    List<RecordData> datas;
    int replayIndex = 0;
    float timeLimit = 0f;


    // Start is called before the first frame update
    void Start()
    {
        datas = new List<RecordData>();
    }

    // Update is called once per frame
    void Update()
    {
        AddTime();
        ReplayRecord();
    }

    //call when each component excute the interactio func
    public void AddRecord(MonoBehaviour mono, string funcName) 
    {
        if (recorderState==1) 
        {
            RecordData data = new RecordData();
            data.monoBehaviour = mono;
            data.funcName = funcName;
            data.excuteTime = excuteTime;
            datas.Add(data);
        }
    }

    void AddTime() 
    {
        if (recorderState == 1) 
        {
            excuteTime += Time.deltaTime;
            if (excuteTime >= timeLimit) 
            {
                StopRecording();
            }
        }
    }

    public void StartRecording() 
    {
        recorderState = 1;
        datas = new List<RecordData>();
    }

    public void StopRecording() 
    {
        AddRecord(this, "EndofReplay");
        recorderState = 0;
        excuteTime = 0f;
        
    }

    void EndofReplay() 
    {
        Debug.Log("end of replay");
    }

    public void StartReplaying() 
    {
        recorderState = 2;
    }

    public void StopReplaying() 
    {
        recorderState = 0;
        currentTime = 0f;
    }


    void ReplayRecord() 
    {
        if (recorderState == 2) 
        {
            currentTime += Time.deltaTime;
            while (replayIndex < datas.Count && datas[replayIndex].excuteTime <= currentTime) 
            {
                datas[replayIndex].monoBehaviour.Invoke(datas[replayIndex].funcName, 0f);
                replayIndex++;
            }
            if (replayIndex == datas.Count) 
            {
                StopReplaying();
                Debug.Log("replay finished");
            }
        }
    }

    public void SetTimeLimit(float tl) 
    {
        timeLimit = tl;
    }
}
