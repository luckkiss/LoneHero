using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSence : ISceneState
{
    public MainMenuSence(SceneStateController controller) : base("MainMenuSence", controller) { }
    public override void StateStart()
    {
        UIController.Instance.Init();
        EventManager.Instance.SendEvent(EventType.MainMenuUI);
        MusicManager.Instance.PlayBGM("BGM");
    }
    public override void StateEnd()
    {

    }
    public override void StateUpdate()
    {

    }
}
