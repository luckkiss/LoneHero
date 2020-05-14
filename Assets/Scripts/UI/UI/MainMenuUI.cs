using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : UIBase
{
    GameLoop gameLoop = null;
    private Text text;
    private Image image;
    public override void Init()
    {
        base.Init();        
        GetControl<Button>("StartButton").onClick.AddListener(StartGame);
        GetControl<Button>("SettingButton").onClick.AddListener(ShowSettingUI);
        GetControl<Button>("InfoButton").onClick.AddListener(ShowInfoUI);
        GetControl<Button>("ExitButton").onClick.AddListener(QuitGame);
        gameLoop = GameObject.Find("GameLoop").GetComponent<GameLoop>();
        AddEventTrigger("StartButton", EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("SettingButton", EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("InfoButton", EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("ExitButton", EventTriggerType.PointerEnter, OnTounchEvent);
    }
    public override void Show()
    {
        base.Show();
    }
    public override void Hide(UnityAction action = null)
    {
        base.Hide(action);
        MusicManager.Instance.StopBGM();
    }
    /// <summary>
    /// 开始游戏，进入游戏界面
    /// </summary>
    private void StartGame()
    {
        Hide(() =>
        {
            gameLoop.controller.SetState(new GameSence(gameLoop.controller));
        });
    }
    /// <summary>
    /// 进入游戏设置界面
    /// </summary>
    private void ShowSettingUI()
    {
        Hide(() =>
        {
            EventManager.Instance.SendEvent(EventType.GameSettingUI);
        });
    }
    /// <summary>
    /// 
    /// </summary>
    private void ShowInfoUI()
    {
        Hide(() =>
        {
            //EventManager.Instance.SendEvent(EventType.GameMenuUI);
        });
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

}
