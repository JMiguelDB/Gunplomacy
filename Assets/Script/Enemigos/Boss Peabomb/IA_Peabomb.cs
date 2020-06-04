using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hecho Por Jose Antonio Diaz Llamas  
/// 22/02/2020
/// </summary>
public class IA_Peabomb : MonoBehaviour
{
    Rigidbody2D mRb;
    Animator mA;
    SpriteRenderer mSr;
    //VidaEnemigos scripVida;
    Transform player;
    int posicionAleatoria = 0;

    public float velocidad;
    public Transform[] puntosSala;

    public CircleCollider2D colliderAtaque;
    public float rangoMaximo = 10;
    public float coldawnAtaque = 5;
    public GameObject bomba;

    float targetFlip;
    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mA = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        //scripVida = GetComponent<VidaEnemigos>();
        colliderAtaque = GetComponent<CircleCollider2D>();
        InvokeRepeating("Atacando", 2, coldawnAtaque);
    }
    private void Update()
    {
        /*
        if(!scripVida.Muerto)
        {
            Moverse();
        }
        else if(scripVida.Muerto)
        {
            StartCoroutine("Muerte");
        }
        */
    }

    void Moverse()
    {
        Vector3 targetPosition;
        float distanciaAlPunto;
        targetPosition = puntosSala[posicionAleatoria].position - transform.position;
        distanciaAlPunto = Vector3.Distance(transform.position, puntosSala[posicionAleatoria].position);
        mRb.velocity = targetPosition.normalized * velocidad * Time.deltaTime;

        if (distanciaAlPunto < 1f)
        {
            posicionAleatoria = Random.Range(0, puntosSala.Length);
        }
    }

    void Atacando()
    {
        /*
        if(!scripVida.Muerto)
        {
            StartCoroutine("Ataque");
        }
        */
    }
    void Flip()
    {
        targetFlip = player.position.x;
        if (targetFlip > transform.position.x)
        {
            mSr.flipX = false;
        }
        if (targetFlip < transform.position.x)
        {
            mSr.flipX = true;
        }
    }
    IEnumerator Ataque()
    {
        mA.SetBool("Ataque", true);
        yield return new WaitForSeconds(1f);
        Instantiate(bomba, transform.position, Quaternion.identity, null);
        mA.SetBool("Ataque", false);
    }

    IEnumerator Muerte()
    {
        mA.SetTrigger("Muerte");
        colliderAtaque.radius = rangoMaximo + 4;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
