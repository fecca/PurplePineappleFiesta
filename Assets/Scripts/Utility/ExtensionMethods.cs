﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
	public static Component GetOrAddComponent<T>(this GameObject go) where T : Component
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
}
