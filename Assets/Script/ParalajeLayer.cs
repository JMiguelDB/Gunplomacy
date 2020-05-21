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

    private void Awake()
    {
        obj=GameObject.FindGameObjectWithTag("GameManager");
    }

    void Start()
    {
        obj.GetComponent<ParalajeMaster>().AddLayer(layer,gameObject);
        
    }

    void Update()
    {
        //H
    }



}
    



