using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalajeMaster : MonoBehaviour
{
    public bool limpiarLista=false;
    [SerializeField]
    List<GameObject> layers = new List<GameObject>(new GameObject[50]);
    [SerializeField]
    List<Vector2> posiciones = new List<Vector2>(new Vector2[50]);



    Camera cam;
    public Vector3 wp;

    bool inicio=true;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //h
        ObtenerPosicionRaton();



        if (limpiarLista == true)
        {
            LimpiarLista();
            limpiarLista = false;
        }
        Paralaje();





    }

    void Paralaje()
    {
        for (int t = 0; t < layers.Count; t++)
        {
            if(layers[t] == null)
            {
                print("La posicion en lista " + t + " está vacia.");

            }
            else
            {
                print("Encontrado en la fila " + t + " el objeto " + layers[t]);

                
                
                layers[t].GetComponent<RectTransform>().anchoredPosition = new Vector3(wp.x * posiciones[t].x, wp.y * 
                    posiciones[t].y, 0) * t;
            }
        }

    }



    void ObtenerPosicionRaton()
    {
        cam = Camera.main;
        wp = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8));
    }

    //[i] Añadir a los script para cada cambio de escena.
    public void LimpiarLista()
    {
        layers.Clear();
        layers.AddRange(new GameObject[50]);
        posiciones.Clear();
        posiciones.AddRange(new Vector2[50]);
    }

    public void AddLayer(int NumeroDeCapa, GameObject Objeto)
    {
        if (layers.Contains(Objeto))
        {
            //[i] Si el objeto ya exite devuelve una advertencia en consola.
            Debug.LogWarning("Se ha intentado registrar un objeto que ya existe con nombre " + Objeto.name + 
                " y en la capa " + NumeroDeCapa.ToString() + ".");
        }
        else
        {
            layers.Insert(NumeroDeCapa, Objeto);
            posiciones.Insert(NumeroDeCapa, Objeto.GetComponent<RectTransform>().anchoredPosition);
            print("Se ha registrado correctamente " + Objeto.name + "en la capa " + NumeroDeCapa.ToString() + " y su posición.");
        }
    }
}
