using UnityEngine;
using System.Collections;

public class StatHolder : MonoBehaviour {

    public float waterLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        waterLevel += Time.deltaTime;

    }
}
