using UnityEngine;
using System.Collections;

public class HeadLook : MonoBehaviour
{

    // Use this for initialization
    public float speed;
    private Quaternion orgRotation;
    void Start()
    {
        orgRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        //俯仰角限制
        orgRotation *= Quaternion.Euler(-mouseY, 0, 0);
        if (orgRotation.eulerAngles.x<=180&&orgRotation.eulerAngles.x>=45)
        {
            orgRotation = Quaternion.Euler(45, 0, 0);
        }
        else if (orgRotation.eulerAngles.x > 180 && orgRotation.eulerAngles.x<=315)
        {
            orgRotation = Quaternion.Euler(315, 0, 0);
        }
        transform.localRotation = orgRotation;
      
    }
}
