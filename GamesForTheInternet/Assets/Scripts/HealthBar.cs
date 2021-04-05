using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider HealthBarSlider;
    public Gradient GradientIn;
    public Image CurrentFill;
    public void SetMaxHealth(int healthIn)
    {
        HealthBarSlider.maxValue = healthIn;
        HealthBarSlider.value = healthIn;

        CurrentFill.color = GradientIn.Evaluate(1.0f);
    }

    public void SetHealth(int healthIn)
    {
        HealthBarSlider.value = healthIn;
        CurrentFill.color = GradientIn.Evaluate(HealthBarSlider.normalizedValue);
    }
}
