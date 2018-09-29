using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IHitListener
{
	[SerializeField]
	private EnemyStats m_stats;
	[SerializeField]
	private NavMeshAgent m_agent;
	[SerializeField]
	private GameObject m_mesh;
	[SerializeField]
	private Detector m_playerDetection;

	private float m_currentHealth;

	public NavMeshAgent Agent { get { return m_agent; } }
	public float PatrolRadius { get { return m_stats.PatrolRadius; } }
	public LootTable LootTable { get { return m_stats.LootTable; } }

	private float Health
	{
		get { return m_currentHealth; }
		set
		{
			var oldHealth = m_currentHealth;
			m_currentHealth = value;
			if (oldHealth > 0 && m_currentHealth <= 0)
			{
				Die();
			}
		}
	}

	private void Awake()
	{
		m_currentHealth = m_stats.BaseHealth;
	}

	private void Die()
	{
		Destroy(gameObject);
		EventManager.TriggerEvent(EnemyEventType.Died, this);
	}

	public void OnHit(float damage)
	{
		Health -= damage;
	}

	public GameObject DetectedObject()
	{
		return m_playerDetection.Detection;
	}

	public void SetChaseSpeed()
	{
		m_agent.speed = m_stats.ChaseSpeed;
	}

	public void SetMovementSpeed()
	{
		m_agent.speed = m_stats.MovementSpeed;
	}
}