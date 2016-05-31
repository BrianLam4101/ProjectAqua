using UnityEngine;
using System.Collections;

public class SprayWater : MonoBehaviour {

    GameObject water;
    StatHolder waterHolder;

    // Use this for initialization
    void Start () {
        water = Resources.Load<GameObject>("water_temp");
        waterHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.Mouse1) && waterHolder.wasteWater(0.1f)) {
            GameObject drop = Instantiate<GameObject>(water);
            drop.transform.SetParent(GameObject.Find("PlayerWater").transform);
            drop.transform.position = gameObject.transform.position + transform.forward * 0.5f + transform.up * -0.3f + transform.right * 0.2f;
            drop.transform.rotation = gameObject.transform.rotation;
            drop.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * 10, ForceMode.VelocityChange);
        }
	}
}
