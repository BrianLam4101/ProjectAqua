using UnityEngine;
using System.Collections;

public class sink : Appliance {

    public float waterUsage;
    StatHolder waterHolder;

    void Start() {

        waterHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
    }

    public override void appUse() {
        //Debug.Log("sink things");

        waterHolder.waterLevel -= waterUsage;
    }
}
