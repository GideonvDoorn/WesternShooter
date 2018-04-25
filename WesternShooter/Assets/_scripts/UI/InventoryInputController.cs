using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryInputController : MonoBehaviour
{

    public UnityBoolEvent evt_SetActiveUI;
    public Color PanelColor;
    public Color SelectedPanelColor;

    private bool active = false;

    InventoryUIPanel[] panels;
    Attack selectedAttack = null;
    Skill selectedSkill = null;

    int selectedAttackPanel = -1;
    int selectedSkillPanel = -1;


    public Inventory inventoryComponent;
    public Attacker attackerComponent;
    public SkillUser skillComponent;

    void Start()
    {
        evt_SetActiveUI.Invoke(true);
        panels = GetComponentsInChildren<InventoryUIPanel>();


        //auto fills, equip slots
        filInitial();


        UpdateAttackUI();
        //why doesnt this work?????
        UpdateSkillUI();
        evt_SetActiveUI.Invoke(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!active)
            {
                evt_SetActiveUI.Invoke(true);
                active = true;
            }
            else
            {
                evt_SetActiveUI.Invoke(false);
                active = false;
            }
        }
    }

    private void filInitial()
    {
        //Fils the panels based on the attacks and skills the player already has
        //Fills equip panels first

        InventoryUIPanel[] panels = GetEquipPanels(true);
        for (int i = 0; i < inventoryComponent.allAttacks.Length; i++)
        {
            if(i < 3)
            {
                panels[i].FillPanel(inventoryComponent.allAttacks[i]);
            }
            else
            {
                GetFirstEmptyPanel(true).FillPanel(inventoryComponent.allAttacks[i]);
            }
        }
        panels = GetEquipPanels(false);
        for (int i = 0; i < inventoryComponent.allSkills.Length; i++)
        {
            if (i < 3)
            {
                panels[i].FillPanel(inventoryComponent.allSkills[i]);
            }
            else
            {
                GetFirstEmptyPanel(false).FillPanel(inventoryComponent.allSkills[i]);
            }
        }
    }

    public void SendClickData(Attack attack, int panelIndex)
    {
        ResetPanels();
        if (attack == null && selectedAttack == null)
        {
            return;
        }
        else if (selectedAttack != null && attack != null)
        {
            //swap panel contents
            GetPanelByIndex(selectedAttackPanel).FillPanel(attack);
            GetPanelByIndex(panelIndex).FillPanel(selectedAttack);

            selectedAttack = null;
            selectedAttackPanel = -1;
        }
        else if (selectedAttack != null && attack == null)
        {
            //empty panel content, fill the other
            GetPanelByIndex(selectedAttackPanel).EmptyPanel();
            GetPanelByIndex(panelIndex).FillPanel(selectedAttack);

            selectedAttack = null;
            selectedAttackPanel = -1;
        }
        else
        {
            //remember contents
            GetPanelByIndex(panelIndex).GetComponent<Image>().color = Color.red;
            selectedAttack = attack;
            selectedAttackPanel = panelIndex;
            GetPanelByIndex(panelIndex).SetSelected(true, SelectedPanelColor);
        }

        UpdateAttackUI();

    }


    public void UpdateAttackUI()
    {
        //Updates the switch weapon UI

        int fullPanels = 0;
        foreach (InventoryUIPanel panel in GetEquipPanels(true))
        {
            if (panel.attackSlot != null)
            {               
                fullPanels++;
            }
        }

        Attack[] result = new Attack[fullPanels];
        int fillIndex = 0;
        foreach (InventoryUIPanel panel in GetEquipPanels(true))
        {
            if(panel.attackSlot != null)
            {
                result[fillIndex] = panel.attackSlot;
                fillIndex++;
            }
        }

        attackerComponent.ActiveAttacks = result;
        attackerComponent.UpdateInventoryValues();
    }

    public void UpdateSkillUI()
    {
        //Updates the switch skill UI

        int fullPanels = 0;
        foreach (InventoryUIPanel panel in GetEquipPanels(false))
        {
            if (panel.skillSlot != null)
            {
                fullPanels++;
            }
        }

        Skill[] result = new Skill[fullPanels];
        int fillIndex = 0;
        foreach (InventoryUIPanel panel in GetEquipPanels(false))
        {
            if (panel.skillSlot != null)
            {
                result[fillIndex] = panel.skillSlot;
                fillIndex++;
            }
        }

        skillComponent.DeactivateSkill();
        skillComponent.ActiveSkills = result;
        skillComponent.UpdateInventoryValues();
    }

    public void SendClickData(Skill skill, int panelIndex)
    {
        ResetPanels();
        if (skill == null && selectedSkill == null)
        {
            return;
        }
        else if (selectedSkill != null && skill != null)
        {
            //swap panel contents
            GetPanelByIndex(selectedSkillPanel).FillPanel(skill);
            GetPanelByIndex(panelIndex).FillPanel(selectedSkill);

            selectedSkill = null;
            selectedSkillPanel = -1;
        }
        else if (selectedSkill != null && skill == null)
        {
            //empty panel content, fill the other
            GetPanelByIndex(selectedSkillPanel).EmptyPanel();
            GetPanelByIndex(panelIndex).FillPanel(selectedSkill);

            selectedSkill = null;
            selectedSkillPanel = -1;
        }
        else
        {
            //remember contents
            selectedSkill = skill;
            selectedSkillPanel = panelIndex;
            GetPanelByIndex(panelIndex).SetSelected(true, SelectedPanelColor);
        }



        UpdateSkillUI();
    }


    public InventoryUIPanel GetPanelByIndex(int index)
    {
        InventoryUIPanel result = null;

        foreach (InventoryUIPanel panel in panels)
        {
            if (panel.PanelIndex == index)
            {
                result = panel;
            }
        }

        return result;
    }

    public InventoryUIPanel GetFirstEmptyPanel(bool attackPanel)
    {
        InventoryUIPanel result = null;

        if (attackPanel)
        {
            for(int i = 0; i < panels.Length; i++)
            {
                InventoryUIPanel panel = GetPanelByIndex(i);
                if (panel.IsAttackPanel)
                {
                    if(panel.attackSlot == null)
                    {
                        return panel;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < panels.Length; i++)
            {
                InventoryUIPanel panel = GetPanelByIndex(i);
                if (!panel.IsAttackPanel)
                {
                    if (panel.skillSlot == null)
                    {
                        return panel;
                    }
                }
            }
        }
        return result;

    }

    public InventoryUIPanel[] GetEquipPanels(bool attackPanel)
    {
        InventoryUIPanel[] result = new InventoryUIPanel[3];

        int filIndex = 0;

        if (attackPanel)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                InventoryUIPanel panel = GetPanelByIndex(i);
                if (panel.IsAttackPanel)
                {
                    if (panel.EquipPanel)
                    {
                        result[filIndex] = panel;
                        filIndex++;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < panels.Length; i++)
            {
                InventoryUIPanel panel = GetPanelByIndex(i);
                if (!panel.IsAttackPanel)
                {
                    if (panel.EquipPanel)
                    {
                        result[filIndex] = panel;
                        filIndex++;
                    }
                }
            }
        }
        return result;

    }

    public void ResetPanels()
    {
        foreach (InventoryUIPanel panel in panels)
        {
            panel.SetSelected(false, PanelColor);
        }
    }

}

[System.Serializable]
public class UnityBoolEvent : UnityEvent<bool>
{
}
