using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoCrazy : MonoBehaviour {

    Slider slider;
    Text text;
    float velocity;

    // Use this for initialization
    void Start () {
        slider = GetComponent<Slider>();
        //text = GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        velocity += Random.Range(-0.01f, 0.01f);
        float value = slider.value + velocity;
        if (value > 1) {
            value = 1;
            velocity = 0;
        } else if (value < 0) {
            value = 0;
            velocity = 0;
        }
        slider.value = value;
        //text.text = ((int)(value * 100)).ToString();
    }
}
