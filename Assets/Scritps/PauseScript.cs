using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
[SerializeField] GameObject PauseMenu;

public void Pause()
{
    PauseMenu.SetActive(true);
    Time.timeScale = 0;
}

}
