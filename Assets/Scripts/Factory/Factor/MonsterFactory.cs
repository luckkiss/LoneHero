using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MonsterFactory
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public MonsterFactory()
    {
        InitMonsterFactory();
    }
    /// <summary>
    /// 存储怪物类的基本属性的字典（怪物类，怪物基本属性）
    /// </summary>
    public Dictionary<Type, ICreature> MonsterFactoryDic = new Dictionary<Type, ICreature>();
    /// <summary>
    /// 创建一个怪物
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="spawnPosition"></param>
    /// <returns></returns>
    public IMonster CreateCharacter<T>(Vector3 spawnPosition) where T : IMonster, new()
    {
        IMonster monster = new T();

        MonsterBuilder builder = new MonsterBuilder(monster, typeof(T),spawnPosition);

        return MonsterBuilderDirector.Construct(builder);
    }
    /// <summary>
    /// 将所有的怪物类对应的基本属性存进字典
    /// </summary>
    public void InitMonsterFactory()
    {
        MonsterFactoryDic.Add(typeof(CowMonster), new ICreature(100,100,10,"Cow",30,3.1f, "FleshEffect"));
        MonsterFactoryDic.Add(typeof(DogMonster), new ICreature(100, 100, 10, "Dog", 30, 2.1f, "FleshEffect"));
        MonsterFactoryDic.Add(typeof(SpiderMonster), new ICreature(100, 100, 10, "Spider",30, 7f, "FleshEffect"));
        MonsterFactoryDic.Add(typeof(RhinoMonster), new ICreature(100, 100, 10, "Rhino",30, 4.3f, "FleshEffect"));
        MonsterFactoryDic.Add(typeof(SnakeMonster), new ICreature(100, 100, 10, "Snake",30, 3.1f, "FleshEffect"));
    }
    /// <summary>
    /// 获取对应怪物类的基本属性
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    public ICreature GetCreatureAttribute(Type monster)
    {
        if(MonsterFactoryDic.ContainsKey(monster))
        {
            return MonsterFactoryDic[monster].Clone();
        }
        Debug.LogError("不存在此类型的怪物" + monster);
        return null;
    }
}
