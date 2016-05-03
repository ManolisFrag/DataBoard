using UnityEngine;
using System.Collections;

public class ForceForDice : MonoBehaviour {

    public string buttonName = "Fire1";
    public float forceAmount = 10.0f;
    public ForceMode forceMode;
    public float torqueAmount = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(buttonName))
        {
            GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * forceAmount, forceMode);
            GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount,forceMode);
        }

	
	}
}
