using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    private Resolution[] _resolutions;   

    public TMPro.TMP_Dropdown resolutionDropdown;

    //Ridiculously hard to script Resolution Function because unity does not have a built in function for comparing resolutions.
    private void Start()
    {
        _resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        var options = new List<string>();

        var currentResolutionsIndex = 0;

        for (var i=0; i < _resolutions.Length; i++)
        {
            var option = _resolutions[i].width + " x " + _resolutions[i].height;
            options.Add(option);

            if (_resolutions[i].width==Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionsIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionsIndex;
        resolutionDropdown.RefreshShownValue();
    }
    //Finally setting the resolution (I love unity (I dont) )
    public void SetResolution (int resolutionIndex)
    {
        var resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }   
    //Set Volume Function
    public void SetVolume(float volume)
    {
      audioMixer.SetFloat("MainVolume", volume);
   }
    //Set Game Quality Function
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    //Fullscreen Function
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
