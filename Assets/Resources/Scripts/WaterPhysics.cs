using UnityEngine;
using System.Collections;

public class WaterPhysics : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        GetComponent<SphereCollider>().radius = GetComponent<SphereCollider>().radius * Random.Range(0.5f, 0.75f);
    }
}
