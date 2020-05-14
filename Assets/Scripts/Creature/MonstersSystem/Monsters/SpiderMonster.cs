using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMonster : IMonster
{
    private GameObject Bullet;
    public override void Attack()
    {
        AttackTimer += Time.deltaTime;
        if(AttackTimer>=0.7)
        {
            if(Bullet ==null)
            {
                Bullet = Resources.Load("Monster/Effect/SpiderBullet") as GameObject;

            }
            GameObject bullet = Object.Instantiate(Bullet);
            bullet.transform.position = gameObject.transform.Find("BulletPoint").transform.position;
            bullet.transform.rotation = gameObject.transform.Find("BulletPoint").transform.rotation;
            AttackTimer = 0;
        }
    }

    public override void Update()
    {
        base.Update();
    }
    public override void DeadExcute()
    {
        base.DeadExcute();
        GameSystem.Instance.AddScore(50);
        PoolManager.monsterPool.PutObjectInPool<SpiderMonster>(this);
    }

}
