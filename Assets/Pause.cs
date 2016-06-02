using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour {


    DayNightLighting time;

    // Use this for initialization
    void Start () {
        PauseGame();
        time = GameObject.Find("Sun").GetComponent<DayNightLighting>();
        GameObject.Find("FadeBlack").SetActive(false);
        GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
        GameObject.Find("daysLast").GetComponent<Text>().text = ("You Lasted " + ((int)(time.time / time.dayDuration)).ToString() + " Days");
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
