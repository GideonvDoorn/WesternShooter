using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIHandler : MonoBehaviour {

    public Text SkillText;

    void Awake()
    {

    }

    public void UpdateUI(string skillName)
    {
        SkillText.text = skillName;
    }
}
