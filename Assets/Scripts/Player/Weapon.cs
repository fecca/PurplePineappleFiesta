using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField]
	private Transform m_barrel;
	[SerializeField]
	private WeaponStats m_stats;

	private bool m_isInitialized;
	private bool m_shooting;
	private Transform m_parent;

	private void Update()
	{
		if (!m_isInitialized || m_shooting)
		{
			return;
		}

		transform.position = Vector3.Lerp(transform.position, m_parent.position, Time.deltaTime * m_stats.FollowSpeed);
		transform.rotation = Quaternion.Lerp(transform.rotation, m_parent.rotation, Time.deltaTime * m_stats.FollowSpeed);
	}

	public void Shoot()
	{
		StartCoroutine(StartShooting());
	}

	private IEnumerator StartShooting()
	{
		m_shooting = true;

		var frames = 10;
		for (var i = 0; i < frames; i++)
		{
			transform.position = Vector3.Lerp(transform.position, m_parent.position, (float)i / frames);
			transform.rotation = Quaternion.Lerp(transform.rotation, m_parent.rotation, (float)i / frames);

			yield return new WaitForEndOfFrame();
		}

		for (var i = 0; i < m_stats.Bullets; i++)
		{
			var direction = m_barrel.forward + (Vector3.right * (Random.value - 0.5f) * m_stats.Spread) + (Vector3.up * (Random.value - 0.5f) * m_stats.Spread);
			var lineRenderer = Instantiate(m_stats.LineRenderer) as LineRenderer;
			lineRenderer.SetPositions(new Vector3[] { m_barrel.position, m_barrel.position + direction * 10.0f });
			Destroy(lineRenderer.gameObject, 0.1f);
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
