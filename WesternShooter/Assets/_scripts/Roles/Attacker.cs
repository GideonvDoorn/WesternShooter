using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attacker : MonoBehaviour {

    public Attack[] ActiveAttacks;
    public float Strength;
    private int currentAttackIndex;
    private int attackAmount;

    [SerializeField]
    public UnityStringEvent evt_UIUpdate;

    void Awake()
    {
        UpdateInventoryValues();
    }

    public void UpdateInventoryValues()
    {
        currentAttackIndex = 0;

        if (ActiveAttacks == null)
        {
            attackAmount = 0;
            return;
        }


        attackAmount = ActiveAttacks.Length;


        if (ActiveAttacks.Length < 1)
        {
            evt_UIUpdate.Invoke("---");
            return;
        }

        evt_UIUpdate.Invoke(ActiveAttacks[currentAttackIndex].AttackName);
    }

    public void Attack()
    {
        if (ActiveAttacks.Length < 1)
        {
            return;
        }

        ActiveAttacks[currentAttackIndex].InitiateAttack(Strength);
    }

    public void SwitchToNextAttack()
    {
        if(ActiveAttacks.Length < 2)
        {
            return;
        }

        if (currentAttackIndex + 1 < attackAmount)
        {
            currentAttackIndex++;
        }
        else
        {
            currentAttackIndex = 0;
        }

        evt_UIUpdate.Invoke(ActiveAttacks[currentAttackIndex].AttackName);
    }

    public void SwitchToPreviousAttack()
    {
        if (ActiveAttacks.Length < 2)
        {
            return;
        }

        if (currentAttackIndex <= 0)
        {
            currentAttackIndex = attackAmount -1;
        }
        else
        {
            currentAttackIndex--;
        }
        evt_UIUpdate.Invoke(ActiveAttacks[currentAttackIndex].AttackName);
    }
}


[System.Serializable]
public class UnityStringEvent : UnityEvent<string>
{
}