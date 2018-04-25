using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUser : MonoBehaviour {

    public Skill[] ActiveSkills;
    private int currenSkillIndex = 0;
    private int skillAmount;

    [SerializeField]
    public UnityStringEvent evt_UIUpdate;

    void Awake()
    {
        UpdateInventoryValues();
    }

    public void UpdateInventoryValues()
    {

        currenSkillIndex = 0;

        if (ActiveSkills == null)
        {
            skillAmount = 0;
            return;
        }
        skillAmount = ActiveSkills.Length;

        if (ActiveSkills.Length < 1)
        {
            evt_UIUpdate.Invoke("---");
            return;
        }

        evt_UIUpdate.Invoke(ActiveSkills[currenSkillIndex].SkillName);

        ActivateSkill();
    }

    public void ActivateSkill()
    {

        if (ActiveSkills.Length < 1)
        {
            return;
        }
        ActiveSkills[currenSkillIndex].ActivateSkill(this.gameObject);
    }

    public void DeactivateSkill()
    {
        if (ActiveSkills.Length < 1)
        {
            return;
        }

        ActiveSkills[currenSkillIndex].DeactivateSkill(this.gameObject);
    }

    public void SwitchToNextSkill()
    {
        if (ActiveSkills.Length < 2)
        {
            return;
        }

        DeactivateSkill();

        if (currenSkillIndex + 1 < skillAmount)
        {
            currenSkillIndex++;
        }
        else
        {
            currenSkillIndex = 0;
        }
        ActivateSkill();

        evt_UIUpdate.Invoke(ActiveSkills[currenSkillIndex].SkillName);
    }

    public void SwitchToPreviousSkill()
    {
        if (ActiveSkills.Length < 2)
        {
            return;
        }

        DeactivateSkill();

        if (currenSkillIndex <= 0)
        {
            currenSkillIndex = skillAmount - 1;
        }
        else
        {
            currenSkillIndex--;
        }

        ActivateSkill();

        evt_UIUpdate.Invoke(ActiveSkills[currenSkillIndex].SkillName);

    }
}
