using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       12-03-2023 12:15:44
================================================*/
public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Text healthText;
    [SerializeField] private GameObject deathScreen;

    private void Awake()
    {
        instance = this;
    }

    public void InitHealthUI(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        healthText.text = maxHealth + "/" + maxHealth;
    }

    public void SetCurrentHealth(int healthValue)
    {
        healthSlider.value = healthValue;
        healthText.text = healthValue + "/" + healthSlider.maxValue;
    }

    public void PlayerDied()
    {
        deathScreen.SetActive(true);
    }
}