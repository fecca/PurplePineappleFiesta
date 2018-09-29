using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SphereGizmo : MonoBehaviour
{
	[SerializeField]
	private bool m_drawGizmos;
	[SerializeField]
	private Color m_gizmoColor;

	private SphereCollider m_collider;

	private SphereCollider Collider { get { if (m_collider == null) { m_collider = GetComponent<SphereCollider>(); } return m_collider; } }

	private void OnDrawGizmos()
	{
		if (m_drawGizmos)
		{
			Gizmos.color = m_gizmoColor;
			Gizmos.DrawWireSphere(transform.position, Collider.radius);
		}
	}
}
