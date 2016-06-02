using UnityEngine;
using System.Collections;

public class DayNightLighting : MonoBehaviour {

    public float dayDuration;
    public float time;
    public float timeOfDay;
    public float waterGain;
    private float waterVelocity;
    StatHolder waterHolder;
    Vector3 rotation;

	// Use this for initialization
	void Start () {
        time = 0;
        waterHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
        waterGain = 90;
        waterVelocity = 0;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timeOfDay += Time.deltaTime;
        if (timeOfDay > dayDuration) {
            timeOfDay = dayDuration - timeOfDay;
            transform.rotation = Quaternion.Euler(0, 330, 0);
            waterHolder.wasteWater(-waterGain);
            GameObject text = Instantiate<GameObject>(Resources.Load<GameObject>("WaterGained"));
            text.transform.SetParent(GameObject.Find("Water Bar").transform);
            text.transform.position = GameObject.Find("Water Bar").transform.position;
            text.GetComponent<FlyingWater>().amount = waterGain;
            waterVelocity = Mathf.Clamp(waterVelocity + Random.Range((50 - waterGain)/10, (100 - waterGain)/10), -10, 5);
            waterGain = Mathf.Clamp(waterGain + waterVelocity, 60, 120);
        }
        transform.Rotate(Vector3.right, (Time.deltaTime * (360/dayDuration)));
    }
}
