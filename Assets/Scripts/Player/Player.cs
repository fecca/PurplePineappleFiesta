using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
	[SerializeField]
	private ItemRuntimeSet Items;

	private NavMeshAgent m_agent;

	private void Awake()
	{
		m_agent = GetComponent<NavMeshAgent>();
	}

	private void PickUpItem(Item item)
	{
		if (Items.Add(item))
		{
			item.PickUp();
		}
		else
		{
			EventManager.TriggerEvent(StringEventType.Message, "NO");
		}
	}

	private void DropItem(Item item)
	{
		if (Items.Remove(item))
		{
			item.Drop();
		}
	}

	private void MoveTo(Vector3 point)
	{
		m_agent.SetDestination(point);
	}

	public void OnItemPickedUp(Item item)
	{
		PickUpItem(item);
	}

	public void OnItemDropped(Item item)
	{
		DropItem(item);
	}

	public void OnClickedGround(Vector3 point)
	{
		MoveTo(point);
	}
}
