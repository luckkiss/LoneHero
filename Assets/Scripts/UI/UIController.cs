using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    /// <summary>
    /// 主菜单界面
    /// </summary>
    MainMenuUI,
    /// <summary>
    /// 游戏界面
    /// </summary>
    GameUI,
    /// <summary>
    /// 游戏菜单界面
    /// </summary>
    GameMenuUI,
    /// <summary>
    /// 游戏设置界面
    /// </summary>
    GameSettingUI,
    /// <summary>
    /// 背包界面
    /// </summary>
    KnapasckUI,
    /// <summary>
    /// 游戏结束界面
    /// </summary>
    GameOverUI
}

public class UIController
{
    #region 单例模式
    private static UIController instance;
    public static UIController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIController();
            }
            return instance;
        }
    }
    #endregion


    /// <summary>
    /// 当前游戏状态
    /// </summary>
    public UIState CurState;

    public void Init()
    {
        EventManager.Instance.Add(EventType.MainMenuUI, this, OnEventMianMenuUI);
        EventManager.Instance.Add(EventType.GameUI, this, OnEventGameUI);
        EventManager.Instance.Add(EventType.GameSettingUI, this, OnEventGameSettingUI);
        EventManager.Instance.Add(EventType.GameMenuUI, this, OnEventGameMenuUI);
        EventManager.Instance.Add(EventType.KnapasckUI, this,OnEventKnapasckUI);
        EventManager.Instance.Add(EventType.GameOverUI, this, OnGameOverUI);
    }

    private void OnEventMianMenuUI()
    {
        CurState = UIState.MainMenuUI;
        UIManager.Instance.ShowPanel<MainMenuUI>("MainMenuUI", "MainMenuUI",EventType.MainMenuUI);
    }

    private void OnEventGameUI()
    {
        CurState = UIState.GameUI;
        UIManager.Instance.ShowPanel<GameUI>("GameUI", "GameUI", GetUIEventType(CurState));
    }

    private void OnEventGameSettingUI()
    {

        UIManager.Instance.ShowPanel<GameSettingUI>("GameSettingUI", "GameSettingUI", GetUIEventType(CurState));
        CurState = UIState.GameSettingUI;
    }

    private void OnEventGameMenuUI()
    {
        UIManager.Instance.ShowPanel<GameMenuUI>("GameMenuUI", "GameMenuUI", GetUIEventType(CurState));
        CurState = UIState.GameMenuUI;
    }

    private void OnEventKnapasckUI()
    {
        UIManager.Instance.ShowPanel<KnapsackUI>("KnapsackUI", "KnapsackUI", GetUIEventType(CurState));
        CurState = UIState.KnapasckUI;
    }

    private void OnGameOverUI()
    {
        UIManager.Instance.ShowPanel<GameOverUI>("GameOverUI", "GameOverUI", GetUIEventType(CurState));
        CurState = UIState.KnapasckUI;
    }

    private EventType GetUIEventType(UIState uIState)
    {
        return (EventType)System.Enum.Parse(typeof(EventType), uIState.ToString());
    }


}
