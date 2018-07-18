using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravidadeInvertida : MonoBehaviour {

	void Update () {
        GetComponent<Rigidbody>().AddForce(-2 * Physics.gravity);
	}
}
