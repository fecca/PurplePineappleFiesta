﻿using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	private void Awake()
	{
		SetupGenericEvents();
		SetupStringEvents();
		SetupItemEvents();
		SetupWorldEvents();
	}

	#region GENERIC EVENTS

	[Header("Generic")]
	[SerializeField]
	private GenericEvent ShootEvent;

	private static Dictionary<GenericEventType, GenericEvent> m_genericEvents = new Dictionary<GenericEventType, GenericEvent>();

	private void SetupGenericEvents()
	{
		m_genericEvents.Add(GenericEventType.Shoot, ShootEvent);
	}

	public static void TriggerEvent(GenericEventType type)
	{
		if (m_genericEvents.ContainsKey(type))
		{
			m_genericEvents[type].Raise();
		}
	}

	#endregion

	#region STRING EVENTS

	[Header("String")]
	[SerializeField]
	private StringEvent ScreenMessageEvent;

	private static Dictionary<StringEventType, StringEvent> m_stringEvents = new Dictionary<StringEventType, StringEvent>();

	private void SetupStringEvents()
	{
		m_stringEvents.Add(StringEventType.Message, ScreenMessageEvent);
	}

	public static void TriggerEvent(StringEventType type, string message)
	{
		if (m_stringEvents.ContainsKey(type))
		{
			m_stringEvents[type].Raise(message);
		}
	}

	#endregion

	#region ITEM EVENTS

	[Header("Item")]
	[SerializeField]
	private ItemEvent ClickedEvent;
	[SerializeField]
	private ItemEvent PickedUpEvent;

	private static Dictionary<ItemEventType, ItemEvent> m_itemEvents = new Dictionary<ItemEventType, ItemEvent>();

	private void SetupItemEvents()
	{
		m_itemEvents.Add(ItemEventType.Clicked, ClickedEvent);
		m_itemEvents.Add(ItemEventType.PickedUp, PickedUpEvent);
	}

	public static void TriggerEvent(ItemEventType type, Item item)
	{
		if (m_itemEvents.ContainsKey(type))
		{
			m_itemEvents[type].Raise(item);
		}
	}

	#endregion

	#region WORLD EVENTS

	[Header("World")]
	[SerializeField]
	private WorldEvent ClickedGroundEvent;

	private static Dictionary<WorldEventType, WorldEvent> m_worldEvents = new Dictionary<WorldEventType, WorldEvent>();

	private void SetupWorldEvents()
	{
		m_worldEvents.Add(WorldEventType.ClickedGround, ClickedGroundEvent);
	}

	public static void TriggerEvent(WorldEventType type, Vector3 vector3)
	{
		if (m_worldEvents.ContainsKey(type))
		{
			m_worldEvents[type].Raise(vector3);
		}
	}

	#endregion
}