using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupNewWeapon : MonoBehaviour
{
    public float range = 2;
    public LayerMask weaponLayer;

    WeaponInventory weaponInventory;
    GameObject currentWeapon;
    Vector3 weaponPosition;

    public bool pick=false;

    private void Start()
    {
        weaponInventory = GetComponent<WeaponInventory>();
    }

    // Update is called once per frame
    void Update()
    {

#if (UNITY_ANDROID || UNITY_IOS)
        if (pick==true)
        {
            TakeWeapon();
        }
#else
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeWeapon();
        }
#endif
    }

    void TakeWeapon()
    {
        Collider2D[] weapons = Physics2D.OverlapCircleAll(transform.position, range, weaponLayer);
        if (weapons.Length > 0)
        {
            currentWeapon = weaponInventory.GetSelectedWeapon();
            weaponPosition = currentWeapon.transform.localPosition;
            if (weaponInventory.HasSpaceForWeapon())
            {
                AttachNewWeapon(weapons[0].gameObject);
                WeaponUI.Instance.UpdateSecondaryWeapon(weapons[0].GetComponentInChildren<SpriteRenderer>().sprite);
            }
            else
            {
                DetachCurrentWeapon();
                AttachNewWeapon(weapons[0].gameObject);
                weaponInventory.ChangeSelectedWeapon();
                WeaponUI.Instance.UpdateSelectedWeapon(weapons[0].GetComponentInChildren<SpriteRenderer>().sprite);
            }
        }
        pick = false;
    }

    void DetachCurrentWeapon()
    {
        currentWeapon.GetComponent<Shot>().gunLight.gameObject.SetActive(false);
        currentWeapon.GetComponent<RotateWeapon>().enabled = false;
        currentWeapon.GetComponent<Shot>().enabled = false;
        currentWeapon.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "WeaponOnGround";
        currentWeapon.layer = LayerMask.NameToLayer("WeaponOnGround");
        currentWeapon.transform.SetParent(null);
        weaponInventory.RemoveWeapon(currentWeapon);
    }

    void AttachNewWeapon(GameObject weapon)
    {
        currentWeapon = weapon;
        currentWeapon.GetComponent<Shot>().gunLight.gameObject.SetActive(true);
        currentWeapon.GetComponent<RotateWeapon>().enabled = true;
        currentWeapon.GetComponent<Shot>().enabled = true;
        currentWeapon.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Player";
        currentWeapon.layer = LayerMask.NameToLayer("Weapon");
        currentWeapon.transform.SetParent(transform);
        currentWeapon.transform.localPosition = weaponPosition;
        weaponInventory.AddWeapon(currentWeapon);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
