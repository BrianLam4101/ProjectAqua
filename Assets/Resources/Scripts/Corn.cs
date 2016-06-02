using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Corn : Appliance {
    
    private float waterLevel;
    private GameObject[] corns;
    StatHolder waterHolder;
    public float hungerUp;
    private float num;

    // Use this for initialization
    void Start() {
        waterHolder = GameObject.Find("WaterLevel").GetComponent<StatHolder>();
        waterLevel = 26;
        Transform cornHolder = transform.parent.Find("Corns");
        corns = new GameObject[cornHolder.childCount];
        for (int i = 0; i < cornHolder.childCount; i++) {
            corns[i] = cornHolder.GetChild(i).gameObject;
        }
        corns = Randomize(corns);
        num = corns.Length / 100f;
        StartCoroutine("updateGrass", 0.25f);
    }

    GameObject[] Randomize(GameObject[] objects) {
        List<GameObject> randomized = new List<GameObject>();
        List<GameObject> original = new List<GameObject>(objects);
        while (original.Count > 0) {
            int index = Random.Range(0, original.Count);
            randomized.Add(original[index]);
            original.RemoveAt(index);
        }

        return randomized.ToArray();
    }

    IEnumerator updateGrass(float delay) {
        while (true) {
            for (int i = 0; i < corns.Length; i++) {
                if (i < waterLevel * num)
                    corns[i].SetActive(true);
                else
                    corns[i].SetActive(false);
            }
            yield return new WaitForSeconds(Random.Range(delay * 0.8f, delay * 1.2f));
        }
    }

    void OnCollisionStay(Collision collision) {
        if (waterLevel < 76 && collision.collider.CompareTag("Water")) {
            Destroy(collision.gameObject);
            waterLevel += 1;
        }
    }

    public override void appUse() {
        if (waterLevel > 0) {
            waterLevel -= 100 / corns.Length;
            waterHolder.hunger += hungerUp;
        }
    }
}
