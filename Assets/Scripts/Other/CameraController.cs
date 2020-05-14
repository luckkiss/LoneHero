using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10;
    private Vector3 offset;
    private Vector3 targetPos;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = target.position - transform.position;
    }

    void Update()
    {
        targetPos = Vector3.Lerp(transform.position, target.position - offset, smoothSpeed);
        transform.position = targetPos;
    }
}
