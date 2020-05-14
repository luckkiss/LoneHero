using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int dog { set; get; }
    public int snake { set; get; }
    public int cow { set; get; }
    public int spider { set; get; }
    public int rhino { set; get; }
    public int monsterCount { set; get; }
    /// <summary>
    /// 生成怪物并减少剩余怪物数量
    /// </summary>
    /// <param name="whichMonster"></param>
    /// <param name="spawnPosition"></param>
    public bool spawnMonster(int whichMonster, Vector3 spawnPosition)
    {
        switch (whichMonster)
        {
            case 1:
                if (dog > 0)
                {
                    if(PoolManager.monsterPool.GetObjectFormPool<DogMonster>(spawnPosition)==null)                    
                        FactoryManager.monsterFactory.CreateCharacter<DogMonster>(spawnPosition);
                }
                    dog--;
                return true;
            case 2:
                if (snake > 0)
                {
                    if(PoolManager.monsterPool.GetObjectFormPool<SnakeMonster>(spawnPosition)==null)
                        FactoryManager.monsterFactory.CreateCharacter<SnakeMonster>(spawnPosition);
                }
                snake--;
                return true;
            case 3:
                if (cow > 0)
                    if (PoolManager.monsterPool.GetObjectFormPool<CowMonster>(spawnPosition) == null)
                        FactoryManager.monsterFactory.CreateCharacter<CowMonster>(spawnPosition);
                cow--;
                return true;
            case 4:
                if (spider > 0)
                    if (PoolManager.monsterPool.GetObjectFormPool<SpiderMonster>(spawnPosition) == null)
                        FactoryManager.monsterFactory.CreateCharacter<SpiderMonster>(spawnPosition);
                spider--;
                return true;
            case 5:
                if (rhino > 0)
                    if (PoolManager.monsterPool.GetObjectFormPool<RhinoMonster>(spawnPosition) == null)
                        FactoryManager.monsterFactory.CreateCharacter<RhinoMonster>(spawnPosition);
                rhino--;
                return true;
            default:
                return false;
        }
    }
}
