using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {
    public float distance;
    private RaycastHit fphit;

    public GameObject crossHair;
    public GameObject hand;

	// Update is called once per frame
	void Update ()
    {
        var layerMask = (1 << 4) + (5 << 8);
        if ((Physics.Raycast(this.transform.position, this.transform.forward, out fphit, distance, ~layerMask)) && (fphit.collider.gameObject.CompareTag("Appliance"))) {
            crossHair.SetActive(false);
            hand.SetActive(true);
            if (Input.GetMouseButtonDown(0)) {
                //Debug.Log("got an appliance and left-click" + " | " + fphit.collider.gameObject);
                foreach (Appliance x in fphit.collider.GetComponents<Appliance>()) {
                    x.appUse();
                }
            }
        } else {
            crossHair.SetActive(true);
            hand.SetActive(false);
        }
	}
}
