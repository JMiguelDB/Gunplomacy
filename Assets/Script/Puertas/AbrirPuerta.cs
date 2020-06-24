using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Abrir", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("Abrir", false);
    }
}
