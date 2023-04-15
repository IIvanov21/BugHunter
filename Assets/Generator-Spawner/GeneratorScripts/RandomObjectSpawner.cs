using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    [SerializeField] public GameObject SpawnLocationParent;
    [SerializeField] public List<Transform> SpawnLocations;
    [SerializeField] public GameObject PrefabWhichWillSpawn;
    private int CurrentObjectCount;
    [SerializeField] public int GoalObjectCount;
    private bool IsObjectHits=false;
    int rand;
    void Start()
    {


        for (int i = 0; i < SpawnLocationParent.transform.childCount; i++)//Add every child to list
        {
            SpawnLocations.Add(SpawnLocationParent.transform.GetChild(i));//Add every child to list
        }
        StartCoroutine(delay());
    }
    void Update()
    {
        bool MultipleObjectHit = false;
        Collider2D[] collisionArray = Physics2D.OverlapCircleAll(gameObject.transform.position, 1f);//Add list every object in overlap circle
        foreach (Collider2D collision in collisionArray)//With foreach peel target object from list
        {
            if (collision != null && collision.gameObject.transform.parent != null && PrefabWhichWillSpawn != null)
            {
                if (collision.gameObject.transform.parent.name == PrefabWhichWillSpawn.name+"(Clone)")//Every spawned object are child of parent beacuse of this we need to avoiding mess
                {                                                                                   // We are adding "(Clone)" to name  beacuse all objects spawned from prefabs
                    MultipleObjectHit = true;
                    IsObjectHits = true;
                }
                else if (MultipleObjectHit != true)
                {
                    IsObjectHits = false;
                }


            }



        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, 1f);//Draw gizmos circle 
    }


    IEnumerator delay()
    {
        
        while (GoalObjectCount > CurrentObjectCount)
        {

            rand = Random.Range(0, SpawnLocations.Count);//pick random spawn position
            gameObject.transform.position = SpawnLocations[rand].GetComponentInParent<Transform>().position;// make gameObject position
            IsObjectHits = false;//make false for spawn object
            yield return new WaitForEndOfFrame();//wait for update method check for there is an object or not
            if (IsObjectHits == false)
            {
                GameObject ins = Instantiate(PrefabWhichWillSpawn, gameObject.transform.position, Quaternion.identity);
                ins.transform.parent = gameObject.transform.parent;//Make child for avoiding mess
                CurrentObjectCount++;//Add one beacuse object has spawned
                IsObjectHits = true;//Beacuse of spawned object current gameObject position has object 
            }
        }
    }
}