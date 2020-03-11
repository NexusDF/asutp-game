using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject whatToTwist;

    public bool isTwist { get; set; }

    void Update()
    {
        if (isTwist)
        {
            whatToTwist.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * 10, Space.World);
            //whatToTwist.transform.Rotate(Vector3.forward, Input.GetAxis("Mouse Y") * 3, Space.World);
        }        
    }
}
