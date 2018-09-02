using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncararPlayer : MonoBehaviour {

    public GameObject robo;

	void Update () {
        gameObject.transform.LookAt(robo.transform.position, -Vector3.up);
	}
}
