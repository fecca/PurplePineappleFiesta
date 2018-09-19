using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private ItemRuntimeSet Items;

	public void OnItemPickedUp(Item item)
	{
		if (Items.Add(item))
		{
			item.PickUp();
		}
		else
		{
			EventManager.TriggerEvent(StringEventType.Message, "NO");
		}
	}

	public void OnItemDropped(Item item)
	{
		if (Items.Remove(item))
		{
			item.Drop();
		}
	}
}
