using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardObject : MonoBehaviour
{

    private int speed = 5;
    public virtual void Start()
    {
        
    }    
    public virtual void Update()
    {
        transform.Rotate(Vector3.up * speed);
    }

}
