using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSystem
{
    public ActorSystem(){}
    /// <summary>
    /// 角色基本属性
    /// </summary>
    public ICreature creatureAttr;
    public bool isDead;
    /// <summary>
    /// 角色物体
    /// </summary>
    public GameObject gameObject;
    public ParticleSystem attacyEffect;

    /// <summary>
    /// 鼠标的屏幕坐标
    /// </summary>
    private Vector3 mouseScreenPos;
    /// <summary>
    /// 角色的屏幕坐标
    /// </summary>
    private Vector3 actorScreenPos;
    /// <summary>
    /// 鼠标的世界坐标
    /// </summary>
    public Vector3 mouseWorldPos;

    private Animator anim;
    public IWeapon weapon = null;
    private float attackCD;
    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        GameSystem.Instance.GetWeapon("Pistol");
        isDead = false;
    }
    public void Update()
    {
        if(!isDead)
        {
            ActorMove();
            KeyControl();
        }        
    }
    /// <summary>
    /// 角色移动控制
    /// </summary>
    void ActorMove()
    {
        //角色朝向鼠标
        mouseScreenPos = Input.mousePosition;
        Vector3 ActorScreenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        mouseScreenPos.z = ActorScreenPos.z;
        mouseWorldPos.x = Camera.main.ScreenToWorldPoint(mouseScreenPos).x;
        mouseWorldPos.z = Camera.main.ScreenToWorldPoint(mouseScreenPos).z;
        mouseWorldPos.y = gameObject.transform.position.y;
        gameObject.transform.LookAt(mouseWorldPos);
        //控制角色移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vactorPos = gameObject.transform.forward;
        float Zangle = Vector3.Angle(vactorPos, new Vector3(0, 0, 1));
        float Xangle = Vector3.Angle(vactorPos, new Vector3(1, 0, 0));
        anim.SetFloat("Velocity X", -Mathf.Cos(Xangle * Mathf.Deg2Rad) * v * 3.6f + Mathf.Cos(Zangle * Mathf.Deg2Rad) * h * 3.6f);
        anim.SetFloat("Velocity Z", Mathf.Cos(Zangle * Mathf.Deg2Rad) * v * 3.6f + Mathf.Cos(Xangle * Mathf.Deg2Rad) * h * 3.6f);
    }
    /// <summary>
    /// 攻击动作
    /// </summary>
    void ActorAttack()
    {
        attackCD += Time.deltaTime;
        if (attackCD >= weapon.attackFrequency / 10.0)
        {
            anim.SetBool("isAttacking", false);
            if (Input.GetMouseButton(0))
            {
                anim.SetTrigger("AttackTrigger");
                weapon.BeforeFire();
                weapon.Fire();
                weapon.AfterFire();
                anim.SetBool("isAttacking", true);
                attackCD = 0;
            }
        }
    }
    /// <summary>
    /// 滚轮切换武器
    /// </summary>
    void SwitchWeaponByScroll()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll == 0.1f)
        {
            GameSystem.Instance.GetWeapon(GameSystem.Instance.weaponSystem.weaponIndex - 1);
            anim.SetInteger("GunID", weapon.id);
        }
        if (scroll == -0.1f)
        {
            GameSystem.Instance.GetWeapon(GameSystem.Instance.weaponSystem.weaponIndex + 1);
            anim.SetInteger("GunID", weapon.id);
        }
    }
    /// <summary>
    /// 按键切换武器
    /// </summary>
    void SwitchWeaponByKey()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            GameSystem.Instance.GetWeapon("Pistol");
            anim.SetInteger("GunID", weapon.id);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            GameSystem.Instance.GetWeapon("Rifle");
            anim.SetInteger("GunID", weapon.id);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            GameSystem.Instance.GetWeapon("Automica");
            anim.SetInteger("GunID", weapon.id);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            GameSystem.Instance.GetWeapon("Submachine");
            anim.SetInteger("GunID", weapon.id);
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            GameSystem.Instance.GetWeapon("Bang");
            anim.SetInteger("GunID", weapon.id);
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            GameSystem.Instance.GetWeapon("Laser");
            anim.SetInteger("GunID", weapon.id);
        }
    }
    /// <summary>
    /// 武器和动作切换、使用手榴弹
    /// </summary>
    void KeyControl()
    {
        ActorMove();
        SwitchWeaponByScroll();
        SwitchWeaponByKey();
        ActorAttack();
    }

    public void UnderAttacked(int damage)
    {
        creatureAttr.hp -= damage;
        attacyEffect.transform.position = gameObject.transform.position;
        attacyEffect.Play();
        if (creatureAttr.hp<=0 && !isDead)
        {
            isDead = true;
            anim.SetBool("isDead", true);
            anim.SetTrigger("DeadTrigger");
        }
    }
}
