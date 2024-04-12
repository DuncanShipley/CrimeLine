using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMenu : MonoBehaviour {
    public void GoToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
    