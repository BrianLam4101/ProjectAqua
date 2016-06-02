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
    private float Thirst;
    public float thirst {
        get {
            return Thirst;
        }
        set {
            Thirst = Mathf.Clamp(value, 0, 100);
        }
    }
    public float happiness;

    public float hungerPerSec;
    public float hygienePerSec;
    public float energyPerSec;
    public float bladderPerSec;
    public float thirstPerSec;

    private GameObject player;
    private Vector3 prevPos;

    public GameObject gameOverScreen;
    // Use this for initialization
    void Start () {
        hunger = 100;
        energy = 100;
        hygiene = 100;
        bladder = 100;
        thirst = 100;

        hungerPerSec = 0.5f;
        hygienePerSec = 0.3f;
        energyPerSec = 0.5f;
        bladderPerSec = 0.6f;
        thirstPerSec = 1f;

        player = GameObject.Find("Player");
        prevPos = player.transform.position;
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
        hunger -= Time.deltaTime * hungerPerSec * (energy < 50 ? (energy < 5 ? 2f : 1.5f) : 1);
        hygiene -= Time.deltaTime * hygienePerSec * (bladder < 33 ? (bladder < 5 ? 5f : 2.5f) : 1);
        energy -= Time.deltaTime * energyPerSec * (hunger < 50 ? (hunger < 15 ? 4 : 2) : 1) * (thirst < 50 ? (thirst < 15 ? 6 : 3) : 1);
        bladder -= Time.deltaTime * bladderPerSec * (hunger > 75 ? (hunger > 95 ? 3f : 1.5f) : 1);
        thirst -= Time.deltaTime * thirstPerSec;

        happiness = (hunger + hygiene + energy + bladder) / 4;

        if (hunger <= 0 || thirst <= 0) {
            gameOverScreen.SetActive(true);
        }
    }

    void FixedUpdate() {
        energy -= Vector3.Distance(prevPos, player.transform.position) * 0.1f;
        thirst -= Vector3.Distance(prevPos, player.transform.position) * 0.1f;
        prevPos = player.transform.position;
    }
}
