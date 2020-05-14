using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 物品槽
/// </summary>
public class Slot : MonoBehaviour ,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler{

    /// <summary>
    /// 存储的Item
    /// </summary>
    public Item item;

    /// <summary>
    /// 把item放在自身下面
    /// 如果自身下面已经有item了，amount++
    /// 如果没有 根据itemPrefab去实例化一个item，放在下面
    /// </summary>
    /// <param name="item"></param>
    public void StoreItem(Item item)
    {
        if (transform.childCount == 0)
        {
            GameObject itemGameObject = Instantiate(Resources.Load("UI/Item")) as GameObject;
            itemGameObject.transform.SetParent(this.transform);
            itemGameObject.transform.localScale = Vector3.one;
            itemGameObject.transform.localPosition = Vector3.zero;
            itemGameObject.AddComponent<ItemUI>().SetItem(item);
            this.item = item;
        }
        else
        {
            transform.GetChild(0).GetComponent<ItemUI>().AddAmount();
        }
    }


    /// <summary>
    /// 得到当前物品槽存储的物品类型
    /// </summary>
    /// <returns></returns>
    public Item.ItemType GetItemType()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.type;
    }

    /// <summary>
    /// 得到物品的id
    /// </summary>
    /// <returns></returns>
    public int GetItemId()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.id;
    }

    public bool IsFilled()
    {
        ItemUI itemUI = transform.GetChild(0).GetComponent<ItemUI>();
        return itemUI.Amount >= itemUI.Item.capacity;//当前的数量大于等于容量
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.uiPanelList["KnapsackUI"].gameObject.GetComponent<KnapsackUI>().HideToolTip();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item!=null)
        {
            UIManager.Instance.uiPanelList["KnapsackUI"].gameObject.GetComponent<KnapsackUI>().ShowToolTip(item.ToolTip());
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {        
        StorePanel.Instance.SetSelectSlot(this);
    }
}
