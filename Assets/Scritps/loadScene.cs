using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class loadScene : MonoBehaviour
{
    public Image slider;

    void Start()
    {
        StartCoroutine(LoadSceneGame());
    }
    IEnumerator LoadSceneGame()
    {
        AsyncOperation LoadAsync = SceneManager.LoadSceneAsync("nojspace1");

        while (!LoadAsync.isDone)
        {
            float progress = LoadAsync.progress;
            slider.fillAmount = progress;
            yield return null;
        }
    }
}