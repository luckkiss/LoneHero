using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneStateController
{
    private ISceneState state;
    private AsyncOperation mAO;
    private bool mIsRunStart = false;

    public void SetState(ISceneState state,bool isLoadScene=true)
    {
        if (this.state != null)
        {
            this.state.StateEnd();
        }
        this.state = state;
        if (isLoadScene)
        {
            mAO = SceneManager.LoadSceneAsync(this.state.SceneName);
            mIsRunStart = false;
        } else
        {
            this.state.StateStart();
            mIsRunStart = true;
        }
        
    }

    public void StateUpdate()
    {
        if (mAO != null && mAO.isDone == false) return;

        if (mIsRunStart==false&& mAO != null && mAO.isDone == true)
        {
            state.StateStart();
            mIsRunStart = true;
        }

        if (state != null)
        {
            state.StateUpdate();
        }
    }
}
