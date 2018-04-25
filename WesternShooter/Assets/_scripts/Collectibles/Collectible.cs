using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Collectible : Droppable {

    void Reset()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public virtual void PickUp(GameObject player)
    {

    }
}