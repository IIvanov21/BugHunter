using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaWidth : MonoBehaviour
{
    private LevelGenarator LevelGen;
    public GameObject GenerateStartingPositionsPrefab;
    [HideInInspector] public static bool WidthCreation=false;
    private void Awake()
    {
        gameObject.transform.position = GameObject.Find("GenereateStartingPosition").transform.position;
        LevelGen = GameObject.Find("RoomGenerator").GetComponent<LevelGenarator>();
        
        Instantiate(GenerateStartingPositionsPrefab, new Vector2(gameObject.transform.position.x + LevelGen.RowCount * LevelGen.moveAmountX, gameObject.transform.position.y), Quaternion.identity);//spawning positions for spawn room this positions

        for (int i = 0; i <LevelGen.RowCount - 1; i++)//apply to all rows
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + LevelGen.moveAmountX, gameObject.transform.position.y);
            Instantiate(GenerateStartingPositionsPrefab, gameObject.transform.position, Quaternion.identity);// spawn prefab
            if (i <LevelGen.RowCount - 1)
            {
                WidthCreation = true;
                LevelGen.IsRowCreationStopped = WidthCreation;//Generate positioning complete
            }   
        }
    }
}
