using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    /// <summary>
    /// UI
    /// </summary>
    public Transform RootUI { set; get; }


    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }

    /// <summary>
    /// UI面板管理表
    /// </summary>
    public Dictionary<string, UIBase> uiPanelList = new Dictionary<string, UIBase>();
    private string uiPrefabPath = "UI/";
    public UIManager()
    {
        RootUI = GameObject.Find("Canvas").transform;
        Object.DontDestroyOnLoad(RootUI);
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="panelName"></param>
    /// <param name="prefabName"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public T ShowPanel<T>(string panelName, string prefabName,EventType topEventType)
        where T : UIBase
    {
        UIBase panel;
        if (!IsHavePanel(panelName))
        {
            GameObject obj = Object.Instantiate(Resources.Load(uiPrefabPath + prefabName)) as GameObject;
            obj.name = panelName;
            obj.transform.SetParent(RootUI);
            panel = obj.AddComponent<T>();
            uiPanelList.Add(panelName, panel);
            panel.Init();
            panel.Show();
            panel.topEventType = topEventType;
        }
        else
        {
            panel = uiPanelList[panelName];
            panel.transform.SetAsLastSibling();
            panel.Show();
        }
        return panel as T;
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="panelName"></param>
    public void HidePanel(string panelName)
    {
        if (IsHavePanel(panelName))
        {
            uiPanelList[panelName].Hide();
        }
    }

    /// <summary>
    /// 隐藏所有面板
    /// </summary>
    public void HideAllPanel()
    {
        Dictionary<string, UIBase>.Enumerator enumerator
            = uiPanelList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            uiPanelList[enumerator.Current.Key].Hide();
        }
    }

    /// <summary>
    /// 移除面板
    /// </summary>
    /// <param name="panelName"></param>
    public void DestroyPanel(string panelName)
    {
        if (IsHavePanel(panelName))
        {
            uiPanelList[panelName].Destroy();
            uiPanelList.Remove(panelName);
        }
    }

    /// <summary>
    /// 移除所有面板
    /// </summary>
    public void DestroyAllPanel()
    {
        Dictionary<string, UIBase>.Enumerator enumerator = uiPanelList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            uiPanelList[enumerator.Current.Key].Destroy();
        }
        uiPanelList.Clear();
    }

    /// <summary>
    /// 获取面板
    /// </summary>
    /// <param name="panelName"></param>
    /// <returns></returns>
    public UIBase GetPanel(string panelName)
    {
        if (IsHavePanel(panelName))
            return uiPanelList[panelName];
        return null;
    }

    /// <summary>
    /// 是否有对应名字的面板
    /// </summary>
    /// <param name="panelName"></param>
    /// <returns></returns>
    bool IsHavePanel(string panelName)
    {
        return uiPanelList.ContainsKey(panelName);
    }
}
