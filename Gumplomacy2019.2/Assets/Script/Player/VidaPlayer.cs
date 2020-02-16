﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public static int maxVida = 6;
    public static int currentVida = 6;
    int currentVidaInformation;

    public List<Image> uiVidas;
    public Sprite tanque_lleno;
    public Sprite tanque_medio;
    public Sprite tanque_vacio;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Image spriteVida in uiVidas){
            spriteVida.sprite = tanque_lleno;
        }
        currentVidaInformation = currentVida;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentVidaInformation != currentVida)
        {
            currentVidaInformation = currentVida;
            UpdateVidaUI();
        }
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Bala"))
        {
            restaVida(col.gameObject.GetComponent<Bala>().daño);
        }
    }

    void UpdateVidaUI()
    {
        switch (currentVida)
        {
            case 6:
                uiVidas[2].sprite = tanque_lleno;
                uiVidas[1].sprite = tanque_lleno;
                uiVidas[0].sprite = tanque_lleno;
                break;
            case 5:
                uiVidas[2].sprite = tanque_medio;
                uiVidas[1].sprite = tanque_lleno;
                uiVidas[0].sprite = tanque_lleno;
                break;
            case 4:
                uiVidas[2].sprite = tanque_vacio;
                uiVidas[1].sprite = tanque_lleno;
                uiVidas[0].sprite = tanque_lleno;
                break;
            case 3:
                uiVidas[2].sprite = tanque_vacio;
                uiVidas[1].sprite = tanque_medio;
                uiVidas[0].sprite = tanque_lleno;
                break;
            case 2:
                uiVidas[2].sprite = tanque_vacio;
                uiVidas[1].sprite = tanque_vacio;
                uiVidas[0].sprite = tanque_lleno;
                break;
            case 1:
                uiVidas[2].sprite = tanque_vacio;
                uiVidas[1].sprite = tanque_vacio;
                uiVidas[0].sprite = tanque_medio;
                break;
            case 0:
                uiVidas[2].sprite = tanque_vacio;
                uiVidas[1].sprite = tanque_vacio;
                uiVidas[0].sprite = tanque_vacio;
                break;
        }
    }

    void restaVida(int num)
    {
        currentVida -= num;
        if (currentVida <= 0)
        {
            UpdateVidaUI();
            GameOverMenu.isGameOver = true;
            gameObject.SetActive(false);
        }
    }
}
