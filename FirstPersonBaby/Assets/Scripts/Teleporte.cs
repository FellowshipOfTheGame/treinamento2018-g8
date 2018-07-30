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
    public GameObject mira;
   
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        pc = AreaPickUp.GetComponent<PickObjects>();
        mira.SetActive(false);
      
       
    }

    void Update()
    {
        SegBrinqTeletransporte = false;

        mira.SetActive(false);
        

        if (pc.segurandoObj)
        {
            if(pc.objetoAPegar == this.gameObject)
            {
                SegBrinqTeletransporte = true;
            }
        }


        if (SegBrinqTeletransporte)
        {
            mira.SetActive(true);
            Vector3 origem = Quaternion.Euler(Camera.main.transform.eulerAngles) * Vector3.forward;
            Ray ray = new Ray(Camera.main.transform.position, origem);
             Debug.DrawRay(ray.origin, ray.direction, Color.black);

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
        
        Vector3 origem = Quaternion.Euler(Camera.main.transform.eulerAngles) * Vector3.forward;
        Ray ray = new Ray(Camera.main.transform.position, origem);
        

        if (Physics.Raycast (ray, out lastRaycastHit, range))
        {
          // Debug.Log(lastRaycastHit.collider.tag);
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



