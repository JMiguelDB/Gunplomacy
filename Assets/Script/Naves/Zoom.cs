using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    //Añadido por ignacio para poder cargar niveles
    [Tooltip("Cada nave presentara un Id distinto para poder cargar el nivel correspondiente")]
    [Range(0, 11)]
    public int LevelId = 0;

    BloquePorMejora bloqueo;
    Vector3 posInicialNave;
    Vector3 posInicialCam;
    Vector3 posPanel;
    Vector3 zoomMouse;

    float sizeOriginal;
    //public Camera Cam;
    Camera cam;

    //public GameObject cExit;
    //public GameObject Panel;
    CanvasElements canvas;

    GameObject cExit;
    GameObject panel;
    GameObject mejoraLaNave;

    public static bool zoom = false;

    [TextArea]
    public string textoNave;
    Text textoPanel;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        canvas = GameObject.Find("CanvasAsalto").GetComponent<CanvasElements>();
        bloqueo = GetComponent<BloquePorMejora>();

        cExit = canvas.exit;
        panel = canvas.holo;
        textoPanel = canvas.texto;
        mejoraLaNave = canvas.mejorLaNave;



        posInicialNave = transform.localScale;
        sizeOriginal = cam.GetComponent<Camera>().orthographicSize;
        posInicialCam = cam.transform.position;
        posPanel = panel.transform.position;

        zoomMouse = transform.localScale + new Vector3(0.3f,0.3f,0);
    }
    private void OnMouseOver()
    {
        if (!zoom)
        {
        transform.localScale = zoomMouse;
        }

    }
    private void OnMouseExit()
    {
        transform.localScale = posInicialNave;
    }
    private void OnMouseDown()
    {
        if (!zoom && bloqueo.Accesible)
        {
            cExit.SetActive(true);
            panel.SetActive(true);
            zoom = true;

            AsaultManager.levelID = LevelId;

            canvas.texto.text = textoNave;

            transform.localScale = posInicialNave;
            cam.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, -10);
            cam.GetComponent<Camera>().orthographicSize = 1.25f;
        }
        if(!zoom && !bloqueo.Accesible)
        {
            mejoraLaNave.SetActive(true);
            Invoke("DesactivarMejoraLaNave", 2);
        }
    }
    void DesactivarMejoraLaNave()
    {
        mejoraLaNave.SetActive(false);
    }
}
