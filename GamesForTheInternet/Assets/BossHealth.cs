using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private int m_BossHealth;
    public int m_SetBossHealth;
    public bool m_HasBasicAttack = false;
    public bool m_FacingRight = false;
    private float m_CoolDownAttack = 0.0f;//Cooldown between attacks
    public float m_CoolDownTimer;//Set cooldown
    public Transform PlayerObject;
    public Player PlayerIn;
    public LayerMask m_WhatIsPlayer;
    public Transform m_AttakcPosition;
    public float m_AttackRange;
    public int m_EnemyDamage = 5;
    public GameObject m_PassScore;
    public const int m_EnemyScore = 5;
    public void Start()
    {
        m_BossHealth = m_SetBossHealth;
    }
    private void Update()
    {
        AttackPlayer();
    }
    public void ReduceHealth(int damageTaken)
    {
        m_BossHealth -= damageTaken;
        if (m_BossHealth <= 0)
        {
            Destroy(gameObject);
            m_PassScore.GetComponent<GameLevelManager>().IncreaseScore(m_EnemyScore);

        }
    }
    public void AttackPlayer()
    {
        m_CoolDownAttack -= Time.deltaTime;
        if (m_CoolDownAttack <= 0)
        {
            Collider2D DamagePlayer = Physics2D.OverlapCircle(m_AttakcPosition.position, m_AttackRange, m_WhatIsPlayer);
            if (DamagePlayer) PlayerIn.TakeDamage(m_EnemyDamage);
            m_CoolDownAttack = m_CoolDownTimer;
            if (!m_FacingRight && transform.position.x < PlayerObject.position.x) Flip();
            else if (m_FacingRight && transform.position.x > PlayerObject.position.x) Flip();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_AttakcPosition.position, m_AttackRange);
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the enemies's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
