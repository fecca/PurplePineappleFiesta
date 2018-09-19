using UnityEngine;

public class Player : MonoBehaviour
{
	private Inventory m_inventory;

	private void Awake()
	{
		m_inventory = new Inventory();
	}

	public void OnItemPickedUp(Item item)
	{
		item.gameObject.SetActive(false);

		if (!m_inventory.AddItem(item))
		{
			EventManager.TriggerEvent(ItemEventType.Dropped, item);
		}
	}

	public void OnItemDropped(Item item)
	{
		item.gameObject.SetActive(true);
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			var item = m_inventory.Pop();
			if (item != null)
			{
				EventManager.TriggerEvent(ItemEventType.Dropped, item);
			}
		}
	}
}
