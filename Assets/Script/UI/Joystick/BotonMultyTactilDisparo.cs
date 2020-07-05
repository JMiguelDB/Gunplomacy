using UnityEngine;
using UnityEngine.EventSystems;

public class BotonMultyTactilDisparo : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    Shot shot;

    public void OnPointerUp(PointerEventData Datos)
    {
        shot.ShootTrue(false);
    }

    public void OnPointerDown(PointerEventData Datos)
    {
        shot.ShootTrue(true);
    }
   
}