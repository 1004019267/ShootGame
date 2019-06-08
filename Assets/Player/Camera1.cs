using UnityEngine;
using System.Collections;

public class Camera1 : MonoBehaviour {
   
    public GameObject player;
    public float speed;
	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {    
        transform.position = Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, speed * Time.deltaTime);    
    }
}
