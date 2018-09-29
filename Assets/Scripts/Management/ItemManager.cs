using UnityEngine;

public class ItemManager : MonoBehaviour
{
	public void OnEnemyDied(Enemy enemy)
	{
		var lootTable = enemy.LootTable;
		foreach (var lootItem in lootTable.Items)
		{
			var position = enemy.transform.position;
			var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
			var item = go.GetOrAddComponent<Item>();
			item.Init(position, lootItem);
			ExplodeItem(go);
		}
	}

	private void ExplodeItem(GameObject go)
	{
		go.GetOrAddComponent<Rigidbody>().AddForce(go.transform.up * 200.0f, ForceMode.Force);
	}
}