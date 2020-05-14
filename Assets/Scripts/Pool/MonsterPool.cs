using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool
{
    private Dictionary<Type, List<IMonster>> PoolDic;
    public MonsterPool()
    {
        Init();
    }
    public void Init()
    {
        PoolDic = new Dictionary<Type, List<IMonster>>();
    }
    /// <summary>
    /// 从池子里获取Object
    /// </summary>
    /// <param name="name"></param>
    public IMonster GetObjectFormPool<T>(Vector3 spawnPosition)
    {
        if(PoolDic.ContainsKey(typeof(T)))
        {
            if (PoolDic[typeof(T)].Count > 0)
            {
                //Debug.Log("池子里有怪物，已经拿出来了");
                return InitMonster(PoolDic[typeof(T)][0], typeof(T), spawnPosition);
            }
            else
                return null;
        }
        else
        {
            PoolDic.Add(typeof(T), new List<IMonster>());
            //Debug.Log("池子里没有这个怪物");
            return null;
        }
    }
    /// <summary>
    /// 把Object放入池子
    /// </summary>
    /// <param name="name"></param>
    public void PutObjectInPool<T>(IMonster monster)
    {
        monster.gameObject.GetComponent<Collider>().enabled = false;
        if (PoolDic.ContainsKey(typeof(T)))
        {
            //Debug.Log("已经把怪物放进池子");
            PoolDic[typeof(T)].Add(monster);
        }
        else
        {
            PoolDic.Add(typeof(T), new List<IMonster>());
            PoolDic[typeof(T)].Add(monster);
        }
    }

    private IMonster InitMonster(IMonster monster,System.Type T,Vector3 spawnPosition)
    {
        //Debug.Log("在池子初始化怪物");
        monster.gameObject.GetComponent<Collider>().enabled = true;
        monster.creatureAttr = monster.initCreatureAttr;
        monster.gameObject.transform.position = spawnPosition;
        monster.isDead = false;
        monster.animator.SetInteger("States", 0);
        monster.navAgent.isStopped = false;
        PoolDic[T].RemoveAt(0);
        monster.gameObject.transform.Find("MinMapIcon").gameObject.SetActive(true);
        return monster;
    }
}
