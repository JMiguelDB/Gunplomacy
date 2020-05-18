using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Canvas topCanvas;

    string _activeSceneName = "Menu Seleccion Asalto";

    // Start is called before the first frame update
    void Start()
    {
        topCanvas = GameObject.Find("CanvasMenuSuperior").GetComponent<Canvas>();
        LoadScene("Menu Seleccion Asalto");
        Zoom.zoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Asalto()
    {
        if (_activeSceneName != "Menu Seleccion Asalto" )
        {
            LoadScene("Menu Seleccion Asalto");
            Zoom.zoom = false;
            UnloadScene(_activeSceneName);
            _activeSceneName = "Menu Seleccion Asalto";
        }
        
    }

    //Aun no implementado
    //public void Opciones()
    //{
    //    LoadScene("Opciones");
    //}


    public void Mejoras()
    {
        if (_activeSceneName != "Menu Mejoras")
        {
            LoadScene("Menu Mejoras");
            UnloadScene(_activeSceneName);
            _activeSceneName = "Menu Mejoras";
        }
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Menu Inicio");
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

}
