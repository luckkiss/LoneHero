using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : IWeapon
{

    /// <summary>
    /// 步枪特效粒子系统
    /// </summary>
    private ParticleSystem muzzleParticle;
    /// <summary>
    /// 爆炸特效粒子系统
    /// </summary>
    private ParticleSystem explodeParticle;

    /// <summary>
    /// 构造函数
    /// </summary>
    public Rifle(int id, string name, string type, string path, string iconPath, string description, int capacity, int damage, int elastance, int maxElastance, int buyPrice, string muzzleEffectPath, string explodeEffectPath, string bulletPath, float attackFrequency) : base(id, name, type, path, iconPath, description, capacity, damage, elastance, maxElastance, buyPrice, muzzleEffectPath, explodeEffectPath, bulletPath, attackFrequency)
    {
        muzzleParticle = muzzleEffectObject.GetComponent<ParticleSystem>();
        explodeParticle = explodeEffectObject.GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// 步枪开枪前动作
    /// </summary>
    public override void BeforeFire()
    {
        base.BeforeFire();
    }

    /// <summary>
    /// 步枪开枪动作
    /// </summary>
    public override void Fire()
    {
        base.Fire();
        muzzleParticle.Play();
        MusicManager.Instance.PlaySound("Rifle");
    }

    /// <summary>
    /// 步枪开枪后动作
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
