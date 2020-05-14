using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBuilderDirector
{
    /// <summary>
    /// 传进来一个要建造的怪物，实现怪物的建造工序后返回结果
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IMonster Construct(MonsterBuilder builder)
    {
        builder.AddCreatureAttribute();
        builder.AddGameObject();
        builder.AddProxy();
        builder.AddEffect();
        builder.AddInMonstSystem();
        return builder.GetResult();
    }
}
