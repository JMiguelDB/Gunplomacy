using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int lifetime = 3;

    int damage;
    //Avoid to call onTriggerEnter multiple times
    bool isColliding = false;

    private void Start()
    {
        StartCoroutine(DestroyAfter(lifetime));
    }


    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    IEnumerator DestroyAfter(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "BalaProta" && collision.transform.tag == "Enemy" && !isColliding)
        {
            collision.gameObject.GetComponent<EnemyHealth>().SetDamage(damage);
            isColliding = true;
            Destroy(gameObject);
        }
        else if(gameObject.tag == "BulletEnemy" && collision.transform.tag == "Player" && !isColliding)
        {
            collision.gameObject.GetComponent<Health>().SetDamage(damage);
            isColliding = true;
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
