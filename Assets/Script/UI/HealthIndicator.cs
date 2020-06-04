using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    public static HealthIndicator Instance { get; private set; }
    public List<Sprite> healthIndicators;

    private Image healthIndicatorUI;
    void Start()
    {
        Instance = this;
        healthIndicatorUI = GetComponent<Image>();
        healthIndicatorUI.sprite = healthIndicators[6];
    }

    public void UpdateVidaUI(int health)
    {
        healthIndicatorUI.sprite = healthIndicators[health > 0 ? health : 0];
    }
}
