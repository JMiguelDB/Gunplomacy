using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> doors;
    public List<GameObject> enemies;

    void Start()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().SetActualRoom(this);
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
            if (enemies.Count > 0)
            {
                SetDoor(false);
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

    public void EnemyDied(GameObject enemy)
    {
        enemies.Remove(enemy);
        if(enemies.Count == 0)
        {
            SetDoor(true);
        }
    }

    private void SetDoor(bool state)
    {
        foreach (GameObject door in doors)
        {
            door.GetComponentInChildren<CircleCollider2D>().enabled = state;
            door.GetComponent<Animator>().SetBool("Abrir", state);
        }
    }
}
