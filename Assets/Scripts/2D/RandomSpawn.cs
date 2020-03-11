using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [Header("Amount objects")]
    public int amount;
    [Header("Randomize X")]
    public float xBegin;
    public float xEnd;
    [Header("Randomize Y")]
    public float yBegin;
    public float yEnd;
    [Header("Randomize Z")]
    public float zBegin;
    public float zEnd;
    [Header("Prefab")]
    public GameObject GameObject;

    private List<GameObject> objects = new List<GameObject>();

    public List<GameObject> Spawn(int breakPoint, float coefficient)
    {
        Vector3 direction;
        float x = Random.Range(xBegin, xEnd);
        float y = Random.Range(yBegin, yEnd);
        float z = Random.Range(zBegin, zEnd);
        float rand = Random.Range(0f, 1.0f);
        if (rand > 0.33f && rand < 0.66f)
        {
            x = -x;
            z = -z;
        }
        else
        {
            if (rand > 0.66f)
            {
                x = -x;
            }
            else
            {
                if (rand < 0.33f)
                {
                    z = -z;
                } 
            }
        }

        for (int i = 0; i < 3; i++)
        {
            
            x += -Mathf.Sign(x) * coefficient;
            z += -Mathf.Sign(z) * coefficient;

            direction = new Vector3(x, y - i * 1.5f, z);

            objects.Add(Instantiate(GameObject, direction, Quaternion.identity));
        }
        return objects;
    }
}
