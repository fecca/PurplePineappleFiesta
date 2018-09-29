using UnityEngine;

public class InputManager : MonoBehaviour
{
	[SerializeField]
	private LayerMask m_walkable;
	[SerializeField]
	private LayerMask m_shootable;
	[SerializeField]
	private FloatReference m_updateInterval;
	[SerializeField]
	private KeyBinding[] m_keyBindings;

	private float m_mousePressTimer;
	private bool m_inputLocked;

	private void Start()
	{
		foreach (var keyBinding in m_keyBindings)
		{
			EventManager.RegisterKeyBinding(keyBinding);
		}
	}

	private void Update()
	{
		if (m_inputLocked)
		{
			return;
		}

		HandleKeyboardInput();
		HandleMouseInput();
	}

	private void HandleKeyboardInput()
	{
		foreach (var keyBinding in m_keyBindings)
		{
			if (Input.GetKeyDown(keyBinding.KeyCode))
			{
				EventManager.TriggerEvent(keyBinding.KeyCode);
			}
		}
	}

	private void HandleMouseInput()
	{
		HandleLeftMouseButton();
		HandleMiddleMouseButton();
		HandleRightMouseButton();
	}

	private void HandleLeftMouseButton()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100f, m_walkable))
			{
				EventManager.TriggerEvent(WorldEventType.ClickedGround, hit.point);
			}

			m_mousePressTimer = 0f;
		}

		if (Input.GetMouseButton(0))
		{
			if (m_mousePressTimer >= m_updateInterval.Value)
			{
				RaycastHit hit;
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, 100f, m_walkable))
				{
					EventManager.TriggerEvent(WorldEventType.ClickedGround, hit.point);
				}

				m_mousePressTimer = 0f;
			}

			m_mousePressTimer += Time.deltaTime;
		}

		if (Input.GetMouseButtonUp(0))
		{
			if (m_mousePressTimer <= 0.1f)
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

			m_mousePressTimer = 0f;
		}
	}

	private void HandleMiddleMouseButton()
	{
	}

	private void HandleRightMouseButton()
	{
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

	public void OnMouseInputLocked(bool value)
	{
		m_inputLocked = value;
	}
}