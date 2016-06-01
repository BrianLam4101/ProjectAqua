using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoodBars : MonoBehaviour {
    StatHolder statBar;
    Slider slider;
    public string Name;

    // Use this for initialization
    void Start () {
        slider = GetComponent<Slider>();
        statBar = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Name == "Happiness")
        {
            slider.value = statBar.happiness / 100;
        }
        else if (Name == "Hunger")
        {
            slider.value = statBar.hunger / 100;
        }
        else if (Name == "Energy")
        {
            slider.value = statBar.energy / 100;
        }
        else if (Name == "Hygiene")
        {
            slider.value = statBar.hygiene / 100;
        }
        else if (Name == "Bladder")
        {
            slider.value = statBar.bladder / 100;
        }

    }
}
