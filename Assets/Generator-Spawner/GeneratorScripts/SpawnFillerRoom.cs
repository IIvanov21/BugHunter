using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFillerRoom : MonoBehaviour
{

    //For spawn filler rooms
    private LevelGenarator levelgen;  
    private void Start()
    {
        levelgen = GameObject.Find("RoomGenerator").GetComponent<LevelGenarator>();//Find level generator gameobject
    }
    void Update()
    {
       
        
            Collider2D roomDetetcion = Physics2D.OverlapCircle(transform.position, 1, levelgen.room);//Draw circle for detect room with layer mask
            if (roomDetetcion == null && levelgen.stopGeneration == true)//There is must not room and room generation must has stop
            {
                int random = Random.Range(0, levelgen.RoomTemplates.Length);//pick random room from room template
                GameObject ins= Instantiate(levelgen.RoomTemplates[random], transform.position, Quaternion.identity);//spawn room
                ins.transform.parent = levelgen.DunegonParent.transform;
            Destroy(gameObject);// Destroy gameobject for increase performance and avoiding mess after spawned room
            }
        
        if (levelgen.stopGeneration == true)
        {
            Destroy(gameObject);// Destroy gameobject for increase performance and avoiding mess If generation has stopped
        }
    }
}
