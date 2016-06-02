using UnityEngine;
using System.Collections;

public class Toilet : Appliance {

    public float waterUsage;
    public float waterScale = 1;
    private GameObject water_pref;
    StatHolder waterHolder;
    public float bladderUp;
    public AudioClip flushSound;
    
    private float timer = 0;

    void Start() {
        waterHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
        water_pref = Resources.Load<GameObject>("water_temp");
    }

    void FixedUpdate() {
        if (timer > Time.fixedTime) {
            GameObject water = Instantiate<GameObject>(water_pref);
            water.transform.localScale = water.transform.localScale * waterScale;
            water.transform.SetParent(gameObject.transform.parent);
            water.transform.position = gameObject.transform.parent.position + new Vector3(0.147f, 0.5702f, -0.552f) * 2.228996f;
            water.GetComponent<Rigidbody>().velocity = new Vector3(-0.1f, 1, 0.5f) * 10;
        }
    }

    public override void appUse() {
        if (!(timer > Time.fixedTime) && waterHolder.wasteWater(waterUsage)) {
            timer = Time.fixedTime + 2;
            waterHolder.bladder += bladderUp;
            AudioSource.PlayClipAtPoint(flushSound, transform.position);
        }
    }
}
