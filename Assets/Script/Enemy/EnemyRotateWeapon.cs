using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotateWeapon : MonoBehaviour
{
    SpriteRenderer playerSprite;
    SpriteRenderer weaponSprite;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponentInParent<SpriteRenderer>();
        weaponSprite = GetComponentInChildren<SpriteRenderer>();
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        theScale.y *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            player = collision.transform.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player = null;
        }
    }

    private void FixedUpdate()
    {
        if(player != null)
            Rotate(player.transform.position);
    }

    void Rotate(Vector3 playerPosition)
    {
        float rad = Mathf.Atan2(transform.position.y - playerPosition.y, transform.position.x - playerPosition.x);
        float degrees = (180 / Mathf.PI) * rad;
        transform.rotation = Quaternion.Euler(0, 0, degrees);

        FlipSprites(degrees);
        ChangeSortingOrderWeapon(degrees);
    }

    void FlipSprites(float degree)
    {
        bool mustToFlip = Mathf.Abs(degree) < 90;
        playerSprite.flipX = mustToFlip;
        weaponSprite.flipY = mustToFlip;
    }

    void ChangeSortingOrderWeapon(float degrees)
    {
        weaponSprite.sortingOrder = degrees > 0 ? 1 : -1;
    }
}
