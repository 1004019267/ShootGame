using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butt : MonoBehaviour
{
    public GameObject effectPrefab;//爆炸特效
    public int damage = 10;
    public float bombRange = 3;
    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {      
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Bear"))
        {
            GetComponent<Bear>().Hurt(damage);
        }
        if (CompareTag("BearBoss"))
        {
            GetComponent<BearMove>().Hurt(damage);
        }
            //球形检测：以transform的位置为圆心，半径range内的所有碰撞器
            Collider[] cols = Physics.OverlapSphere(transform.position, bombRange);
            foreach (var item in cols)
            {
                if (item.CompareTag("Bear"))
                {
                    item.GetComponent<Bear>().Hurt(damage);
                }
            if (item.CompareTag("BearBoss"))
            {
                item.GetComponent<BearMove>().Hurt(damage);
            }
            }
            //播放爆炸特效
        var effect = Instantiate(effectPrefab, transform.position, transform.rotation);
        //var effect = Instantiate(effectPrefab,transform.position,Quaternion.identity);
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
        }
       
    
}
