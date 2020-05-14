using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyReward : RewardObject
{
    private System.Random random = new System.Random();
    public override void  Start()
    {
        
    }

    public override void Update()
    {
        base.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameSystem.Instance.AddMoney(random.Next(100,400));
            Destroy(gameObject);
        }
    }
}
