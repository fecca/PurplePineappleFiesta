using UnityEngine;

public class InputManager : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			EventManager.TriggerEvent(GenericEventType.Test);
		}
	}
}
