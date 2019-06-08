using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public GameObject effectPrefab;
    static int count;
    public int damage = 2;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            if (other.CompareTag("Bear"))
            {
                other.GetComponent<Bear>().Hurt(damage);
            }
            if (other.CompareTag("BearBoss"))
            {
                other.GetComponent<BearMove>().Hurt(damage);
            }
        }
        var go = Instantiate(effectPrefab, transform.position, transform.rotation);
        Destroy(go, 1.5f);
        Destroy(this.gameObject);
    }
}
