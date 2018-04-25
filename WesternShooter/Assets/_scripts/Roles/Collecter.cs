using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Collecter : MonoBehaviour {

    private int currentMoney;

    public UnityIntEvent evt_UIUpdate;

    public void AddMoney(int MoneyToAdd)
    {
        currentMoney += MoneyToAdd;
        evt_UIUpdate.Invoke(currentMoney);
    }

    void Awake()
    {
        currentMoney = 0;
        evt_UIUpdate.Invoke(currentMoney);
    }

    void Reset()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void OnTriggerEnter(Collider other)
    {

        Collectible collectible = other.GetComponent<Collectible>();
        if (collectible != null)
        {

            collectible.PickUp(this.gameObject);

        }
    }
}
