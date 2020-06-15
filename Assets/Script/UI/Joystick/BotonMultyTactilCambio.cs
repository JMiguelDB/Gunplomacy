using UnityEngine;
using UnityEngine.EventSystems;

public class BotonMultyTactilCambio : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Activar;


    public void OnPointerUp(PointerEventData Datos)
    {
        Activar = false;
    }

    public void OnPointerDown(PointerEventData Datos)
    {
        Activar = true;
    }

}
