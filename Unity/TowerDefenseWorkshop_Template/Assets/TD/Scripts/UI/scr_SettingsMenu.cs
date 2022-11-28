using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;


public class scr_SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropDown;

    Resolution[] resolutions;

    [SerializeField]
    private Button _optionsButton;


    //[SerializeField]
    //private Button _optionsReturn;

    [SerializeField]
    private GameObject _mainMenu;

    [SerializeField]
    private GameObject _optionSetting;


    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality ( int qualityIndex )
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void OptionsClicked ()
    {
        _mainMenu.SetActive(false);
        _optionSetting.SetActive(true);
    }

    public void OptionsReturn ()
    {
        _optionSetting.SetActive(false);
        _mainMenu.SetActive(true);

    }

}
