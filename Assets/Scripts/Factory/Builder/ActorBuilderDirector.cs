using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBuilderDirector
{

    /// <summary>
    /// 传进来一个要建造的怪物，实现怪物的建造工序后返回结果
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static ActorSystem Construct(ActorBuilder builder)
    {
        builder.AddCreatureAttribute();
        builder.AddGameObject();
        builder.AddEffect();
        return builder.GetResult();
    }
}
