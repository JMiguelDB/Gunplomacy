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
                LoadScene("Asalto");
                break;
            case 1:
                LoadScene("Asalto");
                break;
            case 2:
                LoadScene("Asalto");
                break;
            case 3:
                LoadScene("Asalto");
                break;
            case 4:
                LoadScene("Asalto");
                break;
            case 5:
                LoadScene("Asalto");
                break;
            case 6:
                LoadScene("Asalto");
                break;
            case 7:
                LoadScene("Asalto");
                break;
            case 8:
                LoadScene("Asalto");
                break;
            case 9:
                LoadScene("Asalto");
                break;
            case 10:
                LoadScene("Asalto");
                break;
            case 11:
                LoadScene("Asalto");
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
