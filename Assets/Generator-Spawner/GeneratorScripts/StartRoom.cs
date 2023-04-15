using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : MonoBehaviour
{
    private int rand;
    private LevelGenarator LevelGen;
    private bool IsRoomSpawned;
    private int LastRoomBlock;
    private bool SpawnShouldStop = false;
    [SerializeField] public GameObject[] StartRooms_or_EndRooms;
    [SerializeField] public GameObject EmptyRoom;



    void Awake()
    {
        LevelGen = GameObject.Find("RoomGenerator").GetComponent<LevelGenarator>();//Find level generator gameobject
       
    }
    private void Start()
    {
        //For detect which room has assinged
        if (gameObject.name == "StartRoom")
        {
            gameObject.transform.position = new Vector2(LevelGen.GenerateStartingPos.position.x - LevelGen.moveAmountX, LevelGen.GenerateStartingPos.position.y);
        }
        else if (gameObject.name == "EndRoom")
        {
            gameObject.transform.position = new Vector2(LevelGen.GenerateStartingPos.position.x + (LevelGen.RowCount + 1) * LevelGen.moveAmountX,LevelGen.GenerateStartingPos.position.y);

        }

    }
    private void Update()
    { 
       //Calling function once
        if (SpawnShouldStop == false)
        {
            Invoke("SpawnFunction", 0.1f);
            SpawnShouldStop = true;
        }
    }


    void SpawnFunction()
    {
        for (int i = 0; i < LevelGen.LairCount; i++)//For repeat for every lair
        {
            
            rand = Random.Range(0, LevelGen.LairCount);//Pick random spawnpoint according to lair count for start or end room
            if (IsRoomSpawned == false && LastRoomBlock==LevelGen.LairCount-1) //check for is room spawned and does gameobject comes to last block
            {
                int RoomRandomIndex = Random.Range(0, StartRooms_or_EndRooms.Length);// Pick random start or end room from template 
               GameObject ins= Instantiate(StartRooms_or_EndRooms[RoomRandomIndex], new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);//If start or end room didnt spawn until gameObject comes to last block then spawn room
                ins.transform.parent = LevelGen.DunegonParent.transform;

            }
            else if (rand == 0 && IsRoomSpawned == false)//All maps has at least one lair. Pick certain number for spawn room and room must not exist
            {
                int RoomRandomIndex = Random.Range(0, StartRooms_or_EndRooms.Length);// Pick random start or end room from template 
               GameObject ins= Instantiate(StartRooms_or_EndRooms[RoomRandomIndex], new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);//spawn room to gameobjects position
                ins.transform.parent = LevelGen.DunegonParent.transform;
                IsRoomSpawned = true;//room spawned
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - LevelGen.moveAmountY);//Move gamObject one block down
                LastRoomBlock++;//Add one to prove lair length going on
            }
            else if (rand != 0||IsRoomSpawned==true)//If rand value doesnt certain number then spawn empty room or room must exist
            {
                GameObject ins = Instantiate(EmptyRoom, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                ins.transform.parent = LevelGen.DunegonParent.transform;
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - LevelGen.moveAmountY);//spawn empty room then Move gamObject one block down
                LastRoomBlock++;//Add one to prove lair length going on
            }


        }
    }
}
