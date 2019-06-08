using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterBear2 : MonoBehaviour {

    public GameObject effectPrefab;
    static int count;
    public int damage = 10;
    Player player;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bear")&&!other.CompareTag("BearBoss"))
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().Hurt(damage);
            }
        }
        var go = Instantiate(effectPrefab, transform.position, transform.rotation);
        Destroy(go, 1.5f);
        Destroy(this.gameObject);
    }
}
