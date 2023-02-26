using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject player;

    public static GameManager Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private void Awake()
    {
        //Turn into a singleton
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //Get a global player reference
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
}
