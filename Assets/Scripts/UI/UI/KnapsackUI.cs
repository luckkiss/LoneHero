using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KnapsackUI : UIBase
{
    /// <summary>
    /// 武器系统
    /// </summary>
    private WeaponSystem weaponSystem;
    /// <summary>
    /// 持有武器Panel
    /// </summary>
    private GameObject weaponPanel;
    /// <summary>
    /// 相机下的武器OBJ
    /// </summary>
    private List<Transform> weaponViewList = new List<Transform>();
    /// <summary>
    /// 相机
    /// </summary>
    WeaponViweCameraController cameraController;
    /// <summary>
    /// 解锁Icon
    /// </summary>
    private GameObject UnlockIcon;
    /// <summary>
    /// 背包格子列表
    /// </summary>
    private List<Transform> knapsackSlotList = new List<Transform>();
    /// <summary>
    /// 商店格子列表
    /// </summary>
    private List<Transform> storeSlotList = new List<Transform>();
    /// <summary>
    /// 武器价格
    /// </summary>
    private Text weaponPrice;
    /// <summary>
    /// 信息简介
    /// </summary>
    public ToolTip toolTip;
    /// <summary>
    /// 拥有的金钱
    /// </summary>
    private Text actorMoney;

    private Text buyInfo;
    public override void Init()
    {
        base.Init();
        weaponSystem = GameSystem.Instance.weaponSystem;
        weaponPanel = GetGameObject("WeaponPanel");
        FindChild(GetGameObject("WeaponObj").transform, weaponViewList);
        GetControl<Button>("ExitButton").onClick.AddListener(Quit);
        GetControl<Button>("UnlockButton").onClick.AddListener(UnLockWeapon);
        GetControl<Button>("BuyButton").onClick.AddListener(EnabledBuyPlanel);
        cameraController = GetGameObject("WeaponStroeCamera").AddComponent<WeaponViweCameraController>();
        UnlockIcon = GetGameObject("UnlockIcon");

        GetControl<Button>("SwitchButtonLeft").onClick.AddListener(SwichWeaponLeft);
        GetControl<Button>("SwitchButtonRight").onClick.AddListener(SwitchWeaponRight);
        GetControl<Button>("RotateButton").onClick.AddListener(RotateWeapon);        
        FindChild(GetGameObject("KnapsackPanel").transform, knapsackSlotList);
        FindChild(GetGameObject("WeaponStorePanel").transform, storeSlotList);
        InitSlots();

        GetGameObject("KnapsackPanel").AddComponent<KnapsackPanel>();
        GetGameObject("WeaponStorePanel").AddComponent<StorePanel>();

        GetGameObject("BuyPanel").transform.Find("BuyButton").GetComponent<Button>().onClick.AddListener(BuyItem);
        GetGameObject("BuyPanel").transform.Find("CancleButton").GetComponent<Button>().onClick.AddListener(DesabledBuyPlanel);

        toolTip = GetGameObject("ToolTip").AddComponent<ToolTip>();

        weaponPrice = GetControl<Text>("Price");
        actorMoney = GetGameObject("CurrentMoney").transform.Find("Text").GetComponent<Text>();
        buyInfo = GetControl<Text>("BuyInfo");

        AddEventTrigger("ExitButton", EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("UnlockButton", EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("BuyButton", EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("SwitchButtonLeft", EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("SwitchButtonRight", EventTriggerType.PointerEnter, OnTounchEvent);
        AddEventTrigger("RotateButton", EventTriggerType.PointerEnter, OnTounchEvent);

    }

    public override void Show()
    {
        base.Show();
        SetCameraTarget(weaponViewList[0]);
    }

    public override void Hide(UnityAction action = null)
    {
        base.Hide(action);
    }

    private void UnLockWeapon()
    {

        int buyprice =  GameSystem.Instance.weaponSystem.GetWeaponPrice(cameraController.target.transform.name);
        if(GameSystem.Instance.GetMoney()>=buyprice)
        {
            GameSystem.Instance.GetWeapon(cameraController.target.transform.name);
            ShowHaveWeapon();
            UnlockIcon.SetActive(false);
            GameSystem.Instance.AddMoney(-buyprice);
        }
        else
        {
            buyInfo.text = "购买金钱不够，需要：" + buyprice + "金，你只有:" + GameSystem.Instance.GetMoney() + "金";
        }

    }
    /// <summary>
    /// 更新显示已经拥有的武器
    /// </summary>
    private void ShowHaveWeapon()
    {
        foreach(var weapon in weaponSystem.weaponDic)
        {
            Image image = weaponPanel.transform.Find(weapon.Key).GetComponent<Image>();            
            if (image!=null)
            {
                image.color = new Color((3 / 255f), (140 / 255f), (67 / 255f), (255 / 255f));
            }
            if(weaponPanel.transform.Find(weapon.Key).gameObject.GetComponent<WeaponSlot>() == null)
            {
                weaponPanel.transform.Find(weapon.Key).gameObject.AddComponent<WeaponSlot>();
            }
        }
    }



    private void Quit()
    {
        Hide();
        //返回上一层
        EventManager.Instance.SendEvent(topEventType);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }

        actorMoney.text = "金钱：" + GameSystem.Instance.GetMoney().ToString();


    }
    #region 相机的设置
    private void SetCameraTarget(Transform target)
    {
        cameraController.target = target;
        if(weaponSystem.weaponDic.ContainsKey(target.name))
        {
            UnlockIcon.SetActive(false);
        }
        else
        {
            UnlockIcon.SetActive(true);
        }
        weaponPrice.text = weaponSystem.GetWeaponPrice(target.name).ToString();
    }
    private void SwichWeaponLeft()
    {
        int index = weaponViewList.FindIndex(List => List.transform == cameraController.target);
        if(index - 1>=0)
        {
            SetCameraTarget(weaponViewList[index - 1]);
        }
    }
    private void SwitchWeaponRight()
    {
        int index = weaponViewList.FindIndex(List => List.transform == cameraController.target);
        if (index + 1 < weaponViewList.Count)
        {
            SetCameraTarget(weaponViewList[index + 1]);
        }
    }
    private void RotateWeapon()
    {

        cameraController.target.transform.Rotate(Vector3.up, 30, Space.World);

    }
    #endregion

    private void InitSlots()
    {
        foreach(Transform transform in knapsackSlotList)
        {
            transform.gameObject.AddComponent<Slot>();            
        }

        foreach (Transform transform in storeSlotList)
        {
            transform.gameObject.AddComponent<Slot>();          
        }
    }


    private void BuyItem()
    {
        string amount = GetGameObject("BuyPanel").transform.Find("BuyCount").GetComponent<InputField>().text;
        for(int i = 0;i<=int.Parse(amount);i++)
        {

            if(GameSystem.Instance.GetMoney()< StorePanel.Instance.selectISlot.item.BuyPrice)
            {
                buyInfo.text = "金钱不够";
                break;
            }          
            bool isSuccess = KnapsackPanel.Instance.StoreItem(StorePanel.Instance.selectISlot.item);
            if(isSuccess)
            {
                GameSystem.Instance.AddMoney(-StorePanel.Instance.selectISlot.item.BuyPrice);
            }
            else
            {
                buyInfo.text = "背包格子不够";
            }
        }
        DesabledBuyPlanel();
    }

    private void DesabledBuyPlanel()
    {
        GetGameObject("BuyPanel").SetActive(false);
    }

    private void EnabledBuyPlanel()
    {
        GetGameObject("BuyPanel").SetActive(true);
    }

    public void ShowToolTip(string content)
    {
        toolTip.Show(content);
    }
    public void HideToolTip()
    {
        toolTip.Hide();
    }
}
