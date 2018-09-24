using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField]
	private Transform m_barrel;
	[SerializeField]
	private WeaponStats m_stats;
	[SerializeField]
	private LayerMask m_hitLayerMask;

	private bool m_isInitialized;
	private bool m_shooting;
	private Transform m_parent;
	private float m_cooldownTimer;

	private void Update()
	{
		m_cooldownTimer += Time.deltaTime;

		if (!m_isInitialized || m_shooting)
		{
			return;
		}

		transform.position = Vector3.Lerp(transform.position, m_parent.position, Time.deltaTime * m_stats.FollowSpeed);
		transform.rotation = Quaternion.Lerp(transform.rotation, m_parent.rotation, Time.deltaTime * m_stats.FollowSpeed);
	}

	public void Shoot()
	{
		if (m_cooldownTimer >= m_stats.Cooldown)
		{
			m_cooldownTimer = 0f;
			StartCoroutine(StartShooting());
		}
	}

	private IEnumerator StartShooting()
	{
		m_shooting = true;

		for (var i = 0; i < m_stats.Frames; i++)
		{
			transform.position = Vector3.Lerp(transform.position, m_parent.position, (float)i / m_stats.Frames);
			transform.rotation = Quaternion.Lerp(transform.rotation, m_parent.rotation, (float)i / m_stats.Frames);

			yield return new WaitForEndOfFrame();
		}

		for (var i = 0; i < m_stats.Bullets; i++)
		{
			var direction = (m_barrel.forward * m_stats.Distance) + (Random.insideUnitSphere * m_stats.SpreadRadius);

			RaycastHit hit;
			Ray ray = new Ray(m_barrel.position, direction.normalized);
			var hitPoint = ray.origin + ray.direction * m_stats.Distance;
			if (Physics.Raycast(ray, out hit, m_stats.Distance, m_hitLayerMask))
			{
				hitPoint = hit.point;
				var hitBox = hit.collider.GetComponent<HitBox>();
				if (hitBox != null)
				{
					hitBox.OnHit(m_stats.Damage);
				}
			}
			var lineRenderer = Instantiate(m_stats.LineRenderer) as LineRenderer;
			lineRenderer.SetPositions(new Vector3[] { m_barrel.position, hitPoint });
			Destroy(lineRenderer.gameObject, m_stats.LineRendererDuration);
		}

		m_shooting = false;
	}

	public void SetParent(Transform parent)
	{
		m_parent = parent;
		transform.position = m_parent.position;
		transform.rotation = m_parent.rotation;
		m_isInitialized = true;
	}
}
