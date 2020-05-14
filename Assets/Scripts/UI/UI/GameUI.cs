using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameUI : UIBase
{
    IWeapon weapon;
    /// <summary>
    /// 武器图标
    /// </summary>
    private Image weaponIcon;
    /// <summary>
    /// 武器名字
    /// </summary>
    private Text weaponName;
    /// <summary>
    /// 武器弹量Text
    /// </summary>
    private Text weaponBullet;
    /// <summary>
    /// 武器弹量条
    /// </summary>
    private Slider weaponSlider;
    /// <summary>
    /// 角色生命条
    /// </summary>
    private Slider healthSlider;
    /// <summary>
    /// 角色生命值
    /// </summary>
    private Text healthValue;
    private Text score;
    private Text money;
    private Texture2D mouseAttack;
    private Texture2D mouseUnattack;
    private CanvasGroup canvasGroupLevel;
    bool showLevel = true;
    public override void Init()
    {
        base.Init();
        weapon = GameSystem.Instance.weaponSystem.currentWeapon;
        weaponIcon = GetControl<Image>("WeaponIcon");
        weaponName = GetControl<Text>("WeaponName");
        weaponBullet = GetControl<Text>("WeaponBulletValue");
        weaponSlider = GetControl<Slider>("WeaponBulletBar");
        healthValue = GetControl<Text>("HeathValue");
        healthSlider = GetControl<Slider>("HealthBar");
        score = GetControl<Text>("ScoreText");
        money = GetControl<Text>("MoneyText");
        mouseAttack = Resources.Load("UI/Mouse/Attack") as Texture2D;
        mouseUnattack = Resources.Load("UI/Mouse/Unattack") as Texture2D;
        canvasGroupLevel = GetGameObject("Level").GetComponent<CanvasGroup>();
    }
    public override void Show()
    {
        base.Show();
        GameSystem.Instance.SetGameStop(false);
        Cursor.SetCursor(mouseAttack, new Vector2(65,65) , CursorMode.Auto);
        MusicManager.Instance.PlayBGM("Environment");
    }
    public override void Hide(UnityAction action = null)
    {
        //base.Hide(action);
        Cursor.SetCursor(mouseUnattack, Vector2.zero, CursorMode.Auto);
        MusicManager.Instance.StopBGM();
        GameSystem.Instance.SetGameStop(true);
        action.Invoke();
    }
    private void UpdateShow()
    {
        weapon = GameSystem.Instance.weaponSystem.currentWeapon;
        //更新武器信息
        weaponIcon.sprite = weapon.icon;
        weaponIcon.color = new Color((3 / 255f), (140 / 255f), (67 / 255f), (255 / 255f));
        weaponName.text = weapon.name;
        //更新弹药信息
        weaponBullet.text = weapon.elastance.ToString() + "/" + weapon.maxElastance.ToString();
        weaponSlider.value = (float)weapon.elastance / (float)weapon.maxElastance;
        //更新角色生命状态
        healthValue.text = GameSystem.Instance.actorSystem.creatureAttr.hp.ToString()+"%";
        healthSlider.value = GameSystem.Instance.actorSystem.creatureAttr.hp / 100.0f;

        //更新金钱
        money.text = "金钱：" + GameSystem.Instance.GetMoney().ToString();
        score.text = "分数：" + GameSystem.Instance.GetScore().ToString();
    }
    private void Update()
    {
        UpdateShow();
        InputExcute();
        if(GameSystem.Instance.actorSystem.isDead)
        {
            ShowGameOverUI();
        }
        ShowLevel();
    }

    private void InputExcute()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowGameMenuUI();
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            ShowKnapasckUI();
        }
    }

    private void ShowLevel()
    {
        if(showLevel)
        {
            GetControl<Text>("Level").text = "怪物波数：" + GameSystem.Instance.levelSystem.currentIntLevel.ToString();
            canvasGroupLevel.alpha = Mathf.Lerp(canvasGroupLevel.alpha, 1, 0.01f);
            if(canvasGroupLevel.alpha>=0.9)
            {
                showLevel = false;
            }
        }
        else
        {
            canvasGroupLevel.alpha = Mathf.Lerp(canvasGroupLevel.alpha, 0, 0.01f);
        }
    }

    private void ShowGameMenuUI()
    {
        Hide(() =>
        {
            EventManager.Instance.SendEvent(EventType.GameMenuUI);
        });
    }

    private void ShowKnapasckUI()
    {
        Hide(() =>
        {
            EventManager.Instance.SendEvent(EventType.KnapasckUI);
        });
    }

    private void ShowGameOverUI()
    {
        Hide(() =>
        {
            EventManager.Instance.SendEvent(EventType.GameOverUI);
        });
    }
    
    public void isShowLevel()
    {
        showLevel = true;
    }
}
