using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float Speed;

    private float currentSpeed;

    void Awake()
    {
        currentSpeed = Speed;


    }

    public void MoveRight()
    {
        this.transform.Translate(Vector3.forward * 0.1f * currentSpeed);
        this.transform.rotation = Quaternion.Euler(0,90,0);
    }
    public void MoveLeft()
    {
        this.transform.Translate(Vector3.forward * 0.1f * currentSpeed);
        this.transform.rotation = Quaternion.Euler(0, -90, 0);

    }
    public void MoveUp()
    {
        this.transform.Translate(Vector3.forward *  0.1f * currentSpeed);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void MoveDown()
    {
        this.transform.Translate(Vector3.forward * 0.1f * currentSpeed);
        this.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public void ChangeSpeed(float speed)
    {
        currentSpeed = speed;

    }
}
