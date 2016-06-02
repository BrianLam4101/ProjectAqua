using UnityEngine;
using System.Collections;

public class StatHolder : MonoBehaviour {

    public float waterLevel;
    private float Hygiene;
    public float hygiene
    {
        get {
            return Hygiene;
        }
        set {
            Hygiene = Mathf.Clamp(value, 0, 100);
        }
    }

    private float Hunger;
    public float hunger
    {
        get
        {
            return Hunger;
        }
        set
        {
            Hunger = Mathf.Clamp(value, 0, 100);
        }
    }
    private float Bladder;
    public float bladder
    {
        get
        {
            return Bladder;
        }
        set
        {
            Bladder = Mathf.Clamp(value, 0, 100);
        }
    }
    private float Energy;
    public float energy
    {
        get
        {
            return Energy;
        }
        set
        {
            Energy = Mathf.Clamp(value, 0, 100);
        }
    }
    public float happiness;

    public float hungerPerSec;
    public float hygienePerSec;
    public float energyPerSec;
    public float bladderPerSec;
    // Use this for initialization
    void Start () {
        hunger = 50;
        energy = 90;
        hygiene = 80;
        bladder = 60;

        hungerPerSec = 0.5f;
        hygienePerSec = 0.3f;
        energyPerSec = 0.5f;
        bladderPerSec = 0.6f;


    }

    public bool wasteWater(float amount) {
        if (waterLevel >= amount) {
            waterLevel -= amount;
            return true;
        }
        return false;
    }
	
	// Update is called once per frame
	void Update () {
        hunger -= Time.deltaTime * .5f * (energy < 50 ? 1.5f : 1);
        hygiene -= Time.deltaTime * .3f * (bladder < 33 ? 2.5f : 1);
        energy -= Time.deltaTime * .5f * (hunger < 50 ? 2 : 1);
        bladder -= Time.deltaTime * .6f * (hunger > 75 ? 1.5f : 1);
        
        happiness = (hunger + hygiene + energy + bladder) / 4;

    }
}
