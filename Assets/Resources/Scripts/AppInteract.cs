using UnityEngine;
using System.Collections;

public class AppInteract : Appliance {

    public float waterUsage;
    public float waterScale = 1;
    private GameObject water_pref;
    private Transform faucet;
    StatHolder waterHolder;
    private bool on;

    void Start() {
        waterHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
        water_pref = Resources.Load<GameObject>("water_temp");
        faucet = transform.parent.Find("FAUCET");
    }

    void FixedUpdate() {
        if (on && waterHolder.wasteWater(waterUsage * Time.fixedDeltaTime)) {
            GameObject water = Instantiate<GameObject>(water_pref);
            water.transform.localScale = water.transform.localScale * waterScale;
            water.transform.SetParent(faucet);
            Debug.Log(water.transform);
            water.transform.position = faucet.position + new Vector3(0, -.11f, 0);
        }
    }

    public override void appUse()
    {
        on = !on;
    }
}
