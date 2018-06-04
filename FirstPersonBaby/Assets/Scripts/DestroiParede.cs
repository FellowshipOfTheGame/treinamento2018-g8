using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiParede : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("destroy"))
        {
            other.gameObject.SetActive(false);
        }

    }
}
