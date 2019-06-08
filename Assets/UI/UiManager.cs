using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiManager : MonoBehaviour {
    Text hpText;
    Text bossText;
    Text soulText;
    Text gameOverText;
    GameObject gameOver;
	// Use this for initialization
	void Awake () {
        gameOver = transform.Find("GameOver").gameObject;      
        hpText = transform.Find("Hp/Text").GetComponent<Text>();
        bossText= transform.Find("Boss/Text").GetComponent<Text>();
        soulText= transform.Find("Soul/Text").GetComponent<Text>();
       gameOverText= transform.Find("GameOver/Text").GetComponent<Text>();
    }
	
	// Update is called once per frame
   public void SetHp(float hp)
    {
        hpText.text = "" + hp;
    }
    public void SetBossHp(float hp)
    {
        bossText.text = "" + hp;
    }
    public void SetSoul(float num)
    {
        soulText.text = "" +num;
    }
   public void SetGameOver(int maxScore,int curenScore)
    {
        gameOver.SetActive(true);       
        gameOverText.text= "本局净化了"+curenScore+"个灵魂" + "\n 最高净化" + maxScore + "个";    
    }
}
