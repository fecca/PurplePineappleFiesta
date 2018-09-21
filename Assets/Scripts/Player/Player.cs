using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	[SerializeField]
	private ItemRuntimeSet Items;
	[SerializeField]
	private Weapon m_weapon;
	[SerializeField]
	private NavMeshAgent m_agent;

	private bool m_moving;
	private Item m_itemTarget;

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

	private void PickUpItem(Item item)
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

	private void MoveTo(Vector3 point)
	{
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
		PickUpItem(item);
	}

	public void OnGroundClicked(Vector3 point)
	{
		m_itemTarget = null;
		MoveTo(point);
	}

	public void OnShoot()
	{
		m_weapon.Shoot();
	}
}
