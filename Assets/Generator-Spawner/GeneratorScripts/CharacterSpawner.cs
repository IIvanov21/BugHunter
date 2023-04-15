using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GameObject game = GameObject.FindGameObjectWithTag("Playermain");
       game.transform.position =  gameObject.transform.position;//Change character position (not necessary)
       
        
    }

}
