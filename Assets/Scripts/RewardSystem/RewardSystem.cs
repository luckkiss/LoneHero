using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem
{
    /// <summary>
    /// 金钱预设体
    /// </summary>
    private GameObject MoneyObj;
    /// <summary>
    /// 回复药预设体
    /// </summary>
    private GameObject RevertObj;
    private System.Random random = new System.Random();

    public RewardSystem()
    {
        Init();
    }
    public void Init()
    {
        MoneyObj = Resources.Load("Reward/Money") as GameObject;
        RevertObj = Resources.Load("Reward/Revert") as GameObject;
    }

    public void InstantiateReward(Vector3 vector3)
    {
        int number = random.Next(1, 10);
        if(number >= 9)
        {
            GameObject gameObject = Object.Instantiate(RevertObj);
            gameObject.transform.position = vector3;
            gameObject.AddComponent<RevertReward>();
        }
        if (number <= 5)
        {
            GameObject gameObject = Object.Instantiate(MoneyObj);
            gameObject.transform.position = vector3;
            gameObject.AddComponent<MoneyReward>();
        }
    }
}
