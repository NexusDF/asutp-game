using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitEvent : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Debug.Log("isInside");
    }
}
