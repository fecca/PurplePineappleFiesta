using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ClickBox : MonoBehaviour
{
	[SerializeField]
	private GameObject m_listener;
	[SerializeField]
	private FloatReference m_radius;

	private SphereCollider m_collider;

	private void Awake()
	{
		m_collider = GetComponent<SphereCollider>();
	}

	private void Update()
	{
		m_collider.radius = m_radius.Value;
	}

	public void OnHit(float damage)
	{
		IClickListener listener = m_listener.GetComponent<IClickListener>();
		if (listener == null)
		{
			Debug.LogWarning($"No interface IClickListener on GameObject {m_listener.name}");
			return;
		}

		listener.OnClick();
	}
}
