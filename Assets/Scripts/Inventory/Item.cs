using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    #region 基本属性
    /// <summary>
    /// 物品ID
    /// </summary>
    public int id { set; get; }
    /// <summary>
    /// 物品名字
    /// </summary>
    public string name { set; get; }
    /// <summary>
    /// 物品类型
    /// </summary>
    public ItemType type { set; get; }
    /// <summary>
    /// 物品资源路径
    /// </summary>
    protected string path { set; get; }
    /// <summary>
    /// 物品图标
    /// </summary>
    public string iconPath { set; get; }
    /// <summary>
    /// 物品描述
    /// </summary>
    protected string description { get; set; }
    /// <summary>
    /// 物品重量
    /// </summary>
    protected int weight { get; set; }
    /// <summary>
    /// 容量
    /// </summary>
    public int capacity { get; set; }
    #endregion

    /// <summary>
    /// 构造函数
    /// </summary>
    public Item(int id, string name, string type, string path,string iconPath, string description, int capacity)
    {
        this.id = id;
        this.name = name;
        this.strType = type;
        this.path = path;
        this.iconPath = iconPath;
        this.description = description;
        this.capacity = capacity;
    }

    /// <summary>
    /// 物品类型
    /// 1.武器
    /// 2.子弹
    /// 3.消耗品
    /// </summary>
    public enum ItemType
    {
        Weapon,
        Bullet,
        Consumable
    }

    private string strType
    {
        set
        {
            type = (ItemType)System.Enum.Parse(typeof(ItemType), value);
        }
    }

    public virtual string ToolTip()
    {
        return " ";
    }

    public virtual int BuyPrice
    {
        set; get;
    }

}



