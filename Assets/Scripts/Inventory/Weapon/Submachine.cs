using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submachine : IWeapon
{
    /// <summary>
    /// 冲锋枪口特效粒子系统
    /// </summary>
    private ParticleSystem muzzleParicle;
    /// <summary>
    /// 爆炸特效粒子系统
    /// </summary>
    private ParticleSystem explodeParticle;
 
    /// <summary>
    /// 构造函数
    /// </summary>
    public Submachine(int id, string name, string type, string path, string iconPath, string description, int capacity, int damage, int elastance, int maxElastance, int buyPrice, string muzzleEffectPath, string explodeEffectPath, string bulletPath, float attackFrequency) : base(id, name, type, path, iconPath, description, capacity, damage, elastance, maxElastance, buyPrice, muzzleEffectPath, explodeEffectPath, bulletPath, attackFrequency)
    {
        muzzleParicle = muzzleEffectObject.GetComponent<ParticleSystem>();
        explodeParticle = explodeEffectObject.GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// 机枪开枪前动作
    /// </summary>
    public override void BeforeFire()
    {
        base.BeforeFire();
    }

    /// <summary>
    /// 机枪开枪动作
    /// </summary>
    public override void Fire()
    {
        base.Fire();
        muzzleParicle.Play();
        MusicManager.Instance.PlaySound("Submachine");
    }

    /// <summary>
    /// 机枪开枪后动作
    /// </summary>
    public override void AfterFire()
    {
        base.AfterFire();
        RaycastHit hit = Hit();
        MonsterProxy monsterProxy = hit.collider.transform.GetComponent<MonsterProxy>();
        if (monsterProxy != null)
        {
            monsterProxy.thisMonster.TakeDamage(damage, hit.point);
        }
        else
        {
            explodeEffectObject.transform.position = hit.point;
            explodeParticle.Play();
        }
    }
}
