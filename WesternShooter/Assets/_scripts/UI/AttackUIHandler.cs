using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackUIHandler : MonoBehaviour {

    public Text AttackText;

    void Awake()
    {

    }

    public void UpdateUI(string attackName)
    {
        AttackText.text = attackName;
    }
}
