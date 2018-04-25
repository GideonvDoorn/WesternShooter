using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyController : MonoBehaviour
{

    Movement movementComponent;
    Attacker attackerComponent;

    // Use this for initialization
    void Start()
    {
        movementComponent = GetComponent<Movement>();
        attackerComponent = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementComponent != null)
        {
            if (Random.Range(0, 10) == 0)
            {
                movementComponent.MoveRight();
            }
            if (Random.Range(0, 10) == 0)
            {
                movementComponent.MoveLeft();
            }
            if (Random.Range(0, 10) == 0)
            {
                movementComponent.MoveUp();
            }
            if (Random.Range(0, 10) == 0)
            {
                movementComponent.MoveDown();
            }
        }

        if(attackerComponent != null)
        {
            if(Random.Range(0,20) == 0)
            {
                attackerComponent.Attack();
            }
            if(Random.Range(0,300) == 0)
            {
                attackerComponent.SwitchToNextAttack();
            }
            if(Random.Range(0,300) == 0)
            {
                attackerComponent.SwitchToPreviousAttack();
            }
        }

    }
}
