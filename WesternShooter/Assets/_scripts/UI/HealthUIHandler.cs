using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIHandler : MonoBehaviour {

    public Slider HealthSlider;
    public Vector3 HealthBarRotation;

    private RectTransform rectTransform;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void UpdateUI(int healthPercentage)
    {
        float hp = (float)healthPercentage;
        float sliderValue = hp / 100;

        HealthSlider.value = sliderValue;
    }

    void LateUpdate()
    {
        rectTransform.rotation = Quaternion.Euler(HealthBarRotation);
    }
}
