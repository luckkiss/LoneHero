using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorFactory
{
    ICreature creature = new ICreature(100, 100, 10, "Actor",0, 0, "FleshEffect");
    public ActorFactory()
    {
        InitMonsterFactory();
    }
    public void InitMonsterFactory()
    {

    }

    public ActorSystem CreateCharacter<T>(Vector3 spawnPosition) where T : ActorSystem, new()
    {
        ActorSystem monster = new T();

        ActorBuilder builder = new ActorBuilder(monster, typeof(T), spawnPosition);

        return ActorBuilderDirector.Construct(builder);
    }
    public ICreature GetCreatureAttribute()
    {
        return creature;
    }
}
