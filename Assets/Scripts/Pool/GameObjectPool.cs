using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool
{
    private Dictionary<string, List<GameObject>> PoolDic;
    public GameObjectPool()
    {
        Init();
    }
    public void Init()
    {
        PoolDic = new Dictionary<string, List<GameObject>>();
    }
    /// <summary>
    /// 从池子里获取Object
    /// </summary>
    /// <param name="name"></param>
    public GameObject GetObjectFormPool(string name)
    {
        if (PoolDic.ContainsKey(name))
        {
            if (PoolDic[name].Count > 0)
            {
                //Debug.Log("已经从池子里取出子弹");
                GameObject go = PoolDic[name][0];
                PoolDic[name].RemoveAt(0);
                return go;
            }
            else
                return null;
        }
        else
        {
            PoolDic.Add(name, new List<GameObject>());
            return null;
        }
    }
    /// <summary>
    /// 把Object放入池子
    /// </summary>
    /// <param name="name"></param>
    public void PutObjectInPool(string name,GameObject gameObject)
    {
        gameObject.SetActive(false);
        if (PoolDic.ContainsKey(name))
        {
            PoolDic[name].Add(gameObject);
        }

        else
        {
            PoolDic.Add(name, new List<GameObject>());
            PoolDic[name].Add(gameObject);
        }

    }


}
