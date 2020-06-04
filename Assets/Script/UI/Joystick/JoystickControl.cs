using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickControl : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    #region Variables.
    //Imagenes que componen el Joystick.
    public Image baseJoystick;
    public Image contolJoystick;
    
    //[i] Alterna el joystick de un lado a otro.
    [SerializeField]
    bool invertirHorizontal = false;

    //[i] Camara para obtener posición en pantalla de loa valores de el Joystick.
    Camera camara;

    //[i] Sirve para almacenar los datos que se leerán al llamar al metodo "Input".
    private Vector3 imputCalculo;

    public Vector3 Input
    {
        get
        {
            return imputCalculo;
        }
    }
    #endregion



    void Start()
    {
        //[i] Aquí opbtenemos la camara actual.
        camara = Camera.main;
    }
    


    #region Metodos y Funciones.
    public void OnDrag(PointerEventData data)
    {
        Vector2 posicion;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(baseJoystick.rectTransform, data.position, data.pressEventCamera, out posicion))
        {
            
            posicion.y = (posicion.y / baseJoystick.rectTransform.sizeDelta.y);
            posicion.x = (posicion.x / baseJoystick.rectTransform.sizeDelta.x);

            //[i] Este if tiene la función de ofrecer el valor correcto en función del lado en el que ocupa en pantalla el joystick.
            if (invertirHorizontal == true)
            {
                imputCalculo = new Vector3(-posicion.x * 2, 0, posicion.y * 2);
                imputCalculo = (imputCalculo.magnitude > 1.0f) ? imputCalculo.normalized : imputCalculo;
                contolJoystick.rectTransform.anchoredPosition = new Vector3(-imputCalculo.x * (baseJoystick.rectTransform.sizeDelta.x * .4f),
                                                                    imputCalculo.z * (baseJoystick.rectTransform.sizeDelta.y * .4f));
            }
            else
            {
                imputCalculo = new Vector3(posicion.x * 2, 0, posicion.y * 2);
                imputCalculo = (imputCalculo.magnitude > 1.0f) ? imputCalculo.normalized : imputCalculo;
                contolJoystick.rectTransform.anchoredPosition = new Vector3(imputCalculo.x * (baseJoystick.rectTransform.sizeDelta.x * .4f),
                                                                    imputCalculo.z * (baseJoystick.rectTransform.sizeDelta.y * .4f));
            }
        }
    }
    //[i] Al soltar el joystick asignamos al controlador la posicion inicial.
    public void OnPointerUp(PointerEventData puntero)
    {
        imputCalculo = Vector3.zero;
        contolJoystick.rectTransform.anchoredPosition = Vector3.zero;
    }
    //[i] Al pulsar el joystick iniciamos el metodo de arrastre ("OnDrag").
    public void OnPointerDown(PointerEventData puntero)
    {
        OnDrag(puntero);
    }


    //Permite cambiar el lado en pantalla del joystick.
    public void cambiarLado()
    {
        //Cambio de Lado
        RectTransform rectTransform = baseJoystick.gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(-rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);

        //Flip a la base
        rectTransform.localScale = new Vector3(-rectTransform.localScale.x, rectTransform.localScale.y, rectTransform.localScale.z);

        invertirHorizontal = !invertirHorizontal;

    }
    #endregion


    #region Experimental - No funciona.
    //public void moverBase()
    //{
    //    RectTransform rectTransform = ImgBg.gameObject.GetComponent<RectTransform>();

    //    if (PointerId >= 0 && PointerId < Input.touches.Length)
    //    {
    //        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x
    //                                                    + camara.ScreenToWorldPoint(new Vector2(Input.touches[PointerId].position.x, Input.touches[PointerId].position.y)).x
    //                                                    , rectTransform.anchoredPosition.y + camara.ScreenToWorldPoint(new Vector2(Input.touches[PointerId].position.x, Input.touches[PointerId].position.y)).y);
    //    }
    //    else
    //    {
    //        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - (rectTransform.anchoredPosition.x 
    //                                                     + camara.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)).x)
    //                                                     , rectTransform.anchoredPosition.y - (rectTransform.anchoredPosition.y + camara.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)).y));
    //    }
    //}
    #endregion
}
