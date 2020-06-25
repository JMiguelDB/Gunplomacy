using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public static WeaponUI Instance { get; private set; }
    public Image selectedWeapon;
    public Image secondaryWeapon;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        secondaryWeapon.enabled = secondaryWeapon.sprite != null;
    }

    public void UpdateSelectedWeapon(Sprite weaponSprite)
    {
        selectedWeapon.sprite = weaponSprite;
    }

    public void UpdateSecondaryWeapon(Sprite weaponSprite)
    {
        secondaryWeapon.sprite = weaponSprite;
        secondaryWeapon.enabled = true;
    }

    public void ChangeWeapon()
    {
        Sprite newSelectedWeapon = secondaryWeapon.sprite;
        secondaryWeapon.sprite = selectedWeapon.sprite;
        selectedWeapon.sprite = newSelectedWeapon;
    }
}
