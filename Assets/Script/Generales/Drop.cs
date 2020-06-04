using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [Tooltip("Prefab objects to drop.")]
    public GameObject[] dropObject;
    [Tooltip("Probability to respawn for each prefab object.")]
    public float[] probability;
    [Tooltip("Number of objects that will be dropped")]
    public int maxDrops = 1;

    public void DropObjects()
    {
        int drops = Random.Range(0, maxDrops + 1);
        for (int drop = 0; drop < drops; drop++)
        {
            for(int i = 0; i < dropObject.Length; i++)
            {
                float prob = Random.Range(0f, 100f);
                if(prob <= probability[i])
                {
                    Instantiate(dropObject[i], transform.position, Quaternion.identity);
                    print("solto un objeto");
                    break;
                }
            }
        }
    }
}
