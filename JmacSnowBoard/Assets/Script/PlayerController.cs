using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float fltTorqueAmount = 10f;
    [SerializeField] float fltBoostSpeed = 30f;
    [SerializeField] float fltBaseSpeed = 20f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow)) 
        {
            surfaceEffector2D.speed = fltBoostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = fltBaseSpeed;
        }
        // If we push up, then speed up
        // otherwise stay at normal speed
        // Access the surface effector 2d and change its speed
    }

    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(fltTorqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-fltTorqueAmount);
        }
    }
}
