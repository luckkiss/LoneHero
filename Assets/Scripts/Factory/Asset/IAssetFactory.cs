using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAssetFactory
{
    public string GoPath { get; set; }
    public string EffectPath { get; set; }
    public string AudioPath { get; set; }
    private Dictionary<string, GameObject> ObAssetDic = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> AudioAssetDic = new Dictionary<string, AudioClip>();
    public virtual GameObject LoadGameObject(string name)
    {
        return LoadAsset(GoPath + name);
    }
    public virtual GameObject LoadEffect(string name)
    {
        if (ObAssetDic.ContainsKey(name)) return Object.Instantiate(ObAssetDic[name]) as GameObject;
        GameObject go = LoadAsset(EffectPath + name) as GameObject;
        if (go == null)
        {
            Debug.LogError("无法加载资源，路径:" + name); return null;
        }
        ObAssetDic.Add(name, go);
        return Object.Instantiate(go) as GameObject;
    }
    public virtual AudioClip LoadAudioClip(string name)
    {
        if (AudioAssetDic.ContainsKey(name)) return AudioAssetDic[name];
        AudioClip audioClip = Resources.Load(AudioPath + name, typeof(AudioClip)) as AudioClip;
        if (audioClip == null)
        {
            Debug.Log("无法加载资源，路径: " + name);
            return null;
        }
        AudioAssetDic.Add(name, audioClip);
        return audioClip;
    }

    public virtual GameObject InstantiateGameObject(string path)
    {
        if(ObAssetDic.ContainsKey(path)) return Object.Instantiate(ObAssetDic[path]) as GameObject;
        GameObject go = Resources.Load(GoPath + path) as GameObject;
        if (go == null)
        {
            Debug.LogError("无法加载资源，路径:" + path); return null;
        }
        ObAssetDic.Add(path, go);
        return Object.Instantiate(go) as GameObject;
    }

    public virtual GameObject LoadAsset(string path)
    {
        if (ObAssetDic.ContainsKey(path)) return Object.Instantiate(ObAssetDic[path]) as GameObject;
        GameObject go = Resources.Load(path) as GameObject;
        ObAssetDic.Add(path, go);
        if (go == null)
        {
            Debug.LogError("无法加载资源，路径:" + path); return null;
        }
        return go;
    }
}
