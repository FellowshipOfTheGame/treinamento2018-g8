﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {



    public enum RotationAxes { MouseXAndY = 0 }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityX = 2F;

    public float sensitivityY = 2F;

    public float minimumX = -120F;

    public float maximumX = 120F;

    public float minimumY = -50F;

    public float maximumY = 50F;

    float rotationX = 0F;

    float rotationY = 0F;

    Quaternion originalRotation;

    



    void Start() {

        originalRotation = transform.localRotation;

        Cursor.lockState = CursorLockMode.Locked;

    }





    void Update() {

        if (axes == RotationAxes.MouseXAndY) {

            //pega o input da rotação do mouse

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

            rotationX += Input.GetAxis("Mouse X") * sensitivityX;



            //especificar os valores até onde a camera poderá virar

            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            rotationX = ClampAngle(rotationX, minimumX, maximumX);



            //pega a rotação

            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);



            //rotaciona a camera

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;





        }

    }





    // função que vai ver o limite de rotação imposto, isso é feito de acordo com angulos 

    public static float ClampAngle(float angle, float minimum, float maximum) {

        angle = angle % 360;

        if ((angle >= 360F) && (angle <= 360F)) {

            if (angle < -360F) {

                angle += 360F;

            }

            if (angle > 360F) {

                angle -= 360F;

            }



        }



        return Mathf.Clamp(angle, minimum, maximum);

    }
}