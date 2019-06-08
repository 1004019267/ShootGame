using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSkill : MonoBehaviour
{

    // Use this for initialization
    public Transform Skill;
    float t;
    bool isNum=true;
  public  bool isHave = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isHave == true)
        {


            t += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.F) && isNum == true)
            {
                t = 0;
                Skill.gameObject.SetActive(true);
                isNum = false;
            }
            if (t >= 3)
            {
                Skill.gameObject.SetActive(false);
            }
            if (t >= 10)
            {
                t = 0;
                isNum = true;
            }
        }      
    }
   
}
