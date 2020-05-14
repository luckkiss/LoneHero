using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : IWeapon
{
    /// <summary>
    /// 镭射枪枪口特效
    /// </summary>
    private GameObject muzzleFireRender;
    /// <summary>
    /// 构造函数
    /// </summary>
    public Laser(int id, string name, string type, string path, string iconPath, string description, int capacity, int damage, int elastance, int maxElastance, int buyPrice, string muzzleEffectPath, string explodeEffectPath, string bulletPath, float attackFrequency) : base(id, name, type, path, iconPath, description, capacity, damage, elastance, maxElastance, buyPrice, muzzleEffectPath, "", bulletPath, attackFrequency)
    {
        if (explodeEffectPath != "") { this.explodeEffectObject = Resources.Load(explodeEffectPath) as GameObject; }
        muzzleFireRender = Resources.Load(muzzleEffectPath) as GameObject;
    }

    /// <summary>
    /// 镭射枪开枪前动作
    /// </summary>
    public override void BeforeFire()
    {
        base.BeforeFire();
    }

    /// <summary>
    /// 镭射枪开枪动作
    /// </summary>
    public override void Fire()
    {
        
        Object.Instantiate(muzzleFireRender, gunObject.transform.Find("GunMuzzlePoint").transform);

        GameObject Bullet = PoolManager.gameObject.GetObjectFormPool("LaserBullet");
        if (Bullet == null)
        {
            Bullet = Object.Instantiate(bulletObject);
        }
        Bullet.transform.position = gunObject.transform.Find("GunMuzzlePoint").position;
        Bullet.transform.rotation = gunObject.transform.Find("GunMuzzlePoint").rotation;
        Bullet.SetActive(true);
        LaserBullet bullet = Bullet.GetComponent<LaserBullet>();
        bullet.explodeEffect = explodeEffectObject;
        bullet.hit = Hit().point;
        MusicManager.Instance.PlaySound("Laser");
    }

    /// <summary>
    /// 镭射枪开枪后动作
    /// </summary>
    public override void AfterFire()
    {
        //base.AfterFire();
    }
}
