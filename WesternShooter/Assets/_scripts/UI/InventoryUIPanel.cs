using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUIPanel : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public int PanelIndex;
    public bool IsAttackPanel;
    public bool EquipPanel;
    public Text content;

    public Attack attackSlot;
    public Skill skillSlot;

    private InventoryInputController controller;

    private Image panelImage;



    void Awake()
    {
        panelImage = GetComponent<Image>();

        controller = GetComponentInParent<InventoryInputController>();

        if(attackSlot != null)
        {
            content.text = attackSlot.AttackName;
        }
        else if(skillSlot != null)
        {
            content.text = skillSlot.SkillName;
        }
        else
        {
            content.text = "";
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsAttackPanel)
        {
            controller.SendClickData(attackSlot, PanelIndex);

        }
        else
        {
            controller.SendClickData(skillSlot, PanelIndex);
        }
    }

    public void EmptyPanel()
    {
        if (IsAttackPanel)
        {
            attackSlot = null;

        }
        else
        {
            skillSlot = null;
        }

        content.text = "";
    }

    public void FillPanel(Attack attack)
    {
        attackSlot = attack;
        content.text = attack.AttackName;
    }
    public void FillPanel(Skill skill)
    {
        skillSlot = skill;
        content.text = skill.SkillName;
    }

    public void SetSelected(bool selected, Color color)
    {
        if (selected)
        {
            panelImage.color = color;
        }
        else
        {
            panelImage.color = color;
        }
    }


    void OnMouseOver()
    {
        panelImage.color = Color.black;
        Debug.Log("over");
    }

    void OnMouseExit()
    {
        panelImage.color = Color.blue;
        Debug.Log("exit");

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Color c = panelImage.color;
        c.a = 1f / 255f * 180f;
        panelImage.color = c;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color c = panelImage.color;
        c.a = 1f / 255f * 100f;
        panelImage.color = c;
    }
}
