using UnityEngine;
using System.Collections;

public class Bed : Appliance {
    
    StatHolder statHolder;
    DayNightLighting time;
    public float energyUp;

    void Start() {
        statHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
        time = GameObject.Find("Sun").GetComponent<DayNightLighting>();
    }

    public override void appUse() {
        float timeDiffrence = time.dayDuration - time.timeOfDay - 0.2f;

        statHolder.energy += energyUp;
        statHolder.hunger -= statHolder.hungerPerSec * timeDiffrence * 0.4f;
        statHolder.hygiene -= statHolder.hygienePerSec * timeDiffrence * 0.2f;
        statHolder.bladder -= statHolder.bladderPerSec * timeDiffrence * 0.8f;

        time.time += timeDiffrence;
        time.timeOfDay += timeDiffrence;
    }
}
