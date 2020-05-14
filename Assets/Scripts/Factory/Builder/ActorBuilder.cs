using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBuilder
{
    protected ActorSystem actorSystem;
    protected Vector3 spawnPosition;
    protected string ObjectPath;
    protected string EffectPath;
    public ActorBuilder(ActorSystem actor, System.Type Type, Vector3 spawnPosition)
    {
        actorSystem = actor;
        
        this.spawnPosition = spawnPosition;
    }

    public void AddCreatureAttribute()
    {
        ICreature creatureAtrr = FactoryManager.actorFactory.GetCreatureAttribute();
        actorSystem.creatureAttr = creatureAtrr;
        ObjectPath = actorSystem.creatureAttr.objectPath;
        EffectPath = actorSystem.creatureAttr.effectPath;
    }
    public void AddGameObject()
    {
        actorSystem.gameObject = FactoryManager.actorAssetFactory.InstantiateGameObject(ObjectPath);
        actorSystem.gameObject.transform.position = spawnPosition;
    }

    public void AddEffect()
    {
        actorSystem.attacyEffect = FactoryManager.actorAssetFactory.LoadEffect(EffectPath).GetComponent<ParticleSystem>();
    }
    public ActorSystem GetResult()
    {
        return actorSystem;
    }
}
