using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Sprite[] llavespuerta;
    public enum ColorLlave { vacio, koala, StarWar, Dragon, Alas, Demons }
    public ColorLlave llave;
    public bool _cercaDeLaPuerta = false;
    SpriteRenderer spritellave;
   
    Animator _animPuerta;

    void Start()
    {
        _animPuerta = GetComponent<Animator>();
        spritellave = transform.GetChild(4).GetComponent<SpriteRenderer>();
        if (llave == ColorLlave.vacio)
        {
            _animPuerta.SetBool("abrir", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SeleccionLlave();
        if ( _cercaDeLaPuerta && Inventario.copia.PuedoUsarLaLlave(llave))
        {
         
                _animPuerta.SetBool("abrir", true);
                llave = ColorLlave.vacio;
          
        }
    }
    void SeleccionLlave()
    {
        if (llave == ColorLlave.vacio)
        {
            spritellave.sprite = llavespuerta[6];
        }
        if (llave == ColorLlave.koala)
        {
            spritellave.sprite = llavespuerta[2];
        }
        if (llave == ColorLlave.StarWar)
        {
            spritellave.sprite = llavespuerta[0];
        }
        if (llave == ColorLlave.Dragon)
        {
            spritellave.sprite = llavespuerta[1];
        }
        if (llave == ColorLlave.Demons)
        {
            spritellave.sprite = llavespuerta[4];
        }
        if (llave == ColorLlave.Alas)
        {
            spritellave.sprite = llavespuerta[3];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _cercaDeLaPuerta = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            spritellave.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _cercaDeLaPuerta = false;
            spritellave.enabled = false;
        }
    }
}
