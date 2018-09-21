using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField]
	private GameObject m_bullet;
	[SerializeField]
	private Transform m_barrel;
	[SerializeField]
	private int m_bullets;
	[SerializeField]
	private float m_power;
	[SerializeField]
	private float m_spread;
	[SerializeField]
	private Material m_material;
	[SerializeField]
	private GameObject m_lineRenderer;

	//private void Update()
	//{
	//if (Input.GetKeyDown(KeyCode.Space))
	//{
	//	Shoot();
	//}
	//}

	public void Shoot()
	{
		for (var i = 0; i < m_bullets; i++)
		{
			var direction = m_barrel.forward + (Vector3.right * (Random.value - 0.5f) * m_spread) + (Vector3.up * (Random.value - 0.5f) * m_spread);
			RaycastHit hitInfo;
			if (Physics.Raycast(new Ray(m_barrel.position, direction), out hitInfo, 100f))
			{
				var lrgo = Instantiate(m_lineRenderer);
				var lr = lrgo.GetComponent<LineRenderer>();
				lr.SetPositions(new Vector3[] { m_barrel.position, hitInfo.point });
				Destroy(lrgo, 0.1f);
			}

			//var bullet = Instantiate(m_bullet);
			//bullet.transform.position = m_barrel.position;
			//var rigidbody = bullet.GetOrAddComponent<Rigidbody>();
			//var direction = m_barrel.forward + (Vector3.right * (Random.value - 0.5f)) + (Vector3.up * (Random.value - 0.5f));
			//rigidbody.AddForce(direction * m_power);

			//Destroy(bullet, 5.0f);
		}
	}
}
