﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class ExtensionMethods
{
	public static T GetOrAddComponent<T>(this GameObject go) where T : Component
	{
		var comp = go.GetComponent<T>();
		if (comp == null)
		{
			comp = go.AddComponent<T>();
		}
		return comp;
	}

	public static Color WithAlpha(this Color color, float alpha)
	{
		var newColor = color;
		newColor.a = alpha;
		return newColor;
	}

	public static Vector3 WithX(this Vector3 v, float x)
	{
		return new Vector3(x, v.y, v.z);
	}

	public static Vector3 WithY(this Vector3 v, float y)
	{
		return new Vector3(v.x, y, v.z);
	}

	public static Vector3 WithZ(this Vector3 v, float z)
	{
		return new Vector3(v.x, v.y, z);
	}

	public static bool CloserThan(this Vector3 v, Vector3 other, float distance)
	{
		return (other - v).sqrMagnitude < (distance * distance);
	}

	public static bool IsEmpty<T>(this ICollection<T> collection)
	{
		return collection.Count <= 0;
	}

	public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
	{
		return collection == null || collection.Count <= 0;
	}

	public static bool IsMoving(this NavMeshAgent agent)
	{
		if (!agent.pathPending)
		{
			if (agent.remainingDistance <= agent.stoppingDistance)
			{
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
				{
					return false;
				}
			}
		}

		return true;
	}

	public static bool Contains(this LayerMask mask, int layer)
	{
		return mask == (mask | (1 << layer));
	}
}
