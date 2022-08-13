using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutionList;

    void Start()
    {
        resolutionList = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i=0; i < resolutionList.Length; i++)
        {
            string option = resolutionList[i].width + "x" + resolutionList[i].height;
            options.Add(option);

            if (resolutionList[i].width == Screen.currentResolution.width &&
                resolutionList[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution (int resolutionIndex) 
    {
        Resolution resolution = resolutionList[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMusicVolume (float musicvolume)
    {
        audioMixer.SetFloat("MusicParameter", musicvolume);
    }

    public void SetSfxVolume(float sfxvolume)
    {
        audioMixer.SetFloat("SfxParameter", sfxvolume);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
