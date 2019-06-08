using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num : MonoBehaviour
{
    Player player;
    GeatBear getBear;
    public Transform Boss;
    public Transform point;
    bool isBoss = true;
    Room room;
    public GameObject BossHp;
    public GameObject Soul;
    // Use this for initialization
    void Start()
    {          
        room = FindObjectOfType<Room>();
        player = GameObject.FindObjectOfType<Player>();
        getBear = FindObjectOfType<GeatBear>();

    }

    // Update is called once per frame
    void Update()
    {      
        if (player.score >= 20)
        {
            getBear.isBear = false;
            if (isBoss == true)
            {
                Instantiate(Boss, point.position, Quaternion.identity);
                room.isOn = true;
                isBoss = false;
                BossHp.gameObject.SetActive(true);
                Soul.gameObject.SetActive(false);
            }          
        }
    }
}
