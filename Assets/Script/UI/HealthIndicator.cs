using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthIndicator : MonoBehaviour
{
    public static HealthIndicator Instance { get; private set; }
    public TextMeshProUGUI healthText;
    public Image healthBar;

    private int maxHealth = 6;
    void Start()
    {
        Instance = this;
        healthBar.fillAmount = 1;
    }

    public void UpdateVidaUI(int health)
    {
        healthText.text = health + "/" + maxHealth;
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }
}
