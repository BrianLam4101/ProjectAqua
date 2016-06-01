using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class waterBar : MonoBehaviour {

    Slider slider;
    Text text;
    StatHolder waterHolder;
    

    // Use this for initialization
    void Start () {
        slider = GetComponent<Slider>();
        text = GetComponentInChildren<Text>();
        waterHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = waterHolder.waterLevel / 100;
        text.text = ((int)waterHolder.waterLevel).ToString();
    }
}
