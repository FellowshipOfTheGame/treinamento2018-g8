using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour {

    private RaycastHit lastRaycastHit;
    public GameObject AreaPickUp;
    PickObjects pc;
    CharacterController controller;
    bool SegBrinqTeletransporte;
    public float distancia = 2.0f;
    public float range = 1000;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        pc = AreaPickUp.GetComponent<PickObjects>();
    }

    void Update()
    {
        SegBrinqTeletransporte = false;


       

        if (pc.segurandoObj)
        {
            if(pc.objetoAPegar == this.gameObject)
            {
                SegBrinqTeletransporte = true;
            }
        }


        if (SegBrinqTeletransporte)
        {
           /*Vector3 origem = controller.transform.position + Vector3.forward;

            Vector3 direcao = 1.2f*Camera.main.transform.forward;
             Ray ray = new Ray(origem, direcao);
             Debug.DrawRay(ray.origin, ray.direction, Color.black);*/

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
        Vector3 origem = controller.transform.position + Vector3.forward;
      
        Vector3 direcao = 1.2f*Camera.main.transform.forward;

        if (Physics.Raycast (origem, direcao, out lastRaycastHit, range))
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
        
        controller.transform.position = lastRaycastHit.point + lastRaycastHit.normal * distancia;

    }

  
}
