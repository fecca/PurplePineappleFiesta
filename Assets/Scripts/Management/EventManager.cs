using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	private void Awake()
	{
		SetupGenericEvents();
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
}