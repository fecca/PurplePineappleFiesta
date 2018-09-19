using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	private void Awake()
	{
		SetupGenericEvents();
		SetupItemEvents();
	}

	#region GENERIC EVENTS

	private static Dictionary<GenericEventType, GenericEvent> m_genericEvents = new Dictionary<GenericEventType, GenericEvent>();

	private void SetupGenericEvents()
	{
	}

	public static void TriggerEvent(GenericEventType type)
	{
		if (m_genericEvents.ContainsKey(type))
		{
			m_genericEvents[type].Raise();
		}
	}

	#endregion

	#region ITEM EVENTS

	[SerializeField]
	private ItemEvent PickedUpEvent;
	[SerializeField]
	private ItemEvent DroppedItemEvent;

	private static Dictionary<ItemEventType, ItemEvent> m_itemEvents = new Dictionary<ItemEventType, ItemEvent>();

	private void SetupItemEvents()
	{
		m_itemEvents.Add(ItemEventType.PickedUp, PickedUpEvent);
		m_itemEvents.Add(ItemEventType.Dropped, DroppedItemEvent);
	}

	public static void TriggerEvent(ItemEventType type, Item item)
	{
		if (m_itemEvents.ContainsKey(type))
		{
			m_itemEvents[type].Raise(item);
		}
	}

	#endregion
}