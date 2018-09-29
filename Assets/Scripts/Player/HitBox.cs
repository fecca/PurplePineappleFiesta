using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class HitBox : MonoBehaviour
{
	[SerializeField]
	private GameObject m_listener;
	[SerializeField]
	private FloatVariable m_radius;

	[Header("Gizmos")]
	[SerializeField]
	private bool m_drawGizmos;
	[SerializeField]
	private Color m_gizmoColor;

	private SphereCollider m_collider;

	private void OnDrawGizmos()
	{
		if (m_drawGizmos)
		{
			Gizmos.color = m_gizmoColor;
			Gizmos.DrawWireSphere(transform.position, m_radius.Value);
		}
	}

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
			Debug.LogWarning($"No interface IHittable on GameObject {m_listener.name}");
			return;
		}

		listener.OnHit(damage);
	}
}