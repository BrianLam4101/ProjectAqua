using UnityEngine;
using System.Collections;

public class AppInteract : Appliance {

    public float waterUsage;
    public float waterScale = 1;
    private GameObject water_pref;
    private Transform faucet;
    StatHolder waterHolder;
    private float on;
    public float hygieneUp;
    public float hungerUp;

    private float timer = 0;

    void Start() {
        waterHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
        water_pref = Resources.Load<GameObject>("water_temp");
        faucet = transform.parent.Find("FAUCET");
    }

    void FixedUpdate() {
        if (on >= 1) {
            if (waterHolder.wasteWater(waterUsage * Time.fixedDeltaTime)) {
                GameObject water = Instantiate<GameObject>(water_pref);
                water.transform.localScale = water.transform.localScale * waterScale;
                water.transform.SetParent(faucet);
                water.transform.position = faucet.position + new Vector3(0, -.11f, 0);
                water.GetComponent<Rigidbody>().velocity = Vector3.down * 4;
                if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 5) {
                    waterHolder.hygiene += hygieneUp * Time.fixedDeltaTime;
                    waterHolder.hunger += hungerUp;
                }

            }
        }
        else {
            if (on > 0) {
                if (timer <= 0) {
                    waterHolder.wasteWater(waterUsage * on);
                    GameObject water = Instantiate<GameObject>(water_pref);
                    water.transform.localScale = water.transform.localScale * waterScale;
                    water.transform.SetParent(faucet);
                    water.transform.position = faucet.position + new Vector3(0, -.11f, 0);
                    timer = 1 - on;
                }
                else
                    timer -= Time.fixedDeltaTime;
            }
            else
                timer = 0;
            if (Random.Range(0f, 100f) < 0.01f) {
                on += 0.1f;
            }
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
