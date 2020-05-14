using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevertReward : MonoBehaviour
{
    private System.Random random = new System.Random();
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameSystem.Instance.actorSystem.creatureAttr.hp += random.Next(30, 70);
            Destroy(gameObject);
        }
    }
}
