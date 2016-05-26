using UnityEngine;
using System.Collections;

public class AppInteract : Appliance {

    public float waterScale = 1;
    private GameObject water_pref;
    private Transform faucet;

    void Start()
    {
        water_pref = Resources.Load<GameObject>("water_temp");
        faucet = transform.parent.Find("FAUCET");
    }

    public override void appUse()
    {
        GameObject water = Instantiate<GameObject>(water_pref);
        water.transform.localScale = water.transform.localScale * waterScale;
        water.transform.SetParent(faucet);
        Debug.Log(water.transform);
        water.transform.position = faucet.position + new Vector3 (0, -.11f, 0);
    }
}
