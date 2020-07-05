using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquePorMejora : MonoBehaviour
{
    [Range(0,2)]
    public int Nivel;

    public bool Accesible;

    public static int nivelDeMejoras;
    private void Awake()
    {
        nivelDeMejoras = PlayerPrefs.GetInt("nivelDeMejora",0);
        //Debug.Log(nivelDeMejoras);
    }
    private void Update()
    {
        if(Nivel == 0)
        {
            Accesible = true;
        }
        if(Nivel == 1 && nivelDeMejoras >= 3)
        {
            Accesible = true;
        }
        if(Nivel == 2 && nivelDeMejoras >= 6)
        {
            Accesible = true;
        }
    }
}
