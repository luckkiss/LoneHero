using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameMenuUI : UIBase
{
    public override void Init()
    {
        base.Init();
        GetControl<Button>("RestStartButton").onClick.AddListener(ReStart);
        GetControl<Button>("SettingButton").onClick.AddListener(ShowSettingUI);
        GetControl<Button>("InfoButton").onClick.AddListener(ShowGameInfoUI);
        GetControl<Button>("ExitButton").onClick.AddListener(QuitGame);
        GetControl<Button>("ReturnGameButton").onClick.AddListener(Return);
        AddEventTrigger("RestStartButton", UnityEngine.EventSystems.EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("SettingButton", UnityEngine.EventSystems.EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("InfoButton", UnityEngine.EventSystems.EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("ExitButton", UnityEngine.EventSystems.EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("ReturnGameButton", UnityEngine.EventSystems.EventTriggerType.PointerEnter, OnTounchEvent);
    }
    public override void Show()
    {
        base.Show();
    }
    public override void Hide(UnityAction action = null)
    {
        base.Hide(action);
    }

    private void ReStart()
    {
        //Application.LoadLevel("GameSence");
    }
    private void ShowSettingUI()
    {
        Hide(() =>
        {
            EventManager.Instance.SendEvent(EventType.GameSettingUI);
        });
    }
    private void ShowGameInfoUI()
    {
        //todo
    }
    private void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                        Application.Quit();
        #endif
    }
    private void Return()
    {
        //返回上一层        
        Hide(() =>
        {
            EventManager.Instance.SendEvent(topEventType);
        });
    }
}
