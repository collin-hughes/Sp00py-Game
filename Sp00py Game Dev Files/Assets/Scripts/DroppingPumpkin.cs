using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingPumpkin : MonoBehaviour {

    public GameObject pumpkinSource;

	// Use this for initialization
	void Start () {
        //Find the pumpkinSource game object
        pumpkinSource = GameObject.Find("pumpkinSource");

        //Set the initial position of the pumpkin
        transform.SetPositionAndRotation(pumpkinSource.transform.position, pumpkinSource.transform.rotation);

        //Destroy the pumpkin after two seconds
        Destroy(gameObject, 2f);
	}
}
