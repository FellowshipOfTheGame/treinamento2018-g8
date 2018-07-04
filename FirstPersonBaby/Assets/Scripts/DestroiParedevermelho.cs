using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiParedevermelho : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("destroyred"))
        {
            other.gameObject.SetActive(false);
        }

    }
}
