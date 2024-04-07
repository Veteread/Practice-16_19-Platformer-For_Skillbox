using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public Transform[] Layers;
    public float[] coeff;

    private int layersCount;

    void Start()
    {
        layersCount = Layers.Length;    
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < layersCount; i++) 
        {
            Layers[i].position = transform.position * coeff[i];
        }
    }
}
