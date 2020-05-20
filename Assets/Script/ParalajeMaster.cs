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
        //layers.Insert(temporalNumeroDeCapa, temporalObjeto);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AddLayer(int NumeroDeCapa, GameObject Objeto)
    {
        layers.Insert(NumeroDeCapa, Objeto);
        print("dfvuge");
    }

}
