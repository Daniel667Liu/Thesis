using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public List<int> soundIndexs;
    public List<int> playModes;//sotre 0 for "Trigger", 1 for "Hold"
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundData(int indexInGroup)
    {
        SoundData data = new SoundData();
        
        data.soundIndex = soundIndexs[indexInGroup];
        data.playMode = playModes[indexInGroup];
        data.audioSourceParent = transform;
        Services.soundEffectManager.PlaySound(data);
    }

    public void StopSoundData(int indexInGroup) 
    {
        SoundData data = new SoundData();
        data.soundIndex = soundIndexs[indexInGroup];
        Services.soundEffectManager.StopSound(data);
    }
}
