﻿using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField]
	private Transform m_barrel;
	[SerializeField]
	private int m_bullets;
	[SerializeField]
	private float m_spread;
	[SerializeField]
	private GameObject m_lineRenderer;
	[SerializeField]
	private GameObject m_parent;
	[SerializeField]
	private float m_lerpSpeed;

	private void Update()
	{
		transform.position = Vector3.Lerp(transform.position, m_parent.transform.position, Time.deltaTime * m_lerpSpeed);
		transform.rotation = Quaternion.Lerp(transform.rotation, m_parent.transform.rotation, Time.deltaTime * m_lerpSpeed);
	}

	public void Shoot()
	{
		for (var i = 0; i < m_bullets; i++)
		{
			var direction = m_barrel.forward + (Vector3.right * (Random.value - 0.5f) * m_spread) + (Vector3.up * (Random.value - 0.5f) * m_spread);
			var lrgo = Instantiate(m_lineRenderer);
			var lr = lrgo.GetComponent<LineRenderer>();
			lr.SetPositions(new Vector3[] { m_barrel.position, m_barrel.position + direction * 10.0f });
			Destroy(lrgo, 0.1f);
		}
	}
}
