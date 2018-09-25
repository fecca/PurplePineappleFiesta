using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent m_agent;
	[SerializeField]
	private GameObject m_mesh;
	[SerializeField]
	private LootTable m_lootTable;
	[SerializeField]
	private float m_patrolRadius;
	[SerializeField]
	private float m_health;

	private float m_idleTimer;
	private float m_idleTime = 2.0f;

	private EnemyState m_state = EnemyState.Idle;

	private void Update()
	{
		switch (m_state)
		{
			case EnemyState.Idle:
				m_idleTimer += Time.deltaTime;
				if (m_idleTimer >= m_idleTime)
				{
					m_idleTimer = 0f;
					m_state = EnemyState.Moving;
					MoveToRandomPositionOnNavMesh();
				}
				break;

			case EnemyState.Moving:
				if (!m_agent.pathPending)
				{
					if (m_agent.remainingDistance <= m_agent.stoppingDistance)
					{
						if (!m_agent.hasPath || m_agent.velocity.sqrMagnitude == 0f)
						{
							m_state = EnemyState.Idle;
						}
					}
				}
				break;

			case EnemyState.Dying:
				Destroy(m_agent);
				Destroy(m_mesh);
				Destroy(gameObject);

				EventManager.TriggerEvent(EnemyEventType.Died, this);
				break;

			default:
				break;
		}
	}

	private void MoveToRandomPositionOnNavMesh()
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
	}

	public void OnHit(float damage)
	{
		if (m_health <= 0)
		{
			Debug.Log("Already dead");
			return;
		}

		m_health -= damage;
		Debug.Log("Taking " + damage + " damage - " + m_health + " left");
		if (m_health <= 0)
		{
			Debug.Log("Dying");
			m_state = EnemyState.Dying;
		}
	}

	public LootTable GetLootTable()
	{
		return m_lootTable;
	}
}