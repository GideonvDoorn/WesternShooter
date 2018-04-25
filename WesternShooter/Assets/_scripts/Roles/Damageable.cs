using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Damageable : MonoBehaviour
{

    public float MaxHealth;
    [ReadOnly]public float currentHealth;
    public bool Invincible;

    public UnityIntEvent evt_UIUpdate;
    public UnityEvent evt_Defeated;

    void Reset()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    void Awake()
    {
        currentHealth = MaxHealth;
        evt_UIUpdate.Invoke(Convert.ToInt32(Math.Round(currentHealth / MaxHealth * 100)));
    }

    public void TakeDamage(float damage)
    {
        if (Invincible)
        {
            return;
        }

        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            evt_Defeated.Invoke();
            DestroyDamageable();
        }


        evt_UIUpdate.Invoke(Convert.ToInt32(Math.Round(currentHealth / MaxHealth * 100)));
    }

    public void Heal(int healAmount)
    {
        if(currentHealth + healAmount > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
        else
        {
            currentHealth += healAmount;
        }
        evt_UIUpdate.Invoke(Convert.ToInt32(Math.Round(currentHealth / MaxHealth * 100)));

    }

    public void DestroyDamageable()
    {
        Destroy(this.gameObject);
    }

}

[System.Serializable]
public class UnityIntEvent : UnityEvent<int>
{
}