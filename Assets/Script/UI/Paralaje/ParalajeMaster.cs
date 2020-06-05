using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalajeMaster : MonoBehaviour
{
    #region Variables

    //[i] -##- Variables editables del Inspector.   -------------------------------------------##-
    [SerializeField]
    float multiplicadorDeDesplazamiento = 1;

    [Header("Activar mensajes de desarroyo en consola.")]
    [SerializeField]
    bool debug = false;
    [SerializeField]
    bool debugPosicionesVacios = false;
    [SerializeField]
    bool debugPosicionesOcupadas = false;


    //[i] -##- Variables que guardan datos sobre la cámara.   ---------------------------------##-
    //[i] Obtiene la "Main Camera".
    Camera camara;
    Vector3 posicionRaton;


    //[i] -##- Variables que guardan datos sobre los objetos.   ------[Despliega para mas Info]-------------------------##-

    //[i] -Esta lista de aqui abajo se encarga de guardar 2 datos, el objeto almacenado, por eso es una lista de tipo "GameObject"
    //  y tambien almacena su posición en layer, que va dictada por su posición en la lista.
    // Por defecto, la lista es creada con un tamaño determinado mediante un "array", y sirve para pemitir usar el comando
    // "list.Insert()" el cual requiere de que el espacio conde se va a insertar un valor exista.Los datos se fijan al inicio.

    // #[Estructura]#:

// |< nombre y tipo de list>|<Asignar nueva list (tamaño = Array 50)>|
// |                        |                                        |
// V                        V                                        V
    List<GameObject> layers = new List<GameObject>(new GameObject[50]);

    //[i] -[Despliega para mas Info]------------------------------------------------------------------------------------##-
    //[i] -Esta otra lista se encara de guardar la posición inicial del objeto, y será usada en el calculo de su nueva posición.
    // El orden en el que se guardan los valores on el mismo que ocupa el objeto dueño de estos datos en la otra lista.
    // Al igual que la lista de arriba el tamaño de la lista es fijado en 50 mediante un "array".Los datos se fijan al inicio.
    List<Vector2> posicionesOriginales = new List<Vector2>(new Vector2[50]);

    #endregion



    private void Start()
    {
        camara = Camera.main;
    }
    void Update()
    {
        //[i] Llama al metodo para obtener la posición del raton en cada frame.
        ObtenerPosicionRaton();

        //[i] Llama al metodo para aplicar la nueva posición del raton en cada frame.
        Paralaje();
    }



    #region Metodos y Funciones

    //[i] Este Metodo es el encargado de detectar los objetos en la lista y aplicarles la nueva posición calculada.
    void Paralaje()
    {
        //[i] El "for(){}" es usado para recorrer la lista hasta el final que será marcado por "layers.Count".
        // El valor int "t" será usado como valor que marca el tiempo y tambien marcará la layer del objeto en lista.
        for (int t = 0; t < layers.Count; t++)
        {
            if(layers[t] == null)
            {
                //[i] Si la lista layer tiene una posición en la lista sin objeto (lista[numero]== null) avisará de esta y
                // saltará a la siguente layer. Para ver el mensaje hace falta activar la variable "Debug" en el inspector.
                if(debugPosicionesVacios == true)
                {
                    print("La posicion en lista " + t + " está vacia.");
                }
            }
            else
            {
                //[i] Si la lista layer tiene una posición en la lista con un objeto, avisará  si está activado "Debug" en 
                //el inspector y aplicará la operación de paralaje.
                if (debugPosicionesOcupadas == true)
                {
                    print("Encontrado en la fila " + t + " el objeto " + layers[t]);
                }

                //[i]Aqui se realiza la operación de paralaje, que consta de la multiplicación de la "posicion original" + "posición del raton"
                // dentro de un "vector2" y este a su vez se mutliplica por el numero de layer, que indicará la profundidad y será multiplicado
                // por el "Valor de desplazamiento".
                
                layers[t].GetComponent<RectTransform>().anchoredPosition = new Vector3((posicionRaton.x * t * multiplicadorDeDesplazamiento) + posicionesOriginales[t].x,
                    (posicionRaton.y * t * multiplicadorDeDesplazamiento) +  posicionesOriginales[t].y, 0) ;
            }
        }

    }



    //[i] Este Metodo es el encargado de obtener la posición del raton en pantalla.
    void ObtenerPosicionRaton()
    {
        //[i] Obtiene la posicion del raron en la pantalla siendo el pivote el centro de la misma.
        posicionRaton = camara.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8));
    }



    //[i] Este Metodo es el encargado de Limpiar la lista en cada cambio de escena.
    //[!] Añadir este metodo a los script para cada cambio de escena.
    public void LimpiarLista()
    {
        //[i] Limpia la lista "layers".
        layers.Clear();

        //[i] Resetea el tamaño de la lista "layers".
        layers.AddRange(new GameObject[50]);

        //[i] Limpia la lista "posicionesOriginales"
        posicionesOriginales.Clear();

        //[i] Resetea el tamaño de la lista "posicionesOriginales".
        posicionesOriginales.AddRange(new Vector2[50]);
    }



    //[i] Este Metodo es el encargado de añadir los objetos a la lista "layers" en la posición que se indique en el "NumeroDeCapa".
    public void AddLayer(int NumeroDeCapa, GameObject Objeto)
    {
        if (layers.Contains(Objeto))
        {
            //[i] Si el objeto ya exite devuelve una advertencia en consola. No necsita el "Debug" activado en el Inspector.
            Debug.LogWarning("Se ha intentado registrar un objeto que ya existe con nombre " + Objeto.name + 
                " y en la capa " + NumeroDeCapa.ToString() + ".");
        }
        else
        {
            //[i] Aqui añadimos los objetos a la lista "layers" en la posición que se indique en el "NumeroDeCapa".
            layers.Insert(NumeroDeCapa, Objeto);

            //[i] Aqui añadimos las posiciones originales de los objetos a la lista "posicionesOriginales".
            posicionesOriginales.Insert(NumeroDeCapa, Objeto.GetComponent<RectTransform>().anchoredPosition);

            //[i] Avisa de que la operación de registro de datos se ha realizado. Para ver el mensaje hace falta activar la variable
            //"Debug" en el inspector.
            if (debug == true)
            {
                print("Se ha registrado correctamente " + Objeto.name + "en la capa " + NumeroDeCapa.ToString() + " y su posición.");
            }
        }
    }
    #endregion
}
