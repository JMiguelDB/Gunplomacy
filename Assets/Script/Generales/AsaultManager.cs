using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsaultManager : MonoBehaviour
{
    /// <summary>
    /// Este script sirve para cargar los distintos niveles en el menu de asalto
    /// </summary>
    

    public static int levelID;

    Camera cam;

    CanvasElements canvas;


    GameObject cExit;
    GameObject panel;



    void LoadScene(string sceneName)
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
        //SceneManager.UnloadSceneAsync("Asalto");
    }

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        canvas = GameObject.Find("CanvasAsalto").GetComponent<CanvasElements>();

        cExit = canvas.exit;
        panel = canvas.holo;
    }

    private void Update()
    {
        Debug.Log(levelID);
    }


    public void CargarNivel()
    {


        switch(levelID)
            {
            //Nave Crucero Mutanos
            case 0:
                LoadScene("Escena Principal");
                break;
            case 1:
                LoadScene("Mut.Patrulla");
                break;
            case 2:
                LoadScene("Mut.Guerra");
                break;
            case 3:
                LoadScene("Mec.Crucero");
                break;
            case 4:
                LoadScene("Mec.Patrulla");
                break;
            case 5:
                LoadScene("Mec.Guerra");
                break;
            case 6:
                LoadScene("Bot.Crucero");
                break;
            case 7:
                LoadScene("Bot.Patrulla");
                break;
            case 8:
                LoadScene("Bot.Guerra");
                break;
            case 9:
                LoadScene("Ict.Crucero");
                break;
            case 10:
                LoadScene("Ict.Patrulla");
                break;
            case 11:
                LoadScene("Ict.Guerra");
                break;


        }
    }

    public void Atras()
    {

        Zoom.zoom = false;
        cam.transform.position = new Vector3(0,0,-10);
        cam.GetComponent<Camera>().orthographicSize = 5f;
        cExit.SetActive(false);
        panel.SetActive(false);

    }
}
