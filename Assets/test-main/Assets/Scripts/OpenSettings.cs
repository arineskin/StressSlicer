using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSettings : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject playButton;

    public void ShowSettings()
    {
        settings.SetActive(true);
        playButton.SetActive(false);
        settingsButton.SetActive(false);
    }

    public void HideSettings()
    {
        settings.SetActive(false);
        playButton.SetActive(true);
        settingsButton.SetActive(true);
    }

}
