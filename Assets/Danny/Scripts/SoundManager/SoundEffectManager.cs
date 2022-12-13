
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SoundEffect
{
    public AudioClip clip;
    public float volume;
}

public class SoundEffectManager : MonoBehaviour
{
    public AudioSource audioSourcePrefab;
    //public List<AudioClip> sounds;
    [HideInInspector] public List<AudioSource> audioSources;
    public List<SoundEffect> soundEffects = new List<SoundEffect>();
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        Services.soundEffectManager = this;
        audioSources = new List<AudioSource>();
        for (int i = 0; i < soundEffects.Count; i++) 
        {
            audioSources.Add(null);
        }

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
            AudioSource audioSource = Instantiate(audioSourcePrefab, new Vector3(0, 0, 0), Quaternion.identity, data.audioSourceParent);
            audioSource.playOnAwake = false;
            audioSource.volume = soundEffects[data.soundIndex].volume;
            audioSources[data.soundIndex] = audioSource;
        }
        else 
        {
            //for test, used to change the volumes during play mode
            audioSources[data.soundIndex].volume = soundEffects[data.soundIndex].volume;
        }
        switch (data.playMode) 
        {
            case 0://trigger
                audioSources[data.soundIndex].PlayOneShot(soundEffects[data.soundIndex].clip);
                if (Services.audienceManager.audiences[data.soundIndex] != null) 
                {
                    Services.audienceManager.audiences[data.soundIndex].Invoke("GiveFeedback", 0.5f);
                    
                }
                break;
            case 1://hold
                audioSources[data.soundIndex].clip = soundEffects[data.soundIndex].clip;
                audioSources[data.soundIndex].Play();
                if (Services.audienceManager.audiences[data.soundIndex] != null)
                {
                    Services.audienceManager.audiences[data.soundIndex].Invoke("GiveFeedback", 0.5f);
                }
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
