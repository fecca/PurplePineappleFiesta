using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SphereCollider))]
public class HitBox : MonoBehaviour
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
		IHitListener listener = m_listener.GetComponent<IHitListener>();
		if (listener == null)
		{
			Debug.LogWarning($"No interface IHitListener on GameObject {m_listener.name}");
			return;
		}

		listener.OnHit(damage);
	}
}