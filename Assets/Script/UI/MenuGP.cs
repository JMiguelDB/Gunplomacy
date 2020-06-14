using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void NuevaPartida()
    {
        SceneManager.LoadScene("Preload");
        Debug.Log("Comenzar partida");
        //Se resetean los playerprefs
        ResetPlayerPrefInt("mejoras_fuselaje");
        ResetPlayerPrefInt("mejoras_motor");
        ResetPlayerPrefInt("mejoras_navegacion");
        ResetPlayerPrefInt("fuselaje");
        ResetPlayerPrefInt("motor");
        ResetPlayerPrefInt("navegacion");
        ResetPlayerPrefInt("nivelDeMejora");
    }

    public void Continuar()
    {
        SceneManager.LoadScene("Preload");
    }



    public void Salir()
    {
        Application.Quit();
        Debug.Log("Acabar partida");

    }

    void ResetPlayerPrefInt(string name)
    {
        PlayerPrefs.SetInt(name, 0);
    }


}
