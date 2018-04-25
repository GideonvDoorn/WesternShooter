using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour {

    public Droppable[] Droppables;


    public void DropItem()
    {


        Instantiate(GetDroppable(), this.transform.position, this.transform.rotation);
    }

    public Droppable GetDroppable()
    {
        return Droppables[Random.Range(0, Droppables.Length)];
    }
}