using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponViweCameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.1f;
    private Vector3 offset;
    private Vector3 targetPos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform Target = target.Find("GunMuzzlePoint");
        targetPos = Vector3.Lerp(transform.position, new Vector3(Target.position.x, transform.position.y, Target.position.z-target.GetComponent<Collider>().bounds.size.x), smoothSpeed);
        transform.position = targetPos;
    }
}
