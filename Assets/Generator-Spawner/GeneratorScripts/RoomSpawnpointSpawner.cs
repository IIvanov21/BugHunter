using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnpointSpawner : MonoBehaviour
{
    private LevelGenarator LevelGen;
    public GameObject SpawnpointPrefab;
    
    void Start()
    {
        LevelGen = GameObject.Find("RoomGenerator").GetComponent<LevelGenarator>();//FÝnd component
        for (int i = 0; i < LevelGen.LairCount-1; i++)// for applying all lairs
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - LevelGen.moveAmountY);//move gameObject down
            Instantiate(SpawnpointPrefab,gameObject.transform.position,Quaternion.identity);//spawn prefab   
        }

    }
    private void Update()
    {
        if (LevelGen.stopGeneration == true)
        {
            Destroy(gameObject);// destroy gameObject when generation stopped for increase performance
        }
    }
}

