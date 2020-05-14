using System;
using System.Collections.Generic;
using System.Text;


public class ISceneState
{
    private string sceneName;
    protected SceneStateController controller;

    public ISceneState(string sceneName,SceneStateController controller)
    {
        this.sceneName = sceneName;
        this.controller = controller;
    }

    public string SceneName
    {
        get { return sceneName; }
    }
    //每次进入到这个状态的时候调用
    public virtual void StateStart() { }
    public virtual void StateEnd() { }
    public virtual void StateUpdate(){}
}
