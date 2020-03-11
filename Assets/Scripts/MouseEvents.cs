using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvents : MonoBehaviour
{
    private Rotate rotate;

    private void Start()
    {
        rotate = GameObject.Find("GameController").GetComponent<Rotate>();
    }

    private void OnMouseDown()
    {
        rotate.isTwist = true;
    }

    private void OnMouseUp()
    {
        rotate.isTwist = false;
    }
}
