using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerarVida : MonoBehaviour
{
    public static float secondsToHeal = 1f;
    public static float increaseSpeedToHeal = 0.1f;


    bool hasCoroutineStarted = false;
    EterManager eterManager;
    Health health;

    private void Start()
    {
        eterManager = GetComponent<EterManager>();
        health = GetComponent<Health>();
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasCoroutineStarted)
        {
            hasCoroutineStarted = true;
            StartCoroutine(Heal());
        }
    }

    // TODO Arreglar la lectura de los valores del arma y de la raza, meter los check en el eterManager
    IEnumerator Heal()
    {
        while (Input.GetKey(KeyCode.E) && VidaPlayer.currentVida != VidaPlayer.maxVida /*&& canHeal()*/)
        {
            yield return new WaitForSeconds(secondsToHeal);
            secondsToHeal -= increaseSpeedToHeal;
            VidaPlayer.currentVida++;
            //Disminuir numero de balas con cada recuperacion
            //eterManager.DecreaseEter(eterConsumed, eterManager.GetCurrentEterTag());
        }
        hasCoroutineStarted = false;
    }
    /*
    bool canHeal()
    {
        bool can = false;
        switch (razaEter)
        {
            case "Botaniclos":
                if(eter.sliderBotaniclos.value > Mathf.Abs(eterConsumed))
                {
                    can = true;
                }
                break;
            case "Mutanos":
                if (eter.sliderMutanos.value > Mathf.Abs(eterConsumed))
                {
                    can = true;
                }
                break;
            case "Mecanos":
                if (eter.sliderMecanos.value > Mathf.Abs(eterConsumed))
                {
                    can = true;
                }
                break;
            case "Ictioniclos":
                if (eter.sliderIctioniclos.value > Mathf.Abs(eterConsumed))
                {
                    can = true;
                }
                break;
        }
        return can;
    }
    */
}
