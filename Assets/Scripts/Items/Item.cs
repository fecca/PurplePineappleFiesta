using UnityEngine;

public class Item : MonoBehaviour, IClickListener
{
	[SerializeField]
	private ItemData Data;

	public void Init(ItemData itemData)
	{
		Data = itemData;
		gameObject.name = Data.Name;
	}

	public void OnClick()
	{
		EventManager.TriggerEvent(ItemEventType.Clicked, this);
	}
}
