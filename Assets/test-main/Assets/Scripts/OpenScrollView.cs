using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenScrollView : MonoBehaviour
{
    [SerializeField] private GameObject scrollView;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject settingsButton;

    public void ShowScrollView()
    {
        scrollView.SetActive(true);
        playButton.SetActive(false);
        settingsButton.SetActive(false);
    }

    public void HideScrollView()
    {
        scrollView.SetActive(false);
        playButton.SetActive(true);
        settingsButton.SetActive(true);
    }

}
