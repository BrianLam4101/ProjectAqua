using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playAnimation : MonoBehaviour {

    Sprite[] images;
    Image image;

    int frame;
    float delay;

	// Use this for initialization
	void Start () {
        images = Resources.LoadAll<Sprite>("interact");
        image = GetComponent<Image>();
        frame = 0;
        delay = 0;

    }

    void Update () {
        if (delay < Time.fixedTime) {
            image.sprite = images[frame];
            frame++;
            if (frame >= images.Length)
                frame = 0;
            delay = Time.fixedTime + 0.2f;
        }
    }
}
