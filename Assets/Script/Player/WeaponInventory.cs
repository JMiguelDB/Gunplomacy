using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    public int maxWeapons = 2;
    public List<GameObject> weapons;

    EterManager eterManager;
    [SerializeField]
    BotonMultyTactilCambio botonMultyTactilCambio;

    void Start()
    {
        eterManager = GetComponent<EterManager>();
        ChangeSelectedWeapon();
    }

    private void Update()
    {

#if (UNITY_ANDROID || UNITY_IOS)
        if (botonMultyTactilCambio.Activar == true)
        {
            ChangeSelectedWeapon();
            botonMultyTactilCambio.Activar = false;
        }
#else
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            ChangeSelectedWeapon();
        }
#endif
    }

    public GameObject GetSelectedWeapon()
    {
        return weapons[0];
    }

    public void ChangeSelectedWeapon()
    {
        if (!HasSpaceForWeapon())
        {
            GameObject weapon1 = weapons[1];
            weapons[1] = weapons[0];
            weapons[1].SetActive(false);
            weapons[0] = weapon1;
            weapons[0].SetActive(true);
        }
        eterManager.SetCurrentEter(weapons[0].tag);
    }

    public void AddWeapon(GameObject newWeapon)
    {
        weapons.Add(newWeapon);
        newWeapon.SetActive(false);
    }

    public void RemoveWeapon(GameObject existingWeapon)
    {
        weapons.Remove(existingWeapon);
    }

    public bool HasSpaceForWeapon()
    {
        return weapons.Count < maxWeapons;
    }
}
