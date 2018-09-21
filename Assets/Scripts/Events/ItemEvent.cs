using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Item", order = 1)]
public class ItemEvent : ScriptableObject
{
	private List<ItemEventListener> Listeners = new List<ItemEventListener>();

	public void Raise(Item item)
	{
		for (int i = Listeners.Count - 1; i >= 0; i--)
		{
			Listeners[i].OnEventRaised(item);
		}
	}

	public void RegisterListener(ItemEventListener listener)
	{
		Listeners.Add(listener);
	}

	public void UnregisterListener(ItemEventListener listener)
	{
		Listeners.Remove(listener);
	}
}