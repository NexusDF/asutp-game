using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    protected PipeDirectionController _pipeController;
    protected virtual void Start()
    {
        _pipeController = GameObject.Find("Tower").GetComponent<PipeDirectionController>();

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {    
            _pipeController.IsEnterPlast = true;
        }
        
    }

    protected void SetSens(float sens)
    {
        if (_pipeController != null)
        {
            _pipeController.sensitivity = sens;
        }
    }
}
