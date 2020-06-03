using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{

    public int damage = 1;
    public float shotRate = 1f;
    public float shotForce = 20f;
    public GameObject bulletPrefab;
    public Transform bulletPosition;

    bool canShot = true;
    GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player = collision.transform.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player = null;
        }
    }

    private void Update()
    {
        if (player != null && canShot)
        {
            Shoot();
            StartCoroutine(Refresh(shotRate));
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
        bullet.tag = "BulletEnemy";
        bullet.GetComponent<Bullet>().SetDamage(damage);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(bulletPosition.right * -1 * shotForce, ForceMode2D.Impulse);
    }

    IEnumerator Refresh(float time)
    {
        canShot = false;
        yield return new WaitForSeconds(time);
        canShot = true;
    }
}
