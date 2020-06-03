using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : MonoBehaviour
{
    public static float secondsToHeal = 1f;
    public static float increaseSpeedToHeal = 0.1f;
    public int healCost = 5;


    bool hasCoroutineStarted = false;
    EterManager eterManager;
    Health health;

    private void Start()
    {
        eterManager = GetComponent<EterManager>();
        health = GetComponent<Health>();
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasCoroutineStarted)
        {
            hasCoroutineStarted = true;
            StartCoroutine(Heal());
        }
    }

    IEnumerator Heal()
    {
        while (Input.GetKey(KeyCode.E) && !health.HasMaxHealth() && eterManager.CanUseEter(healCost))
        {
            yield return new WaitForSeconds(secondsToHeal);
            secondsToHeal -= increaseSpeedToHeal;
            health.SetHeal(1);
            eterManager.DecreaseCurrentEter(healCost);
        }
        hasCoroutineStarted = false;
    }
}
