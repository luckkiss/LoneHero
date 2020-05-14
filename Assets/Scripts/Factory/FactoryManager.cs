using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager
{
    private static MonsterFactory MonsterFactory = null;
    private static IAssetFactory MonsterAssetFactory = null;
    private static IAssetFactory ActorAssetFactory = null;
    private static ActorFactory ActorFactory = null;

    public static MonsterFactory monsterFactory
    {
        get
        {
            if(MonsterFactory == null)
            {
                MonsterFactory = new MonsterFactory();
            }
            return MonsterFactory;
        }
    }
    public static IAssetFactory monsterAssetFactory
    {
        get
        {
            if (MonsterAssetFactory == null)
            {
                MonsterAssetFactory = new MonsterAssetFactory();
            }
            return MonsterAssetFactory;
        }
    }

    public static ActorFactory actorFactory
    {
        get
        {
            if (ActorFactory == null)
            {
                ActorFactory = new ActorFactory();
            }
            return ActorFactory;
        }
    }
    public static IAssetFactory actorAssetFactory
    {
        get
        {
            if (ActorAssetFactory == null)
            {
                ActorAssetFactory = new ActorAssetFactory();
            }
            return ActorAssetFactory;
        }
    }
}
