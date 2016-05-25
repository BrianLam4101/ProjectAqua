using UnityEngine;
using System.Collections;

public class DayNightLighting : MonoBehaviour {

    public float time;
    Vector3 rotation;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right, (Time.deltaTime * 5));
	}
}
