using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        IWeapon weapon = GameSystem.Instance.weaponSystem.weaponDic[transform.name];
        UIManager.Instance.uiPanelList["KnapsackUI"].gameObject.GetComponent<KnapsackUI>().ShowToolTip(weapon.ToolTip());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.uiPanelList["KnapsackUI"].gameObject.GetComponent<KnapsackUI>().HideToolTip();
    }
}
