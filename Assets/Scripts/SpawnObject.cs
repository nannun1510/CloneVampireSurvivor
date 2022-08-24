using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    [SerializeField][Range(0f, 1f)] float probability;

    public void Spawn()
    {
        float x = Random.value;
        if (x < probability)
        {
            //Debug.Log(x);
            GameObject go = Instantiate(toSpawn, transform.position, Quaternion.identity);
        }
    }
}
