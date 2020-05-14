using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMonster : IMonster
{

    public override void Attack()
    {
        base.Attack();
        //todo
    }

    public override void Update()
    {
        //todo
        base.Update();
    }
    public override void DeadExcute()
    {
        base.DeadExcute();
        GameSystem.Instance.AddScore(60);
        PoolManager.monsterPool.PutObjectInPool<SnakeMonster>(this);
    }
}
