using UnityEngine;
using UnityEngine.EventSystems;

public class BotonMultyTactil : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    Shot shotScript;

    bool Activar;


    public void OnPointerUp(PointerEventData Datos)
    {
        Activar = false;
    }

    public void OnPointerDown(PointerEventData Datos)
    {
        shotScript.ShotNow();
        Activar = true;
    }
   
}