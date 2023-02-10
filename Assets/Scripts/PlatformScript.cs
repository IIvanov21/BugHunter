using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private Vector3 m_PosA;
    private Vector3 m_PosB;
    private Vector3 m_NextPos;
    public float m_Speed;
    [SerializeField]
    private Transform m_Platform;
    [SerializeField]
    private Transform m_PointB;
    private const float m_DistanceTo=0.1f;

    // Start is called before the first frame update
    void Start()
    {
        m_PosA = m_Platform.localPosition;
        m_PosB = m_PointB.localPosition;
        m_NextPos = m_PosB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        m_Platform.localPosition = Vector3.MoveTowards(m_Platform.localPosition, m_NextPos, m_Speed * Time.deltaTime);
        if (Vector3.Distance(m_Platform.localPosition, m_NextPos) <= m_DistanceTo)
        {
            ChangeTarget();
        }
    }

    private void ChangeTarget()
    {
        m_NextPos = m_NextPos != m_PosA? m_PosA:m_PosB;
    }
}
