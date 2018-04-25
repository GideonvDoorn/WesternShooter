using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBeam : Projectile {

    [Header("General")]
    public float Speed;
    public float LifeTimeInSeconds;

    private Timer destroyTimer;

    void Reset()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void Awake()
    {
        destroyTimer = new Timer(LifeTimeInSeconds, true);
    }

    void Update()
    {
        HandleMovement();
        HandleTimer();
    }

    void HandleMovement()
    {
        this.transform.Translate(Vector3.forward * 0.1f * Speed);
    }

    void HandleTimer()
    {
        destroyTimer.TickTimer(Time.deltaTime);

        if (destroyTimer.IsDone())
        {
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (AttackerCollider == null)
        {
            return;
        }

        if (other.name == AttackerCollider.name)
        {
            return;
        }

        other.gameObject.AddComponent<InputContoller>();

        //if (damageable != null)
        //{
        //    damageable.TakeDamage(currentDamage * playerStrenght);

        //    if (!Piercing)
        //    {
        //        Destroy(this.gameObject);

        //    }
        //    else
        //    {
        //        currentDamage -= Damage * PiercingWeakenMultiplier;
        //        if (currentDamage <= 0)
        //        {
        //            Destroy(this.gameObject);
        //        }
        //    }
        //}
    }
}
