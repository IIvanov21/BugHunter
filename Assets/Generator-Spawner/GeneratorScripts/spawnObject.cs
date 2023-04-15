using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour,IDestroyTiles
{
    private Grids grid;
    public GameObject[] objects;
    private int rand;
    private GameObject instance;

    void Start()
    {
        rand = Random.Range(0, objects.Length); //pick random prefab form template prefab
        instance=(GameObject) Instantiate(objects[rand], transform.position, Quaternion.identity);
        instance.transform.parent = gameObject.transform;  //make child for avoiding mess
    }

    public void DestroyTiles()//interface
    {
        Destroy(instance);//destroy clone
    }
}
