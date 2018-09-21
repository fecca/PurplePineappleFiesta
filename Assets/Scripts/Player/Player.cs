using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	[SerializeField]
	private ItemRuntimeSet Items;
	[SerializeField]
	private Weapon m_weaponPrefab;
	[SerializeField]
	private NavMeshAgent m_agent;
	[SerializeField]
	private Transform[] m_weaponSlots;

	private bool m_moving;
	private Item m_itemTarget;
	private List<Weapon> m_weapons;

	private void Awake()
	{
		m_weapons = new List<Weapon>(m_weaponSlots.Length);
		for (var i = 0; i < m_weaponSlots.Length; i++)
		{
			var weapon = Instantiate(m_weaponPrefab);
			weapon.SetParent(m_weaponSlots[i]);
			m_weapons.Add(weapon);
		}
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
		m_agent.isStopped = false;
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

	public void OnShoot(Vector3 direction)
	{
		m_agent.isStopped = true;
		m_agent.enabled = false;

		var target = direction.WithY(m_agent.transform.position.y);
		m_agent.transform.LookAt(target);

		foreach (var weapon in m_weapons)
		{
			weapon.Shoot();
		}

		m_agent.enabled = true;
	}
}