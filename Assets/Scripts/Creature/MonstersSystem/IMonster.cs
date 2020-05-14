using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class IMonster
{
    /// <summary>
    /// 是否死亡
    /// </summary>
    public bool isDead;
    public float AttackTimer;
    /// <summary>
    /// 这个生物的组件
    /// </summary>
    private GameObject GameObject;
    /// <summary>
    /// 动画
    /// </summary>
    public Animator animator;
    /// <summary>
    /// 寻路系统
    /// </summary>
    public NavMeshAgent navAgent;
    /// <summary>
    /// 被攻击的血浆
    /// </summary>
    public ParticleSystem attackedEffec;
    public ICreature creatureAttr;
    private ICreature InitCreatureAttr;
    public GameObject gameObject
    {
        set
        {
            GameObject = value;
            navAgent = GameObject.GetComponent<NavMeshAgent>();
            animator = GameObject.GetComponent<Animator>();
            attackedEffec = GameObject.GetComponent<ParticleSystem>();
        }
        get
        {
            return GameObject;
        }
    }
    public ICreature initCreatureAttr
    {
        set
        {
            InitCreatureAttr = value;
        }
        get
        {
            return InitCreatureAttr.Clone();
        }
    }

    public virtual void Attack()
    {
        AttackTimer += Time.deltaTime;
        if(AttackTimer>=0.7)
        {
            GameSystem.Instance.actorSystem.UnderAttacked(creatureAttr.damage);
            AttackTimer = 0;
        }
    }

    public virtual void Update()
    {
        if(!isDead)
        {
            navAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
            float distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, gameObject.transform.position);
            if (distance <= creatureAttr.attactDistance && !isDead)
            {
                gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                animator.SetInteger("States", 1);
                Attack();

            }
            else
            {
                AttackTimer = 0;
                if (!isDead) animator.SetInteger("States", 0);
            }
        }
        
    }
    /// <summary>
    /// 受到攻击
    /// </summary>
    /// <param name="damage"></param>
    public virtual void TakeDamage(int damage,Vector3 hitPiont)
    {
        attackedEffec.transform.position = hitPiont;
        attackedEffec.Play();
        creatureAttr.hp -= damage;
        //Debug.Log("受到了伤害，当前血量为:" + creatureAttr.hp);
        if (creatureAttr.hp <= 0)
        {
            if(!isDead)
            {
                DeadExcute();
            }
        }
    }
    public virtual void DeadExcute()
    {
        isDead = true;
        animator.SetInteger("States", 2);
        animator.SetTrigger("Dead");
        navAgent.isStopped = true;
        GameSystem.Instance.AddMonsterDeadCount();
        GameSystem.Instance.Reward(gameObject.transform.position);
        gameObject.transform.Find("MinMapIcon").gameObject.SetActive(false);
    }
}


