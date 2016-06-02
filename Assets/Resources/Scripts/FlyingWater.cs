using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlyingWater : MonoBehaviour {

    public float baseVelocity;
    private float velocity;
    public float acceleration;
    public float amount;
    Text text;
    Color c;

    void Start() {
        text = GetComponentInChildren<Text>();
        velocity = baseVelocity;
        c = text.color;
        text.text = "+" + ((int)amount).ToString();
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(new Vector3(0, velocity, 0));
        velocity += acceleration;
        c.a = velocity / baseVelocity;
        text.color = c;
        if (velocity <= 0)
            Destroy(gameObject);
	}
}
