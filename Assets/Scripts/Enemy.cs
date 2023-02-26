using UnityEngine.Events;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform m_LeftCheck; // A position marking left patrol end point.
    [SerializeField] private Transform  m_RightCheck;//A position marking right patrol end point.
    [SerializeField] private float m_PositionRadius=0.3f;//Distance to point before changing movement direction
    private Rigidbody2D m_Rigidbody2D;
    private float m_EnemySpeed=1.0f;
    private const int m_EnemyScore = 5;
    public GameObject m_PassScore;
    public float m_SetEnemySpeed = 1.0f;
    public int m_EnemyHealth;
    public int m_EnemyDamage=5;
    private bool m_PlayerInRange = false;//Follow the player
    public float stoppingDistance = 10.0f;//Distance to the player to follow
    public float shootingDistance = 8.0f;//Distance to the player before shooting
    public float ShotToPlayer = 0.5f;//Distance to the player before shooting
    private float m_CoolDownAttack=0.0f;//Cooldown between attacks
    public float m_CoolDownTimer;//Set cooldown
    private bool m_FacingRight = true ;//Determine facing position 
    public bool m_HasRangeAttack = false;//Allows only certain enemies to make projectiles
    public bool m_HasBasicAttack = false;
    public float m_KnockBackDistance;
    public Transform m_AttakcPosition;
    public float m_AttackRange;
    //Shooting/Attacking the player
    private float m_ShotDelay;
    public float m_DelayTime;
    private const float m_MaxDelayTime = 5.0f;//Demonstate randomisation
    private bool m_BackToPosition = false;
    private float m_DazedTime;
    public float m_DazedTimer;
    private float m_AwayFromPatrol;
    private const float m_AwayTime = 5.0f;
    public GameObject projecTile;
    public LayerMask m_WhatIsPlayer;


    void Start()
    {
        m_ShotDelay = m_DelayTime;
        m_AwayFromPatrol = m_AwayTime;
    }
    // Update is called once per frame
    private void Awake()
    {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Attack();

        Chase();

        Shoot();

        Patrol();
        
        
    }

    void Attack()
    {
        if (m_CoolDownAttack <= 0 && m_HasBasicAttack)
        {
            Collider2D DamagePlayer = Physics2D.OverlapCircle(m_AttakcPosition.position, m_AttackRange, m_WhatIsPlayer);
            if (DamagePlayer) GameManager.Instance.player.GetComponent<Player>().TakeDamage(m_EnemyDamage);
            m_CoolDownAttack = m_CoolDownTimer;
        }
        else m_CoolDownAttack -= Time.deltaTime;//Restart attack
    }

    void Chase()
    {
        
        if (m_DazedTime <= 0)//Restart enemy movement
        {
            m_EnemySpeed = m_SetEnemySpeed;
        }
        else
        {//When enemy is dazed prevent him from moving
            m_EnemySpeed = 0;
            m_DazedTime -= Time.deltaTime;
        }
        //True for right //False for left
        if (Vector2.Distance(transform.position, GameManager.Instance.player.transform.position) < stoppingDistance)
        {
            //Move enemy towards player
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.player.transform.position, m_EnemySpeed * Time.deltaTime);
            m_PlayerInRange = true;
            if (!m_FacingRight && transform.position.x < GameManager.Instance.player.transform.position.x) Flip();
            else if (m_FacingRight && transform.position.x > GameManager.Instance.player.transform.position.x) Flip();
            m_AwayFromPatrol = m_AwayTime;
            m_BackToPosition = true;

        }
        else if (Vector2.Distance(transform.position, GameManager.Instance.player.transform.position) > stoppingDistance)
        {
            m_PlayerInRange = false;
            m_AwayFromPatrol -= Time.deltaTime;
            if (m_AwayFromPatrol <= 0 && m_BackToPosition)
            {
                transform.position = m_RightCheck.position;
                m_BackToPosition = false;
            }

        }
    }

    void Patrol()
    {
        if (!m_PlayerInRange)
        {
            if (m_FacingRight)
            {//Move enemy towards right checkpoint
                transform.position = Vector2.MoveTowards(transform.position, m_RightCheck.position, m_EnemySpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, m_RightCheck.position) < m_PositionRadius)
                {
                    Flip();
                }
            }

            if (!m_FacingRight)
            {//Move enemy towards left checkpoint
                transform.position = Vector2.MoveTowards(transform.position, m_LeftCheck.position, m_EnemySpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, m_LeftCheck.position) < m_PositionRadius)
                {
                    Flip();
                }
            }
        }
    }


    void Shoot()
    {
        if (m_HasRangeAttack && m_DazedTime <= 0)
        {
            if (m_ShotDelay <= 0 && Vector2.Distance(transform.position, GameManager.Instance.player.transform.position) < shootingDistance)
            {
                //Perform enemy attack here
                Instantiate(projecTile, transform.position, Quaternion.identity);
                SoundManager.PlaySound("pewShot");
                m_ShotDelay = Random.Range(m_DelayTime, m_MaxDelayTime);
            }
            else m_ShotDelay -= Time.deltaTime;
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

    public void ReduceHealth(int damageIn)
    {
        m_EnemyHealth -= damageIn;
        m_DazedTime = m_DazedTimer;
        Vector3 knockBackDirection = GameManager.Instance.player.transform.position + transform.position;
        if (GameManager.Instance.player.transform.position.x < transform.position.x) knockBackDirection = -knockBackDirection;
        m_Rigidbody2D.AddForce(knockBackDirection*m_KnockBackDistance);

        if (m_EnemyHealth <= 0)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        SoundManager.PlaySound("enemyDeath");
        m_PassScore.GetComponent<GameLevelManager>().IncreaseScore(m_EnemyScore);
        Destroy(gameObject);
    }
}

