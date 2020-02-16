﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoProta : MonoBehaviour
{
    public Armas scripArma;
    bool puedoDisparar = true;
    GestionEter eter;

    private void Start()
    {
        eter = gameObject.GetComponent<GestionEter>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(puedoDisparar && haveEter())
            {
                scripArma.Disparar();
                eter.ControlEter(scripArma.consumoEter, scripArma.raza);
                puedoDisparar = false;
                Invoke("PuedoDisparar", scripArma.cadencia);
            }
        }
    }

    void PuedoDisparar()
    {
        puedoDisparar = true;
    }

    bool haveEter()
    {
        bool can = false;
        switch (scripArma.raza)
        {
            case "EterBotaniclos":
                if (eter.sliderBotaniclos.value > Mathf.Abs(scripArma.consumoEter))
                {
                    can = true;
                }
                break;
            case "EterMutanos":
                if (eter.sliderMutanos.value > Mathf.Abs(scripArma.consumoEter))
                {
                    can = true;
                }
                break;
            case "EterMecanos":
                if (eter.sliderMecanos.value > Mathf.Abs(scripArma.consumoEter))
                {
                    can = true;
                }
                break;
            case "EterIctioniclos":
                if (eter.sliderIctioniclos.value > Mathf.Abs(scripArma.consumoEter))
                {
                    can = true;
                }
                break;
        }
        return can;
    }
}
