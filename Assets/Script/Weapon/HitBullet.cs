using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBullet : MonoBehaviour
{
    private void DestroyHit()
    {
        Destroy(gameObject);
    }
}
