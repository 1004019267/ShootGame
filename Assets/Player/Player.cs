using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    // Use this for initialization
    //    #不限题材，不限剧情，不限玩法的一个射击游戏
    //##参考：
    //* 1.生存模式，无尽模式
    //* 2.探险，拯救，解谜，闯关
    //* 3.推车（有敌人车不走），时间限定。
    //* 4.爆破的，AB点，埋雷后保护雷
    //* 5.子弹有限的，寻找子弹和道具，最终比分数
    //* 6.boss模式
    //* 7.上帝模式，策略模式。


    //##要求<1级>：
    //* 1.第一（三）人称：行走，旋转，跳跃。
    //* 2.子弹系统，子弹至少两种类型，例如：子弹，炸弹，激光等。
    //* 3.道具系统，随机出道具，例如：加血，加炸弹，加速等。
    //* 4.UI系统，例如：血量，分数、时间或能量等。
    //* 5.敌人类型至少有两种，例如：近战和远战等。
    //* 6.游戏的重新开始。


    //##要求<2级>：
    //* 1.使用UGUI显示界面，血条和按钮。例如：开始游戏和结束游戏，自己血条和敌人的血条。
    //* 2.添加小地图。
    //* 3.UI界面要求适配（16:9为基准）。
    //* 4.添加游戏背景音乐，并且有设置界面，音量可调节。#不限题材，不限剧情，不限玩法的一个射击游戏
    //##参考：
    //* 1.生存模式，无尽模式
    //* 2.探险，拯救，解谜，闯关
    //* 3.推车（有敌人车不走），时间限定。
    //* 4.爆破的，AB点，埋雷后保护雷
    //* 5.子弹有限的，寻找子弹和道具，最终比分数
    //* 6.boss模式
    //* 7.上帝模式，策略模式。


    //##要求<1级>：
    //* 1.第一（三）人称：行走，旋转，跳跃。
    //* 2.子弹系统，子弹至少两种类型，例如：子弹，炸弹，激光等。
    //* 3.道具系统，随机出道具，例如：加血，加炸弹，加速等。
    //* 4.UI系统，例如：血量，分数、时间或能量等。
    //* 5.敌人类型至少有两种，例如：近战和远战等。
    //* 6.游戏的重新开始。


    //##要求<2级>：
    //* 1.使用UGUI显示界面，血条和按钮。例如：开始游戏和结束游戏，自己血条和敌人的血条。
    //* 2.添加小地图。
    //* 3.UI界面要求适配（16:9为基准）。
    //* 4.添加游戏背景音乐，并且有设置界面，音量可调节。
    Animator animator;
    public float speed = 6.0F;
    CharacterController characterCon;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
   public float hp = 10;
    SkillAll[] skills;
    private int skillIndex = 0;
    public int score;
    bool isFire = false;
    public TextMesh tm;
    UiManager uiManager;
    //Awake里面赋值组件获取组件，较及时，推荐使用
    void Awake()
    {
        uiManager = GameObject.FindObjectOfType<UiManager>();
        animator = this.GetComponent<Animator>();
        characterCon = GetComponent<CharacterController>();
        skills = transform.GetComponentsInChildren<SkillAll>();
        //把鼠标的光标锁定到Game视图
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Start()
    {
        MoreSkill();      
        EventManager.ScoreAdd += this.AddScore;
    }
    //一定要写-=
    private void OnDestroy()
    {
        EventManager.ScoreAdd -= this.AddScore;
    }
    // Update is called once per frame
   
    void Update()
    {
        //退出游戏
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        Move();
        Rotate();
        //切换技能
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            skillIndex = 0;
            MoreSkill();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&&isFire==true)
        {
            skillIndex = 1;
            MoreSkill();
        }       
        if (Input.GetMouseButton(0))
        {
            skills[skillIndex].Fire();
        }
        
        
    }
    //更换不同武器
    void MoreSkill()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            if (i==skillIndex)
            {
                skills[i].gameObject.SetActive(true);
            }
            else
            {
                skills[i].gameObject.SetActive(false);
            }
        }
    }
    public  void FireSkill()
    {
        isFire = true;
    }
    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * 1000, mouseX);
    }
    void Move()
    {
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (characterCon.isGrounded)
        {

            moveDirection = new Vector3(horizon, 0, vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (horizon != 0 || vertical != 0)
            {
                animator.SetBool("run", true);
            }
            else
            {
                animator.SetBool("run", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
                animator.SetBool("run", true);
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterCon.Move(moveDirection * Time.deltaTime);
    }
    public void Hurt(int damage)
    {
        hp-=damage;
        //想上取整
        uiManager.SetHp(Mathf.Ceil(hp));
        if ((hp <= 0 ? hp = 0 : hp)<= 0)
        {
            tm.text = "渣渣Loser";
            Time.timeScale = 0;
            //获取最高分
            int maxScore = PlayerPrefs.GetInt("maxScore");
            if (score>maxScore)
            {
                //重新设置最高分
                maxScore = score;
                PlayerPrefs.SetInt("maxScore", maxScore);             
            }
            uiManager.SetGameOver(maxScore, score);
        }
    }
    public void AddScore(int val=1)
    {
        score += val;
        uiManager.SetSoul(20 - score);      
    }         
}
