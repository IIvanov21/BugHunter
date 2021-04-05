using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesCollision : MonoBehaviour
{
    public Player m_Player;
    public Transform m_PointToReturn;
    private const int m_Damage = 5;
    private const float m_Radius = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //m_Player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_Player.SendMessage("TakeDamage", m_Damage);
            m_Player.transform.position = m_PointToReturn.position;
        }
    }
}
