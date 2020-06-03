using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Enemy")
                enemies.Add(child.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            foreach(GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyManager>().StartCombat(collision.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyManager>().StopCombat();
            }
        }
    }
}
