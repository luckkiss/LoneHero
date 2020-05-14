using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBuilder 
{
    protected IMonster monster;
    protected System.Type monsterType;
    protected Vector3 spawnPosition;
    protected string ObjectPath;
    protected string EffectPath;
    public MonsterBuilder(IMonster monster,System.Type monsterType, Vector3 spawnPosition)    
    {
        this.monster = monster;
        this.monsterType = monsterType;
        this.spawnPosition = spawnPosition;
    }
    /// <summary>
    /// 将怪物基本属性赋值
    /// </summary>
    public void AddCreatureAttribute()
    {
        monster.creatureAttr = FactoryManager.monsterFactory.GetCreatureAttribute(monsterType);
        monster.initCreatureAttr = FactoryManager.monsterFactory.GetCreatureAttribute(monsterType);
        ObjectPath = monster.creatureAttr.objectPath;
    }
    /// <summary>
    /// 将怪物实例出来后的Object复制给怪物类的Object
    /// </summary>
    public void AddGameObject()
    {

        GameObject gameObject = FactoryManager.monsterAssetFactory.InstantiateGameObject(ObjectPath);
        gameObject.transform.position = spawnPosition;
        monster.gameObject = gameObject;
    }

    public void AddEffect()
    {
        EffectPath = monster.creatureAttr.effectPath;
        GameObject gameObject = FactoryManager.monsterAssetFactory.LoadEffect(EffectPath);
        monster.attackedEffec = gameObject.GetComponent<ParticleSystem>();
    }

    public void AddProxy()
    {
        MonsterProxy monsterProxy  = monster.gameObject.AddComponent<MonsterProxy>();
        monsterProxy.thisMonster = monster;
    }

    /// <summary>
    /// 把建造的GameObject返回
    /// </summary>
    /// <returns></returns>
    public IMonster GetResult()
    {
        return monster;
    }
    /// <summary>
    /// 把实例化出来的怪物放进怪物系统进行管理
    /// </summary>
    public void AddInMonstSystem()
    {
        //todo
        GameSystem.Instance.AddMonsterToMonsterSystem(monster);        
    }

}
