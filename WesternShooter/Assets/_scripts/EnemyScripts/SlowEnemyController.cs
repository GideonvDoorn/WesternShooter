using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemyController : MonoBehaviour
{

    Movement movementComponent;

    // Use this for initialization
    void Start()
    {
        movementComponent = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementComponent != null)
        {
            if (Random.Range(0, 60) == 0)
            {
                movementComponent.MoveRight();
            }
            if (Random.Range(0, 60) == 0)
            {
                movementComponent.MoveLeft();
            }
            if (Random.Range(0, 60) == 0)
            {
                movementComponent.MoveUp();
            }
            if (Random.Range(0, 60) == 0)
            {
                movementComponent.MoveDown();
            }
        }
    }
}
