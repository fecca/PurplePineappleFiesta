using UnityEngine;

public class EnemyEventListener : MonoBehaviour
{
	[SerializeField]
	private EnemyEvent Event;
	[SerializeField]
	private EnemyUnityEvent Response;

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised(Enemy enemy)
	{
		Response.Invoke(enemy);
	}
}