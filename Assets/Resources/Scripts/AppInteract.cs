using UnityEngine;
using System.Collections;

public class AppInteract : Appliance {

    public float waterUsage;
    public float waterScale = 1;
    private GameObject water_pref;
    private Transform faucet;
    StatHolder waterHolder;
    private float on;

    void Start() {
        waterHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
        water_pref = Resources.Load<GameObject>("water_temp");
        faucet = transform.parent.Find("FAUCET");
    }

    void FixedUpdate() {
        if (on > 0) {
            if (waterHolder.wasteWater(waterUsage * on * Time.fixedDeltaTime)) {
                GameObject water = Instantiate<GameObject>(water_pref);
                water.transform.localScale = water.transform.localScale * waterScale;
                water.transform.SetParent(faucet);
                //Debug.Log(water.transform);
                water.transform.position = faucet.position + new Vector3(0, -.11f, 0);
                water.GetComponent<Rigidbody>().velocity = Vector3.down * 4;
            }
        } else if (Random.Range(0f, 100f) < 0.01f) {
            on += 0.1f;
        }
    }

    public override void appUse()
    {
        if (on > 0)
            on = 0;
        else
            on = 1;
    }
}
