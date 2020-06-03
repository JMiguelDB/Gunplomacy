using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyMovement enemyMovement;
    EnemyShot enemyShot;
    EnemyRotateWeapon enemyRotateWeapon;

    void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyShot = GetComponentInChildren<EnemyShot>();
        enemyRotateWeapon = GetComponentInChildren<EnemyRotateWeapon>();

        StopCombat();
    }

    public void StopCombat()
    {
        enemyMovement.enabled = false;
        enemyShot.enabled = false;
        enemyRotateWeapon.enabled = false;
    }

    public void StartCombat(Transform player)
    {
        enemyMovement.enabled = true;
        enemyMovement.SetTarget(player);
        enemyShot.enabled = true;
        enemyRotateWeapon.enabled = true;
    }
}
