using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour
{
    public Vector3 target;
    //public GameObject explodeEffect;
    private float flyTime = 0;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Update()
    {
        flyTime++;
        if (flyTime <= 3)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target - transform.position), 20 * Time.deltaTime);
        }
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

         //GameObject a = Instantiate(explodeEffect, transform.position, transform.rotation);
         
        if(collision.transform.tag == "Player")
        {
            GameSystem.Instance.actorSystem.UnderAttacked(10);
            Destroy(this.gameObject);
        }
    }
}
