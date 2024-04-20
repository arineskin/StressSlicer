using UnityEngine;
using UnityEngine.SceneManagement;

public class resumeScript : MonoBehaviour
{
[SerializeField] GameObject PauseMenu;

public void Resume()
{
    PauseMenu.SetActive(false);
    Time.timeScale = 1;


}

}
