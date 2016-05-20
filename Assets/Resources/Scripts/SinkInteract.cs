using UnityEngine;
using System.Collections;

public class SinkInteract : Appliance {
    private GameObject water_pref;
    private Transform faucet;

    void Start()
    {
        water_pref = Resources.Load<GameObject>("water_temp");
        faucet = transform.FindChild("FAUCET");
    }

    public override void appUse()
    {
        //Debug.Log("sink things");
        GameObject water = Instantiate(water_pref);
        water.transform.SetParent(faucet);
        water.transform.position = faucet.position + new Vector3 (0, -.3f, -.5f);
    }
}
