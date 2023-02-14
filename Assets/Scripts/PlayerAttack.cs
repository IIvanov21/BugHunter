using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private float m_TimeBetweenAttack;
    public float m_AttackCoolDown;
    public int m_PlayerDamage;
    public Transform m_AttakcPosition;
    public float m_AttackRange;
    public LayerMask m_WhatIsEnemy;
    // Update is called once per frame
    void Update()
    {
        if (m_TimeBetweenAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                SoundManager.PlaySound("swordAttack");
                Collider2D[] DamageEnemy = Physics2D.OverlapCircleAll(m_AttakcPosition.position, m_AttackRange, m_WhatIsEnemy);
                for (int i=0;i<DamageEnemy.Length;i++)
                {
                    if (DamageEnemy[i].tag == "Enemy") DamageEnemy[i].GetComponent<Enemy>().ReduceHealth(m_PlayerDamage);
                    if(DamageEnemy[i].tag=="Box")DamageEnemy[i].GetComponent<BoxBreak>().DestroyBox();
                    if (DamageEnemy[i].tag == "Boss") DamageEnemy[i].GetComponent<BossHealth>().ReduceHealth(m_PlayerDamage);


                }
                m_TimeBetweenAttack = m_AttackCoolDown;
            }
        }
        else m_TimeBetweenAttack -= Time.deltaTime;
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_AttakcPosition.position, m_AttackRange);
    }
}
