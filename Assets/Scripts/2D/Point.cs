using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool IsTrigger { get; set; } = false;
    public Material active;

    private Tower tower;
    private MeshRenderer meshRenderer;

    void Start()
    {
        tower = GameObject.Find("Tower").GetComponent<Tower>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pipe")
        {
            IsTrigger = true;
            meshRenderer.material = active;
            if (tower != null && Time.timeScale != 0)
            {
                tower.AddScore(100);
            }
        }
    }
}
