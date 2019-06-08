using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last : MonoBehaviour {
    public Transform firePoint;
    public GameObject bulletPrefab;
    Transform target;
    BearMove bear;
    GameObject tm;  
    // Use this for initialization
    float t;
	void Start () {
        bear =  GameObject.FindObjectOfType<BearMove>();
        target = GameObject.Find("Player").transform;
        tm = GameObject.Find("Fire (5)");
    }
	
	// Update is called once per frame
	void Update () {         
        if (BearMove.hp<=30)
        {
            tm.GetComponent<TextMesh>().text = "跟踪弹已就位，请击破";
            t += Time.deltaTime;
            if (t>=3)
            {
                var go = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
                t = 0;
            }
        }
        if (BearMove.hp <= 0)
        {
            tm.GetComponent<TextMesh>().text = "还不错通关了";
            Time.timeScale = 0;          
        }
    }
}
