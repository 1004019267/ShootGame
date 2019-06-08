using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastButter : MonoBehaviour
{
    Transform target;
    public float speed = 5;
    public Transform effectPrefab;
    int damage = 2;
    public
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bear")||!other.CompareTag("BearMove"))
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().Hurt(damage);
            }
        }
        if (!other.CompareTag("BearFire"))
        {
            var go = Instantiate(effectPrefab, transform.position, transform.rotation);
            Destroy(go, 1.5f);
            Destroy(this.gameObject);
        }


    }
}
