using LoneHeroes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener
{
    /// <summary>
    /// 监听事件对象
    /// </summary>
    public object Listener { get; }

    /// <summary>
    /// 回调
    /// </summary>
    public EventCallBack CallBack { get; }


    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="listener"></param>
    /// <param name="callback"></param>
    public EventListener(object listener, EventCallBack callback)
    {
        Listener = listener;
        CallBack = callback;
    }
}
