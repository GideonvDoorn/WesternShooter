using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Projectile {

    [Header("General")]
    public float Damage;
    private float currentDamage;
    public float Speed;
    public float LifeTimeInSeconds;

    [Header("Piercing")]
    public bool Piercing;
    public float PiercingWeakenMultiplier;

    private Timer destroyTimer;

    void Reset()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void Awake()
    {
        currentDamage = Damage;
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

        Damageable damageable = other.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(currentDamage * playerStrenght);

            if (!Piercing)
            {
                Destroy(this.gameObject);

            }
            else
            {
                currentDamage -= Damage * PiercingWeakenMultiplier;
                if (currentDamage <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
