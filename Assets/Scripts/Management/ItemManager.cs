using UnityEngine;

public class ItemManager : MonoBehaviour
{
	[SerializeField]
	private FloatReference m_fountainSpread = new FloatReference();
	[SerializeField]
	private FloatReference m_fountainForce;

	public void OnEnemyDied(Enemy enemy)
	{
		var lootTable = enemy.LootTable;
		foreach (var lootItem in lootTable.Items)
		{
			var position = enemy.transform.position;
			var go = Instantiate(lootItem.Prefab, position, Quaternion.identity);
			var item = go.GetOrAddComponent<Item>();
			item.Init(lootItem);

			ExplodeItem(go);
		}
	}

	private void ExplodeItem(GameObject go)
	{
		var randomInCircle = Random.insideUnitCircle * m_fountainSpread.Value;
		var randomDirection = go.transform.up + new Vector3(randomInCircle.x, transform.position.y, randomInCircle.y);
		go.GetComponent<Rigidbody>().AddForce(randomDirection * m_fountainForce.Value, ForceMode.Force);
	}
}