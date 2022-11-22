using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public List<int> soundIndexs;
    public List<int> playModes;//sotre 0 for "Trigger", 1 for "Hold"
    SoundEffectManager manager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PassSoundData(int indexInGroup) 
    {
        SoundData data = new SoundData();
        
        
        //if there is no audio source component in this object, add one
        if (this.gameObject.GetComponent<AudioSource>() == null)
        {
            this.gameObject.AddComponent<AudioSource>();
            data.audioSource = GetComponent<AudioSource>();
        }
        else 
        {
            data.audioSource = GetComponent<AudioSource>();
        }

        data.soundIndex = soundIndexs[indexInGroup];
        data.playMode = playModes[indexInGroup];


    }
}
