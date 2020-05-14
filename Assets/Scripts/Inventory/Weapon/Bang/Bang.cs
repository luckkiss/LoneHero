using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bang : IWeapon
{
    /// <summary>
    /// 枪口特效粒子系统
    /// </summary>
    private ParticleSystem muzzleParticle;
    /// <summary>
    /// 构造函数
    /// </summary>
    public Bang(int id, string name, string type, string path, string iconPath, string description, int capacity, int damage, int elastance, int maxElastance, int buyPrice, string muzzleEffectPath, string explodeEffectPath, string bulletPath, float attackFrequency) : base(id, name, type, path, iconPath, description, capacity, damage, elastance, maxElastance, buyPrice, muzzleEffectPath, "", bulletPath, attackFrequency)
    {
        if (explodeEffectPath != "") { this.explodeEffectObject = Resources.Load(explodeEffectPath) as GameObject; }
        muzzleParticle = muzzleEffectObject.GetComponent<ParticleSystem>();
    }

    /// <summary>
    ///导弹开枪前动作
    /// </summary>
    public override void BeforeFire()
    {
        base.BeforeFire();
    }

    /// <summary>
    /// 导弹开枪动作
    /// </summary>
    public override void Fire()
    {
        //base.Fire();
        muzzleParticle.Play();
        GameObject Bullet = PoolManager.gameObject.GetObjectFormPool("BangBullet");
        if(Bullet == null)
        {
            Bullet = Object.Instantiate(bulletObject);
        }
        Bullet.transform.position = gunObject.transform.Find("BulletPoint").position;
        Bullet.transform.rotation = gunObject.transform.Find("BulletPoint").rotation;
        Bullet.SetActive(true);
        BangBullet bullet = Bullet.GetComponent<BangBullet>();
        bullet.explodeEffect = explodeEffectObject;
        bullet.hit = Hit().point;
        MusicManager.Instance.PlaySound("Bang");
    }

    /// <summary>
    /// 导弹开枪后动作
    /// </summary>
    public override void AfterFire()
    {
        //base.AfterFire();
    }
}
