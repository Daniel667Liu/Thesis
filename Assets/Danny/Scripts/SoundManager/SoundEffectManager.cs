
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public List<AudioClip> sounds;
    [HideInInspector] public List<AudioSource> audioSources;
    public AudioSource audioSourcePrefab;
    
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        Services.soundEffectManager = this;
        audioSources = new List<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(SoundData data) 
    {
        //if there is no audio source at the index in list, create one and add into list
        if (audioSources[data.soundIndex] == null) 
        {
            AudioSource audioSource= Instantiate(audioSourcePrefab, new Vector3(0,0,0), Quaternion.identity,data.audioSourceParent);
            audioSource.playOnAwake = false;
            audioSources[data.soundIndex] = audioSource;
        }
        switch (data.playMode) 
        {
            case 0://trigger
                audioSources[data.soundIndex].PlayOneShot(sounds[data.soundIndex]);
                break;
            case 1://hold
                audioSources[data.soundIndex].clip = sounds[data.soundIndex];
                audioSources[data.soundIndex].Play();
                break;
            default:
                Debug.LogWarning("audio " + data.soundIndex + " play mode out of switch!");
                return;
        }
    }

    public void StopSound(SoundData data) 
    {
        audioSources[data.soundIndex].Stop();
    }
}
