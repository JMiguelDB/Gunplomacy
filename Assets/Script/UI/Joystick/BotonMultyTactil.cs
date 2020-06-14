using UnityEngine;
using UnityEngine.EventSystems;

public class BotonMultyTactil : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    PickupNewWeapon pickupNewWeapon;
    
    [HideInInspector]
    public bool Activar;


    public void OnPointerUp(PointerEventData Datos)
    {
        Activar = false;
    }

    public void OnPointerDown(PointerEventData Datos)
    {
        pickupNewWeapon.pick = true;
        Activar = true;
    }
   
}