using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAssetFactory : IAssetFactory
{
    ///GoPath = "Monster/GameObject/";
    ///EffectPath = "Monster/Effect/";
    ///AudioPath = "Monster/Audio/";   
    public MonsterAssetFactory()
    {
        GoPath = "Monster/GameObject/";
        EffectPath = "Monster/Effect/";
        AudioPath = "Monster/Audio/"; 
    }
}
