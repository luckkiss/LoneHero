using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverUI : UIBase
{
    /// <summary>
    /// 计分板
    /// </summary>
    private Text text;
    public override void Init()
    {
        base.Init();
        text = GetControl<Text>("Score");
        GetControl<Button>("ExitButton").onClick.AddListener(ExitGame);
        GetControl<Button>("ResStartButton").onClick.AddListener(RestartGame);
        AddEventTrigger("ExitButton", EventTriggerType.PointerEnter,OnTounchEvent);
        AddEventTrigger("ResStartButton", EventTriggerType.PointerEnter, OnTounchEvent);
    }
    public override void Show()
    {
        text.text = "分数："+GameSystem.Instance.GetScore().ToString();
        MusicManager.Instance.PlaySound("GameOver");
        base.Show();
    }
    public override void Hide(UnityAction action = null)
    {
        base.Hide(action);
    }

    private void ExitGame()
    {
        
    }

    private void RestartGame()
    {

    }
}
