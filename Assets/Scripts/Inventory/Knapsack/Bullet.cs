using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Item
{
    /// <summary>
    /// 物品单格最大储存数
    /// </summary>
    private int maxStorage { get; set; }
    /// <summary>
    /// 购买价格
    /// </summary>
    private int buyPrice { get; set; }

    public Bullet(int id, string name, string type, string path, string iconPath, string description, int capacity, int maxStorage, int buyPrice) : base(id, name, type, path, iconPath, description, capacity)
    {
        this.maxStorage = maxStorage;
        this.buyPrice = buyPrice;
    }

    public override string ToolTip()
    {
        string text = string.Format("<color=green><size=28>{0}</size></color>\n<size=18>{1}</size>\n<color=green><size=18>价格:{2}</size></color>", name, description, buyPrice );
        return text;
    }

    public override int BuyPrice { get  { return buyPrice; } set => base.BuyPrice = value; }
}
