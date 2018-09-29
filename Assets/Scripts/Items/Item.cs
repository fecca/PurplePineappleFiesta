using UnityEngine;

public class Item : MonoBehaviour, IClickListener
{
	[SerializeField]
	private ItemData Data;

	public void Init(ItemData itemData)
	{
		Data = itemData;
	}

	public void OnClick()
	{
		Debug.Log("Clicked item");
		EventManager.TriggerEvent(ItemEventType.Clicked, this);
	}
}
