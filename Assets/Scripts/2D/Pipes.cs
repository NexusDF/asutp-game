using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    //public Camera cam;
    
    [SerializeField]
    private GameObject _pipe = null;
    private GameObject _tower;
    private PipeDirectionController _controller;

    private List<GameObject> _pipes = new List<GameObject>();

    private void Start()
    {
        _tower = GameObject.Find("Tower");
        _controller = _tower.GetComponent<PipeDirectionController>();
    }

    public void CreatePipe(Vector3 direction, Quaternion quaternion)
    {
        if (_pipe != null)
        {
            GameObject p = Instantiate(_pipe, direction, quaternion);
            p.transform.parent = _tower.transform;
            _pipes.Add(p);

            /*if (!_controller.IsEnterPlast)
            {
                cam.transform.position = new Vector3(cam.transform.position.x, p.transform.position.y + 2.6f, cam.transform.position.z);
            }*/
            
        }
             
    }

    public List<GameObject> GetPipes()
    {
        return _pipes;
    }

}
