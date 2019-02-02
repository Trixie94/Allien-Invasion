using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicControler : MonoBehaviour
{
    public AudioMixer mixer;
   

    public void SetLevelMusic(float sliderValue)
    {
        mixer.SetFloat("Music", Mathf.Log10(sliderValue)*20);
    }

    public void SetLevelSFX(float sliderValue)
    {
        mixer.SetFloat("Sound Effects", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelMaster(float sliderValue)
    {
        mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
    }
}
