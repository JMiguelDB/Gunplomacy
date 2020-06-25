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
    public GameObject gunLight;
    public Transform bulletPosition;
    public Animator bulletAnimator;
#if (UNITY_ANDROID || UNITY_IOS)
    public float thresholdPressure = 2.5f;
#endif

    EterManager eterManager;
    bool canShot;

    public bool conditionToShot = false;


    void Start()
    {
        eterManager = GetComponentInParent<EterManager>();
        canShot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
#if (UNITY_ANDROID || UNITY_IOS)
        //conditionToShot = JoystickArma.Pressure() > thresholdPressure;
        //print(JoystickArma.Pressure());
        //print(conditionToShot);
#else
        conditionToShot = Input.GetMouseButtonDown(0);
#endif
        if (conditionToShot && canShot && eterManager.CanUseEter(eterCost))
        {
            Shoot();
            StartCoroutine(Refresh(shotRate));
        }
    }

    public void ShootTrue(bool estado)
    {
        conditionToShot = estado;
    }


    void Shoot() 
    {
        AudioManager.instance.Play("Shot");
        bulletAnimator.SetTrigger("shot");
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
