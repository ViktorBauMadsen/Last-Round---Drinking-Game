using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

// Manages the settings menu for graphics quality and audio volumes.

public class SettingsMenuManager : MonoBehaviour
{
    // Dropdown for selecting graphics quality levels
    public TMP_Dropdown graphicsDropdown;

    // Sliders for controlling master, music, and SFX volume
    public Slider masterVol;
    public Slider Music;
    public Slider SFX;

    // Reference to the main audio mixer for setting volume levels
    public AudioMixer mainAudioMixer;


    // Called when the graphics quality dropdown value is changed.
    // Applies the selected graphics quality level.
    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }

    // Called when the master volume slider value is changed.
    // Sets the overall game volume in the audio mixer.
    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("Master_Vol", masterVol.value);
    }


    // Called when the music volume slider value is changed.
    // Adjusts the music volume channel in the audio mixer.
    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("Music", Music.value);
    }


    // Called when the SFX volume slider value is changed.
    // Adjusts the sound effects volume channel in the audio mixer.
    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("SFX", SFX.value);
    }
}
