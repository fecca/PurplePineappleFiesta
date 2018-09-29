using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/World")]
public class WorldEvent : ScriptableObject
{
	private List<WorldEventListener> Listeners = new List<WorldEventListener>();

	public void Raise(Vector3 vector3)
	{
		for (int i = Listeners.Count - 1; i >= 0; i--)
		{
			Listeners[i].OnEventRaised(vector3);
		}
	}

	public void RegisterListener(WorldEventListener listener)
	{
		Listeners.Add(listener);
	}

	public void UnregisterListener(WorldEventListener listener)
	{
		Listeners.Remove(listener);
	}
}