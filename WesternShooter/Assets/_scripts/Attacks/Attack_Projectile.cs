using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Projectile : Attack {

    public Projectile projectile;
    public float Cooldown;

    Timer CooldownTimer;

    public override void InitiateAttack(float strenght)
    {
        if (CooldownTimer.IsDone())
        {

            Projectile p = Instantiate(projectile, this.transform.position, this.transform.rotation);
            p.AttackerCollider = GetComponentInParent<Collider>();
            p.playerStrenght = strenght;

            CooldownTimer.Restart();
        }
    }

    void Awake()
    {
        CooldownTimer = new Timer(Cooldown, false);
    }

    void Update()
    {

        CooldownTimer.TickTimer(Time.deltaTime);       
    }
}