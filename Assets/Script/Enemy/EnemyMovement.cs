using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    public float maxDistance = 4f;
    [Tooltip("The probability the enemy doesn't move")]
    public float probIdle = 0.3f;
    public float maxIdleTime = 3f;

    Animator animator;
    Transform target;

    bool isIdle;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isIdle = false;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }

    void StayIdle()
    {
        if (Random.value < probIdle)
        {
            isIdle = true;
            StartCoroutine(Idle());
        }
    }

    IEnumerator Idle()
    {
        float idleTime = Random.Range(0, maxIdleTime);
        animator.SetBool("isRunning", false);
        yield return new WaitForSeconds(idleTime);
        animator.SetBool("isRunning", true);
        isIdle = false;
        yield return null;
    }


    void Run()
    {
        //StayIdle();
        if (!isIdle)
        {
            float distance = Vector2.Distance(transform.position, target.position);
            if(Mathf.Abs(distance - maxDistance) > 1f)
            {
                int direction = distance < maxDistance ? -1 : 1;
                transform.position = Vector3.MoveTowards(transform.position, target.position, direction * speed * Time.deltaTime);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
