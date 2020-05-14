using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWeapon : Item
{
    #region 基本属性
    /// <summary>
    /// 武器伤害
    /// </summary>
    public int damage { set; get; }
    /// <summary>
    /// 武器弹药容量
    /// </summary>
    public int elastance { set; get; }
    /// <summary>
    /// 武器最大弹药容量
    /// </summary>
    public int maxElastance { set; get; }
    /// <summary>
    /// 武器攻击频率
    /// </summary>
    public float attackFrequency;
    /// <summary>
    /// 枪支物体
    /// </summary>   
    public GameObject gunObject;
    /// <summary>
    /// 购买价格
    /// </summary>
    public int buyPrice;

    /// <summary>
    /// 枪口特效
    /// </summary>
    protected GameObject muzzleEffectObject;
    /// <summary>
    /// 爆炸特效
    /// </summary>
    protected GameObject explodeEffectObject;
    /// <summary>
    /// 子弹实例
    /// </summary>
    protected GameObject bulletObject;
    /// <summary>
    /// 武器图标
    /// </summary>
    public Sprite icon;
    #endregion
    private System.Random random = new System.Random();
    /// <summary>
    /// 构造函数
    /// </summary>
    public IWeapon(int id, string name, string type, string path,string iconPath, string description, int capacity, int damage, int elastance,int maxElastance,int buyPrice,string muzzleEffectPath,string explodeEffectPath,string bulletPath, float attackFrequency) :base(id,name,type,path,iconPath,description, capacity)
    {

        this.damage = damage;
        this.elastance = elastance;
        this.maxElastance = maxElastance;
        this.attackFrequency = attackFrequency;
        this.buyPrice = buyPrice;
        GameObject parent = GameObject.Find("Hand");
        if (path != "") { this.gunObject = Object.Instantiate(Resources.Load(path) as GameObject, parent.transform, false); }
        if (muzzleEffectPath != "")
        {
            this.muzzleEffectObject = Object.Instantiate(Resources.Load(muzzleEffectPath) as GameObject);
            muzzleEffectObject.transform.SetParent(gunObject.transform);
        }
        if (explodeEffectPath != "") { this.explodeEffectObject = Object.Instantiate(Resources.Load(explodeEffectPath) as GameObject); }
        if (bulletPath != "")
        {
            this.bulletObject = Resources.Load(bulletPath) as GameObject;
        }
        if (iconPath != "") icon = Resources.Load(iconPath,typeof(Sprite)) as Sprite;
    }
    
    /// <summary>
    /// 开火前动作
    /// </summary>
    public virtual void BeforeFire()
    {

    }
    
    /// <summary>
    /// 开火动作
    /// </summary>
    public virtual void Fire()
    {
        elastance--;
        muzzleEffectObject.transform.position = gunObject.transform.Find("GunMuzzlePoint").transform.position;
        muzzleEffectObject.transform.rotation = gunObject.transform.Find("GunMuzzlePoint").transform.rotation;
    }
    
    /// <summary>
    /// 开火后动作
    /// </summary>
    public virtual void AfterFire()
    {
        //base.AfterFire();
        RaycastHit hit = Hit();
        MonsterProxy monsterProxy = hit.collider.transform.GetComponent<MonsterProxy>();
        if (monsterProxy != null)
        {
            monsterProxy.thisMonster.TakeDamage(damage, hit.point);
        }
        else
        {
            explodeEffectObject.transform.position = hit.point;
            //explodeParticle.Play();
        }
    }

    protected RaycastHit Hit()
    {        
        float dis = (new Vector2(Screen.width / 2, Screen.height / 2) - new Vector2(Input.mousePosition.x, Input.mousePosition.y)).magnitude;
        int offsetx = random.Next(-(int)dis / 5, (int)dis / 5);
        int offsety = random.Next(-(int)dis / 5, (int)dis / 5);
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Input.mousePosition.x+ offsetx, Input.mousePosition.y+ offsety));
        Physics.Raycast(ray, out RaycastHit hit);
        return hit;
    }

    public override string ToolTip()
    {
        string text = string.Format("<color=green><size=28>{0}</size></color>\n<size=18>{1}</size>\n\n<color=green><size=18>攻击力: {2}\n射速: {3}\n弹药容量: {4}\n价格: {2}</size></color>", name, description,damage, attackFrequency,maxElastance, buyPrice);
        return text;
    }

    public override int BuyPrice { get { return buyPrice; } set => base.BuyPrice = value; }
}
