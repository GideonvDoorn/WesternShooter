using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Strength : Skill {

    public float StrengthMultiplier;
    private float originalStrength;
    private bool activated;

    public override void ActivateSkill(GameObject skillUser)
    {
        if (!activated)
        {
            this.skillUser = skillUser;
            originalStrength = skillUser.GetComponent<Attacker>().Strength;
            skillUser.GetComponent<Attacker>().Strength = originalStrength * StrengthMultiplier;
            activated = true;
        }      
    }

    public override void DeactivateSkill(GameObject skillUser)
    {
        if (activated)
        {
            this.skillUser = skillUser;

            skillUser.GetComponent<Attacker>().Strength = originalStrength;
            activated = false;
        }
    }
}