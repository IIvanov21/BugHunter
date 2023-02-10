using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyGraphicsEffects : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath m_AiPath;

    // Update is called once per frame
    void Update()
    {
        if (m_AiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if(m_AiPath.desiredVelocity.x<=-0.01f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }
    }
}
