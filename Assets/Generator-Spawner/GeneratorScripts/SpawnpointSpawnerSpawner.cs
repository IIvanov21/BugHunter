using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointSpawnerSpawner : MonoBehaviour
{
    [SerializeField]public GameObject SpawnpointSpawnerPrefab;
    private void Awake()
    {
        Instantiate(SpawnpointSpawnerPrefab, gameObject.transform.position, Quaternion.identity);//Spawn  room spawnpoint spawner :)
    }
}
