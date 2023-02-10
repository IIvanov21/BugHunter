using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed;
    public float DistanceTo=1.0f;
    private Transform m_Player;
    private Vector2 m_Target;
    public int m_ProjectileDamage = 2;
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Target = new Vector2(m_Player.position.x, m_Player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_Target, ProjectileSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, m_Target) < DistanceTo)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_Player.SendMessage("TakeDamage", m_ProjectileDamage);
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
