using System.Collections.Generic;
using UnityEngine;

public class LayerGenerator : MonoBehaviour
{
    public float yStart = 2f;
    public float yEnd = 2.2f;
    public List<GameObject> layers = new List<GameObject>();

    private GameObject parent;
    private GameObject tower;
    private List<GameObject> buildLayers = new List<GameObject>();
    private List<Vector3> cubeTransforms = new List<Vector3>();

    void Start()
    {
        cubeTransforms.Add(new Vector3(0, 0, 0));
        parent = GameObject.Find("3D");
        tower = GameObject.Find("Tower");
        GameObject gc = GameObject.Find("GameController");

        //tower.transform.parent = parent.transform;
        Generate();
        ChangeParent();
        //tower.transform.position = cubeTransforms[cubeTransforms.Count - 2];
        PipeDirectionController pip = tower.GetComponent<PipeDirectionController>();
        pip.Position = cubeTransforms[cubeTransforms.Count - 2];

        BoxCollider bc = buildLayers[1].AddComponent<BoxCollider>();
        bc.isTrigger = true;
        gc.GetComponent<RandomSpawn>().yBegin = bc.bounds.max.y;
        gc.GetComponent<RandomSpawn>().yEnd = bc.bounds.max.y + 0.2f;
    }

    private void ChangeParent()
    {
        for (int i = 0; i < buildLayers.Count - 1; i++)
        {
            buildLayers[i].transform.parent = parent.transform;
            buildLayers[i].transform.localScale = new Vector3(1, buildLayers[i].transform.localScale.y, 1);
        }
        buildLayers[buildLayers.Count - 1].transform.position = cubeTransforms[cubeTransforms.Count - 2];
        buildLayers[buildLayers.Count - 1].transform.position += new Vector3(0, 0.01f, 0);
    }

    private void Generate()
    {
        for (int i = 0; i < layers.Count; i++)
        {
            GameObject g = Instantiate(layers[i], cubeTransforms[i], Quaternion.identity);
            Vector3 scale = g.transform.localScale;
            scale = new Vector3(scale.x, Random.Range(yStart, yEnd), scale.z);
            g.transform.localScale = scale;
            Bounds bounds = g.GetComponent<BoxCollider>().bounds;
            bounds.size = scale;
            float pivot = (bounds.max.y - bounds.min.y) / 2.0f;
            Vector3 pos = g.transform.position;
            pos = new Vector3(pos.x, pos.y + pivot, pos.z);
            g.transform.position = pos;
            cubeTransforms.Add(new Vector3(pos.x, bounds.max.y + pivot, pos.z));
            Destroy(g.GetComponent<BoxCollider>());
            buildLayers.Add(g);
        }
    }
}
