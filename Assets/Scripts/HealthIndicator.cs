using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthIndicator : MonoBehaviour
{

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;

    public Slider ProgressBarSlider;


    CanvasGroup canvas;
    CharacterParams characterParams;
    float currentHealth;
    float startHealth;


    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<CanvasGroup>();
        characterParams = GetComponent<CharacterParams>();
        startHealth = characterParams.Health - 1.0f;
        currentHealth = startHealth;

        damageText.text = $"dmg: {characterParams.Damage}";
    }

    // Update is called once per frame
    void Update()
    {
        float value = characterParams.Health;
        if (Mathf.Abs(currentHealth - value) >= 0.00001f) {
            currentHealth = value;
            healthText.text = $"{value}/{startHealth + 1}";
        }
        SetHPProgress(value, startHealth + 1);
        if (value == 0)
        {    
            canvas.alpha = 0.5f;
        }
    }

    private void SetHPProgress(float current, float all)
    {
        ProgressBarSlider.value = current / all;
    }
}
