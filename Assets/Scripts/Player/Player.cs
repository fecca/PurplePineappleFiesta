using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
	[SerializeField]
	private ItemRuntimeSet Items;

	private NavMeshAgent m_agent;
	private bool m_moving;
	private Item m_itemTarget;

	private void Awake()
	{
		m_agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		if (m_moving)
		{
			if (!m_agent.pathPending)
			{
				if (m_agent.remainingDistance <= m_agent.stoppingDistance)
				{
					if (!m_agent.hasPath || m_agent.velocity.sqrMagnitude == 0f)
					{
						Debug.Log("Reached destination");
						m_moving = false;

						if (m_itemTarget != null)
						{
							EventManager.TriggerEvent(ItemEventType.PickedUp, m_itemTarget);
							m_itemTarget = null;
						}
					}
				}
			}
		}
	}

	private void MoveTo(Vector3 point)
	{
		Debug.Log("Starting movement");
		m_agent.SetDestination(point);
		m_moving = true;
	}

	public void OnItemClicked(Item item)
	{
		m_itemTarget = item;
		MoveTo(item.transform.position);
	}

	public void OnItemPickedUp(Item item)
	{
		if (Items.Add(item))
		{
			Destroy(item.gameObject);
		}
		else
		{
			EventManager.TriggerEvent(StringEventType.Message, "Can't pick up item");
		}
	}

	public void OnGroundClicked(Vector3 point)
	{
		m_itemTarget = null;
		MoveTo(point);
	}
}
