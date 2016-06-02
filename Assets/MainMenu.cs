using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void startGame() {
        SceneManager.LoadScene("test");
    }

    public void controls() {
        SceneManager.LoadScene("controls");
    }

    public void credits() {
        SceneManager.LoadScene("credits");
    }

    public void exitGame() {
        Application.Quit();
    }
}
