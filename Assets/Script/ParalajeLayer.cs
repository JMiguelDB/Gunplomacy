using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalajeLayer : MonoBehaviour
{
    [SerializeField]
    int layer = 0;
    [SerializeField]
    GameObject obj;
    // Start is called before the first frame update
    
    void Start()
    {
        obj = gameObject;
        ParalajeMaster paralajeMaster = new ParalajeMaster();
        
        paralajeMaster.AddLayer(layer, gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
