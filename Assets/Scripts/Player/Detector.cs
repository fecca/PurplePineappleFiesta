using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Detector : MonoBehaviour
{
	[SerializeField]
	private LayerMask m_layerMask;
	[SerializeField]
	private float m_radius;

	public GameObject Detection { get; private set; }

	private SphereCollider m_collider;

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, m_radius);
	}

	private void Awake()
	{
		m_collider = GetComponent<SphereCollider>();
	}

	private void Update()
	{
		m_collider.radius = m_radius;
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
			//Detection = null;
		}
	}
}
