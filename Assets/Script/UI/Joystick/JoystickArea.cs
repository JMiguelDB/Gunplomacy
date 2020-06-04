using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region Variables
    //[i] Camara para obtener posición en pantalla.
    Camera camara;

    //[i] Se usa para Indicar la pulsación en "Input.touches[]".
    [HideInInspector]
    protected int numeroDePulsación;

    //[i] Indica el punto inicial antes de ser arrastrado.
    [HideInInspector]
    public Vector2 origenInicial;

    //[i] Permite mantener el if mientras se mantiene pulsado el Joystick Area.
    [HideInInspector]
    public bool Pulsado;

    //[i] Es el OUTPUT que da el joystick Area.
    [HideInInspector]
    public Vector2 areaInput;
    #endregion


    
    void Start()
    {
        //[i] Aquí opbtenemos la camara actual.
        camara = Camera.main;
    }
    
    void Update()
    {
        pulsacion();
    }


    #region Metodos y Funciones.

    //Aquí se calcula la posicion de la posición.
    void pulsacion()
    {
        if (Pulsado == true)
        {
            if (numeroDePulsación >= 0 && numeroDePulsación < Input.touches.Length)
            {
                areaInput = camara.ScreenToWorldPoint(new Vector3(Input.touches[numeroDePulsación].position.x, Input.touches[numeroDePulsación].position.y, 8));
                origenInicial = Input.touches[numeroDePulsación].position;
            }
            else
            {
                areaInput = camara.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8));
                origenInicial = Input.mousePosition;
            }
        }
    }

    //[i] Aqui mediante "IPointerDownHandler" detectamos una pulsación y asignamos valores.
    public void OnPointerDown(PointerEventData puntero)
    {
        Pulsado = true;
        numeroDePulsación = puntero.pointerId;
        origenInicial = puntero.position;
        
    }

    //[i] Aqui mediante "IPointerUpHandler" detectamos si se deja de pulsar.
    public void OnPointerUp(PointerEventData puntero)
    {
        Pulsado = false;
    }
    #endregion
}