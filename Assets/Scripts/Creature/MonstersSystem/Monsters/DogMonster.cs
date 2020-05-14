using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMonster : IMonster
{

    public override void Attack()
    {
        base.Attack();
    }

    public override void Update()
    {
        //todo
        base.Update();
    }
    public override void DeadExcute()
    {
        base.DeadExcute();
        GameSystem.Instance.AddScore(10);
        PoolManager.monsterPool.PutObjectInPool<DogMonster>(this);
    }
}
