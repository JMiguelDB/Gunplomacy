using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hecho Por Jose Antonio Diaz
/// 23/02/2020
/// </summary>
public class IA_BossSlurm : MonoBehaviour
{
    Rigidbody2D mRb;
    SpriteRenderer mSr;
    SpriteRenderer SrBola;
    Transform player;
    Animator mA;
    //VidaEnemigos vidaScrip;
    //public Animation animacion;
    bool Puedotacar = false;
    bool Atacando = false;

    public float potencia;

    public int daño = 3;
    Vector3 target;
    float targetFlip;
    private void Awake()
    {
        mRb = GetComponent<Rigidbody2D>();
        mSr = GetComponent<SpriteRenderer>();
        SrBola = transform.GetChild(1).GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        mA = GetComponent<Animator>();
        //vidaScrip = GetComponent<VidaEnemigos>();
    }

    private void Update()
    {
        target = player.position - transform.position;
        Flip();
        if(!Puedotacar)
        {
            Ataque();
        }
        if(Atacando)
        {
            mRb.velocity = target * potencia * Time.deltaTime;
        }
    }

    void Ataque()
    {
        Puedotacar = true;
        mA.SetBool("Mover", true);
        Invoke("Atacar", 2);
    }
    void Atacar()
    {
        Atacando = true;
    }
    void Flip()
    {
        targetFlip = player.position.x;
        if (targetFlip > transform.position.x)
        {
            mSr.flipX = true;
            SrBola.flipX = true;
            if(Atacando)
            {
                //animacion["MovimientoSlurg"].speed = -1.0f;
                //PREGUNTAR A PEDRO COMO INVERTIR LA ANIMACION DE RODAR
            }
        }
        if (targetFlip < transform.position.x)
        {
            mSr.flipX = false;
            SrBola.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Atacando = false;
        mRb.velocity = new Vector3(0, 0, 0);
        transform.position = transform.position;
        mA.SetBool("Mover", false);
        Invoke("EstadoBase", 2);
    }

    void EstadoBase()
    {
        Puedotacar = false;
    }
}
