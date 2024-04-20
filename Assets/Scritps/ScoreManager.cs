using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SaveBestScore(int score)
    {
        PlayerPrefs.SetInt("BestScore", score);
        PlayerPrefs.Save();
    }

    public int LoadBestScore()
    {
        return PlayerPrefs.GetInt("BestScore", 0);
    }
}


