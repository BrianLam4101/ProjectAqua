using UnityEngine;
using System.Collections;

public class WaterPhysics : MonoBehaviour {

    public AudioClip splashSound;
    SphereCollider collider;
    float originalScale;

    // Use this for initialization
    void Start () {
        collider = GetComponent<SphereCollider>();
        collider.radius = collider.radius * Random.Range(0.5f, 0.75f);
        float randomScale = transform.localScale.x * Random.Range(0.8f, 1.2f);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        originalScale = transform.localScale.x;
        StartCoroutine("slowlyDissapear");
    }

    void FixedUpdate() {
        Vector3 distance = (transform.parent.GetChild(Random.Range(0, transform.parent.childCount - 1)).position - transform.position);
        for (int i = 0; i < 10 && distance.magnitude > transform.lossyScale.x * 3; i++) {
            Vector3 d = (transform.parent.GetChild(Random.Range(0, transform.parent.childCount - 1)).position - transform.position);
            if (d.magnitude < distance.magnitude)
                distance = d;
        }
        if (distance.magnitude < transform.lossyScale.x * 3)
            GetComponent<Rigidbody>().AddForce((distance.normalized * transform.lossyScale.x * 3 - distance) * 5, ForceMode.Acceleration);
    }

    IEnumerator slowlyDissapear() {
        yield return new WaitForSeconds(Random.Range(1f,2f));
        transform.localScale = new Vector3(transform.localScale.x * 0.98f, transform.localScale.x * 0.98f, transform.localScale.x * 0.98f);
        while (transform.localScale.x > originalScale*0.2f) {
            float ratio = transform.localScale.x * Mathf.Pow(transform.localScale.x / originalScale, 0.25f);
            //float thing = transform.localScale.x - ((transform.localScale.x - ratio) * Time.deltaTime * 10);
            transform.localScale = new Vector3(ratio, ratio, ratio);
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision) {
        if (!collision.collider.CompareTag("Water") && Random.Range(0, 101) < 20)
            AudioSource.PlayClipAtPoint(splashSound, transform.position, gameObject.GetComponent<Rigidbody>().velocity.magnitude * 0.1f * Random.Range(0.25f, 1f));
    }
}
