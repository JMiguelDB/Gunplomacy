using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalajeMaster : MonoBehaviour
{
    public GameObject test;

    int temporalNumeroDeCapa;
    GameObject temporalObjeto;

    [SerializeField]
    List<GameObject> layers= new List<GameObject>(new GameObject[50]);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
            print("Se ha registrado correctamente " + Objeto.name + "en la capa " + NumeroDeCapa.ToString() + ".");
        }
    }
}
