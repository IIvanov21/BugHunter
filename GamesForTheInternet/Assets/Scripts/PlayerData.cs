using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int m_Level;
    public int m_Health;
    public float[] m_Position;
    public PlayerData(Player player)
    {
        //m_Level = player.Level ;
        m_Health = player.m_CurrentHealth;
        m_Position = new float[3];
        m_Position[0] = player.transform.position.x;
        m_Position[1] = player.transform.position.y;
        m_Position[2] = player.transform.position.z;

    }
}
