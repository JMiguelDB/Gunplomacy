using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public int damage = 1;
    public int eterCost = 2;
    public float shotRate = 1f;
    public float shotForce = 20f;
    public GameObject bulletPrefab;
    public Transform bulletPosition;

    EterManager eterManager;
    bool canShot;
    void Start()
    {
        eterManager = GetComponentInParent<EterManager>();
        canShot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShot && eterManager.CanUseEter(eterCost))
        {
            Shoot();
            StartCoroutine(Refresh(shotRate));
        }
    }

    void Shoot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
        bullet.tag = "BalaProta";
        bullet.GetComponent<Bullet>().SetDamage(damage);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(bulletPosition.right * -1 * shotForce, ForceMode2D.Impulse);

        eterManager.DecreaseCurrentEter(eterCost);
    }

    IEnumerator Refresh(float time)
    {
        canShot = false;
        yield return new WaitForSeconds(time);
        canShot = true;
    }
}
