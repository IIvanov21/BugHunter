using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenarator : MonoBehaviour
{
    //Inspired by ------> https://www.youtube.com/watch?v=hk6cUanSfXQ&ab_channel=Blackthornprod
    private GameObject[] startingPositions;
    [SerializeField] public GameObject[] RoomTemplates ;
    [Header("X axis variance between centers of rooms touching each other(get absolute value)")]
    [Space(10)]
    [Header("!!!!!  Area of the rooms must be the same  !!!!!")]
    [SerializeField] public  float moveAmountX=38.5f;
    [Header("Y axis variance between centers of rooms touching each other(get absolute value)")]
    [SerializeField] public  float moveAmountY = 22f;
    [SerializeField] public Transform GenerateStartingPos;
    [SerializeField] public int LairCount;
    [SerializeField] public int RowCount;
    private float timeBetweenRoom;
    [Header("For seeing process(Not necessary)")]
    [SerializeField] private float startTimeBetweenRoomsSpawn;
    [Header("The layer of the rooms")]
    [SerializeField] public LayerMask room;
    private int downcounter=0;
    [HideInInspector]public bool stopGeneration;
    private int direction;
    [HideInInspector] public float minXpositionRoomCenter;
    [HideInInspector] public float maxXpositionRoomCenter;
    [HideInInspector] public float minYpositionRoomCenter;
    [HideInInspector] public bool IsRowCreationStopped;
    [Header("Parent of everthing")]
    public GameObject DunegonParent;
    private void Awake()
    {
      RowCount--;//for display row count as a normal 


      //Calculating  map limits according to generate starting position and lair,row count
      minXpositionRoomCenter = GenerateStartingPos.position.x;
      maxXpositionRoomCenter = GenerateStartingPos.position.x + RowCount * moveAmountX;
      minYpositionRoomCenter = GenerateStartingPos.position.y - LairCount * moveAmountY;
    }
    private void Update()
    {
        

        if (IsRowCreationStopped==true)//Row creation must has stopped
        {
            startingPositions = GameObject.FindGameObjectsWithTag("GenerateStartingPos");//Assing room spawnpoints to list
            int randomStartingPos = Random.Range(0, startingPositions.Length);
            gameObject.transform.position = startingPositions[randomStartingPos].transform.position;//Pick random int for pick starting position from list
           GameObject ins= Instantiate(RoomTemplates[0], gameObject.transform.position, Quaternion.identity);//Spawn room
            ins.transform.parent = DunegonParent.transform;
            direction = Random.Range(1, 6);//Pick random direction for room moving direction
            IsRowCreationStopped = false;
        }
        if (timeBetweenRoom <= 0 && stopGeneration==false)//check for Is generate stopped
        {
            Move();//call function
            timeBetweenRoom = startTimeBetweenRoomsSpawn;

        }
        else
        {
            timeBetweenRoom -= Time.deltaTime;  
        }
    }
    private void Move()
    {
        /*
         * direction=1 && direction=2 ----> move gameObject right with adding moveAmountX 
         * 
         * 
         * direction=2 && direction=3 ----> move gameObject left with adding -moveAmountX 
         * 
         * 
         * direction=5 ----> move gameObject down with adding -moveAmountY 
         * 
         */
        if (direction==1|| direction == 2)//move gameObject to right
        {
            
            if (gameObject.transform.position.x < maxXpositionRoomCenter  -0.1f)//limiting room spawns on max x axis 
            {
                downcounter = 0;// counter for room moving direction down
                Vector2 newPos = new Vector2(gameObject.transform.position.x + moveAmountX, gameObject.transform.position.y);//move gamobject right with adding moveAmonutX
                gameObject.transform.position = newPos;
                int randRoomType = Random.Range(0, RoomTemplates.Length);//pick random room from template
                GameObject ins= Instantiate(RoomTemplates[randRoomType], transform.position, Quaternion.identity);//spawn room
                ins.transform.parent = DunegonParent.transform;

                direction = Random.Range(1, 6);//find new direction after spawning room
                if (direction == 3)// direction 3 = go left if direction value comes out as a 3 gameObject will move left and  spawn room. Then rooms will go  on top of each other we must avoid this situation

                {
                    direction = 2;
                }
                else if(direction==4) //direction 4 = go left. if direction value comes out as a 4 gameObject will move left and  spawn room. Then rooms will go on top of each other we must avoid this situation
                {
                    direction = 5;//move gameobject down
                }
            }
            else
            {
                direction = 5;//move gameobject down
            }
            
        }
        else if (direction == 3 || direction == 4)//move gameObject to left
        {
            
            if (gameObject.transform.position.x > minXpositionRoomCenter + 0.1f)//limiting room spawns on min x axis 
            {
                downcounter = 0;
                Vector2 newPos = new Vector2(gameObject.transform.position.x - moveAmountX, gameObject.transform.position.y);//move gamobject right with adding move -moveAmountX
                gameObject.transform.position = newPos;
                int randRoomType = Random.Range(0, RoomTemplates.Length);//pick random room from template
               GameObject ins= Instantiate(RoomTemplates[randRoomType], transform.position, Quaternion.identity);//spawn room
                ins.transform.parent = DunegonParent.transform;
                direction = Random.Range(3, 6);// find new direction after spawning room  avoiding rooms comes to on top each other picking form Random.Range(3,6)
            }
            else
            {
                direction = 5;//move gameobject down
            }
          
        }
       else if (direction == 5)//move gameobject down
        {
            downcounter++;//adding down counter when gameObject moves to down 
            if (gameObject.transform.position.y > minYpositionRoomCenter+moveAmountY + 0.1f)//limiting room spawns on min y axis
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position,1, room);//draw circle to detect rooms
                if (roomDetection != null)
                {
                    if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
                    {
                        if (downcounter >= 2)//did  the gameObject came to last block on y axis
                        {
                            roomDetection.GetComponent<RoomType>().RoomDestruction();//destroy current room
                          GameObject ins=  Instantiate(RoomTemplates[2], transform.position, Quaternion.identity);//spawn LRBT room
                            ins.transform.parent =DunegonParent.transform;

                        }
                        else
                        {
                            roomDetection.GetComponent<RoomType>().RoomDestruction();//destroy current room
                            int randBottomRoom = Random.Range(1, 4);//pick random room template
                            if (randBottomRoom == 3)//If 3 comes out as a value there will be a dead end in map
                            {
                                randBottomRoom = 1;
                            }
                          GameObject ins=  Instantiate(RoomTemplates[randBottomRoom], transform.position, Quaternion.identity);//spawn room
                            ins.transform.parent = DunegonParent.transform;
                        }

                    }
                }
                Vector2 newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - moveAmountY);//move gameObject down 
                gameObject.transform.position = newPos;
                int randRoomType = Random.Range(2, 4);//pick random room index
               GameObject inss = Instantiate(RoomTemplates[randRoomType], transform.position, Quaternion.identity);// spawn random room according to index
                inss.transform.parent = DunegonParent.transform;

                direction = Random.Range(1, 6);//after spawning room find direction

            }
            else
            {
                stopGeneration = true;//stop spawning objects
            }
        }  
    }
}
