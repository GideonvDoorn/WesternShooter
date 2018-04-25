using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : Collectible {

    public int HealthValue;
    public override void PickUp(GameObject player)
    {
        player.GetComponent<Damageable>().Heal(HealthValue);
        Destroy(this.gameObject);
    }
}
