using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour {

    private RaycastHit lastRaycastHit;
    public GameObject AreaPickUp;
    PickObjects pc;
    CharacterController controller;
    bool SegBrinqTeletransporte;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        pc = AreaPickUp.GetComponent<PickObjects>();
    }

    void LateUpdate()
    {
        SegBrinqTeletransporte = false;

        if(pc.segurandoObj)
        {
            if(pc.objetoAPegar == this.gameObject)
            {
                SegBrinqTeletransporte = true;
            }
        }


        if (SegBrinqTeletransporte)
        {
            if (Input.GetButtonDown("Action"))
            {
                if (GetLookedAtObject() != null)
                {
                    TeleportToLookAt();
                }
            }
        }
       

    }
    private GameObject GetLookedAtObject()
    {
        Vector3 origem = transform.position;
        Vector3 direcao = Camera.main.transform.forward;
        float range = 1000;
        if(Physics.Raycast (origem, direcao, out lastRaycastHit, range))
        {
            return lastRaycastHit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    private void TeleportToLookAt()
    {
        transform.position = lastRaycastHit.point + lastRaycastHit.normal * 2;

    }

    void Update()
    {
        if(Input.GetButtonDown("Action"))
        {
            if(GetLookedAtObject() != null)
            {
                TeleportToLookAt();
            }
        }
    }
}
