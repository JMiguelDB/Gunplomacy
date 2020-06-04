using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Activa y desactiva el disparo
/// Hecho por Jose Antonio 30/01
/// </summary>
public class DisparoIAEnemiga : MonoBehaviour
{
    [Tooltip("Pun aqúi el scrip del arma que tenga equipada el enemigo")]
    //public Armas arma;

    bool puedoDisparar = false;

    void Update()
    {
        if(puedoDisparar)
        {
            //arma.Disparar();
        }
    }
    /// <summary>
    /// activa para poder disparar
    /// </summary>
    public void Disparar()
    {
        puedoDisparar = true;
    }
    /// <summary>
    /// desactiva y no puede disparar
    /// </summary>
    public void DejarDeDisparar()
    {
        puedoDisparar = false;
    }
}
