using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lawn : MonoBehaviour {

    public float degenPerSec;
    private float waterLevel;
    private GameObject[] grass;
    private float num;

	// Use this for initialization
	void Start () {
        waterLevel = 75;
        grass = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            grass[i] = transform.GetChild(i).gameObject;
        }
        grass = Randomize(grass);
        num = grass.Length / 100;
        StartCoroutine("updateGrass", 0.5f);
	}

    GameObject[] Randomize(GameObject[] objects) {
        List<GameObject> randomized = new List<GameObject>();
        List<GameObject> original = new List<GameObject>(objects);
        while (original.Count > 0) {
            int index = Random.Range(0,original.Count);
            randomized.Add(original[index]);
            original.RemoveAt(index);
        }

        return randomized.ToArray();
    }

    IEnumerator updateGrass (float delay) {
        while (true) {
            waterLevel = Mathf.Clamp(waterLevel - (degenPerSec * delay), 0, 100);
            for (int i = 0; i < waterLevel * num; i++) {
                grass[i].SetActive(true);
            }
            for (int i = transform.childCount - 1; i > waterLevel * num; i--) {
                grass[i].SetActive(false);
            }
            yield return new WaitForSeconds(Random.Range(delay * 0.8f, delay * 1.2f));
        }
    }

    void OnCollisionStay(Collision collision) {
        if (waterLevel <= 100 && collision.collider.CompareTag("Water")) {
            Destroy(collision.gameObject);
            waterLevel += 1;
        }
    }
}
