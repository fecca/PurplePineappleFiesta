using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Enemy", order = 4)]
public class EnemyEvent : ScriptableObject
{
	private List<EnemyEventListener> Listeners = new List<EnemyEventListener>();

	public void Raise(Enemy enemy)
	{
		for (int i = Listeners.Count - 1; i >= 0; i--)
		{
			Listeners[i].OnEventRaised(enemy);
		}
	}

	public void RegisterListener(EnemyEventListener listener)
	{
		Listeners.Add(listener);
	}

	public void UnregisterListener(EnemyEventListener listener)
	{
		Listeners.Remove(listener);
	}
}