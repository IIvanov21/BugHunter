using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointsSystem : MonoBehaviour
{
    private const int m_Points = 10;
    public GameObject objectIn;
    public Transform m_PlayerPosition;
    private float m_Radius=0.5f;
     public void Update()
    {
        if (Vector2.Distance(transform.position, m_PlayerPosition.position) < m_Radius)
        {
            objectIn.GetComponent<GameLevelManager>().IncreaseScore(m_Points);
            Destroy(gameObject);
        }
    }
}
