using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
        PauseGame();
        GameObject.Find("FadeBlack").SetActive(false);
        GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public static void PauseGame() {
        Time.timeScale = 0;
    }

    public static void ResumeGame() {
        Time.timeScale = 1;
    }

    public static bool IsPaused() {
        return Time.timeScale == 0;
    }

    public void mainMenu() {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame() {
        Application.Quit();
    }
}
