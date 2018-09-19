using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField]
	private ItemData Data;

	public void OnClick()
	{
		EventManager.TriggerEvent(ItemEventType.PickedUp, this);

		Debug.Log(Data.Name);
	}
}
