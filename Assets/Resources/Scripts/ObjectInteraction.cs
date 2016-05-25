using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {
    public float distance;
    private RaycastHit fphit;
	// Update is called once per frame
	void Update ()
    {
        
        if ((Physics.Raycast(this.transform.position, this.transform.forward, out fphit, distance)) && (fphit.collider.gameObject.CompareTag("Appliance")) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("got an appliance and left-click" + " | " + fphit.collider.gameObject);
            fphit.collider.GetComponent<Appliance>().appUse();
        }
	}
}
