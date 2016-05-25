using UnityEngine;
using System.Collections;

public class sasdasdf : MonoBehaviour {

    GameObject water;
    StatHolder waterHolder;

    // Use this for initialization
    void Start () {
        water = Resources.Load<GameObject>("water_temp");
        waterHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.Mouse1)) {
            waterHolder.waterLevel -= 0.1f;
            GameObject drop = Instantiate<GameObject>(water);
            drop.transform.position = gameObject.transform.position + transform.forward * 1f;
            drop.transform.rotation = gameObject.transform.rotation;
            drop.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * 10, ForceMode.VelocityChange);
        }
	}
}
