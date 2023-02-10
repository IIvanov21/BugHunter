using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int m_MaxHealth = 100;
    public int m_CurrentHealth;
    public HealthBar m_HealthBar;
    private Transform m_Enemy;
    private bool m_AttackEnemy = false;
    public Transform m_LevelEnd;//End of level checkpoint
    private const float m_DistanceToEnd=0.5f;
    public GameObject m_LevelEndMenu;
    public int m_PlayerChoice;
    public bool m_Shot = true;
    public GameObject m_GameOverMenu;
    void Start()
    {
        //Set collider sizes according to size of character skin
        if (DBManager.m_PlayerChoice == 0) GetComponent<CircleCollider2D>().radius = 0.103f;
        if (DBManager.m_PlayerChoice == 1) GetComponent<CircleCollider2D>().radius = 0.086f;

        m_CurrentHealth = m_MaxHealth;
        m_HealthBar.SetMaxHealth(m_MaxHealth);
        m_Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_AttackEnemy = true;
        }
        else m_AttackEnemy = false;

        if (m_CurrentHealth <= 0)
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
        m_CurrentHealth -= damageIn;
        m_HealthBar.SetHealth(m_CurrentHealth);
        
    }

    public void OnDeath()
    {
        m_GameOverMenu.SetActive(true);
        SoundManager.PlaySound("playerDeath");
        Time.timeScale = 0;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData m_LoadedData = SaveSystem.LoadPlayer();
        m_CurrentHealth = m_LoadedData.m_Health;
        Vector3 playerPosition;
        playerPosition.x = m_LoadedData.m_Position[0];
        playerPosition.y = m_LoadedData.m_Position[1];
        playerPosition.z = m_LoadedData.m_Position[2];
        transform.position = playerPosition;

    }
}
