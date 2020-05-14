using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICreature
{
    /// <summary>
    /// 当前血量
    /// </summary>
    public int hp;
    /// <summary>
    /// 最大血量
    /// </summary>
    public int maxHp;
    /// <summary>
    /// 移动速度
    /// </summary>
    public int moveSpeed;
    /// <summary>
    /// 攻击伤害
    /// </summary>
    public int damage;
    /// <summary>
    /// 攻击距离
    /// </summary>
    public float attactDistance;
    /// <summary>
    /// 预制体路径
    /// </summary>
    public string objectPath;
    /// <summary>
    /// 被攻击时候的特效
    /// </summary>
    public string effectPath;
    public ICreature(int hp, int maxHp, int moveSpeed, string objectPath,int damage, float attactDistance, string effectPath)
    {
        this.hp = hp;
        this.maxHp = maxHp;
        this.moveSpeed = moveSpeed;
        this.damage = damage;
        this.objectPath = objectPath;
        this.attactDistance = attactDistance;
        this.effectPath = effectPath;
    }
    public ICreature Clone()
    {
        return (ICreature)MemberwiseClone();
    }
}
