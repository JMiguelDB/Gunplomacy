﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script para el movimiento del personaje
/// Hecho por Jose Antonio Diaz 28/01/2020
/// </summary>
public class MoviminetoPlayer : MonoBehaviour
{
    Rigidbody2D mRb;
    Animator mA;
    SpriteRenderer mSr;

    [Tooltip("Velocidad a la que se moverá el personaje")]
    public float velocidad;

    //Para tener por separado la entrada del teclado para si necesitamos añadir más cosas a las mismas, 
    //como el flip del sprite por ejemplo
    Vector2 input;

    void Start()
    {
        //Llamamos a nuestro rigidbody
        mRb = GetComponent<Rigidbody2D>();
        mA = GetComponent<Animator>();
        mSr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Animacion();
        FlipPersonaje();
        LeerInput();
        Movimineto(input,velocidad);
    }

    void Animacion()
    {
        if (input.x != 0 || input.y != 0)
        {
            mA.SetBool("Andando", true);
        }
        else
        {
            mA.SetBool("Andando", false);
        }
            
    }
    /// <summary>
    /// 
    /// </summary>
    void FlipPersonaje()
    {
        mSr.flipX = (input.x < 0) ?true: false;
    }
    /// <summary>
    /// Recoje la entrade del teclado tanto vertical como horizontal
    /// </summary>
    void LeerInput()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
    }

    /// <summary>
    /// Aplica una velocidad al personaje que depende de la dirección y la velocidad
    /// </summary>
    void Movimineto(Vector2 direccion, float velocidad)
    {
        mRb.velocity = direccion * velocidad;
    }
}
