using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : Projectile {

    [Header("General")]
    public float Damage;
    private float currentDamage;
    public float Speed;
    public float LifeTimeInSeconds;

    [Header("Weaken")]
    public bool WeakensOverTime;
    public float WeakenInterval;
    public float WeakenMultiplier;

    private Timer destroyTimer;
    private Timer distanceTimer;

    void Reset()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void Awake()
    {
        currentDamage = Damage;
        destroyTimer = new Timer(LifeTimeInSeconds, true);

        if (WeakensOverTime)
        {
            distanceTimer = new Timer(LifeTimeInSeconds, true);

        }
    }

    void Update()
    {
        HandleTimers();
        HandleMovement();
    }

    void HandleMovement()
    {
        float sizeSpeed = 0.1f * Speed;
        this.transform.localScale += new Vector3(sizeSpeed, sizeSpeed, sizeSpeed);
    }
    
    void HandleTimers()
    {
        destroyTimer.TickTimer(Time.deltaTime);
        if (destroyTimer.IsDone())
        {
            Destroy(this.gameObject);
        }

        if (WeakensOverTime)
        {
            distanceTimer.TickTimer(Time.deltaTime);
            if (distanceTimer.IsDone())
            {
                currentDamage -= Damage * WeakenMultiplier;
                distanceTimer.Restart();
            }
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

            currentDamage -= Damage * WeakenMultiplier;
            if (currentDamage <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
