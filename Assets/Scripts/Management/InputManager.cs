using UnityEngine;

public class InputManager : MonoBehaviour
{
	[SerializeField]
	private LayerMask m_walkable;
	[SerializeField]
	private LayerMask m_shootable;

	private float m_updateInterval = 0.2f;
	private float m_timer;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			m_timer = 0f;

			RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100f, m_walkable))
			{
				EventManager.TriggerEvent(WorldEventType.ClickedGround, hit.point);
			}
		}

		if (Input.GetMouseButton(0))
		{
			if (m_timer >= m_updateInterval)
			{
				m_timer = 0f;

				RaycastHit hit;
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, 100f, m_walkable))
				{
					EventManager.TriggerEvent(WorldEventType.ClickedGround, hit.point);
				}
			}

			m_timer += Time.deltaTime;
		}

		if (Input.GetMouseButtonUp(0))
		{
			if (m_timer <= 0.1f)
			{
				RaycastHit hit;
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, 100f))
				{
					var item = hit.collider.GetComponent<Item>();
					if (item != null)
					{
						EventManager.TriggerEvent(ItemEventType.Clicked, item);
						return;
					}
				}
			}

			m_timer = 0f;
		}

		if (Input.GetMouseButtonUp(1))
		{
			RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100f, m_shootable))
			{
				EventManager.TriggerEvent(WorldEventType.ShootInDirection, hit.point);
			}
		}
	}
}