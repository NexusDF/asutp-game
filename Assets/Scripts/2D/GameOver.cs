using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject panel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
