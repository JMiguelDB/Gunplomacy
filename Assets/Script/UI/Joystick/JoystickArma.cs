using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickArma : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Image baseJoystick;
    public Image contolJoystick;

    Shot shotScript;

    [SerializeField]
    WeaponInventory WeaponInventory;

    private static Vector3 imputCalculo;
    private static float pressure = 0;
    

    public void OnDrag(PointerEventData data)
    {
        Vector2 posicion;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(baseJoystick.rectTransform, data.position, data.pressEventCamera, out posicion))
        {

            posicion.y = (posicion.y / baseJoystick.rectTransform.sizeDelta.y);
            posicion.x = (posicion.x / baseJoystick.rectTransform.sizeDelta.x);

            imputCalculo = new Vector3(-posicion.x * 2, 0, posicion.y * 2);
            imputCalculo = (imputCalculo.magnitude > 1.0f) ? imputCalculo.normalized : imputCalculo;
            contolJoystick.rectTransform.anchoredPosition = new Vector3(-imputCalculo.x * (baseJoystick.rectTransform.sizeDelta.x * .4f),
                                                                    imputCalculo.z * (baseJoystick.rectTransform.sizeDelta.y * .4f));

            if (Input.touchCount > 0)
            {
                pressure = Input.GetTouch(0).pressure;
            }
        }
    }
    //[i] Al soltar el joystick asignamos al controlador la posicion inicial.
    public void OnPointerUp(PointerEventData puntero)
    {
        //print("DES PULSADO");
        shotScript.ShootTrue(false);
        imputCalculo = Vector3.zero;
        contolJoystick.rectTransform.anchoredPosition = Vector3.zero;
        pressure = 0;
    }
    //[i] Al pulsar el joystick iniciamos el metodo de arrastre ("OnDrag").
    public void OnPointerDown(PointerEventData puntero)
    {
        //print("PULSADO");
        shotScript = WeaponInventory.GetSelectedWeapon().GetComponent<Shot>();
        shotScript.ShootTrue(true);
        OnDrag(puntero);
    }

    public static Vector3 GetTargetPoint()
    {
        return new Vector3(imputCalculo.x * -1, imputCalculo.z, 0);
    }

    public static float Pressure()
    {
        return pressure;
    }
}