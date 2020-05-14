using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameSettingUI : UIBase
{
    /// <summary>
    /// 音乐调节Slider
    /// </summary>
    private Slider muiseSlider;
    /// <summary>
    /// 退出按钮
    /// </summary>
    private Button quitButton;
    /// <summary>
    /// 上层UI界面
    /// </summary>
    public override void Init()
    {
        base.Init();
        muiseSlider = GetControl<Slider>("Slider");
        quitButton = GetControl<Button>("ReturnButton");
        quitButton.onClick.AddListener(Quit);
        AddEventTrigger("ReturnButton", EventTriggerType.PointerEnter, OnTounchEvent);
    }
    public override void Show()
    {
        base.Show();
    }
    public override void Hide(UnityAction action = null)
    {
        base.Hide(action);
    }
    private void Quit()
    {
        Hide();
        //返回上一层
        EventManager.Instance.SendEvent(topEventType);
    }
}
