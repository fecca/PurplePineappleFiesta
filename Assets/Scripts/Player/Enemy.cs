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
	[SerializeField]
	private Detector m_playerDetection;

	public NavMeshAgent Agent { get { return m_agent; } }

	private bool m_hasDetectedPlayer;

	private void OnTriggerEnter(Collider other)
	{
		m_hasDetectedPlayer = true;
	}

	private void OnTriggerExit(Collider other)
	{
		m_hasDetectedPlayer = true;
	}

	public void OnHit(float damage)
	{
		if (m_health <= 0)
		{
			return;
		}

		m_health -= damage;
		if (m_health <= 0)
		{
			Destroy(gameObject);

			EventManager.TriggerEvent(EnemyEventType.Died, this);
		}
	}

	public LootTable GetLootTable()
	{
		return m_lootTable;
	}

	public GameObject Detection()
	{
		return m_playerDetection.Detection;
	}

	public void ChasePlayer()
	{

	}
}