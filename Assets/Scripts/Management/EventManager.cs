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

	[SerializeField]
	private GenericEvent TestEvent;

	private static Dictionary<GenericEventType, GenericEvent> m_genericEvents = new Dictionary<GenericEventType, GenericEvent>();

	private void SetupGenericEvents()
	{
		m_genericEvents.Add(GenericEventType.Test, TestEvent);
	}

	public static void TriggerEvent(GenericEventType type)
	{
		m_genericEvents[type].Raise();
	}

	#endregion

	#region ITEM EVENTS

	[SerializeField]
	private ItemEvent PickedUpEvent;

	private static Dictionary<ItemEventType, ItemEvent> m_itemEvents = new Dictionary<ItemEventType, ItemEvent>();

	private void SetupItemEvents()
	{
		m_itemEvents.Add(ItemEventType.PickedUp, PickedUpEvent);
	}

	public static void TriggerEvent(ItemEventType type, Item item)
	{
		m_itemEvents[type].Raise(item);
	}

	#endregion
}