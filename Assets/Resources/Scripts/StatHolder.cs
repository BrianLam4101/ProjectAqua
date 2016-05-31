using UnityEngine;
using System.Collections;

public class StatHolder : MonoBehaviour {

    public float waterLevel;

	// Use this for initialization
	void Start () {
	
	}

    public bool wasteWater(float amount) {
        if (waterLevel >= amount) {
            waterLevel -= amount;
            return true;
        }
        return false;
    }
	
	// Update is called once per frame
	void Update () {
        waterLevel = Mathf.Clamp(waterLevel + Time.deltaTime, 0, 10000000000);

    }
}
