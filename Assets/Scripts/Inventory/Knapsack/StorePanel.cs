using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePanel : Inventory
{
    #region 单例模式
    private static StorePanel _instance;
    public static StorePanel Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("WeaponStorePanel").GetComponent<StorePanel>();
            }
            return _instance;
        }
    }
    #endregion



    public override void Start()
    {
        base.Start();
        StoreItem(ItemManager.Instance.itemDic[8]);
        StoreItem(ItemManager.Instance.itemDic[9]);
        StoreItem(ItemManager.Instance.itemDic[10]);
        StoreItem(ItemManager.Instance.itemDic[11]);
        StoreItem(ItemManager.Instance.itemDic[12]);
    }

    public override bool StoreItem(Item item)
    {
        if (item == null)
        {
            Debug.LogWarning("要存储的物品的id不存在");
            return false;
        }
        Slot slot = FindEmptySlot();
        if (slot == null)
        {
            Debug.LogWarning("没有空的物品槽");
            return false;
        }
        else
        {
            slot.StoreItem(item);//把物品存储到这个空的物品槽里面
        }
        
        return true;
    }


}
