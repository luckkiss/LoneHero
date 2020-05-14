using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAssetFactory:IAssetFactory
{
    public ActorAssetFactory()
    {
        GoPath = "Actor/GameObject/";
        EffectPath = "Actor/Effect/";
        AudioPath = "Actor/Audio/";
    }
}
