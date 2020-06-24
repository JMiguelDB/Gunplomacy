using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario copia;
    public bool llavekoala = false;
    public bool llaveStarWar = false;
    public bool llaveDragon = false;
    public bool llaveAlas = false;
    public bool llaveDemons = false;

    Animator _animLlavekoala;
    Animator _animLlaveStarWar;
    Animator _animLlaveDragon;
    Animator _animLlaveAlas;
    Animator _animLlaveDemons;

    void Start()
    {
        copia = this;

        /*/
         * _animLlavekoala = GameObject.Find("ImagenLlaveKoala").GetComponent<Animator>();
         * _animLlaveStarWar = GameObject.Find("ImagenLlaveStarWar").GetComponet<Animator>();
         * _animLlaveDragon = GameObject.Find("ImagenLlaveDragon").GetComponent<Animator>();
         * _animLlaveAlas = GameObject.Find("ImagenLlaveAlas").GetComponent<Animator();
         * _animLlavesDemons = GameObject.Find("ImagenLlavesDemons").GetComponent<Animator>();
         * 
        /*/
        
    }
    public void CogeLlave(string color)
    {
        if(color == "LlaveKoala")
        {
            Inventario.copia.llavekoala = true;
            //_animLlavekoala.SetBool("activar", true);
        }
        if(color == "LlaveStarWar")
        {
            Inventario.copia.llaveStarWar = true;
            //_animLlaveStarWar.SetBool("activar", true);

        }
        if (color == "LlaveDragon")
        {
            Inventario.copia.llaveDragon = true;
            //_animLlaveDragon.SetBool("activar", true);

        }
        if (color == "LlaveAlas")
        {
            Inventario.copia.llaveAlas = true;
            //_animLlaveAlas.SetBool("activar", true);
        }
        if (color == "LlavesDemons")
        {
            Inventario.copia.llaveDemons = true;
            //_animLlaveDemons.SetBool("activar", true);

        }
    }
    public bool PuedoUsarLaLlave(Puerta.ColorLlave llave)
    {
        bool puedoUsar = false;
        Debug.Log(llave);
        switch(llave)
        {
            case Puerta.ColorLlave.koala:
                if (llavekoala)
                {
                    puedoUsar = true;
                }
                break;
            case Puerta.ColorLlave.StarWar:
                if(llaveStarWar)
                {
                    puedoUsar = true;
                }
                break;
            case Puerta.ColorLlave.Dragon:
                if (llaveDragon)
                {
                    puedoUsar = true;

                }
                break;
            case Puerta.ColorLlave.Alas:
                if(llaveAlas)
                {
                    puedoUsar = true;
                }
                break;
            case Puerta.ColorLlave.Demons:
                if(llaveDemons)
                {
                    puedoUsar = true;
                }
                break;      

         
        }
        Debug.Log(puedoUsar);
        return puedoUsar;
        
    }

}
