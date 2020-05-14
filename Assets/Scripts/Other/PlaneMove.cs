using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    private Vector3 InitPos;
    void Start()
    {
        InitPos = transform.position;
    }

    void Update()
    {
        transform.position += Vector3.forward *Time.deltaTime*4;
        if (transform.position.z >=100)
        {
            transform.position = new Vector3(0,0,-100);
        }
    }
}
