using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private Tower tower;
    bool isPressed = false;
    private void Start()
    {
        tower = GameObject.Find("Tower").GetComponent<Tower>();
    }

    public void SetPause()
    {
        isPressed = !isPressed;

        if (isPressed)
            Menu.menu.Open(tower.GetScore());
        else
            Menu.menu.Close();

        
        
    }
}
