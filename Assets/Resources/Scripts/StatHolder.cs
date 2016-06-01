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
    // Use this for initialization
    void Start () {
        hunger = 100;
        energy = 100;
        hygiene = 100;
        bladder = 100;

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
        waterLevel = Mathf.Clamp(waterLevel + Time.deltaTime, 0, 10000000000);
        hunger -= Time.deltaTime * .25f;
        hygiene -= Time.deltaTime * .15f;
        energy -= Time.deltaTime * .25f;
        bladder -= Time.deltaTime * .3f;

        happiness = hunger + hygiene + energy + bladder / 4;

    }
}
