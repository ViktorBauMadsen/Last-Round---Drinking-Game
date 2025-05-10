using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenuManager : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;
    public Slider masterVol, Music, SFX;
    public AudioMixer mainAudioMixer;




    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }
    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("Master_Vol", masterVol.value);   //Master Value Slider
    }
    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("Music", Music.value);   //Music Value Slider
    }
    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("SFX", SFX.value);   //SFX Value Slider
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
