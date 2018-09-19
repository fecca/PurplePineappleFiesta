using UnityEngine;

public class ItemEventListener : MonoBehaviour
{
	[SerializeField]
	private ItemEvent Event;
	[SerializeField]
	private ItemUnityEvent Response;

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised(Item item)
	{
		Response.Invoke(item);
	}
}