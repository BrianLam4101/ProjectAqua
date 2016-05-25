using UnityEngine;
using System.Collections;

public class SinkInteract : Appliance {
    private GameObject water_pref;
    private Transform faucet;

    void Start()
    {
        water_pref = Resources.Load<GameObject>("water_temp");
        faucet = transform.parent.FindChild("FAUCET");
    }

    public override void appUse()
    {
        GameObject water = Instantiate(water_pref);
        water.transform.SetParent(faucet);
        Debug.Log(water.transform.parent);
        water.transform.position = faucet.position + new Vector3 (0, -.053f, -.055f);
    }
}
