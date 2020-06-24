using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llaves : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Inventario.copia.CogeLlave(transform.tag);
            Destroy(gameObject);
        }
    }
}
