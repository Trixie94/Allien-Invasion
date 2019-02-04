using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicControler : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider soundEffectsSlider;
    private float vol1, vol2, vol3;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Master"))
        {
            vol1 = PlayerPrefs.GetFloat("Master");
            masterSlider.value = vol1;
        }
        if (PlayerPrefs.HasKey("Music"))
        {
            vol2 = PlayerPrefs.GetFloat("Music");
            musicSlider.value = vol2;
        }
        if(PlayerPrefs.HasKey("Sound Effects"))
        {
            vol3 = PlayerPrefs.GetFloat("Sound Effects");
            soundEffectsSlider.value = vol3;
        }
        
    }

    public void SetLevelMusic(float sliderValue)
    {
        mixer.SetFloat("Music", Mathf.Log10(sliderValue)*20);
        PlayerPrefs.SetFloat("Music", sliderValue);
    }

    public void SetLevelSFX(float sliderValue)
    {
        mixer.SetFloat("Sound Effects", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Sound Effects", sliderValue);
    }

    public void SetLevelMaster(float sliderValue)
    {
        mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Master", sliderValue);
    }
}
