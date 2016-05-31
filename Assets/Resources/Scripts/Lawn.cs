using UnityEngine;
using System.Collections;

public class Lawn : MonoBehaviour {

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
        num = grass.Length / 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        waterLevel -= 1 * Time.deltaTime;
        for (int i = 0; i < waterLevel * num; i++) {
            grass[i].SetActive(true);
        }
        for (int i = transform.childCount - 1; i > waterLevel * num; i--) {
            grass[i].SetActive(false);
        }
    }

    void OnCollisionStay(Collision collision) {
        if (waterLevel <= 100 && collision.collider.CompareTag("Water")) {
            Destroy(collision.gameObject);
            waterLevel += 1;
        }
    }
}
