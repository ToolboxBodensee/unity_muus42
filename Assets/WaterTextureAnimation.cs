using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTextureAnimation : MonoBehaviour
{
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float old = GetComponent<Renderer>().material.mainTextureOffset.x;
        float offset = Time.deltaTime * speed;
        
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(old + offset, old + offset);
    }
}
