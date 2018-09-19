using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
	public int Slots = 2;
	public HashSet<T> Items = new HashSet<T>();

	public bool Add(T t)
	{
		if (Items.Count < Slots && !Items.Contains(t))
		{
			Items.Add(t);
			return true;
		}

		return false;
	}

	public bool Remove(T t)
	{
		if (Items.Contains(t))
		{
			Items.Remove(t);
			return true;
		}

		return false;
	}

	public void Clear()
	{
		Items.Clear();
	}
}