using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    [System.NonSerialized]
    public Collider AttackerCollider;
    [System.NonSerialized]
    public float playerStrenght;
}