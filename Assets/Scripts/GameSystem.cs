using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem
{

    private static GameSystem instance;
    public static GameSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameSystem();
            }
            return instance;
        }
    }

    private MonsterSystem monsterSystem;
    public WeaponSystem weaponSystem;
    public ActorSystem actorSystem;
    public LevelSystem levelSystem;
    private ArchievementSystem archievementSystem;
    private RewardSystem rewardSystem;

    public bool isStopGame = false;
    public void Init()
    {
        monsterSystem = new MonsterSystem();
        weaponSystem = new WeaponSystem();
        levelSystem = new LevelSystem();
        archievementSystem = new ArchievementSystem();
        rewardSystem = new RewardSystem();
        actorSystem = FactoryManager.actorFactory.CreateCharacter<ActorSystem>(new Vector3(0,0,0));
        actorSystem.Start();
        GameObject.FindGameObjectWithTag("MainCamera").AddComponent<CameraController>();
    }
    
    public void Update()
    {
        if(!isStopGame)
        {
            monsterSystem.Update();
            actorSystem.Update();
            levelSystem.Update();
        }
    }

    public void AddMonsterToMonsterSystem(IMonster monster)
    {
        monsterSystem.monsters.Add(monster);
    }

    public void GetWeapon(string WeaponName)
    {
        actorSystem.weapon =  weaponSystem.GetWeapon(WeaponName);
    }

    public void GetWeapon(int WeaponIndex)
    {
        actorSystem.weapon = weaponSystem.GetWeapon(WeaponIndex);
    }

    public void AddMonsterDeadCount()
    {
        levelSystem.deadCount++;
    }

    public void AddScore(int score)
    {
        archievementSystem.score += score;
    }

    public void AddMoney(int money)
    {
        archievementSystem.money += money;
    }

    public int GetMoney()
    {
        return archievementSystem.money;
    }

    public int GetScore()
    {
        return archievementSystem.score;
    }

    public void Reward(Vector3 vector3)
    {
        rewardSystem.InstantiateReward(vector3);
    }

    public void SetGameStop(bool state)
    {
        if(state)
        {
            isStopGame = true;
            for(int i=0;i < monsterSystem.monsters.Count; i++)
            {
                monsterSystem.monsters[i].navAgent.isStopped =  true;                
            }             
        }
        else
        {
            isStopGame = false;
            for (int i = 0; i < monsterSystem.monsters.Count; i++)
            {
                monsterSystem.monsters[i].navAgent.isStopped = false;
            }
        }
    }
}
