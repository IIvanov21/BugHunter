using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int m_Health;
    public HealthBar m_HealthBar;
    private Transform m_Enemy;
    public Transform m_LevelEnd;//End of level checkpoint
    private const float m_DistanceToEnd = 0.5f;
    public GameObject m_LevelEndMenu;
    public int m_PlayerChoice;
    public bool m_Shot = true;
    public GameObject m_GameOverMenu;
    void Start()
    {
        //Set collider sizes according to size of character skin
        //if (DBManager.m_PlayerChoice == 0) GetComponent<CircleCollider2D>().radius = 0.103f;
        //if (DBManager.m_PlayerChoice == 1) GetComponent<CircleCollider2D>().radius = 0.086f;

       // m_HealthBar.SetMaxHealth(m_Health);
        //m_Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {


        if (m_Health <= 0)
        {
            OnDeath();
        }

        if (Vector2.Distance(transform.position, m_LevelEnd.position) < m_DistanceToEnd)
        {
            m_LevelEndMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void TakeDamage(int damageIn)
    {
        m_Health -= damageIn;
        m_HealthBar.SetHealth(m_Health);

    }

    public void OnDeath()
    {
        m_GameOverMenu.SetActive(true);
        SoundManager.PlaySound("playerDeath");
        Time.timeScale = 0;
    }

    /*public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }*/

    /*public void LoadPlayer()
    {
        PlayerData m_LoadedData = SaveSystem.LoadPlayer();
        m_Health = m_LoadedData.m_Health;
        Vector3 playerPosition;
        playerPosition.x = m_LoadedData.m_Position[0];
        playerPosition.y = m_LoadedData.m_Position[1];
        playerPosition.z = m_LoadedData.m_Position[2];
        transform.position = playerPosition;

    }*/

    
}
