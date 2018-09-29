using UnityEngine;

public class ItemFountain : MonoBehaviour
{
	[SerializeField]
	private FloatReference m_fountainSpread = new FloatReference();
	[SerializeField]
	private FloatReference m_fountainForce;

	public void OnEnemyDied(Enemy enemy)
	{
		var position = enemy.transform.position;
		foreach (var lootItem in enemy.LootTable.Items)
		{
			var item = CreateItem(position, lootItem);
			ExplodeItem(item.gameObject);
			EventManager.TriggerEvent(ItemEventType.Spawned, item);
		}
	}

	private Item CreateItem(Vector3 position, ItemData itemData)
	{
		var go = Instantiate(itemData.Prefab, position, Quaternion.identity);
		var item = go.GetOrAddComponent<Item>();
		item.Init(itemData);

		return item;
	}

	private void ExplodeItem(GameObject go)
	{
		var direction = Random.insideUnitCircle * m_fountainSpread.Value;
		var force = go.transform.up + new Vector3(direction.x, transform.position.y, direction.y);
		go.GetComponent<Rigidbody>().AddForce(force * m_fountainForce.Value, ForceMode.Force);
	}
}