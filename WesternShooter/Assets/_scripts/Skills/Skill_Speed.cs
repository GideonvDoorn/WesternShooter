using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Speed : Skill {

    public float SpeedMultiplier;
    private float originalSpeed;
    private bool activated;

    public override void ActivateSkill(GameObject skillUser)
    {
        if (!activated)
        {
            this.skillUser = skillUser;
            originalSpeed = skillUser.GetComponent<Movement>().Speed;
            skillUser.GetComponent<Movement>().ChangeSpeed(originalSpeed * SpeedMultiplier);

            activated = true;
        }
    }

    public override void DeactivateSkill(GameObject skillUser)
    {
        if (activated)
        {
            this.skillUser = skillUser;

            skillUser.GetComponent<Movement>().ChangeSpeed(originalSpeed);
            activated = false;
        }
    }
}
