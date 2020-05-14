using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager
{
    private static MusicManager instance;
    public static MusicManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MusicManager();
            }
            return instance;
        }
    }
    string bgmPath = "Audio/BGM/";
    string soundPath = "Audio/sound/";

    private GameObject BGM;
    //string soundBagName = "";
    //string bgmBagName = "";
    Dictionary<string, AudioSource> bgmList = new Dictionary<string, AudioSource>();
    Dictionary<string, AudioSource> soundList = new Dictionary<string, AudioSource>();

    /// <summary>
    /// 改变背景音乐大小
    /// </summary>
    /// <param name="value"></param>
    public void ChangeBGMValue(float value)
    {
        if (bgmList.Count == 0)
            return;
        Dictionary<string, AudioSource>.Enumerator enumerator = bgmList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            bgmList[enumerator.Current.Key].volume = value;
        }
    }

    /// <summary>
    /// 改变音效音乐大小
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSoundValue(float value)
    {
        if (soundList.Count == 0)
            return;
        Dictionary<string, AudioSource>.Enumerator enumerator = soundList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            soundList[enumerator.Current.Key].volume = value;
        }
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name"></param>
    public void PlayBGM(string name)
    {
        if(!bgmList.ContainsKey(name))
        {
            if (bgmList.Count == 0)
            {
                BGM = new GameObject("BGM");
                GameObject.DontDestroyOnLoad(BGM);
            }
            AudioSource audioSource = BGM.AddComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>(bgmPath + name);
            audioSource.Play();
            audioSource.loop = true;
            bgmList.Add(name, audioSource);
        }
        bgmList[name].loop = true;
        bgmList[name].Play();
    }

    /// <summary>
    /// 停止背景音乐
    /// </summary>
    public void StopBGM()
    {

        Dictionary<string, AudioSource>.Enumerator enumerator = bgmList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            bgmList[enumerator.Current.Key].Stop();
        }
    }

    /// <summary>
    /// 暂停背景音乐
    /// </summary>
    public void PauseBGM()
    {
        Dictionary<string, AudioSource>.Enumerator enumerator = bgmList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            bgmList[enumerator.Current.Key].Pause();
        }
    }

    /// <summary>
    /// 播放音效音乐
    /// </summary>
    /// <param name="name"></param>
    /// <param name="isLoop"></param>
    public void PlaySound(string name, bool isLoop = false,float volume = 0.5f)
    {
        if (!soundList.ContainsKey(name))
        {
            if (GameObject.Find("Sound") == null)
            {
                GameObject go = new GameObject("Sound");
                GameObject.DontDestroyOnLoad(go);
            }
            AudioSource tmp = GameObject.Find("Sound").AddComponent<AudioSource>();
            // TODO：待修改
            tmp.clip = Resources.Load<AudioClip>(soundPath + name);
            tmp.name = name;
            soundList.Add(name, tmp);
        }
        soundList[name].volume = volume;
        soundList[name].loop = isLoop;
        soundList[name].Play();
    }

    /// <summary>
    /// 停止音效音乐
    /// </summary>
    /// <param name="name"></param>
    public void StopSound(string name)
    {
        if (!soundList.ContainsKey(name))
            return;
        if (soundList[name].isPlaying)
            soundList[name].Stop();
    }

    /// <summary>
    /// 停止所有音效
    /// </summary>
    public void StopAllSound()
    {
        Dictionary<string, AudioSource>.Enumerator enumerator = soundList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            soundList[enumerator.Current.Key].Stop();
        }
    }
}

