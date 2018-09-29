using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Detector : MonoBehaviour
{
	[SerializeField]
	private LayerMask m_layerMask;
	[SerializeField]
	private FloatVariable m_radius;

	[Header("Gizmos")]
	[SerializeField]
	private bool m_drawGizmos;
	[SerializeField]
	private Color m_gizmoColor;

	public GameObject Detection { get; private set; }

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

	private void OnTriggerEnter(Collider other)
	{
		if (m_layerMask.Contains(other.gameObject.layer))
		{
			Detection = other.gameObject;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (m_layerMask.Contains(other.gameObject.layer))
		{
			Detection = null;
		}
	}
}
