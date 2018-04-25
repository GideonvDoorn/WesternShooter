using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDrop : Collectible {

    public int MoneyValue;
    public override void PickUp(GameObject player)
    {
        player.GetComponent<Collecter>().AddMoney(MoneyValue);
        Destroy(this.gameObject);
    }
}
