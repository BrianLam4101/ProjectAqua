using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bed : Appliance {
    
    StatHolder statHolder;
    DayNightLighting time;
    public float energyUp;
    Image fadeBlack;

    void Start() {
        statHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
        time = GameObject.Find("Sun").GetComponent<DayNightLighting>();
        fadeBlack = GameObject.Find("FadeBlack").GetComponent<Image>();
    }

    public override void appUse() {
        float timeDiffrence = time.dayDuration - time.timeOfDay - 0.2f;

        statHolder.energy += energyUp;
        statHolder.hunger -= statHolder.hungerPerSec * timeDiffrence * 0.4f;
        statHolder.hygiene -= statHolder.hygienePerSec * timeDiffrence * 0.2f;
        statHolder.bladder -= statHolder.bladderPerSec * timeDiffrence * 0.8f;

        time.time += timeDiffrence;
        time.timeOfDay += timeDiffrence;

        StartCoroutine("fadeDelayed", 0.025f);
    }

    IEnumerator fadeDelayed (float delay) {
        fadeBlack.color = Color.black;
        yield return new WaitForSeconds(delay);
        Color c = fadeBlack.color;
        while (fadeBlack.color.a > 0) {
            fadeBlack.color = c;
            c.a -= 0.025f;
            yield return new WaitForSeconds(delay);
        }
    }
}
