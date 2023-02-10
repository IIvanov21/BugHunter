using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip m_PlayerDeath, m_PlayerAttack, m_EnemyDeath, m_EnemyShot;
    static AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_PlayerDeath = Resources.Load<AudioClip>("playerDeath");
        m_PlayerAttack = Resources.Load<AudioClip>("swordAttack");
        m_EnemyDeath = Resources.Load<AudioClip>("enemyDeath");
        m_EnemyShot = Resources.Load<AudioClip>("pewShot");


        m_AudioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "playerDeath":
                m_AudioSource.PlayOneShot(m_PlayerDeath);
                break;
            case "swordAttack":
                m_AudioSource.PlayOneShot(m_PlayerAttack);
                break;
            case "enemyDeath":
                m_AudioSource.PlayOneShot(m_EnemyDeath);
                break;
            case "pewShot":
                m_AudioSource.PlayOneShot(m_EnemyShot);
                break;
        }
    }
}
