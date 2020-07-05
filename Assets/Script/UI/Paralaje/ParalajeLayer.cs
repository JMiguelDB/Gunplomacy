using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalajeLayer : MonoBehaviour
{
    [SerializeField]
    //Este es el unico valor que va a introducir el usuario, el orden de capa del objeto que porta este script.
    int layer = 0;

    //[i] Aqui se guarda el objeto que contiene el script "ParalajeMaster", se asigna automaticamente.
    GameObject obj;

    private void Awake()
    {
        //[i] Aqui se busca el GameManager gracias a una tag y se asigna a "obj".
        obj = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start()
    {
        //[i] Aqui se llama al metodo "AddLayer" en el script que contiene el objeto "GameManager" y se le envian los valores.
        obj.GetComponent<ParalajeMaster>().AddLayer(layer,gameObject);
        
    }
}
    



