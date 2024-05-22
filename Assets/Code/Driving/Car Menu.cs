using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CarMenu : MonoBehaviour {

    public Animator transition;

    public float transitionTime = 1f;

    public void LoadNextLevel(string sceneName) {
        transition.SetTrigger("Start");
        new WaitForSeconds(transitionTime);
        GoToScene(sceneName);
    }

    public void GoToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit() {
        Application.Quit();
    }

}
    