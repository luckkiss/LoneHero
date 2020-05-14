using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSence : ISceneState
{
    public GameSence(SceneStateController controller) : base("GameSence", controller) { }
    public override void StateStart()
    {
        GameSystem.Instance.Init();
        
        EventManager.Instance.SendEvent(EventType.GameUI);
    }
    public override void StateEnd() { }
    public override void StateUpdate()
    {
        GameSystem.Instance.Update();
    }
}
