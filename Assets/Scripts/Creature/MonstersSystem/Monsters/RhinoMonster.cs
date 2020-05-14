using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoMonster : IMonster
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
        GameSystem.Instance.AddScore(100);
        PoolManager.monsterPool.PutObjectInPool<RhinoMonster>(this);
    }
}
