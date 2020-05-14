using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager 
{
    private static ItemManager instance;
    public static ItemManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ItemManager();
            }
            return instance;
        }
    }
    private ItemManager()
    {
        Init();
    }
    /// <summary>
    /// 储存每个物品的基本信息（ID，物品类）
    /// </summary>
    public Dictionary<int, Item> itemDic = new Dictionary<int, Item>();
    /// <summary>
    /// 解析Json，储存各个物品的基本信息
    /// </summary>
    private void Init()
    {
        TextAsset itemText = Resources.Load<TextAsset>("Item");
        string itemJson = itemText.text;
        JsonData jsonData = JsonMapper.ToObject(itemJson);
        Item item = null;
        for(int i = 0;i<jsonData.Count;i++)
        {
            int id = (int)jsonData[i]["ID"];
            string name = jsonData[i]["Name"].ToString();
            string type = jsonData[i]["Type"].ToString();
            string path = jsonData[i]["Path"].ToString();
            string iconPath = jsonData[i]["IconPath"].ToString();
            string description = jsonData[i]["Description"].ToString();
            int capacity = (int)jsonData[i]["Capacity"];
            Item.ItemType itemType = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), type);
            switch (itemType)
            {
                case Item.ItemType.Bullet:
                    int maxStorage = (int)jsonData[i]["MaxStorage"];
                    int buyPrice = (int)jsonData[i]["BuyPrice"];
                    item = new Bullet(id, name, type, path, iconPath, description, capacity, maxStorage,buyPrice);
                    break;
                case Item.ItemType.Consumable:
                    break;
            }
            itemDic.Add(id, item);
        }
    }
    public Item GetItemById(int id)
    {
        //todo
        return null;
    }
}
