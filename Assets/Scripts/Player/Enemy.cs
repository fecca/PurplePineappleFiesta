using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent m_agent;
	[SerializeField]
	private float m_patrolRadius;

	private StateMachine<Enemy> m_stateMachine;
	private bool m_moving;

	private void Awake()
	{
		m_stateMachine = new StateMachine<Enemy>();
	}

	private void Start()
	{
		m_stateMachine.Initialize(new EnemyTestState(this));
	}

	private void Update()
	{
		m_stateMachine.Update();

		if (m_moving)
		{
			if (!m_agent.pathPending)
			{
				if (m_agent.remainingDistance <= m_agent.stoppingDistance)
				{
					if (!m_agent.hasPath || m_agent.velocity.sqrMagnitude == 0f)
					{
						m_moving = false;
						StartCoroutine(WaitOnSpot());
					}
				}
			}
		}

		if (Input.GetKeyUp(KeyCode.Return))
		{
			m_stateMachine.ChangeState(new EnemyTestState(this));
		}

		if (Input.GetKeyUp(KeyCode.Escape))
		{
			m_stateMachine.ChangeState(new EnemyIdleState(this));
		}
	}

	private IEnumerator WaitOnSpot()
	{
		yield return new WaitForSeconds(2.0f);
		m_stateMachine.ChangeState(new EnemyTestState(this));
	}

	public void MoveToRandomPositionOnNavMesh()
	{
		var randomDirection = Random.insideUnitSphere * m_patrolRadius;
		randomDirection += transform.position;
		NavMeshHit hit;
		var finalPosition = Vector3.zero;
		if (NavMesh.SamplePosition(randomDirection, out hit, m_patrolRadius, 1))
		{
			finalPosition = hit.position;
		}

		m_agent.SetDestination(finalPosition);
		m_moving = true;

		m_stateMachine.ChangeState(new EnemyIdleState(this));
	}
}