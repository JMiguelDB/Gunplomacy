using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int lifetime = 3;
    public GameObject hitPrefab;

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
        if (gameObject.tag == "BalaProta" && collision.transform.tag == "Enemy" && !isColliding)
        {
            collision.gameObject.GetComponent<EnemyHealth>().SetDamage(damage);
            isColliding = true;
            Hit();
        }
        else if(gameObject.tag == "BulletEnemy" && collision.transform.tag == "Player" && !isColliding)
        {
            collision.gameObject.GetComponent<Health>().SetDamage(damage);
            isColliding = true;
            Hit();
        }
        else if (collision.CompareTag("Wall"))
        {
            Hit();
        }
    }

    private void Hit()
    {
        //Quaternion rotation = Quaternion.Euler(0, 0, NormalizeRotationZ());
        Instantiate(hitPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private float NormalizeRotationZ()
    {
        float rotation = 0;
        float actualRotation = transform.rotation.eulerAngles.z;

        if (actualRotation <= 225 && actualRotation > 135)
        {
            rotation = 180;
        }else if(actualRotation <= 310 && actualRotation > 225)
        {
            rotation = 270;
        }else if(actualRotation > 45 && actualRotation <= 135)
        {
            rotation = 90;
        }
        return rotation;
    }
}
