using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : IWeapon 
{
    /// <summary>
    /// 枪口特效粒子系统
    /// </summary>
    public ParticleSystem muzzleParticle;
    /// <summary>
    /// 爆炸特效粒子系统
    /// </summary>
    private ParticleSystem explodeParticle;

    /// <summary>
    /// 构造函数
    /// </summary>
    public Pistol(int id, string name, string type, string path, string iconPath, string description, int capacity, int damage, int elastance, int maxElastance, int buyPrice, string muzzleEffectPath, string explodeEffectPath, string bulletPath, float attackFrequency) : base(id, name, type, path, iconPath, description, capacity, damage, elastance, maxElastance, buyPrice, muzzleEffectPath, explodeEffectPath, bulletPath, attackFrequency)
    {
        muzzleParticle = muzzleEffectObject.GetComponent<ParticleSystem>();
        explodeParticle = explodeEffectObject.GetComponent<ParticleSystem>();
    }
    
    /// <summary>
    /// 手枪开枪前动作
    /// </summary>
    public override void BeforeFire()
    {
        base.BeforeFire();
    }
   
    /// <summary>
    /// 手枪开枪动作
    /// </summary>
    public override void Fire()
    {
        
        muzzleEffectObject.transform.position = gunObject.transform.Find("GunMuzzlePoint").transform.position;
        muzzleEffectObject.transform.rotation = gunObject.transform.Find("GunMuzzlePoint").transform.rotation;
        muzzleParticle.Play();
        MusicManager.Instance.PlaySound("Pistol");
    }
    
    /// <summary>
    /// 手枪开枪后动作
    /// </summary>
    public override void AfterFire()
    {
        base.AfterFire();
        RaycastHit hit = Hit();
        MonsterProxy monsterProxy =  hit.collider.transform.GetComponent<MonsterProxy>();
        if(monsterProxy != null)
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
