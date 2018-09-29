using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Bool")]
public class BoolEvent : ScriptableObject
{
	private List<BoolEventListener> Listeners = new List<BoolEventListener>();

	public void Raise(bool value)
	{
		for (int i = Listeners.Count - 1; i >= 0; i--)
		{
			Listeners[i].OnEventRaised(value);
		}
	}

	public void RegisterListener(BoolEventListener listener)
	{
		Listeners.Add(listener);
	}

	public void UnregisterListener(BoolEventListener listener)
	{
		Listeners.Remove(listener);
	}
}