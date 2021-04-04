﻿using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody Player;
    private Transform myTransform;              // this transform
    private Vector3 destinationPosition;        // The destination Point
    private float destinationDistance;          // The distance between myTransform and destinationPosition
    private GameObject Pushtext;
    private Animator playerAnimator;

    public float moveSpeed;                     // The Speed the character will move



    void Start()
    {
        myTransform = transform;                            // sets myTransform to this GameObject.transform
        destinationPosition = myTransform.position;         // prevents myTransform reset
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetBool("Move", false);
    }

    void Update()
    {

        // Отслеживает расстояние между объектом и точкой назначения.
        destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);

        if (destinationDistance < .5f)
        {
            playerAnimator.SetBool("Move", false);
            moveSpeed = 0; // Объект не может двигаться, если расстояния меньше 0.5.
        }
        else if (destinationDistance > .5f)
        {
            playerAnimator.SetBool("Move", true);
            moveSpeed = 10; // Сброс скорости перемещения до стандартной.
        }


        // Движение, если игрок нажал на кнопку мыши.
        if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        {
            Plane playerPlane = new Plane(Vector3.up, myTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                destinationPosition = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                myTransform.rotation = targetRotation;
            }
        }

        // Движение, если игрок удерживает клавишу мыши.
        else if (Input.GetMouseButton(0) && GUIUtility.hotControl == 0)
        {
            Plane playerPlane = new Plane(Vector3.up, myTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                destinationPosition = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                myTransform.rotation = targetRotation;
            }
        }
        if (destinationDistance > .5f)
        {
            myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
        }
    }
}