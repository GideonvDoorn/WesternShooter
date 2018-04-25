using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUIHandler : MonoBehaviour {

    public Text MoneyText;


    public void UpdateUI(int money)
    {
        MoneyText.text = string.Format("Money: {0}", money);
    }
}
