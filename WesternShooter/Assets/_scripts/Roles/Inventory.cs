using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public Attack[] allAttacks;
    public Skill[] allSkills;

    private Attacker attackerComponent;

    void Awake()
    {
        attackerComponent = GetComponent<Attacker>();
    }

}
