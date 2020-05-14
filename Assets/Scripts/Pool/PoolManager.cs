using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static MonsterPool MonsterPool = null;
    public static GameObjectPool GameObjectPool = null;

    public static MonsterPool monsterPool
    {
        get
        {
            if (MonsterPool == null)
            {
                MonsterPool = new MonsterPool();
            }
            return MonsterPool;
        }
    }

    public static GameObjectPool gameObject
    {
        get
        {
            if (GameObjectPool == null)
            {
                GameObjectPool = new GameObjectPool();
            }
            return GameObjectPool;
        }
    }
}
