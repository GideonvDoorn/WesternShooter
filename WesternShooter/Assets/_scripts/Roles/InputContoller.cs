using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputContoller : MonoBehaviour {

    Movement movementComponent;
    Attacker attackerComponent;
    SkillUser skillComponent;

	// Use this for initialization
	void Start () {
        movementComponent = GetComponent<Movement>();
        attackerComponent = GetComponent<Attacker>();
        skillComponent = GetComponent<SkillUser>();
	}
	
	// Update is called once per frame
	void Update () {
        if (movementComponent != null)
        {
            //input
            if (Input.GetKey(KeyCode.D))
            {
                movementComponent.MoveRight();
            }
            if (Input.GetKey(KeyCode.A))
            {
                movementComponent.MoveLeft();
            }
            if (Input.GetKey(KeyCode.W))
            {
                movementComponent.MoveUp();
            }
            if (Input.GetKey(KeyCode.S))
            {
                movementComponent.MoveDown();
            }
        }

        if(attackerComponent != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackerComponent.Attack();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                attackerComponent.SwitchToPreviousAttack();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                attackerComponent.SwitchToNextAttack();
            }

        }
        if(skillComponent != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                skillComponent.SwitchToPreviousSkill();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                skillComponent.SwitchToNextSkill();
            }
        }
    }
}
