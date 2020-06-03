using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Con este scrip conseguipos que el cofre detecte a nuestro jugador y asu vez si el jugador pulsa la tecla "e" 
/// interactuar este activará el booleano y nos dará un item aleatorio.
/// Hecho por jose antonio 20/01 v.1
/// </summary>
[RequireComponent(typeof(Drop))]
public class ActivarDropCofre : MonoBehaviour
{
    SpriteRenderer mSr;

    bool contactoPlayer;

    public Sprite cofreAbierto;

    Drop activarDrop;
    [Tooltip("Este colider se desactivará para que el personaje no pueda abrir dos veces el cofre")]
    public Collider2D colliderDetector;

    void Start()
    {
        mSr = GetComponent<SpriteRenderer>();
        activarDrop = this.GetComponent<Drop>();  
    }
    void Update()
    {
        if(contactoPlayer && Input.GetButtonDown("Interactuar"))
        {
            mSr.sprite = cofreAbierto;
            //activarDrop.drop = true;
            colliderDetector.enabled = false;
        }
        else
        {
            //activarDrop.drop = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            contactoPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            contactoPlayer = false;
        }
    }
}
