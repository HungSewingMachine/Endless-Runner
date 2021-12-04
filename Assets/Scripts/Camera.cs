using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float m_DampTime = 0.2f;
    public Transform[] m_Targets;

    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;


    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        FindAveragePosition();
        // di thep nguoi choi
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            averagePos += m_Targets[i].position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        // giu nguyen do cao camera
        averagePos.y = transform.position.y;

        m_DesiredPosition = averagePos - new Vector3(0,0,5);
    }

}
