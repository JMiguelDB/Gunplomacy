using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

#if (UNITY_ANDROID || UNITY_IOS)
    
    [SerializeField]
    JoystickControl joystickControl;
    #endif

    float moveHorizontal;
    float moveVertical;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 m_velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
#if (UNITY_ANDROID || UNITY_IOS)
        
        moveHorizontal = JoystickControl.Input.x * speed;
        moveVertical = JoystickControl.Input.z * speed;
        
#else
        moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;
        moveVertical = Input.GetAxisRaw("Vertical") * speed;
#endif
        if((moveHorizontal != 0) || (moveVertical != 0))
        {
            AudioManager.instance.Play("Step");
            animator.SetBool("Andando", true);
        }
        else
        {
            animator.SetBool("Andando", false);
        }

        Vector3 targetVelocity = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_velocity, m_MovementSmoothing);
    }
}