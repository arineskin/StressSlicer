using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class loadScene1 : MonoBehaviour
{
    public Image slider;

    void Start()
    {
        StartCoroutine(LoadSceneGame());
    }
    IEnumerator LoadSceneGame()
    {
        AsyncOperation LoadAsync = SceneManager.LoadSceneAsync("nojfood1");

        while (!LoadAsync.isDone)
        {
            float progress = LoadAsync.progress;
            slider.fillAmount = progress;
            yield return null;
        }
    }
}
