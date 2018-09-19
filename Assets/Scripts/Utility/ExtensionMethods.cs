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

	public static Vector3 WithY(this Vector3 v, float y)
	{
		return new Vector3(v.x, y, v.z);
	}
}
