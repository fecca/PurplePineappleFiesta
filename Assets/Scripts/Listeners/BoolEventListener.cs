using UnityEngine;

public class BoolEventListener : MonoBehaviour
{
	[SerializeField]
	private BoolEvent Event;
	[SerializeField]
	private BoolUnityEvent Response;

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised(bool value)
	{
		Response.Invoke(value);
	}
}