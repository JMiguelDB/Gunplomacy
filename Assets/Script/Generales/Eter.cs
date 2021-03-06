﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eter : MonoBehaviour
{
    [Tooltip("Indica cuanto éter rellena cada célula")]
    public int eterValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            AudioManager.instance.Play("TakeEter");
            collision.GetComponent<EterManager>().IncreaseEter(eterValue, transform.tag);
            Destroy(gameObject);
        }
    }
}

