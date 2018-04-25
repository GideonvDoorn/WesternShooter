using System;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{

    public string AttackName;
    public virtual void InitiateAttack(float strength)
    {

    }
}