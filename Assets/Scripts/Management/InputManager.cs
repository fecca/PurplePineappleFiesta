using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			ClickItem(item =>
			{
				EventManager.TriggerEvent(ItemEventType.PickedUp, item);
			});
		}
		else if (Input.GetMouseButtonUp(1))
		{
			ClickItem(item =>
			{
				EventManager.TriggerEvent(ItemEventType.Dropped, item);
			});
		}
	}

	private void ClickItem(Action<Item> action)
	{
		RaycastHit hit;
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 100f))
		{
			var item = hit.collider.GetComponent<Item>();
			if (item != null)
			{
				action(item);
			}
		}
	}
}
