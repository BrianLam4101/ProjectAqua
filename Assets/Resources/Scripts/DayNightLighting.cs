using UnityEngine;
using System.Collections;

public class DayNightLighting : MonoBehaviour {

    public float dayDuration;
    public float time;
    public float timeOfDay;
    Vector3 rotation;

	// Use this for initialization
	void Start () {
        time = 0;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timeOfDay = time % dayDuration;
        transform.Rotate(Vector3.right, (Time.deltaTime * (360/dayDuration)));
        if (timeOfDay < 0.1f)
            transform.rotation = Quaternion.Euler(0, 330, 0);
    }
}
