using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class BearMove : MonoBehaviour {

    // Use this for initialization
    // Use this for initialization
    Animator animator;
    Player player;
    Transform targe;
    public static float hp = 50;
    NavMeshAgent agent;   
    public int attackDamage = 3;
    public float attackRate = 2;
    float attackInterval;
    float lastAttackTime;
    bool isHurt = true;
    UiManager uiManager;
    void Start()
    {
        uiManager = FindObjectOfType<UiManager>();
        player = GameObject.FindObjectOfType<Player>();
        agent = GetComponent<NavMeshAgent>();
        this.gameObject.tag = "BearBoss";
        targe = GameObject.Find("Player").transform;
        animator = GameObject.FindObjectOfType<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //目标寻路
        if (agent.isActiveAndEnabled)
        {
            agent.SetDestination(targe.position);
        }
        if (agent.velocity.sqrMagnitude <= 0.1f)
        {
            animator.SetBool("run", false);
        }
        else
        {
            animator.SetBool("run", true);
        }


        //近战敌人，攻击判定
        Vector3 dist = targe.position - transform.position;
        dist.y = 0;
        if (dist.sqrMagnitude < 0.5 && isHurt == true)
        {
            if (Time.time - lastAttackTime > attackRate)
            {
                lastAttackTime = Time.time;
                player.Hurt(attackDamage);
            }
        }

    }

    public void Hurt(int damage)
    {
        if (hp > 0)//活着才能受到伤害
        {
            hp -= damage;
            uiManager.SetBossHp(Mathf.Ceil(hp));
            if ((hp<=0?0:hp) <= 0)
            {
                
                isHurt = false;
                //寻路失活，避免死亡后滑行        
                agent.enabled = false;
                //碰撞失活，避免再次受伤或者挡道  
                agent.GetComponent<Collider>().enabled = false;
                animator.Play("Dying");
                Destroy(this.gameObject, 2.5f);                
            }
        }


    }
}
