using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;

public class LevelSystem
{
    public LevelSystem()
    {
        Init();
    }
    public int currentIntLevel { set; get; }
    /// <summary>
    /// 当前关卡
    /// </summary>
    private Level currentLevel { set; get; }
    /// <summary>
    /// 通关怪兽数量
    /// </summary>
    public int deadCount { set; get; }
    /// <summary>
    /// 怪兽出生速率
    /// </summary>
    private float spawnVelocity { set; get; }
    /// <summary>
    /// 计时器
    /// </summary>
    private float Timer;
    /// <summary>
    /// 怪物出生点
    /// </summary>
    private List<Vector3> spawnPoint = new List<Vector3>();
    /// <summary>
    /// 存储每个关卡的关卡信息
    /// </summary>
    private List<Level> LevelList = new List<Level>();
    /// <summary>
    /// 产生随机数
    /// </summary>
    private System.Random random = new System.Random();
    /// <summary>
    /// 将每个管卡的怪物数量初始化
    /// </summary>
    public  void Init()
    {
        TextAsset itemText = Resources.Load<TextAsset>("Level");
        string levelJson = itemText.text;
        JsonData jsonData = JsonMapper.ToObject(levelJson);
        for(int i = 0;i<=jsonData.Count-1;i++)
        {
            Level level = JsonMapper.ToObject<Level>(jsonData[i].ToJson());
            LevelList.Add(level);
        }
        //获取出生点
        GameObject gameObject =  GameObject.Find("SpawnPoint");
        for(int i = 0;i<=gameObject.transform.childCount-1;i++)
        {
            spawnPoint.Add(gameObject.transform.GetChild(i).transform.position);
        }
        //生成频率
        spawnVelocity = 1;
        //初始化计时器
        Timer = 0;
        //设置管卡等级为1
        currentIntLevel = 1;
        currentLevel = LevelList[currentIntLevel-1];
        deadCount = 0;
    }

    public void Update()
    {
        Timer += Time.deltaTime;
        if(Timer>=spawnVelocity)
        {
            if(SpawnMonsters(currentLevel)) Timer = 0;
        }
        if(deadCount == currentLevel.monsterCount)
        {
            currentIntLevel++;
            currentLevel = LevelList[currentIntLevel-1];
            deadCount = 0;
            MusicManager.Instance.PlaySound("Level",false,1f);
            (UIManager.Instance.uiPanelList["GameUI"] as GameUI).isShowLevel();
        }
    }

    private bool SpawnMonsters(Level level)
    {
        return level.spawnMonster(random.Next(1, 6), spawnPoint[random.Next(0, spawnPoint.Count - 1)]);
    }
}
