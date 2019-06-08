using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterBear : MonoBehaviour {

    public GameObject effectPrefab;   
    public int damage = 1;
    // Use this for initialization
    void Start () {
        Destroy(gameObject, 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bear")||!other.CompareTag("BearBoss"))
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
