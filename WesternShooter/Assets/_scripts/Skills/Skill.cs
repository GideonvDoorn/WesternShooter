using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour {

    public string SkillName;
    [System.NonSerialized]public GameObject skillUser;
    public virtual void ActivateSkill(GameObject skillUser)
    {
        this.skillUser = skillUser;
    }

    public virtual void DeactivateSkill(GameObject skillUser)
    {
        this.skillUser = skillUser;

    }
}
