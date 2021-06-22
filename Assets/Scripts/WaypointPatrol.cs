using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;

    void Start()
    {
        //设置 Nav Mesh Agent 的初始目标
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        //查看到目标的剩余距离是否小于 您先前在Inspector窗口中设置的停止距离
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}