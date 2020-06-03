using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    SpriteRenderer playerSprite;
    SpriteRenderer weaponSprite;
    Vector3 targetPosition;
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

    // Update is called once per frame
    void Update()
    {
        targetPosition = GetWorldPositionOnPlane(Input.mousePosition, 0f);

        float rad = Mathf.Atan2(transform.position.y - targetPosition.y, transform.position.x - targetPosition.x);

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

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
