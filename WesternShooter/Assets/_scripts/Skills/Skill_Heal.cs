using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Heal : Skill {

    public float HealInterval;
    public int HealPerInterval;
    private bool activated;

    Timer healTimer;
    Damageable userDamageable;

    public override void ActivateSkill(GameObject skillUser)
    {
        if (!activated)
        {
            activated = true;
            healTimer.StartTimer();
            userDamageable = skillUser.GetComponent<Damageable>();
        }

    }

    public override void DeactivateSkill(GameObject skillUser)
    {
        if (activated)
        {
            activated = false;
        }
    }

    void Awake()
    {
        healTimer = new Timer(HealInterval, false);
    }

    void Update()
    {
        healTimer.TickTimer(Time.deltaTime);

        if (healTimer.IsDone())
        {
            Heal();
            healTimer.Restart();
        }        
    }

    public void Heal()
    {
        if (activated)
        {
            userDamageable.Heal(HealPerInterval);
        }
    }
}
