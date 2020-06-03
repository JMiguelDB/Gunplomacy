using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 6;
    private int currentHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetDamage(int damage)
    {
        currentHealth -= damage;
        CheckDeath();
    }

    public void SetHeal(int heal)
    {
        currentHealth += heal;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            GetComponent<Drop>().DropObjects();
            Destroy(gameObject);
        }
    }

    public bool HasMaxHealth()
    {
        return currentHealth == maxHealth;
    }
}
