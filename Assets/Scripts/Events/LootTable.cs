using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/LootTable")]
public class LootTable : ScriptableObject
{
	public List<ItemData> Items = new List<ItemData>();
}