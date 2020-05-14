using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangBullet : MonoBehaviour
{
    public Vector3 hit;
    public GameObject explodeEffect;
    private float flyTime = 0;

    void Start()
    {

    }

    void Update()
    {
        flyTime++;        
        if(flyTime <= 3)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(hit - transform.position), 10 * Time.deltaTime);
        }
        else
        {
            transform.LookAt(hit);
        }
        transform.Translate(Vector3.forward * 10 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        GameObject Explode = PoolManager.gameObject.GetObjectFormPool("BangExplode");
        if(Explode == null)
        {
            Explode = Instantiate(explodeEffect);
        }
        Explode.transform.position = transform.position;
        Explode.transform.rotation = transform.rotation;
        Explode.SetActive(true);
        MusicManager.Instance.PlaySound("Explosion");
        Collider[] collisionList = Physics.OverlapSphere(transform.position, 2);
        foreach(Collider hit in collisionList)
        {
            if (hit.gameObject.tag =="Monster")
                hit.gameObject.GetComponent<MonsterProxy>().thisMonster.TakeDamage(GameSystem.Instance.weaponSystem.currentWeapon.damage,transform.position);
        }
        PoolManager.gameObject.PutObjectInPool("BangBullet", this.gameObject);
    }
}
