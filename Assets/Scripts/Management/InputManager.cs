using UnityEngine;

public class InputManager : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100f))
			{
				var item = hit.collider.GetComponent<Item>();
				if (item != null)
				{
					item.OnClick();
				}
			}
		}
	}
}
