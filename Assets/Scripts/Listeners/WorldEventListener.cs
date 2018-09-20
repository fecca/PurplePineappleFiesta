using UnityEngine;

public class WorldEventListener : MonoBehaviour
{
	[SerializeField]
	private WorldEvent Event;
	[SerializeField]
	private WorldUnityEvent Response;

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised(Vector3 vector3)
	{
		Response.Invoke(vector3);
	}
}